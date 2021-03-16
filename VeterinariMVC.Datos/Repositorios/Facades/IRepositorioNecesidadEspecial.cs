using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioNecesidadEspecial
    {
        List<NecesidadEspecialListDto> GetLista();

        NecesidadEspecialEditDto GetNecesidadEspecialId(int? Id);

        void Guardar(NecesidadesEspeciales necesidadesEspeciales);

        void Borrar(int? Id);

        bool Existe(NecesidadesEspeciales necesidadesEspeciales);
    }
}
