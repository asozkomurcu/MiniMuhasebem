using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.IncomeDtos;
using MiniMuhasebem.UI.Models.RequestModels.IncomeRM;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Policy = "AdminOrUser")]
    public class IncomeController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public IncomeController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Günlük Kazanç İşlemleri";
            ViewBag.Title = "Yeni Günlük Kazanç Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncomeVM createIncomeVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createIncomeVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateIncomeVM, Result<int>>(createIncomeVM, "income/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Income", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Günlük Kazanç İşlemleri";
            ViewBag.Title = "Günlük Kazanç Düzenle";

            //Apiye istek at
            //category/get
            var response = await _restService.GetAsync<Result<List<IncomeDto>>>("income/get");

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
            ViewBag.Header = "Kategori İşlemleri";
            ViewBag.Title = "Kategori Güncelle";

            //ilgili kategoriyi bul ve View'e git
            var response = await _restService.GetAsync<Result<IncomeDto>>($"income/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateIncomeVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateIncomeVM updateIncomeModel)
        {
            var response = await _restService.PutAsync<UpdateIncomeVM, Result<int>>(updateIncomeModel, $"income/update/{updateIncomeModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Income", new { Area = "User" });
            }

        }

    }
}
