using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetManager
    {
       Task <Sheet> GetItem(Guid id);
       Task<Guid> Create(SheetRequest sheet);

        Task <IEnumerable<Sheet>> GetItems();
       Task Update(Guid id,SheetRequest sheetRequest);
    }
}
