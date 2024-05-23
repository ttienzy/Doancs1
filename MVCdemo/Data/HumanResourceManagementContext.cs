using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCdemo.Models;

namespace MVCdemo.Data
{
    public class HumanResourceManagementContext : IdentityDbContext<AppUser>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmploymentContract> employmentContracts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salarys { get; set; }

        public HumanResourceManagementContext(DbContextOptions<HumanResourceManagementContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<IdentityRole> identityRolesroleList = new List<IdentityRole>(){
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole{
                    Name = "User_1",
                    NormalizedName = "USER_1"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(identityRolesroleList);
        }
    }
}
