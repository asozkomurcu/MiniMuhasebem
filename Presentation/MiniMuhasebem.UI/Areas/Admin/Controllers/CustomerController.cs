using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.UI.Models.Dtos.CustomerDtos;
using MiniMuhasebem.UI.Services.Abstraction;
using MiniMuhasebem.UI.Wrapper;
using System.Net;

namespace MiniMuhasebem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Policy = "Admin")]
    public class CustomerController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public CustomerController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }



        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Kullanıcılar";
            ViewBag.Title = "";

            //Apiye istek at
            //customer/get
            var response = await _restService.GetAsync<Result<List<CustomerDto>>>("customer/get");

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


        //public async Task<IActionResult> Edit(int id)
        //{
        //    ViewBag.Header = "Kategori İşlemleri";
        //    ViewBag.Title = "Kategori Güncelle";

        //    //ilgili kategoriyi bul ve View'e git
        //    var response = await _restService.GetAsync<Result<CategoryDto>>($"category/get/{id}");

        //    if (response.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        ModelState.AddModelError("", response.Data.Errors[0]);
        //        return View();
        //    }
        //    else // herşey yolunda
        //    {
        //        var model = _mapper.Map<UpdateCategoryVM>(response.Data.Data);
        //        return View(model);
        //    }

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(UpdateCategoryVM updateCategoryModel)
        //{
        //    var response = await _restService.PutAsync<UpdateCategoryVM, Result<int>>(updateCategoryModel, $"category/update/{updateCategoryModel.Id}");

        //    if (response.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        ModelState.AddModelError("", response.Data.Errors[0]);
        //        return View();
        //    }
        //    else // herşey yolunda
        //    {
        //        TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
        //        return RedirectToAction("List", "Category", new { Area = "User" });
        //    }

        //}



        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    //api endpointi çağır
        //    //category/delete/id

        //    var response = await _restService.DeleteAsync<Result<int>>($"category/delete/{id}");

        //    return Json(response.Data);

        //}
    }
}
