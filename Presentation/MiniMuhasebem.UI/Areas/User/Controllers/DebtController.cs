using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.DebtDtos;
using MiniMuhasebem.UI.Models.RequestModels.DebtRM;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Policy = "AdminOrUser")]
    public class DebtController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public DebtController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }
        public IActionResult Create()
        {
            ViewBag.Header = "Borç İşlemleri";
            ViewBag.Title = "Yeni Borç Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDebtVM createDebtVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createDebtVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateDebtVM, Result<int>>(createDebtVM, "debt/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Debt", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Borç İşlemleri";
            ViewBag.Title = "Borç Düzenle";

            //Apiye istek at
            //debt/get
            var response = await _restService.GetAsync<Result<List<DebtDto>>>("debt/get");

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


        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Header = "Borç İşlemleri";
            ViewBag.Title = "Borç Güncelle";

            //ilgili borcu bul ve View'e git
            var response = await _restService.GetAsync<Result<DebtDto>>($"debt/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateDebtVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDebtVM updateDebtModel)
        {
            var response = await _restService.PutAsync<UpdateDebtVM, Result<int>>(updateDebtModel, $"category/update/{updateDebtModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Debt", new { Area = "User" });
            }

        }

    }

}
