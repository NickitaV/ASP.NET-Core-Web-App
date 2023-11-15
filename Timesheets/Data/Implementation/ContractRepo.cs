using Timesheets.Data.Interfaces;
using Timesheets.Domain;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ContractRepo : IContractRepo
    {

        private readonly TimesheetDBContext _DBContext;

        public ContractRepo(TimesheetDBContext DBContext)
        {
            _DBContext = DBContext;
        }

        public Task Add(Contract item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            var contract= await _DBContext.Contracts.FindAsync(id);
           var now=DateTime.Now;
            var IsActive= now<= contract?.DateEnd && now>=contract?.DateStart;
            return IsActive;
        }

        public Task<Contract> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contract>> GetItems()
        {
            throw new NotImplementedException();
        }

        

        public async Task Update(Contract item)
        {
              _DBContext.Contracts.Update(item);
            await _DBContext.SaveChangesAsync();
        }

        Task<bool> IContractRepo.CheckContractIsActive(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
