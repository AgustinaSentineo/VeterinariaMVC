using System.Collections.Generic;
using VeterinariaMVC.Entidades.ViewModels.TipoDeProducto;

namespace VeterinariaMVC.Entidades.ViewModels.Producto
{
    public class ProductoFilterViewModel
    {
        public List<ProductoListViewModel> Productos { get; set; }
        public List<TipoDeProductoListViewModel> TipoProducto { get; set; }
    }
}
