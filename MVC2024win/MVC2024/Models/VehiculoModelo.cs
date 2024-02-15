using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2024.Models
{
    public class VehiculoModelo
    {
        public int Id { get; set; }
        public String Matricula { get; set; }
        public String Color { get; set; }
        public int SerieId {get; set;}
        public int SucursalId { get; set; }
        public SerieModelo Serie { get; set; }
        public SucursalModelo Sucursal { get; set; }
        //lo que ponemos a continuación no lo mapees, no lo metas en la tabla (porque no se puede mapear una lista de enteros)
        [NotMapped]
        public List<int> ExtrasSeleccionados { get; set; }
        public List<VehiculoExtraModelo> VehiculoExtra { get; set; }
    }
}
