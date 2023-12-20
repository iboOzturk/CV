using Microsoft.AspNetCore.Mvc;

namespace CV_Web.ViewComponents.Layout
{
    public class _ScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
