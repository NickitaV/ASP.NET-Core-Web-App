using System.Threading.Tasks;
using System.Text;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using System.Security.Cryptography;

namespace Timesheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Guid> CreateUser(CreateUserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),


                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),

                Role = request.Role
            };

            await _userRepo.CreateUser(user);
            return user.Id;
            

        }
        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {


                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }



        }

        public async Task<User> GetUser(LoginRequest request)
        {
           var passwordHash= GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);
            return user;
        }
    }
}
