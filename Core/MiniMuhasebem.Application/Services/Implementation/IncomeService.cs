using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebem.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.IncomesValidators;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using MiniMuhasebem.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Implementation
{
    public class IncomeService : IIncomeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uwork;

        public IncomeService(IMapper mapper, IUnitWork uwork)
        {
            _mapper = mapper;
            _uwork = uwork;
        }

        public async Task<Result<List<IncomeDto>>> GetAllIncomes()
        {
            var result = new Result<List<IncomeDto>>();

            var incomeEntites = await _uwork.GetRepository<Income>().GetAllAsync();

            var incomeDtos = await incomeEntites.ProjectTo<IncomeDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = incomeDtos;
            _uwork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetIncomeByIdValidator))]
        public async Task<Result<IncomeDto>> GetIncomeById(int id)
        {
            var result = new Result<IncomeDto>();

            var incomeEntites = await _uwork.GetRepository<Income>().GetSingleByFilterAsync(x => x.Id == id);
            if (incomeEntites == null)
            {
                throw new NotFoundException($"{id} numaralı hesap hareketi bulunamadı.");
            }

            var incomeDtos = _mapper.Map<IncomeDto>(incomeEntites);
            result.Data = incomeDtos;
            return result;
        }

        [ValidationBehavior(typeof(CreateIncomeValidator))]
        public async Task<Result<int>> CreateIncome(CreateIncomeVM createIncomeVM)
        {
            var result = new Result<int>();

            var incomeEntites = _mapper.Map<CreateIncomeVM, Income>(createIncomeVM);

            _uwork.GetRepository<Income>().Add(incomeEntites);
            await _uwork.CommitAsync();

            result.Data = incomeEntites.Id;
            _uwork.Dispose();
            return result;

        }

        [ValidationBehavior(typeof(UpdateIncomeValidator))]
        public async Task<Result<bool>> UpdateIncome(UpdateIncomeVM updateIncomeVM)
        {
            var result = new Result<bool>();

            var incomeEntites = await _uwork.GetRepository<Income>().GetSingleByFilterAsync(x => x.Id == updateIncomeVM.Id);
            if (incomeEntites == null)
            {
                throw new NotFoundException($"{updateIncomeVM.Id} numaralı hesap hareketi bulunamadı.");
            }

            var existsIncomeEntity = await _uwork.GetRepository<Income>().GetById(updateIncomeVM.Id.Value);

            _mapper.Map(updateIncomeVM, existsIncomeEntity);

            _uwork.GetRepository<Income>().Update(existsIncomeEntity);

            result.Data = await _uwork.CommitAsync();
            return result;
        }

    }
}
