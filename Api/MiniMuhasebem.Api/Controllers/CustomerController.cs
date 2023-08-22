using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebem.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;

namespace MiniMuhasebem.Api.Controllers
{
    [Route("customer")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<CustomerDto>>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<CustomerDto>>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(new GetCustomerByIdVM { Id = id });
            return Ok(customer);
        }

    }
}
