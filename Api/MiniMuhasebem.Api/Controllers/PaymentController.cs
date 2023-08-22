using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebem.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Api.Controllers
{
    [ApiController]
    [Route("payment")]
    [Authorize(Roles = "User")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<PaymentDto>>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<PaymentDto>>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            return Ok(payment);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreatePayments(CreatePaymentVM createPaymentVM)
        {
            var payment = await _paymentService.CreatePayments(createPaymentVM);
            return Ok(payment);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateDebts(int id, UpdatePaymentVM updatePaymentVM)
        {

            if (id != updatePaymentVM.Id)
            {
                return BadRequest();
            }
            var payment = await _paymentService.UpdatePayments(updatePaymentVM);
            return Ok(payment);
        }

    }
}
