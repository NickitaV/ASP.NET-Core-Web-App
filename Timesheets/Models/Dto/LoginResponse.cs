using Humanizer;
using Mono.TextTemplating;
using System;
using Timesheets.Domain.Implementation;

namespace Timesheets.Models.Dto
{/// <summary>
/// Информация об аутентификации пользователя
/// </summary>
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Epoch.net.EpochTime ExpiresIn { get; set; }


    }
}
