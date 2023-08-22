using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebem.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;

namespace MiniMuhasebem.Api.Controllers
{
    [ApiController]
    [Route("income")]
    [Authorize(Roles = "User")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<IncomeDto>>>> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();
            return Ok(incomes);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<IncomeDto>>> GetIncomeById(int id)
        {
            var incomes = await _incomeService.GetIncomeById(id);
            return Ok(incomes);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateIncome(CreateIncomeVM createIncomeVM)
        {
            var incomes = await _incomeService.CreateIncome(createIncomeVM);
            return Ok(incomes);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateIncome(int id, UpdateIncomeVM updateIncomeVM)
        {
            if (id != updateIncomeVM.Id)
            {
                return BadRequest();
            }
            var incomes = await _incomeService.UpdateIncome(updateIncomeVM);
            return Ok(incomes);
        }

    }
}
