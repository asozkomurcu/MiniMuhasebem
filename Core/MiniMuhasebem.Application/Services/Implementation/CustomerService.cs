using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebem.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.CustomersValidators;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using MiniMuhasebem.Domain.UWork;

namespace MiniMuhasebem.Application.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;
        public CustomerService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        public async Task<Result<List<CustomerDto>>> GetAllCustomers()
        {
            var result = new Result<List<CustomerDto>>();

            var customerEntites = await _uWork.GetRepository<Customer>().GetAllAsync();
            var customerDtos = await customerEntites.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = customerDtos;
            _uWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(GetCustomerByIdValidator))]
        public async Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM)
        {
            var result = new Result<CustomerDto>();

            var customerExists = await _uWork.GetRepository<Customer>().AnyAsync(x => x.Id == getCustomerByIdVM.Id);
            if (!customerExists)
            {
                throw new NotFoundException($"{getCustomerByIdVM.Id} numaralı kullanıcı bulunamadı.");
            }

            var customerEntity = await _uWork.GetRepository<Customer>().GetById(getCustomerByIdVM.Id);

            var customerDto = _mapper.Map<Customer, CustomerDto>(customerEntity);

            result.Data = customerDto;
            _uWork.Dispose();
            return result;
        }
    }
}
