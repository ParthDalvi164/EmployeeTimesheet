using EmployeeTimesheet.Models;
using EmployeeTimesheet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLibraryAPI.Models;

namespace EmployeeTimesheet;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [Authorize(Roles = nameof(Role.ADMIN))]
    public IActionResult Get()
    {
        var employeeList = _employeeService.GetAll();
        return Ok(employeeList);
    }

    [HttpPost]
    public IActionResult Post(Employee employee)
    {
        if (ModelState.IsValid)
        {
            var addedEmployee = _employeeService.Add(employee);
            return CreatedAtAction("GetEmployee", new { id = addedEmployee.Id }, employee);
        }
        return BadRequest(employee);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployee(int id)
    {
        var employee = _employeeService.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employeeFound = _employeeService.GetById(id);

        if (employeeFound != null)
        {
            _employeeService.Delete(id);
            return NoContent();
        }
        return NotFound(employeeFound);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
    {
        var employeeFound = _employeeService.GetById(id);

        if (employeeFound != null)
        {
            employee.Id = employeeFound.Id;
            _employeeService.Update(employee);
            return Ok(employee);
        }

        return NotFound(employeeFound);
    }
}
