using System.ComponentModel.DataAnnotations;

namespace VeterinariaMVC.Entidades.ViewModels.Producto
{
    public class ProductoListViewModel
    {
        public int ProductoId { get; set; }

        [Display(Name = "Tipo de Producto")]
        public string TipoDeProducto { get; set; }
        public string Modelo { get; set; }

        [Display(Name = "Precio de Venta")]
        public decimal PrecioVenta { get; set; }
        public string Imagen { get; set; }
    }
}
