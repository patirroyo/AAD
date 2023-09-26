﻿using RazorPages.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Service
{
    public class AlumnoRepositorio : IAlumnoRepositorio //los : sirven para el extends y el implements de Java
        //luego le damos a la ayuda y le damos a implementar interfaz
    {
        public List<Alumno> ListaAlumnos; //creamos el objeto ListaAlumos de la clase List, que será un atributo de la clase

        public AlumnoRepositorio() //ctor nos crea el método constructor
        {
            //vamos a cargar los datos en la lista
            //instanciamos la lista y la cargamos
            ListaAlumnos = new List<Alumno>()
            { //cargamos la lista
                new Alumno()
                {
                    Id=1,
                    Nombre="Alberto Saz",
                    Email="saz@zaragoza.salesianos.edu",
                    Foto="Alberto.jpg",
                    CursoId = Curso.H2
                },
                new Alumno()
                {
                    Id=2,
                    Nombre="Jesús Montero",
                    Email="montero@zaragoza.salesianos.edu",
                    Foto="Jesus.jpg",
                    CursoId = Curso.H2
                },
                new Alumno()
                {
                    Id=3,
                    Nombre="Ismael Bernad",
                    Email="bernad@zaragoza.salesianos.edu",
                    Foto="Ismael2.jpg",
                    CursoId = Curso.H1
                },
                new Alumno()
                {
                    Id=4,
                    Nombre="Ismael Abed",
                    Email="abed@zaragoza.salesianos.edu",
                    Foto="Isma1.jpg",
                    CursoId = Curso.H1
                }
            };
        }
        public IEnumerable<Alumno> GetAllAlumnos()
        {
            return ListaAlumnos; //este método sólo devuelve la lista
            /*a un IEnumerable le está pasando un List y lo acepta porque
             prácticamente es lo mismo
             */
        }
        public Alumno GetAlumnoById(int id)
        {
            /*a es el operador lambda, es una especie de alias para manipular el 
             * objeto a través del cual has llamado a la función. 
             * en este caso ListaAlumnos
             * FirstOrDefault busca la primera ocurrencia
             * Esta forma de trabajar se llama modo predicado*/
            return ListaAlumnos.FirstOrDefault(a => a.Id.Equals(id));
        }
        public Alumno Update(Alumno alumnoActualizado)
        {
            return ListaAlumnos.FirstOrDefault(a => a.Id.Equals(alumnoActualizado.Id));
        }
    }
}
