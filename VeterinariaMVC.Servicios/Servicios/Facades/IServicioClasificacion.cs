using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioClasificacion
    {
        List<ClasificacionListDto> GetLista();

        ClasificacionEditDto GetClasificacionId(int? Id);

        void Guardar(ClasificacionEditDto clasificacion);

        void Borrar(int? Id);

        bool Existe(ClasificacionEditDto clasificacion);
    }
}
