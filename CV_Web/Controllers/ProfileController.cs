using CV_Web.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Telegram.Bot;

namespace CV_Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private const string BotToken = "telegram-bot-token";
        public ProfileController()
        {
            _telegramBotClient = new TelegramBotClient(BotToken);
        }


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
     
        public async Task<IActionResult> SendMessage(string chatId, string name, string email, string subject, string message)
        {
            string fullMessage = $"İsim: {name}\nE-posta: {email}\nKonu: {subject}\nMesaj: {message}";
            await _telegramBotClient.SendTextMessageAsync(chatId, fullMessage);
            return View(); 
        }
    }
}
