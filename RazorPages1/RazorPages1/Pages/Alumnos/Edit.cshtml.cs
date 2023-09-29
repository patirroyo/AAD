using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Service;

namespace RazorPages1.Pages.Alumnos
{
    public class EditModel : PageModel
    {

        //declaramos un atributo de clase de la clase IAlumnoRepositorio para poder llamar al método GetAlumnoById
        private readonly IAlumnoRepositorio alumnoRepositorio;

        public Alumno alumno { get; set; }

        //el atributo Photo de la clase IFormFile que es diferente del atributo Foto de la clase Alumno
        public IFormFile Photo { get; set; }

        public EditModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
        //se ejecuta siempre al cargar la página con el get
        public void OnGet(int id)
        {
            alumno = alumnoRepositorio.GetAlumnoById(id);
        }
        //cuando demos al botón de submit se ejecutará éste metodo
        //en vez de void, va a devolver una acción
        public IActionResult OnPost(Alumno alumno)
        {
            alumnoRepositorio.Update(alumno);
            return RedirectToPage("Index");
        }
    }
}
