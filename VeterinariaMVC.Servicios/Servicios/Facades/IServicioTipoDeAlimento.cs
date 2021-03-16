using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeAlimento
    {
        List<TipoDeAlimentoListDto> GetLista();

        TipoDeAlimentoEditDto GetTipoDeAlimentoId(int? Id);

        void Guardar(TipoDeAlimentoEditDto tipo);

        void Borrar(int? Id);

        bool Existe(TipoDeAlimentoEditDto tipo);
    }
}
