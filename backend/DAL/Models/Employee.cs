using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee: IdentityUser
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? LastName { get; set; }
        public Position? Position { get; set; }  
        public Role? Role { get; set; }  
    }
}
