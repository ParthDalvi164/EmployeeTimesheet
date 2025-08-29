using EmployeeTimesheet.Models;

namespace EmployeeTimesheet.Repositories;

public interface IEmployeeRepository
{
    Employee Add(Employee employee);
    Employee Update(Employee employee);
    void Delete(int id);
    Employee GetById(int id);
    IEnumerable<Employee> GetAll();
    LoginResponseViewModel Login(LoginViewModel loginVM);
}
