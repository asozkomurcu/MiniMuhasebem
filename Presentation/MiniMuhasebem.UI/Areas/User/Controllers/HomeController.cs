using Microsoft.AspNetCore.Mvc;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = "Mini Muhasebe";
            ViewBag.Title = "Kullanıcı Paneli";
            return View();
        }
    }
}
