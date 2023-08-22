using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebem.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using System.Data;

namespace MiniMuhasebem.Api.Controllers
{
    [ApiController]
    [Route("wholesaler")]
    [Authorize(Roles = "User")]
    public class WholesalerController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;

        public WholesalerController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }
        [HttpGet("get")]
        public async Task<ActionResult<Result<List<Wholesaler>>>> GetAllWholesaler()
        {
            var wholesalers = await _wholesalerService.GetAllWholesaler();
            return Ok(wholesalers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<Wholesaler>>> GetWholesalerById(int id,GetWholesalerByIdVM getWholesalerByIdVM)
        {
            var wholesalers = await _wholesalerService.GetWholesalerById(getWholesalerByIdVM);
            return Ok(wholesalers);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateWholesalerImage(CreateWholesalerVM createWholesalerVM)
        {
            var wholesalers = await _wholesalerService.CreateWholesaler(createWholesalerVM);
            return Ok(wholesalers);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateWholesaler(int id, UpdateWholesalerVM updateWholesalerVM)
        {
            if (id != updateWholesalerVM.Id)
            {
                return BadRequest();
            }
            var wholesalers = await _wholesalerService.UpdateWholesaler(updateWholesalerVM);
            return Ok(wholesalers);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteWholesaler(int id)
        {
            var wholesalers = await _wholesalerService.DeleteWholesaler(new DeleteWholesalerVM { Id=id});
            return Ok(wholesalers);
        }
    }
}
