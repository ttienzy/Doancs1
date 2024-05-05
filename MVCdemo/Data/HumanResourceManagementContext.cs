using Microsoft.EntityFrameworkCore;
using MVCdemo.Models;

namespace MVCdemo.Data
{
    public class HumanResourceManagementContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentContract> employmentContracts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salarys { get; set;}

        public HumanResourceManagementContext(DbContextOptions<HumanResourceManagementContext> options) : base(options) { }
    }
}
