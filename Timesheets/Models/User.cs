﻿namespace Timesheets.Models
{///<summary>Информация о пользователе</summary>
    public class User
     
    { public Guid Id { get; set; }
    
    
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
