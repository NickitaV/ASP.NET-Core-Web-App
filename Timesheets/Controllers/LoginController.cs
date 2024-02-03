using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Implementation;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ILoginManager _loginManager;

        public LoginController(IUserManager userManager, ILoginManager loginManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
        }
        [HttpPost]
        public async Task <IActionResult> Login([FromBody] LoginRequest request) {
            var user = await _userManager.GetUser(request);

            if (user == null) {
                return Unauthorized();
            
            }

            var loginResponse = await _loginManager.Authenticate(user);
            return Ok(loginResponse);
        }
    
    
    }
}
