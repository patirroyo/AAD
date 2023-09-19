using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Service;
using System.Runtime.CompilerServices;

namespace RazorPages1.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        //declaramos un atributo de clase de la clase IAlumnoRepositorio para poder llamar al m�todo GetAllAlumnos
        private readonly IAlumnoRepositorio alumnoRepositorio;
        //para que salga IAlumnoRepositorio a�ado la dependencia del .Service 
        // y uso este objeto para llamar al m�todo GetAllAlumnos()
        public IEnumerable<Alumno> Alumnos;
        //cuando llamemos al GetAllAlumnos nos devolver� una lista de objetos de la clase Alumno, por lo que creamos 
        //un objeto de esa clase para poder llamarlo.

        public IndexModel(IAlumnoRepositorio alumnoRepositorio) 
        {
            this.alumnoRepositorio = alumnoRepositorio;
            /*esto es inyecci�n de dependencias:
            * que sin llamar explicitamente a los m�todos constructores
            * se creen */
        }
        public void OnGet()
        {
            Alumnos = alumnoRepositorio.GetAllAlumnos();
        }
    }
}
