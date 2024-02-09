namespace MVC2024.Models
{
    public class SucursalModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public List<VehiculoModelo> Vehiculos { get; set; }
    }
}
