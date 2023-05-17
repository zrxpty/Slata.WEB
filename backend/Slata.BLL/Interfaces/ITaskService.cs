using DAL.Models;
using Slata.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<ICollection<MergedTaskApplicant>> GetAll();
        Task Confirmed(string id);

    }
}
