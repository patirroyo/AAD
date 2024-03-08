
using ExamenAlbertoSaz.Models;
using Microsoft.EntityFrameworkCore;
using static ExamenAlbertoSaz.Controllers.CompraController;

namespace MVC2024.Models
{
    public class Contexto : DbContext 
    {
        
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasNoKey(); 
        }
        public DbSet<ProductoModelo> Productos { get; set; }
        public DbSet<ClienteModelo> Clientes { get; set; }
        public DbSet<ProveedorModelo> Proveedores { get; set; }
        public DbSet<CompraModelo> Compras { get; set; }
        public DbSet<VentaModelo> Ventas { get; set; }
        public DbSet<Stock> Stock { get; set; }
    }
}