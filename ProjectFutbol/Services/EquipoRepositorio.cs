using System;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class EquipoRepositorio : IEquipoRepositorio
	{
        private readonly FutbolDbContext context;
		public EquipoRepositorio(FutbolDbContext context)
        { 
            this.context = context;
		
		}

        public void Add(Equipo equipoNuevo)
        {
            throw new NotImplementedException();
        }

        public Equipo Delete(int idBorrar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> GetAllEquipos()
        {
            return context.Equipos.FromSqlRaw<Equipo>("SELECT * FROM Equipos").ToList();
        }

        public Equipo GetEquipoById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo equipoActualizado)
        {
            throw new NotImplementedException();
        }
    }
}

