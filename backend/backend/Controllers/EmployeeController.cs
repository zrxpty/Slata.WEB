using backend.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Helpers;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<EmployeeController> _logger;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public EmployeeController(RoleManager<IdentityRole> roleManager, ILogger<EmployeeController> logger, UserManager<Employee> userManager,
            AppDbContext appDbContext)
        {
            _roleManager = roleManager;
            _userManager= userManager;
            _logger = logger;
            _db = appDbContext;
        }
        [HttpGet]
        public async Task<IResult> Index()
        {
            
            var employees = _db.Employees.Include(x => x.Position).Include(x => x.Role).ToList();
            
            return Results.Json(employees);
        }

        [HttpGet("getAllTeamLead")]
        public async Task<IResult> GetAllTeamLead()
        {
            var employees = _db.Employees
                .Include(x => x.Position)
                .Include(x => x.Role)
                .Where(x => x.Role.Name.ToLower() == "teamlead")
                .ToList();
            return Results.Json(employees);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string? id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            return Ok(new {Employee = employee});
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(employee.Employee.Id);
                var position = _db.Positions.Where(x => x.Id == Guid.Parse(employee.positionId)).FirstOrDefault();
                var role = _db.Roles.Where(x => x.Id == Guid.Parse(employee.roleId)).FirstOrDefault();
                user.Position = position;
                user.Role = role;
                user.Name = employee.Employee.Name;
                user.SurName = employee.Employee.SurName;
                user.LastName = employee.Employee.LastName;
                await _userManager.UpdateAsync(user);

                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetAllRoles")]
        public async Task<IResult> GetAllRoles()
        {
            var roles = await _db.Roles.ToArrayAsync();
            return Results.Ok(roles);
        }






    }
}
