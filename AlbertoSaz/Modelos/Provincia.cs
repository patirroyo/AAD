using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Provincia
    {
        [Key]
        public int codProvincia { get; set; }
        public string nomProvincia { get; set; }
        public int superficie { get; set; }
        public int numHabitantes { get; set; }
        public Comunidad codComunidad { get; set; }
    }
}