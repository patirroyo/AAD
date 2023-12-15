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
	public class IndexModel : PageModel
    {
        private readonly IProvinciaRepositorio provinciaRepositorio;
        
        public IEnumerable<Provincia> Provincias;
       
        public string elementoABuscar { get; set; }

        public IndexModel(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;
            
        }

        public void OnGet(string elementoABuscar = "")
        {
            Provincias = provinciaRepositorio.GetAllProvincias();
        }


    }
}
