using CV_Web.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Octokit;
using System.Net.Http;

namespace CV_Web.Controllers
{
    public class ProfileController : Controller
    {
        
        
        private readonly GitHubClient _gitHubClient;

        public ProfileController()
        {
            _gitHubClient = new GitHubClient(new ProductHeaderValue("MyApp"));
            _gitHubClient.Credentials = new Credentials("github-personal-access-token");
        }

        public async Task<IActionResult> Index()
        {
            var repos = await _gitHubClient.Repository.GetAllForCurrent();
            var repositoryInfos = repos.OrderByDescending(x=>x.UpdatedAt).Select(repo => new GitHubRepoDto
            {
                Name = repo.Name,
                IsPrivate = repo.Private,
                Description = repo.Description,
                HtmlUrl = repo.HtmlUrl,
                Language=repo.Language,
                UpdatedAt = repo.UpdatedAt.DateTime
            }).ToList();
            return View(repositoryInfos);
        }
    }
}
