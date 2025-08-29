using EmployeeTimesheet.Models;
using Microsoft.EntityFrameworkCore;
using SmartLibraryAPI.Models;

namespace EmployeeTimesheet.Data;

public class EmployeeTimesheetDbContext : DbContext
{
    public EmployeeTimesheetDbContext() { }
    public EmployeeTimesheetDbContext(DbContextOptions<EmployeeTimesheetDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Timesheet> Timesheets { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasData(new UserRole { Id = 1, Role = Role.ADMIN },
            new UserRole { Id = 2, Role = Role.USER });
    }
}
