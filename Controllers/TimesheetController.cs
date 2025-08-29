using EmployeeTimesheet.Models;
using EmployeeTimesheet.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimesheet;

[Route("api/[controller]")]
[ApiController]
public class TimesheetController : ControllerBase
{
    private readonly ITimesheetService _timesheetService;
    public TimesheetController(ITimesheetService timesheetService)
    {
        _timesheetService = timesheetService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var timesheetList = _timesheetService.GetAll();
        return Ok(timesheetList);
    }

    [HttpPost]
    public IActionResult Post(Timesheet timesheet)
    {
        if (ModelState.IsValid)
        {
            var addedTimesheet = _timesheetService.Add(timesheet);
            return CreatedAtAction("GetTimesheet", new { id = addedTimesheet.Id }, timesheet);
        }
        return BadRequest(timesheet);
    }

    [HttpGet("{id}")]
    public IActionResult GetTimesheet(int id)
    {
        var timesheet = _timesheetService.GetById(id);
        if (timesheet == null)
        {
            return NotFound();
        }
        return Ok(timesheet);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTimesheet(int id)
    {
        var timesheetFound = _timesheetService.GetById(id);

        if (timesheetFound != null)
        {
            _timesheetService.Delete(id);
            return NoContent();
        }
        return NotFound(timesheetFound);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTimesheet(int id, Timesheet timesheet)
    {
        var timesheetFound = _timesheetService.GetById(id);

        if (timesheetFound != null)
        {
            timesheet.Id = timesheetFound.Id;
            _timesheetService.Update(timesheet);
            return Ok(timesheetFound);
        }

        return NotFound(timesheetFound);
    }
}
