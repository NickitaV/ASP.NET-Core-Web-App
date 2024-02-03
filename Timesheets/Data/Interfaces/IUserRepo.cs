using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo 
    {
        Task CreateUser(User user);
     Task <User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
    }
}
