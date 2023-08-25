using EMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EMSDb");
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FirstName= "Kevin",
                MiddleName="B",
                LastName="Wanzer",
                Address="Bangalore",
                Department="IT",
                Email="nitin@contoso.com",
                Phone="+91 55655433454"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Adam",
                MiddleName = "C.",
                LastName = "Ban",
                Address = "Bangalore",
                Department = "IT",
                Email = "paul@contoso.com",
                Phone = "+91 55655433454"
            });
        }
    }
}
