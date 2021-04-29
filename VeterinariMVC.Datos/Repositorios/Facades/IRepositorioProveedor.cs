using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProveedor
    {
        List<ProveedorListDto> GetLista();
        ProveedorEditDto GetProveedorPorId(int? id);
        bool Existe(Proveedor proveedor);
        void Guardar(Proveedor proveerdor);
        void Borrar(int vmProveedorId);
    }
}
