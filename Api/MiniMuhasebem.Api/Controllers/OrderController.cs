using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.RequestModels.OrderRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using System.Data;

namespace MiniMuhasebem.Api.Controllers
{
    [ApiController]
    [Route("order")]
    [Authorize(Roles = "User")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<Order>>>> GetAllOrder()
        {
            var orders = await _orderService.GetAllOrder();
            return Ok(orders);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<Order>>> GetOrderById(int id)
        {
            var orders = await _orderService.GetOrderById(id);
            return Ok(orders);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateOrder(CreateOrderVM createOrderVM)
        {
            var orders = await _orderService.CreateOrder(createOrderVM);
            return Ok(orders);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateOrder(int id, UpdateOrderVM updateOrderVM)
        {
            if (id != updateOrderVM.Id)
            {
                return BadRequest();
            }
            var orders = await _orderService.UpdateOrder(updateOrderVM);
            return Ok(orders);
        }

    }
}
