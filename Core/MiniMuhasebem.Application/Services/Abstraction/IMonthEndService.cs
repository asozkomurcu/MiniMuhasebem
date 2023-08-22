using MiniMuhasebem.Application.Models.Dtos.MonthEndDtos;
using MiniMuhasebem.Application.Models.RequestModels.MonthEndRM;
using MiniMuhasebem.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IMonthEndService
    {
        Task<Result<List<MonthEndDto>>> GetAllMonthEnd();
        Task<Result<MonthEndDto>> GetMonthEndById(int id);
        Task<Result<MonthEndDto>> CreateMonthEnd2();
        Task<Result<int>> CreateMonthEnd(CreateMonthEndVM createMonthEndVM);


    }
}
