using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Applicant
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? HrId { get; set; }
        public Guid? PositionId { get; set; }
        public DateTime? Interview { get; set; }
        public DateTime? DeadLine { get; set; }
        

    }
}
