using System;
using Microsoft.Data.SqlClient;
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
        public IEnumerable<Equipo> GetAllEquipos()
        {
            return context.Equipos.FromSqlRaw<Equipo>("SELECT * FROM Equipos").ToList();
        }
        public Equipo GetEquipoById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);

            return context.Equipos.Find(id);
        }
        public void Add(Equipo equipoNuevo)
        {
            equipoNuevo.Id = context.Equipos.Max(a => a.Id) + 1;
            context.Equipos.Add(equipoNuevo);
            context.SaveChanges();

            return;
        }

        public Equipo Delete(int idBorrar)
        {
            Equipo equipoBorrar = context.Equipos.Find(idBorrar);
            if (equipoBorrar != null)
            {
                context.Equipos.Remove(equipoBorrar);
                context.SaveChanges();
            }
            return equipoBorrar;
        }

        public void Update(Equipo equipoActualizado)
        {
            var equipo = context.Equipos.Attach(equipoActualizado);
            equipo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//en lugar de guardar cambios
            context.SaveChanges();
        }
    }
}

