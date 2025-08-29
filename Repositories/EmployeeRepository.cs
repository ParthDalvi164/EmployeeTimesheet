using EmployeeTimesheet.Data;
using EmployeeTimesheet.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimesheet.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeTimesheetDbContext _context;
    public EmployeeRepository(EmployeeTimesheetDbContext context)
    {
        _context = context;
    }
    Employee IEmployeeRepository.Add(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return employee;
    }

    void IEmployeeRepository.Delete(int id)
    {
        var employeeToBeDeleted = _context.Employees.FirstOrDefault(e => e.Id == id);
        _context.Employees.Remove(employeeToBeDeleted);
        _context.SaveChanges();
    }

    IEnumerable<Employee> IEmployeeRepository.GetAll()
    {
        return _context.Employees.ToList();
    }

    Employee IEmployeeRepository.GetById(int id)
    {
        return _context.Employees.AsNoTracking().FirstOrDefault(e => e.Id == id);
    }

    Employee IEmployeeRepository.Update(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
        return employee;
    }

    LoginResponseViewModel IEmployeeRepository.Login(LoginViewModel loginVM)
    {
        var employee = _context.Employees.Include(u => u.UserRole).FirstOrDefault(u => u.Email == loginVM.Email && u.Password == loginVM.Password);

        if (employee != null)
        {
            return new LoginResponseViewModel() { IsSuccess = true, Employee = employee, Token = "" };
        }

        return new LoginResponseViewModel() { IsSuccess = false, Employee = null, Token = "" };
    }
}
