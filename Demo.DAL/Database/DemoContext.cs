using Demo.DAL.Entity;
using Demo.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Database
{
    public class DemoContext : IdentityDbContext<ApplicationUser>
    {
        //using constractor replacement for oncofiguring
        public DemoContext(DbContextOptions<DemoContext> opt):base(opt)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Country> Country { get; set; }


        public DbSet<City> City { get; set; }


        public DbSet<District> District { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=DemoDb;Integrated Security=true");
        //}
    }
}
