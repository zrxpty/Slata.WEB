using DAL.Models;

namespace backend.Models
{
    public class EmployeeVM
    {
        public Employee? Employee { get; set; }
        public string? positionId { get; set; }
        public string? roleId { get; set; }
        
    }
}
