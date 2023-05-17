using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TaskApplicant
    {
        public Guid Id { get; set; }
        public string? ApplicantId { get; set; }
        public string? PositionId { get; set; }
        public bool? IsCompleted { get; set; } = false;
    }
}
