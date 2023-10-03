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
        public IWebHostEnvironment WebHostEnvironment { get; }//en el destornillador crear y asignar la propiedad

        public EditModel(IAlumnoRepositorio alumnoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.alumnoRepositorio = alumnoRepositorio;
            WebHostEnvironment = webHostEnvironment;
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
            if (Photo != null)
            {
                {
                    if(alumno.Foto != null)
                    {
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, "images", alumno.Foto);
                        System.IO.File.Delete(filePath);
                    }
                }
                alumno.Foto = ProcessUploadedFile();
            }
            alumnoRepositorio.Update(alumno);
            return RedirectToPage("Index");
        }

        private string ProcessUploadedFile()
        {
            //necesitamos un objeto de una clase que sea capaz de manipular el proyecto por lo que la creamos en el constructor
            string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");//lo primero nos devuelve el path a wwwroot
            string filePath = Path.Combine(uploadsFolder, Photo.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Photo.FileName;
        }
    }
}
