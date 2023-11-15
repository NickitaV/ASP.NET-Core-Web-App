using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Implementation;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheetsController : ControllerBase
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;



        public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {

            var result = await _sheetManager.GetItem(id);
            return Ok(result);


        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {

            var result = await _sheetManager.GetItems();
            return Ok(result);


        }
        ///<summary>Возвращает запись табеля </summary>

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SheetRequest sheet) {
            var IsAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);
            if (IsAllowedToCreate != null && !(bool)IsAllowedToCreate)
            { return BadRequest($"Contract {sheet.ContractId} is not active or not found"); }
            var id = await _sheetManager.Create(sheet);
            return Ok(id);
        }///<summary>Обновляет запись табеля </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody] SheetRequest sheet) {

            var IsAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);
            if (IsAllowedToCreate != null && !(bool)IsAllowedToCreate)
            { return BadRequest($"Contract {sheet.ContractId} is not active or not found"); }
           
             await _sheetManager.Update(id, sheet);
           
            return Ok();
        }
        
        }
    
}
