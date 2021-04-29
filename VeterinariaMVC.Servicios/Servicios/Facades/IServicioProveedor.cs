using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Proveedor;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioProveedor
    {
        List<ProveedorListDto> GetLista();
        ProveedorEditDto GetProveedorPorId(int? id);
        bool Existe(ProveedorEditDto proveedorDto);
        void Guardar(ProveedorEditDto proveedorDto);
        void Borrar(int vmProveedorId);
    }
}
