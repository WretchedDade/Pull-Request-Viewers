using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace PullRequestViewers.Net.Core
{
    public record GithubPR(string Title, string Body, string AuthorName, string AuthorAvatarUrl, string State);
    public record GithubRepo(string Owner, string Name, string Description, IEnumerable<GithubPR> PullRequests);

    public class GithubService
    {
        private readonly GitHubClient gitHubClient;

        public GithubService() => gitHubClient = new GitHubClient(new ProductHeaderValue("WretchedDade"));

        public async Task<GithubRepo> GetGithubRepo(string owner, string name)
        {
            Repository repository = await gitHubClient.Repository.Get(owner, name);
            IReadOnlyList<PullRequest> pullRequests = await gitHubClient.PullRequest.GetAllForRepository(repository.Id, new PullRequestRequest()
            {
                State = ItemStateFilter.All
            });

            return new(owner, name, repository.Description, pullRequests.Select(pr => new GithubPR(pr.Title, pr.Body, pr.User.Login, pr.User.AvatarUrl, pr.State.StringValue)));
        }
    }
}
