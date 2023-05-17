using DAL.Models;
using Slata.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.Interfaces
{
    public interface IApplicantService
    {
        Task AddAsync(ApplicantDTO applicant);
        IEnumerable<object> GetAll();

        Task<Applicant> GetAsync(string id);

        Task Edit(ApplicantDTO applicant);
    }
}
