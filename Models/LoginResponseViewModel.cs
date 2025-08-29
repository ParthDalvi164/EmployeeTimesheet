using SmartLibraryAPI.Models;

namespace EmployeeTimesheet.Models;

public class LoginResponseViewModel
{
    public bool IsSuccess { get; set; }
    public Employee Employee { get; set; }
    public string Token { get; set; }
}
