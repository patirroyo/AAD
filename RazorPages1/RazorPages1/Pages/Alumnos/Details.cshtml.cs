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
	public class DetailsModel : PageModel
    {
        public Alumno alumno { get; set; }

        public DetailsModel(AlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }

        public void OnGet(int id)
        {
            alumno = 
            
            
        }
    }
}
