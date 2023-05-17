using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Slata.BLL.Interfaces;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;
        private IMapper _mapper;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger, IMapper mapper)
        {
            _taskService = taskService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = _taskService.GetAll().Result;
            return Ok(tasks);
        }
        [HttpGet("IsComplited/{id}")]
        public async Task<IActionResult> ConfirmTask(string? id)
        {
            await _taskService.Confirmed(id);
            return Ok();
        }

        
    }
}
