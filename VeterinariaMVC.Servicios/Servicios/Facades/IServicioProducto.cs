using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Producto;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioProducto
    {
        List<ProductoListDto> GetLista(string tipo);
        bool Existe(ProductoEditDto productoEditDto);
        void Guardar(ProductoEditDto productoDto);
        ProductoEditDto GetProductoPorId(int? id);
        void Borrar(int tipoVmProductoId);
    }
}
