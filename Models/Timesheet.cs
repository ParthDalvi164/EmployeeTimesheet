using System.ComponentModel.DataAnnotations;

namespace EmployeeTimesheet.Models;

public class Timesheet
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Employee is required")]
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    [Required(ErrorMessage = "Date is required")]
    public DateOnly Date { get; set; }
    [Required(ErrorMessage = "Start time is required")]
    public TimeOnly StartTime { get; set; }
    [Required(ErrorMessage = "End time is required")]
    public TimeOnly EndTime { get; set; }
    [Required(ErrorMessage = "Task name is required")]
    public string? TaskName { get; set; }
    public TimeSpan TotalHours => EndTime - StartTime;
}
