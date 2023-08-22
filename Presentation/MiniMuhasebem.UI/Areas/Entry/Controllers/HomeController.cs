using Microsoft.AspNetCore.Mvc;

namespace MiniMuhasebem.UI.Areas.Entry.Controllers
{
    [Area("Entry")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = "Mini Muhasebe";
            ViewBag.Title = "Giriş sayfası";
            return View();
        }
    }
}
