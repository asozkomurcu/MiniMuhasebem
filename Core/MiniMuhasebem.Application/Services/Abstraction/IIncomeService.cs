using MiniMuhasebem.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebem.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebem.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IIncomeService
    {
        Task<Result<List<IncomeDto>>> GetAllIncomes();
        Task<Result<IncomeDto>> GetIncomeById(int id);

        Task<Result<int>> CreateIncome(CreateIncomeVM createIncomeVM);
        Task<Result<bool>> UpdateIncome(UpdateIncomeVM updateIncomeVM);
    }
}
