using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.OrderDtos;
using MiniMuhasebem.UI.Models.RequestModels.OrderRM;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.User.Controllers
{
    [Area("User")]
    //[Authorize(Policy = "AdminOrUser")]
    public class OrderController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public OrderController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Sipariş İşlemleri";
            ViewBag.Title = "Yeni Sipariş Oluştur";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderVM orderModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(orderModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateOrderVM, Result<int>>(orderModel, "order/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Order", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Sipariş İşlemleri";
            ViewBag.Title = "Sipariş Düzenle";

            //Apiye istek at
            //order/get
            var response = await _restService.GetAsync<Result<List<OrderDto>>>("order/get");

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
            var response = await _restService.GetAsync<Result<OrderDto>>($"order/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateOrderVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateOrderVM updateOrderModel)
        {
            var response = await _restService.PutAsync<UpdateOrderVM, Result<int>>(updateOrderModel, $"order/update/{updateOrderModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Order", new { Area = "User" });
            }

        }
    }
}
