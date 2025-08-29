using EmployeeTimesheet.Models;

namespace EmployeeTimesheet.Services;

public interface ITimesheetService
{
    Timesheet Add(Timesheet timesheet);
    Timesheet Update(Timesheet timesheet);
    void Delete(int id);
    Timesheet GetById(int id);
    IEnumerable<Timesheet> GetAll();
}
