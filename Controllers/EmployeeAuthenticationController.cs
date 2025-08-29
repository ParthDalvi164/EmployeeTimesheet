using EmployeeTimesheet.Models;
using EmployeeTimesheet.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimesheet;

[Route("api/[controller]")]
[ApiController]
public class EmployeeAuthenticationController : ControllerBase
{
    private readonly IEmployeeService _userService;
    public EmployeeAuthenticationController(IEmployeeService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public IActionResult Login(LoginViewModel loginVM)
    {
        if (ModelState.IsValid)
        {
            var loginResp = _userService.Login(loginVM);
            if (loginResp.IsSuccess == true)
            {
                return Ok(loginResp);
            }
            return Unauthorized();
        }
        return BadRequest(loginVM);
    }
}
