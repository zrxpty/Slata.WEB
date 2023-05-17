using DAL.Models;
using Slata.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.Interfaces
{
    public interface IPositionService
    {
        Task<PositionDTO> AddAsync(PositionDTO position);
        Task<PositionDTO> GetAsync(string id);
        ICollection<PositionDTO> GetAll();
    }
}
