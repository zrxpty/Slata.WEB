using AutoMapper;
using DAL.Interface;
using DAL.Models;
using Slata.BLL.DTO;
using Slata.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.Services
{
    public class TaskService : ITaskService
    {
        private IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public TaskService(IMapper mapper, IUnitOfWork uow)
        {
            _uow= uow;
            _mapper= mapper;
        }

        public async Task<ICollection<MergedTaskApplicant>> GetAll()
        {
            var taskApplicants = _uow.GetRepository<TaskApplicant>().GetAll().ToList();
            var positions = _uow.GetRepository<Position>().GetAll().ToList();
            var applicants = _uow.GetRepository<Applicant>().GetAll().ToList();

            var mergedTaskApplicants = taskApplicants.Select(taskApplicant =>
            {
                var position = positions.SingleOrDefault(p => p.Id == Guid.Parse(taskApplicant.PositionId));
                var applicant = applicants.SingleOrDefault(a => a.Id.ToString() == taskApplicant.ApplicantId);

                return new MergedTaskApplicant
                {
                    Id = taskApplicant.Id,
                    ApplicantId = taskApplicant.ApplicantId,
                    PositionId = taskApplicant.PositionId,
                    IsCompleted = taskApplicant.IsCompleted,
                    Applicant = applicant,
                    Position = position
                };
            }).ToList();

            return mergedTaskApplicants;
        }

        public async Task Confirmed(string id)
        {
            var taskApplicant = await _uow.GetRepository<TaskApplicant>().GetAsync(x => x.Id.ToString() == id);
            if ((bool)!taskApplicant.IsCompleted || taskApplicant.IsCompleted == null)
                taskApplicant.IsCompleted = true;
            else
                taskApplicant.IsCompleted = false;

            if (taskApplicant != null)
            {
                await _uow.GetRepository<TaskApplicant>().UpdateAsync(taskApplicant);
            }

            await _uow.SaveChangesAsync();

        }
    }
}
