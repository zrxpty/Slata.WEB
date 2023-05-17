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
using System.Text;
using System.Threading.Tasks;

namespace Slata.BLL.Services
{
    public class ApplicantService : IApplicantService
    {
        private IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public ApplicantService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(ApplicantDTO applicant)
        {
            
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            

            var newApplicant = new Applicant();
            newApplicant.Id = Guid.NewGuid();
            newApplicant.Name = applicant.Name;
            newApplicant.SurName = applicant.surName;
            newApplicant.LastName = applicant.lastName;
            newApplicant.PhoneNumber = applicant.phoneNumber;
            newApplicant.PositionId = Guid.Parse(applicant.positionId);
            newApplicant.HrId = Guid.Parse(applicant.hr);
            newApplicant.Interview = applicant.Interview;
            newApplicant.DeadLine = applicant.DeadLine;

            TaskApplicant taskApplicant = new TaskApplicant();
            taskApplicant.Id = Guid.NewGuid();
            taskApplicant.ApplicantId = newApplicant.Id.ToString();
            taskApplicant.PositionId = newApplicant.PositionId.ToString();
            taskApplicant.IsCompleted = false;

            await _uow.GetRepository<Applicant>().CreateAsync(newApplicant);
            await _uow.GetRepository<TaskApplicant>().CreateAsync(taskApplicant);
            await _uow.SaveChangesAsync();
            
        }

        public IEnumerable<object> GetAll()
        {
            var applicants = _uow.GetRepository<Applicant>().GetAll();
            var positions = _uow.GetRepository<Position>().GetAll();

            var mergedApplicants = applicants.Join(positions,
                a => a.PositionId,
                p => p.Id,
                (a, p) => new {
                    id = a.Id,
                Name = a.Name,
                Surname = a.SurName,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                Position = p.Name,
                hr = a.HrId,
                Interview = a.Interview,
                DeadLine = a.DeadLine
                });

            return mergedApplicants;
        }

        public async Task<Applicant> GetAsync(string id)
        {
            var applicant = await _uow.GetRepository<Applicant>().GetAll().Where(x => x.Id.ToString() == id).FirstOrDefaultAsync();
            return applicant;
        }

        public async Task Edit(ApplicantDTO applicant)
        {
            if (applicant == null)
                throw new ArgumentNullException(nameof(applicant));

            var applicantOld = await _uow.GetRepository<Applicant>().GetAsync(x => x.Id.ToString() == applicant.id);

            if (applicantOld == null)
                throw new Exception("Applicant not found");

            var hrId = applicantOld.HrId;
            var positionId = Guid.Parse(applicant.positionId);

            applicantOld.Name = applicant.Name;
            applicantOld.SurName = applicant.surName;
            applicantOld.LastName = applicant.lastName;
            applicantOld.PhoneNumber = applicant.phoneNumber;
            applicantOld.PositionId = positionId;
            applicantOld.DeadLine = applicant.DeadLine;
            applicantOld.Interview = applicant.Interview;

            await _uow.GetRepository<Applicant>().UpdateAsync(applicantOld);

            var taskApplicant = await _uow.GetRepository<TaskApplicant>().GetAsync(x => x.ApplicantId == applicantOld.Id.ToString());
            if (taskApplicant != null)
            {
                taskApplicant.PositionId = applicant.positionId;
                await _uow.GetRepository<TaskApplicant>().UpdateAsync(taskApplicant);
            }

            await _uow.SaveChangesAsync();
        }

    }
}
