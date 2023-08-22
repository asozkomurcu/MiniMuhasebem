using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.MonthEndDtos;
using MiniMuhasebem.Application.Models.RequestModels.MonthEndRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.MonthEndsValidators;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using MiniMuhasebem.Domain.UWork;

namespace MiniMuhasebem.Application.Services.Implementation
{
    public class MonthEndService : IMonthEndService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uwork;

        public MonthEndService(IMapper mapper, IUnitWork uwork)
        {
            _mapper = mapper;
            _uwork = uwork;
        }

        public async Task<Result<List<MonthEndDto>>> GetAllMonthEnd()
        {
            var result = new Result<List<MonthEndDto>>();
            var monthEndEntites = await _uwork.GetRepository<MonthEnd>().GetAllAsync();


            var monthEndDtos = await monthEndEntites.ProjectTo<MonthEndDto>(_mapper.ConfigurationProvider).ToListAsync();

            result.Data = monthEndDtos;
            _uwork.Dispose();
            return result;
        }

        public async Task<Result<MonthEndDto>> GetMonthEndById(int id)
        {
            var result = new Result<MonthEndDto>();

            var monthEndEntites = await _uwork.GetRepository<MonthEnd>().GetSingleByFilterAsync(x => x.Id == id, "Income", "Wholasaler", "Order", "Payment", "Debt");
            if (monthEndEntites == null)
            {
                throw new NotFoundException($"{id} numaralı ay sonu hesap bilgisi bulunamadı.");
            }

            var monthEndDtos = _mapper.Map<MonthEndDto>(monthEndEntites);
            result.Data = monthEndDtos;
            return result;
        }

        public async Task<Result<MonthEndDto>> CreateMonthEnd2()
        {
            var result = new Result<MonthEndDto>();

            //var monthEndIncomeTotalPrice = await _uwork.GetRepository<MonthEnd>().GetAllColumnsTotalAsync(x => x.Debt.OrderDebt);
            ////monthEndIncomeTotalPrice.Sum(x => x.Income.Cash);
            //var totalIncomeCash = monthEndIncomeTotalPrice;
            //var monthEndIncomeEntites = _mapper.Map<MonthEndDto>(monthEndIncomeTotalPrice);
            //result.Data.TotalIncomeCash = Convert.ToDecimal(monthEndIncomeTotalPrice);
            return result;
        }

        [ValidationBehavior(typeof(CreateMonthEndValidator))]
        public async Task<Result<int>> CreateMonthEnd(CreateMonthEndVM createMonthEndVM)
        {
            var result = new Result<int>();

            var monthEndEntites = _mapper.Map<CreateMonthEndVM, MonthEnd>(createMonthEndVM);

            _uwork.GetRepository<MonthEnd>().Add(monthEndEntites);
            await _uwork.CommitAsync();

            result.Data = monthEndEntites.Id;
            _uwork.Dispose();
            return result;

        }


    }
}
