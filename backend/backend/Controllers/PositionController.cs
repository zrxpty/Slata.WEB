using AutoMapper;
using backend.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Slata.BLL.DTO;
using Slata.BLL.Interfaces;
using System.Diagnostics;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly ILogger<PositionController> _logger;
        private IMapper _mapper;
        public PositionController(IMapper mapper, ILogger<PositionController> logger, IPositionService positionService)
        {
            _mapper = mapper;
            _logger = logger;
            _positionService = positionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var positions = _positionService.GetAll();
            return Ok(positions);
        }
        [HttpPost("AddPosition")]
        public async Task<IActionResult> Add(PositionVM position)
        {
            if (position.Id == default)
            {
                position.Id = Guid.NewGuid();
            }
            await _positionService.AddAsync(_mapper.Map<PositionDTO>(position));
            return Ok();
        }
        
    }
}
