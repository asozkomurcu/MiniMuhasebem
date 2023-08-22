﻿using Microsoft.AspNetCore.Mvc;

namespace MiniMuhasebem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = "Mini Muhasebe";
            ViewBag.Title = "Yönetim Paneli";
            return View();
        }
    }
}
