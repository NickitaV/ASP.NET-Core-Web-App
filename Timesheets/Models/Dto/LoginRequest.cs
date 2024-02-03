namespace Timesheets.Models.Dto
{
    public class LoginRequest
        ///<summary>Запрос аутентификации пользователя по логину и паролю</summary>>
    { public string Login { get; set; }
        public string Password { get; set; }
    }
}
