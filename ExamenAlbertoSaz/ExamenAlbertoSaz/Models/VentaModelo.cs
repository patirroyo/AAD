namespace ExamenAlbertoSaz.Models
{
    public class VentaModelo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public ClienteModelo Cliente { get; set; }
        public int ProductoId { get; set; }
        public ProductoModelo Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Fecha { get; set; }
    }
}
