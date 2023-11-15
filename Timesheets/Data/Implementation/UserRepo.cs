using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
      

        Task IRepoBase<User>.Add(User item)
        {
            throw new NotImplementedException();
        }

        Task<User> IRepoBase<User>.GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IRepoBase<User>.GetItems()
        {
            throw new NotImplementedException();
        }

       

        public Task Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
