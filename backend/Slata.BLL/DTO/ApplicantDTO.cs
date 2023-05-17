using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.DTO
{
    public class ApplicantDTO
    {
        public string? id { get; set; }
        public string? hr { get; set; }
        public string? Name { get; set; }
        public string? surName { get; set; }
        public string? lastName { get; set; }
        public string? phoneNumber { get; set; }
        public string? positionId { get; set; }
        public string? teamLeadId { get; set; }
        public DateTime? Interview { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
