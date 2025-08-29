using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EmployeeTimesheet.Models;

namespace SmartLibraryAPI.Models
{
    public enum Role { ADMIN, USER }
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Role is required!")]
        public Role Role { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
