using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class GeografiaDbContext : DbContext
    {
        public DbSet<Provincia> Provincias{ get; set; }

        //instancia por inyección de dependencias gracias a esto
        public GeografiaDbContext(DbContextOptions<GeografiaDbContext> options) : base(options)
        {
        }
    }

}

