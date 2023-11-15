﻿namespace Timesheets.Models
{/// <summary>
/// Информация о сотруднике
/// </summary>
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}
