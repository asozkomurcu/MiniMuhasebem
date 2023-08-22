using MiniMuhasebem.Application.Models.Dtos.AccountDtos;
using MiniMuhasebem.Application.Models.RequestModels.AccountRM;
using MiniMuhasebem.Application.Wrapper;

namespace MiniMuhasebem.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM createUserVM);

        Task<Result<TokenDto>> Login(LoginVM loginVM);

        Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM);
    }
}
