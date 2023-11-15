using Microsoft.EntityFrameworkCore;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain
{
    public class TimesheetDBContext:DbContext
    {
        

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<User> Users { get; set; }

        public TimesheetDBContext(DbContextOptions<TimesheetDBContext> options):base(options){

}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Contract>().ToTable("contracts");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Service>().ToTable("services");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Sheet>().HasOne(sheet=>sheet.Contract).WithMany(contract=>contract.Sheets).HasForeignKey("ContractId");
           
            modelBuilder.Entity<Sheet>().HasOne(sheet => sheet.Service).WithMany(service => service.Sheets).HasForeignKey("ServiceId");
           
            modelBuilder.Entity<Sheet>().HasOne(sheet => sheet.Employee).WithMany(employee => employee.Sheets).HasForeignKey("EmployeeId");
     
        }


    }
}
