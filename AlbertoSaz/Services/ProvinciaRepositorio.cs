using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class ProvinciaRepositorio : IProvinciaRepositorio
    {
        private readonly GeografiaDbContext context;

        public ProvinciaRepositorio(GeografiaDbContext context)
        {
            this.context = context;

        }
        public IEnumerable<Provincia> GetAllProvincias()
        {
            return context.Provincias.FromSqlRaw<Provincia>("SELECT * FROM Provincias").ToList();
        }
        public Provincia GetProvinciaById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);

            return context.Provincias.Find(id);
        }


        public IEnumerable<ComunidadCuantos> ProvinciasPorComunidad(Comunidad? comunidad)
        {
            IEnumerable<Provincia> consulta = context.Provincias;
            if (comunidad.HasValue)
            {
                consulta = consulta.Where(p => p.codComunidad == comunidad).ToList();
            }

            return consulta.GroupBy(e => e.codComunidad)
                .Select(g => new ComunidadCuantos()//g es por el aGrupamiento
                {
                    Comunidad = g.Key,
                    SuperficieTotal = g.Sum(s => s.superficie),
                    NumeroHabitantes = g.Sum(s => s.numHabitantes),
                    NumeroProvincias = g.Count()
                }).ToList();//el resultado lo convertimos en lista

        }
        public IEnumerable<Provincia> FindProvinciasByComunidad(Comunidad elementoABuscar)
        {
            if (elementoABuscar == null)
            {
                return context.Provincias;
            }
            else
            {
                return context.Provincias.Where(p => p.codComunidad.Equals(elementoABuscar));
            }

        }
    }
}

