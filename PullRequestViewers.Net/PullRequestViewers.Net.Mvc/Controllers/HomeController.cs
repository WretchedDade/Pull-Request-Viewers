using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PullRequestViewers.Net.Core;
using PullRequestViewers.Net.Mvc.Models;

namespace PullRequestViewers.Net.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("GithubRepo");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([Bind] GithubRepoModel model)
        {
            if (ModelState.IsValid)
            {
                GithubService githubService = new();
                GithubRepo githubRepo = await githubService.GetGithubRepo(model.Owner, model.Name);

                return View("GithubRepo", new GithubRepoModel { GithubRepo = githubRepo });
            }

            return View("GithubRepo", model);
        }
    }
}
