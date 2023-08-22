using MiniMuhasebem.Application.Models.Dtos.OrderDtos;
using MiniMuhasebem.Application.Models.RequestModels.OrderRM;
using MiniMuhasebem.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IOrderService
    {
        Task<Result<List<OrderDto>>> GetAllOrder();
        Task<Result<OrderDto>> GetOrderById(int id);
        Task<Result<int>> CreateOrder(CreateOrderVM createOrderVM);
        Task<Result<bool>> UpdateOrder(UpdateOrderVM updateOrderVM);
    }
}
