namespace Timesheets.Models
{/// <summary>
/// ИНформация о счете
/// </summary>
    public class Sheet
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; internal set; }
        public DateTime Date { get; set; }
        //public Guid UserId { get; set; }
       public Guid ContractId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public Guid ServiceId { get; set; }
        public Employee Employee { get; set; }
        public Contract Contract { get; set; }
        public Service Service { get; set; }
        public int Amount { get; set; }
       
    }
}
