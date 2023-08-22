using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.PaymentDtos;
using MiniMuhasebem.UI.Models.RequestModels.PaymentRM;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Policy = "AdminOrUser")]
    public class PaymentController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public PaymentController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Ödeme İşlemleri";
            ViewBag.Title = "Yeni Ödeme Kaydı Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentVM paymentModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(paymentModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreatePaymentVM, Result<int>>(paymentModel, "payment/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Payment", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Ödeme İşlemleri";
            ViewBag.Title = "Ödeme Kaydı Düzenle";

            //Apiye istek at
            //payment/get
            var response = await _restService.GetAsync<Result<List<PaymentDto>>>("payment/get");

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
            ViewBag.Header = "Ödeme İşlemleri";
            ViewBag.Title = "Ödeme Kaydı Güncelle";

            //ilgili kategoriyi bul ve View'e git
            var response = await _restService.GetAsync<Result<PaymentDto>>($"payment/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdatePaymentVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePaymentVM updatePaymentModel)
        {
            var response = await _restService.PutAsync<UpdatePaymentVM, Result<int>>(updatePaymentModel, $"payment/update/{updatePaymentModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Payment", new { Area = "User" });
            }

        }
    }
}
