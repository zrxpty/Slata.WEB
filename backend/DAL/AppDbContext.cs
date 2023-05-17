using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<TaskApplicant> Tasks { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Position>().HasData(
                new Position[]
                {
                    new Position {Id = Guid.NewGuid(), Name="Senior C#"},
                    new Position {Id = Guid.NewGuid(), Name="Middle C#"},
                    new Position {Id = Guid.NewGuid(), Name="fullstack developer"},
                }
            );

            builder.Entity<Role>().HasData(

                new Role[]
                {
                    new Role { Id = Guid.NewGuid(), Name="admin"},
                    new Role { Id = Guid.NewGuid(), Name="teamlead"},
                    new Role { Id = Guid.NewGuid(), Name="hr"}
                });
        }


    }
}