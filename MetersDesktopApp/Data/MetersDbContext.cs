using MetersDesktopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersDesktopApp
{
    public class MetersDbContext : DbContext
    {
        public DbSet<Meter> Meters { get; set; }

        public MetersDbContext() : base() { }

        public MetersDbContext(DbContextOptions<MetersDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; User Id=admin; Password=1234; Database=Landis;");
        }

    }
}
