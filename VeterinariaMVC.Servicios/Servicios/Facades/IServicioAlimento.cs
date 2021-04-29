using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Alimento;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioAlimento
    {
        List<AlimentoListDto> GetLista();
        bool Existe(AlimentoEditDto alimentoEditDto);
        void Guardar(AlimentoEditDto alimentoDto);
        AlimentoEditDto GetAlimentoPorId(int? id);
        void Borrar(int VmAlimentoId);
    }
}
