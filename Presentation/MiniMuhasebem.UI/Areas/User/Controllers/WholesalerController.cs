using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.WholasalerDtos;
using MiniMuhasebem.UI.Models.RequestModels.WholasalerRM;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Policy = "AdminOrUser")]
    public class WholesalerController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public WholesalerController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Tedarikçi İşlemleri";
            ViewBag.Title = "Yeni Tedarikçi Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWholesalerVM wholesalerModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(wholesalerModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateWholesalerVM, Result<int>>(wholesalerModel, "wholesaler/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Wholesaler", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Tedarikçi İşlemleri";
            ViewBag.Title = "Tedarikçi Düzenle";

            //Apiye istek at
            //wholesaler/get
            var response = await _restService.GetAsync<Result<List<WholesalerDto>>>("wholesaler/get");

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
            ViewBag.Header = "Tedarikçi İşlemleri";
            ViewBag.Title = "Tedarikçi Güncelle";

            //ilgili tedarikçiyi bul ve View'e git
            var response = await _restService.GetAsync<Result<WholesalerDto>>($"wholesaler/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateWholesalerVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateWholesalerVM updateWholesalerModel)
        {
            var response = await _restService.PutAsync<UpdateWholesalerVM, Result<int>>(updateWholesalerModel, $"wholesaler/update/{updateWholesalerModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Wholesaler", new { Area = "User" });
            }

        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //api endpointi çağır
            //wholesaler/delete/id

            var response = await _restService.DeleteAsync<Result<int>>($"wholesaler/delete/{id}");

            return Json(response.Data);

        }
    }
}
