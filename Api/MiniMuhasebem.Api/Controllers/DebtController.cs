using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.Dtos.DebtDtos;
using MiniMuhasebem.Application.Models.RequestModels.DebtRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Api.Controllers
{
    [ApiController]
    [Route("debt")]
    [Authorize(Roles = "User")]
    public class DebtController : ControllerBase
    {
        private readonly IDebtService _debtService;

        public DebtController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<DebtDto>>>> GetAllDebts()
        {
            var debts = await _debtService.GetAllDebts();
            return Ok(debts);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<DebtDto>>> GetDebtById(int id)
        {
            var debt = await _debtService.GetDebtsById(new GetDebtByIdVM { Id = id });
            return Ok(debt);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateDebts(CreateDebtVM createDebtVM)
        {
            var debts = await _debtService.CreateDebts(createDebtVM);
            return Ok(debts);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateDebts(int id, UpdateDebtVM updateDebtVM)
        {
            if (id != updateDebtVM.Id)
            {
                return BadRequest();
            }
            var debts = await _debtService.UpdateDebts(updateDebtVM);
            return Ok(debts);
        }

    }
}
