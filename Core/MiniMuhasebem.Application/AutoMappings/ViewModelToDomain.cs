using AutoMapper;
using MiniMuhasebem.Application.Models.RequestModels.AccountRM;
using MiniMuhasebem.Application.Models.RequestModels.CategoryRM;
using MiniMuhasebem.Application.Models.RequestModels.CustomerImageRM;
using MiniMuhasebem.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebem.Application.Models.RequestModels.DebtRM;
using MiniMuhasebem.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebem.Application.Models.RequestModels.MonthEndRM;
using MiniMuhasebem.Application.Models.RequestModels.OrderRM;
using MiniMuhasebem.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebem.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Application.AutoMappings
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            //Kullanıcı oluşturma isteği
            CreateMap<RegisterVM, Customer>();
            CreateMap<RegisterVM, Account>()
                .ForMember(x => x.Role, y => y.MapFrom(e => Roles.User));

            CreateMap<UpdateUserVM, Customer>();

            //Customer
            CreateMap<GetCustomerByIdVM, Customer>();

            //CustomerImage
            CreateMap<CreateCustomerImageVM, CustomerImage>();

            //Category
            CreateMap<CreateCategoryVM, Category>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));
            CreateMap<UpdateCategoryVM, Category>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(e => e.CategoryName.ToUpper().Trim()));
            CreateMap<DeleteCategoryVM, Category>();
            CreateMap<GetCategoryByIdVM, Category>();

            //Debt
            CreateMap<CreateDebtVM, Debt>();
            CreateMap<UpdateDebtVM, Debt>();
            CreateMap<GetDebtByIdVM, Debt>();

            //Income
            CreateMap<CreateIncomeVM, Income>();
            CreateMap<UpdateIncomeVM, Income>();
            CreateMap<GetIncomeByIdVM, Income>();

            //Income
            CreateMap<CreateMonthEndVM, MonthEnd>();
            //Order
            CreateMap<CreateOrderVM, Order>();
            CreateMap<UpdateOrderVM, Order>();
            CreateMap<GetOrderByIdVM, Order>();

            //Payment
            CreateMap<CreatePaymentVM, Payment>();
            CreateMap<UpdatePaymentVM, Payment>();
            CreateMap<GetPaymentByIdVM, Payment>();

            //Wholesaler
            CreateMap<CreateWholesalerVM, Wholesaler>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));
            CreateMap<UpdateWholesalerVM, Wholesaler>()
                .ForMember(x => x.WholesalerName, y => y.MapFrom(e => e.WholesalerName.ToUpper().Trim()));
            CreateMap<DeleteWholesalerVM, Wholesaler>();
            CreateMap<GetWholesalerByIdVM, Wholesaler>();
        }
    }
}
