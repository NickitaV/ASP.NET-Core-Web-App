

using Epoch.net;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Auth;


namespace Timesheets.Domain.Implementation
{
    

    public class LoginManager : ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;
        public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions)
        {

            _jwtAccessOptions = jwtAccessOptions.Value;
        }
        public async Task<LoginResponse> Authenticate(User user)
        {
            var claims = new List<Claim>() {

               new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,user.Id.ToString()),
               new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName,user.Username),
               new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role)



           };


            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);

            var loginResponse=new LoginResponse(){AccessToken = accessToken,
                ExpiresIn=accessTokenRaw.ValidTo.ToEpochTime()
        };
            return loginResponse;
        }

        


    }
}
