using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Producto;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProducto
    {
        List<ProductoListDto> GetLista(string tipo);
        bool Existe(Producto producto);
        void Guardar(Producto producto);
        ProductoEditDto GetProductoPorId(int? id);
        void Borrar(int tipoVmProductoId);
    }
}
