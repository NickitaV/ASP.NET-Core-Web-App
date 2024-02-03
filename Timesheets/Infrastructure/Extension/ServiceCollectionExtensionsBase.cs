using Microsoft.AspNetCore.Authentication.JwtBearer;
using Timesheets.Domain.Implementation;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto.Auth;

namespace Timesheets.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));

            var jwtSetting = new JwtOptions();
            configuration.Bind("Authentication:JwtAccessOptions", jwtSetting);

            services.AddTransient<ILoginManager, LoginManager>();
            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Options => { Options.TokenValidationParameters = jwtSetting.GetTokenValidationParameters(); });

        }
    }
}