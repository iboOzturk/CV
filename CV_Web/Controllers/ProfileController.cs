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
        public ProfileController(GitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }       

        public async Task<IActionResult> Index()
        {           
            var repos = _gitHubClient.Repository.GetAllForCurrent().Result;
            var repositoryInfos = repos.OrderByDescending(x => x.UpdatedAt).Select(repo => new GitHubRepoDto
            {
                Name = repo.Name,
                IsPrivate = repo.Private,
                Description = repo.Description,
                HtmlUrl = repo.HtmlUrl,
                Language = repo.Language,
                UpdatedAt = repo.UpdatedAt.DateTime
            }).ToList();
            return View(repositoryInfos);
        }
    }
}
