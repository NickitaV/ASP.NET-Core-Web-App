using System.Data;
using System.Diagnostics.Contracts;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class SheetManager : ISheetManager
    {
        public readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }

        public async Task<Guid> Create(SheetRequest sheetRequest)
        {
            var sheet = new Sheet
            {
                Id = Guid.NewGuid(),
                Date = sheetRequest.Date,                
                ContractId = sheetRequest.ContractId,
                ServiceId = sheetRequest.ServiceId,
                Amount = sheetRequest.Amount,
                EmployeeId = sheetRequest.EmployeeId,
                

            };
          await  _sheetRepo.Add(sheet);
            return sheet.Id;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
           return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
           return await _sheetRepo.GetItems();
        }

        public async Task Update(Guid id, SheetRequest sheetRequest)
        {
            var sheet = new Sheet { 
            Id = id,
                Date = sheetRequest.Date,                
                ContractId = sheetRequest.ContractId,
                ServiceId = sheetRequest.ServiceId,
                Amount = sheetRequest.Amount,
                EmployeeId = sheetRequest.EmployeeId,
                

            };
        await _sheetRepo.Update(sheet);
           
           
        }
    }
}
