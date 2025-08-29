using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeTimesheet.Models;
using EmployeeTimesheet.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeTimesheet.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IConfiguration _configuration;
    public EmployeeService(IEmployeeRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }
    Employee IEmployeeService.Add(Employee employee)
    {
        return _repository.Add(employee);
    }

    void IEmployeeService.Delete(int id)
    {
        _repository.Delete(id);
    }

    IEnumerable<Employee> IEmployeeService.GetAll()
    {
        return _repository.GetAll();
    }

    Employee IEmployeeService.GetById(int id)
    {
        return _repository.GetById(id);
    }

    Employee IEmployeeService.Update(Employee employee)
    {
        return _repository.Update(employee);
    }

    LoginResponseViewModel IEmployeeService.Login(LoginViewModel loginVM)
    {
        var response = _repository.Login(loginVM);

        if (response.IsSuccess)
        {
            response.Token = GenerateToken(response.Employee);
        }
        return response;
    }

    string GenerateToken(Employee employee)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes(_configuration["AuthVariables:SecretKey"]));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Name, employee.Email),
                new Claim(ClaimTypes.Role, employee.UserRole.Role.ToString()),
            };

        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration["AuthVariables:Issuer"],
            audience: _configuration["AuthVariables:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: signingCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }  
}
