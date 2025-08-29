using System.ComponentModel.DataAnnotations;

namespace EmployeeTimesheet.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Employee email is required")]
    [EmailAddress(ErrorMessage = "Email not in proper format")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
