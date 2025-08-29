using EmployeeTimesheet;
using EmployeeTimesheet.Data;
using EmployeeTimesheet.Models;
using EmployeeTimesheet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TimesheetTimesheet.Repositories;

public class TimesheetRepository : ITimesheetRepository
{
    private readonly EmployeeTimesheetDbContext _context;
    public TimesheetRepository(EmployeeTimesheetDbContext context)
    {
        _context = context;
    }
    Timesheet ITimesheetRepository.Add(Timesheet timesheet)
    {
        _context.Timesheets.Add(timesheet);
        _context.SaveChanges();
        return timesheet;
    }

    void ITimesheetRepository.Delete(int id)
    {
        var timesheetToBeDeleted = _context.Timesheets.FirstOrDefault(e => e.Id == id);
        _context.Timesheets.Remove(timesheetToBeDeleted);
        _context.SaveChanges();
    }

    IEnumerable<Timesheet> ITimesheetRepository.GetAll()
    {
        return _context.Timesheets.Include(t => t.Employee).ToList();
    }

    Timesheet ITimesheetRepository.GetById(int id)
    {
        return _context.Timesheets.AsNoTracking().FirstOrDefault(e => e.Id == id);
    }

    Timesheet ITimesheetRepository.Update(Timesheet timesheet)
    {
        _context.Timesheets.Update(timesheet);
        _context.SaveChanges();
        return timesheet;
    }
}
