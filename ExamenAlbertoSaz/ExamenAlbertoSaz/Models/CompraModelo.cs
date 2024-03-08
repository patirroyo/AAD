namespace ExamenAlbertoSaz.Models
{
    public class CompraModelo
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public ProductoModelo Producto { get; set; }
        public int ProveedorId { get; set; }
        public ProveedorModelo Proveedor { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Fecha { get; set; }
    }
}
