using CV_Web.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Octokit;
using System.Net;
using System.Net.Http;

namespace CV_Web.Controllers
{
    public class ProfileController : Controller
    {
        
        
        //private readonly GitHubClient _gitHubClient;
        //public ProfileController(GitHubClient gitHubClient)
        //{
        //    _gitHubClient = gitHubClient;
        //}       

        public IActionResult Index()
        {
            var url = "https://api.github.com/users/iboozturk/repos";
          

            using (var webClient = new WebClient())
             {
                webClient.Headers.Add("User-Agent", "request");

                try
                {
                    var rawJSON = webClient.DownloadString(url);
                    var repos = JsonConvert.DeserializeObject<List<GitHubRepoDto>>(rawJSON).OrderByDescending(x=>x.Updated_At).ToList();
                  
                    return View(repos);
                }
                catch (WebException ex)
                {
                    var response = ex.Response as HttpWebResponse;

                    if (response != null && response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        // Handle 403 Forbidden error
                    }
                    throw;
                }
            }



          

        }
    }
}
