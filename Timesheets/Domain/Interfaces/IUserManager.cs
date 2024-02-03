using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<Guid> CreateUser(CreateUserRequest request);

        Task<User> GetUser(LoginRequest request);


    }
}
