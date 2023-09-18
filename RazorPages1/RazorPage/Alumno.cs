using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPage.Modelos
{
    internal class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public Curso? CursoId { get; set; } // a ese campo le puedes o no asignar un valor por el ? es decir, permite el null.
    }
}
