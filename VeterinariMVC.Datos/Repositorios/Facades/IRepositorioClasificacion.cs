using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioClasificacion
    {
        List<ClasificacionListDto> GetLista();

        ClasificacionEditDto GetClasificacionId(int? Id);

        void Guardar(Clasificacion clasificacion);

        void Borrar(int? Id);

        bool Existe(Clasificacion clasificacion);
    }
}
