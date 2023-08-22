using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.Dtos.MonthEndDtos;
using MiniMuhasebem.Application.Models.RequestModels.MonthEndRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;

namespace MiniMuhasebem.Api.Controllers
{
    [ApiController]
    [Route("monthEnd")]
    [Authorize(Roles = "User")]
    public class MonthEndController : ControllerBase
    {
        private readonly IMonthEndService _monthEndService;

        public MonthEndController(IMonthEndService monthEndService)
        {
            _monthEndService = monthEndService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<MonthEndDto>>>> GetAllMonthEnd()
        {
            var monthEnds = await _monthEndService.GetAllMonthEnd();
            return Ok(monthEnds);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<MonthEndDto>>> GetMonthEndById(int id)
        {
            var monthEnds = await _monthEndService.GetMonthEndById(id);
            return Ok(monthEnds);
        }

        //[HttpGet("get2")]
        //public async Task<ActionResult<Result<MonthEndDto>>> CreateMonthEnd2()
        //{
        //    var monthEnds = await _monthEndService.CreateMonthEnd2();
        //    return Ok(monthEnds);
        //}

        [HttpPost("create")]
        public async Task<ActionResult<Result<MonthEndDto>>> CreateMonthEnd(CreateMonthEndVM createMonthEndVM)
        {
            var monthEnds = await _monthEndService.CreateMonthEnd(createMonthEndVM);
            return Ok(monthEnds);
        }
    }
}
