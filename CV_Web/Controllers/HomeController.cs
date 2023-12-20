using CV_Web.Interfaces;
using CV_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CV_Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProfileRepository _profileRepository;

		public HomeController(ILogger<HomeController> logger, IProfileRepository profileRepository)
		{
			_logger = logger;
			_profileRepository = profileRepository;
		}

		public async Task<IActionResult> Index()
		{
			var values=await _profileRepository.GetAsync();
			return View(values);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
