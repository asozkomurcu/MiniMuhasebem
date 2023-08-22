using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.Dtos.CustomerImageDtos;
using MiniMuhasebem.Application.Models.RequestModels.CustomerImageRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;

namespace MiniMuhasebem.Api.Controllers
{

    [ApiController]
    [Route("customerImage")]
    //[Authorize("Admin")]
    public class CustomerImageController : ControllerBase
    {
        private readonly ICustomerImageService _customerImageService;

        public CustomerImageController(ICustomerImageService customerImageService)
        {
            _customerImageService = customerImageService;
        }

        [HttpGet("getAllByCustomer/{id:int?}")]
        public async Task<ActionResult<Result<List<CustomerImageDto>>>> GetAllImagesByCustomer(int? id)
        {
            var result = await _customerImageService.GetAllImagesByCustomer(new GetAllCustomerImageByCustomerVM { CustomerId = id });
            return Ok(result);
        }

        [HttpGet("getAllDetailByCustomer/{id:int?}")]
        public async Task<ActionResult<Result<List<CustomerImageWithCustomerDto>>>> GetAllImagesWithCustomerByCustomer(int? id)
        {
            var result = await _customerImageService.GetAllCustomerImagesWithCustomer(new GetAllCustomerImageByCustomerVM { CustomerId = id });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCustomerImage([FromForm] CreateCustomerImageVM createCustomerImageVM)
        {
            var result = await _customerImageService.CreateCustomerImage(createCustomerImageVM);
            return Ok(result);
        }


        [HttpDelete("delete/{id:int?}")]
        public async Task<ActionResult<Result<int>>> DeleteCustomerImage(int? id)
        {
            var result = await _customerImageService.DeleteCustomerImage(new DeleteCustomerImageVM { Id = id });
            return Ok(result);
        }


    }
}

