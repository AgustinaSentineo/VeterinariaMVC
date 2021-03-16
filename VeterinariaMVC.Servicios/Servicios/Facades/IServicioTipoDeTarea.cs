using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeTarea
    {
        List<TipoDeTareaListDto> GetLista();

        TipoDeTareaEditDto GetTipoDeTareaId(int? Id);

        void Guardar(TipoDeTareaEditDto tipoDeTareaEditDto);

        void Borrar(int? Id);

        bool Existe(TipoDeTareaEditDto tipoDeTareaEditDto);
    }
}
