using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.RequestModels.AccountRM;

namespace MiniMuhasebem.UI.Areas.Entry.Controllers
{
    [Area("Entry")]
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegisterVM registerVM)
        {
            return View();
        }
    }
}
