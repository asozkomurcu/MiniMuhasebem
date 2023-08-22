using MiniMuhasebem.Application.Models.Dtos.DebtDtos;
using MiniMuhasebem.Application.Models.RequestModels.DebtRM;
using MiniMuhasebem.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IDebtService
    {
        Task<Result<List<DebtDto>>> GetAllDebts();
        Task<Result<DebtDto>> GetDebtsById(GetDebtByIdVM getDebtByIdVM);
        Task<Result<int>> CreateDebts(CreateDebtVM createDebtVM);
        Task<Result<int>> UpdateDebts(UpdateDebtVM updateDebtVM);
    }
}
