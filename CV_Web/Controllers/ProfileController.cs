using Microsoft.AspNetCore.Mvc;

namespace CV_Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
