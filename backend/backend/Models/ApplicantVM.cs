using DAL.Models;

namespace backend.Models
{
    public class ApplicantVM
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
