using EmployeeTimesheet.Models;

namespace EmployeeTimesheet.Repositories;

public interface ITimesheetRepository
{
    Timesheet Add(Timesheet timesheet);
    Timesheet Update(Timesheet timesheet);
    void Delete(int id);
    Timesheet GetById(int id);
    IEnumerable<Timesheet> GetAll();
}
