using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Localidad;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioLocalidad
    {
        List<LocalidadListDto> GetLista(string provincia);
        LocalidadEditDto GetLocalidadPorId(int? id);
        bool Existe(LocalidadEditDto localidadDto);
        void Guardar(LocalidadEditDto localidadDto);
        void Borrar(int vmLocalidadId);
    }
}
