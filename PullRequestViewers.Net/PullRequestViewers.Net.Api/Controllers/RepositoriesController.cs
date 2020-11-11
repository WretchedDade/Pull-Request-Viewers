using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PullRequestViewers.Net.Core;

namespace PullRequestViewers.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly GithubService githubService;

        public RepositoriesController() => githubService = new();

        [HttpGet("{owner}/{name}")]
        public async Task<GithubRepo> GetGithubRepo(string owner, string name) => await githubService.GetGithubRepo(owner, name);
    }
}
