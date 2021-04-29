using System;

namespace VeterinariaMVC.Entidades.DTOs.Producto
{
    public class ProductoListDto : ICloneable
    {
        public int ProductoId { get; set; }
        public string TipoDeProducto { get; set; }
        public string Modelo { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Imagen { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
