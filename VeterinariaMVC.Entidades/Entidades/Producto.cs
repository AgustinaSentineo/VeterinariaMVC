namespace VeterinariaMVC.Entidades.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int TipoDeProductoId { get; set; }
        public TipoDeProducto TipoDeProducto { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string  Imagen { get; set; }

    }
}
