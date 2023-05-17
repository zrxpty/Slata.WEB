using AutoMapper;
using backend.Models;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slata.BLL.DTO;
using Slata.BLL.Interfaces;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        
        private readonly ILogger<ApplicantController> _logger;
        private IApplicantService _serviceApplicant;
        private IPositionService _positionService;
        private IMapper _mapper;

        public ApplicantController(IPositionService positionService, IMapper mapper, IApplicantService applicantService, ILogger<ApplicantController> logger)
        {
            _mapper = mapper;
            _serviceApplicant = applicantService;
            _logger = logger;
            _positionService = positionService;
        }


        [HttpPost("AddApplicant")]
        public async Task<IActionResult> Add(ApplicantVM applicant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _serviceApplicant.AddAsync(_mapper.Map<ApplicantDTO>(applicant));
            
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applicants  = _serviceApplicant.GetAll();
            return Ok(applicants);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Get(string? id)
        {
            var applicant = await _serviceApplicant.GetAsync(id);
            return Ok(applicant);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(ApplicantVM applicant)
        {
            await _serviceApplicant.Edit(_mapper.Map<ApplicantDTO>(applicant));
            return Ok();
        }
    }
}
