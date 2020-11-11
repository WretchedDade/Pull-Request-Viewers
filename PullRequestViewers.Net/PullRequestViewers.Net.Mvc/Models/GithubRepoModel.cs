using PullRequestViewers.Net.Core;

namespace PullRequestViewers.Net.Mvc.Models
{
    public class GithubRepoModel
    {
        public string Owner { get; set; }

        public string Name { get; set; }

        public GithubRepo GithubRepo { get; set; }
    }
}
