using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Timesheets.Models.Dto.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SingingKey { get; set; }
        public int Lifetime { get; set; }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidIssuer = Issuer,
                ValidateAudience = false,
                ValidateLifetime = false,

                IssuerSigningKeys = (IEnumerable<SecurityKey>)GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
                RoleClaimType = ClaimsIdentity.DefaultRoleClaimType

            };


        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SingingKey));

        }

        public JwtSecurityToken GenerateToken(IEnumerable<Claim> claims) {
            var now = DateTime.UtcNow;
            var jwt=new JwtSecurityToken(
            issuer:Issuer,
                audience:Audience,
                notBefore:now,
                claims:claims,
                expires:now.Add(TimeSpan.FromMinutes(Lifetime)),
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
            return jwt;

        
        
        }
    }

   

}
