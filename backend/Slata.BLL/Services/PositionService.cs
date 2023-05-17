using AutoMapper;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Slata.BLL.DTO;
using Slata.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.Services
{
    

    public class PositionService : IPositionService
    {
        private IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public PositionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PositionDTO> AddAsync(PositionDTO item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Position position = _mapper.Map<Position>(item);

            await _uow.GetRepository<Position>().CreateAsync(position);
            await _uow.SaveChangesAsync();

            return item;
        }

        public async Task<PositionDTO> GetAsync(string id)
        {
            return  _mapper.Map<PositionDTO>(_uow.GetRepository<Position>().GetAll().Where(x => x.Id.ToString() == id).SingleOrDefault());
        }

        public ICollection<PositionDTO> GetAll()
        {
            return _mapper.Map<ICollection<PositionDTO>>(_uow.GetRepository<Position>().GetAll());
        }
    }
}
