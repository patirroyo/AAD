using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC2024.Models
{
    public class Contexto : DbContext
    {
        public DbSet<MarcaModelo> Marcas { get; set; } //esta será la tabla de marcas, creará la tabla automáticamente con la estrucutura de MarcaModelo
        public Contexto(DbContextOptions<Contexto> options) : base(options)//de esta manera por inyección de dependencias te crea la base de datos si no existe
        {

        }
    }
}

