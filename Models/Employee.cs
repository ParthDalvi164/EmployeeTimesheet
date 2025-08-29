using System.ComponentModel.DataAnnotations;
using SmartLibraryAPI.Models;

namespace EmployeeTimesheet.Models;

public class Employee
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Employee name is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Employee code is required")]
    [RegularExpression("^[0-9]{3}-[0-9]{3}$", ErrorMessage = "Phone number must be in the format")]
    public string? Code { get; set; }
    [Required(ErrorMessage = "Employee designation is required")]
    public string? Designation { get; set; }
    [Required(ErrorMessage = "Employee email is required")]
    [EmailAddress(ErrorMessage = "Email not in proper format")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public int? UserRoleId { get; set; }
    public virtual UserRole? UserRole { get; set; }
}
