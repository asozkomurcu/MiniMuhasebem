using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.MonthEndDtos;
using MiniMuhasebem.UI.Models.RequestModels.MonthEndRM;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Policy = "AdminOrUser")]
    public class MonthEndController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public MonthEndController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Ay Sonu İşlemleri";
            ViewBag.Title = "Yeni Ay Sonu Raporu Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMonthEndVM monthEndModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(monthEndModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateMonthEndVM, Result<int>>(monthEndModel, "monthEnd/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "MonthEnd", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Ay Sonu İşlemleri";
            ViewBag.Title = "Ay Sonu Raporu Düzenle";

            //Apiye istek at
            //monthEnd/get
            var response = await _restService.GetAsync<Result<List<MonthEndDto>>>("monthEnd/get");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                return View(response.Data.Data);
            }
        }
    }
}
