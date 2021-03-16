using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioNecesidadEspecial
    {
        List<NecesidadEspecialListDto> GetLista();

        NecesidadEspecialEditDto GetNecesidadEspecialId(int? Id);

        void Guardar(NecesidadEspecialEditDto necesidadEspecial);

        void Borrar(int? Id);

        bool Existe(NecesidadEspecialEditDto necesidadEspecial);
    }
}
