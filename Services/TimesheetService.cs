using EmployeeTimesheet.Models;
using EmployeeTimesheet.Repositories;

namespace EmployeeTimesheet.Services;

public class TimesheetService : ITimesheetService
{
    private readonly ITimesheetRepository _repository;
    public TimesheetService(ITimesheetRepository repository)
    {
        _repository = repository;
    }
    Timesheet ITimesheetService.Add(Timesheet timesheet)
    {
        return _repository.Add(timesheet);
    }

    void ITimesheetService.Delete(int id)
    {
        _repository.Delete(id);
    }

    IEnumerable<Timesheet> ITimesheetService.GetAll()
    {
        return _repository.GetAll();
    }

    Timesheet ITimesheetService.GetById(int id)
    {
        return _repository.GetById(id);
    }

    Timesheet ITimesheetService.Update(Timesheet timesheet)
    {
        return _repository.Update(timesheet);
    }
}
