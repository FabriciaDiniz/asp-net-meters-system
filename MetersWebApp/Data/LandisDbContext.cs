using Microsoft.EntityFrameworkCore;
using LandisWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandisWebApp.Data
{
    public class LandisDbContext : DbContext
    {
        public DbSet<Meter> Meters { get; set; }

        public LandisDbContext(DbContextOptions<LandisDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
