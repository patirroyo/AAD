using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPages.Modelos;

namespace RazorPages.Service
{
	public class AlumnoRepositorioBD : IAlumnoRepositorio 
	{
        private readonly ColegioDbContext context;


        public AlumnoRepositorioBD(ColegioDbContext context)
		{
            this.context = context;
        }

        public IEnumerable<Alumno> GetAllAlumnos()
        {
            //return context.Alumnos; //este método sólo devuelve la lista
            return context.Alumnos.FromSqlRaw<Alumno>("SELECT * FROM Alumnos").ToList();
        }
        public Alumno GetAlumnoById(int id)
        {
            //return context.Alumnos.Find(id);
            SqlParameter parameter = new SqlParameter("@Id", id);

            return context.Alumnos.FromSqlRaw<Alumno>("GetAlumnoById @Id", parameter)
                .ToList().
                FirstOrDefault();

            /*return context.Alumnos.FromSqlRaw<Alumno>("GetAlumnoById {0}", id)
                .ToList().
                FirstOrDefault();*/
        }
        public void Update(Alumno alumnoActualizado)
        {
            var alumno = context.Alumnos.Attach(alumnoActualizado);
            alumno.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//en lugar de guardar cambios
            context.SaveChanges();

        }
        public void Add(Alumno alumnoNuevo)
        {
            //alumnoNuevo.Id = context.Alumnos.Max(a => a.Id) + 1; es autoincrementativo ya no hace falta
            //context.Alumnos.Add(alumnoNuevo);
            //context.SaveChanges();
            
            context.Database.ExecuteSqlRaw("insertarAlumno {0}, {1}, {2}, {3}",
                alumnoNuevo.Nombre,
                alumnoNuevo.Email,
                alumnoNuevo.Foto,
                alumnoNuevo.CursoId);

            return ;
        }
        public Alumno Delete(int idBorrar)
        {
            Alumno alumnoBorrar = context.Alumnos.Find(idBorrar);
            if (alumnoBorrar != null) { 
                context.Alumnos.Remove(alumnoBorrar);
                context.SaveChanges();
            }

            return alumnoBorrar;
        }

        public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
        {
            IEnumerable<Alumno> consulta = context.Alumnos;
            if (curso.HasValue)
            {
                consulta = consulta.Where(a => a.CursoId == curso).ToList();
            }
            
            return consulta.GroupBy(a => a.CursoId)
                .Select(g => new CursoCuantos()//g es por el aGrupamiento
                {
                    Clase = g.Key.Value,
                    NumAlumnos = g.Count()
                }).ToList();//el resultado lo convertimos en lista

        }

        public IEnumerable<Alumno> FindAlumnos(string elementoABuscar)
        {
            if (string.IsNullOrEmpty(elementoABuscar))
            {
                return context.Alumnos;
            }
            else
            {
                return context.Alumnos.Where(a => a.Nombre.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));
            }
        }
        public IEnumerable<Alumno> FindAlumnosByCurso(Curso elementoABuscar)
        {
            if (elementoABuscar == null)
            {
                return context.Alumnos;
            }
            else
            {
                return context.Alumnos.Where(a => a.CursoId.Equals(elementoABuscar));
            }

        }
    }
}
