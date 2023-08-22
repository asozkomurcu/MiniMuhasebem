using MiniMuhasebem.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebem.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebem.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IWholesalerService
    {
        Task<Result<List<WholesalerDto>>> GetAllWholesaler();
        Task<Result<WholesalerDto>> GetWholesalerById(GetWholesalerByIdVM getWholesalerByIdVM);
        Task<Result<int>> CreateWholesaler(CreateWholesalerVM createWholesalerVM);
        Task<Result<bool>> UpdateWholesaler(UpdateWholesalerVM updateWholesalerVM);
        Task<Result<bool>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM);
    }
}
