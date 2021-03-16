using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioLocalidad
    {
        List<LocalidadListDto> GetLista(string provincia);
        LocalidadEditDto GetLocalidadPorId(int? id);
        bool Existe(Localidad localidad);
        void Guardar(Localidad localidad);        
        void Borrar(int vmLocalidadId);
    }
}
