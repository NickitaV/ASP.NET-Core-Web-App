using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ILoginManager
    {
        Task<LoginResponse> Authenticate(User user);
       // Task Authenticate(User user);
    }
}
