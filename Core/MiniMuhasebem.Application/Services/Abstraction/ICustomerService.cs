using MiniMuhasebem.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebem.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebem.Application.Wrapper;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface ICustomerService
    {
        Task<Result<List<CustomerDto>>> GetAllCustomers();
        Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM);
    }
}
