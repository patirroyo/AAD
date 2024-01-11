using Microsoft.EntityFrameworkCore;

namespace MVC2024.Models
{
    public class Contexto : DbContext //Extiende de la clase Db Context
    {
        //Esta clase se encarga de la conexion con la base de datos
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            //no tenemos que hacer nada más, se instancia el objeto
        }

        //Aqui se declaran las tablas de la base de datos
        //En este caso la tabla sería marcas que son un conjunto de objetos de la clase marcaModelo
        public DbSet<MarcaModelo> Marcas { get; set; }
        //DbSet es un objeto equivalente a un ienumerable
        //y se usa para tratar tablas como listas y a sus elementos como items
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set;}
    }
}