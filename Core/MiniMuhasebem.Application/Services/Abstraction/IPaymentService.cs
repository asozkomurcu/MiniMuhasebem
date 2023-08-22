using MiniMuhasebem.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebem.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebem.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IPaymentService
    {
        Task<Result<List<PaymentDto>>> GetAllPayments();
        Task<Result<PaymentDto>> GetPaymentById(int id);
        Task<Result<int>> CreatePayments(CreatePaymentVM createPaymentVM);
        Task<Result<bool>> UpdatePayments(UpdatePaymentVM updatePaymentVM);

    }
}
