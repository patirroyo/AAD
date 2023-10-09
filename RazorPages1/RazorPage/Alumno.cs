using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Modelos
{

    public class Alumno //internal es un modificador que equivale al modificador private de Java, por lo que lo cambiamos a public
    {
        public int Id { get; set; }

        [Required]//Esto es para que el nombre sea obligatorio
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }
        public string Foto { get; set; }
        public Curso? CursoId { get; set; } // a ese campo le puedes o no asignar un valor por el ? es decir, permite el null.
    }
}
