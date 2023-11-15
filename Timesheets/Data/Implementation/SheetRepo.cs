using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Domain;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Implementation
{
    public class SheetRepo : ISheetRepo
    {

        private readonly TimesheetDBContext _context;

        public SheetRepo(TimesheetDBContext context)
        {
            _context = context;
        }

        // private List<Sheet> sheet { get; set; } = new List<Sheet>() {

        //    new Sheet{
        //    Id = Guid.Parse("AD1964CB-2A96-8E97-3C69-2326B219845C"),

        //    EmployeeId = Guid.Parse("5B3C7916-7696-CBA5-EA17-AEAE0119698E"),
        //    ContractId = Guid.Parse("482CAAB0-07D6-D5B7-B41B-212BA49822F2"),
        //    ServiceId = Guid.Parse("4AEB56C0-78D3-3D86-15A0-628D8EE9BC7B"),
        //    Amount = 4
        //},

        //new Sheet {
        //    Id = Guid.Parse("B2AC07D6-DE4A-2407-C020-E348D4AB75A6"),

        //    EmployeeId = Guid.Parse("E54E84EE-D9A7-C765-4B36-3BB9AF216ADC"),
        //    ContractId = Guid.Parse("52517EDD-431F-3A69-DB99-79CD7C91D3C4"),
        //    ServiceId = Guid.Parse("0E4C2D43-2B75-444E-CA19-633AD5371368"),
        //    Amount = 5
        //}};

        public async Task Add(Sheet item)
        {
           await _context.Sheets.AddAsync(item);
           await _context.SaveChangesAsync();
        }

       

       

      

        public async Task<Sheet> GetItem(Guid id)
        {
         return await _context.Sheets.FindAsync(id);
          
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
          var result= await _context.Sheets.ToListAsync();

            var FilteredResult = result.Where(x => x.Amount > 2);

            var result2 = _context.Sheets.AsQueryable();
            FilteredResult = result2.Where(x => x.Amount > 2);

            return FilteredResult.AsEnumerable();


        }

        

        public async Task Update(Sheet item)
        {
            _context.Sheets.Update(item);
             await _context.SaveChangesAsync();
        }
    }
}
