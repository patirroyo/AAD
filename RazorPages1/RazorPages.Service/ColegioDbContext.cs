using System;
using Microsoft.EntityFrameworkCore;
using RazorPages.Modelos;

namespace RazorPages.Service
{
	internal class ColegioDbContext : DbContext
	{
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options) : base(options)
        {
            //no tenemos que hacer nada más, se instancia el objeto
        }
        public DbSet<Alumno> Alumnos { get; set; } //DbSet es un objeto equivalente a  tablas

    }
}

