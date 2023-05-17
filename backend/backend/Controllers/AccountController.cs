using backend.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace authentication.back.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger, UserManager<Employee> userManager, IConfiguration configuration)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager= userManager;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return Results.Json("Invalid model state");

            var user = new Employee
            {
                Email = model.login,
                UserName = model.login,
                Name = model.Name,
                SurName = model.SurName,
                LastName = model.LastName,
            };

            var result = await _userManager.CreateAsync(user, model.password);

            if (!result.Succeeded)
            {
                return Results.Json("Failed to create user");
            }

            return Results.Ok();
        }


        [HttpPost("login")]
        public async Task<IResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.login);
                var role = _db.Employees
                    .Where(x => x.Id == user.Id)
                    .Include(x => x.Role)
                    .Include(x => x.Position)
                    .FirstOrDefault();

                if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };

                    var jwt = new JwtSecurityToken(
                        issuer: _configuration["AuthSettings:ISSUER"],
                        audience: _configuration["AuthSettings:AUDIENCE"],
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:KEY"])), SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                    string position = role?.Position?.Name;

                    var response = new
                    {
                        access_token = encodedJwt,
                        crntUser = role,
                        position = position
                    };
                    return Results.Json(response);
                }
            }

            return (IResult)BadRequest("Login Error");
        }

    }
}