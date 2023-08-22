using AutoMapper;
using MiniMuhasebem.Application.Models.Dtos.AccountDtos;
using MiniMuhasebem.Application.Models.Dtos.CategoryDtos;
using MiniMuhasebem.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebem.Application.Models.Dtos.CustomerImageDtos;
using MiniMuhasebem.Application.Models.Dtos.DebtDtos;
using MiniMuhasebem.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebem.Application.Models.Dtos.MonthEndDtos;
using MiniMuhasebem.Application.Models.Dtos.OrderDtos;
using MiniMuhasebem.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebem.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Application.AutoMappings
{
    public class DomainToDtoModel : Profile
    {
        public DomainToDtoModel()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerImage, CustomerImageDto>();
            CreateMap<CustomerImage, CustomerImageWithCustomerDto>();

            CreateMap<Debt, DebtDto>();

            CreateMap<Income, IncomeDto>();

            CreateMap<MonthEnd, MonthEndDto>();

            CreateMap<Order, OrderDto>();

            CreateMap<Payment, PaymentDto>();

            CreateMap<Wholesaler, WholesalerDto>();

        }
    }
}
