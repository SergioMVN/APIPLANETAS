using APIPLANETAS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIPLANETAS
{
    public class ApplicationDbContext
    {
        public class PlanetContext : DbContext
        {
            public PlanetContext(DbContextOptions<PlanetContext> options) : base(options) { }

            public DbSet<Planets> Planets { get; set; }
        }
    }
}
