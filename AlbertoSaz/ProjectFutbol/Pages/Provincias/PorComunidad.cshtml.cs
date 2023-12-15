using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace AlbertoSaz.Pages.Provincias
{
	public class PorComunidad : PageModel
    {
        private readonly IProvinciaRepositorio provinciaRepositorio;
        
        public IEnumerable<Provincia> Provincias;

        public Comunidad comunidad;

        [BindProperty(SupportsGet = true)]
        public Comunidad elementoABuscar { get; set; }
       
        public PorComunidad(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;
            
        }

        public void OnGet()
        {
            Provincias = provinciaRepositorio.FindProvinciasByComunidad(elementoABuscar);
        }

        
    }
}
