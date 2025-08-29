using EmployeeTimesheet.Models;

namespace EmployeeTimesheet.Services;

public interface IEmployeeService
{
    Employee Add(Employee employee);
    Employee Update(Employee employee);
    void Delete(int id);
    Employee GetById(int id);
    IEnumerable<Employee> GetAll();
    LoginResponseViewModel Login(LoginViewModel loginVM);

}
