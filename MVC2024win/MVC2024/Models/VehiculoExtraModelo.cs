namespace MVC2024.Models
{
    public class VehiculoExtraModelo
    {//clase que relaciona la tabla vehiculo con la tabla extra (relación muchos a muchos)
        public int ID { get; set; }
        public int extraID { get; set; }
        public ExtraModelo extra { get; set; }
        public int vehiculoId { get; set; }
        public VehiculoModelo vehiculo { get; set; }
        //Añadimos una lista de extras para poder mostrarlos en la vista
       
    }
}
