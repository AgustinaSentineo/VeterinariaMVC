using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeTarea
    {
        List<TipoDeTareaListDto> GetLista();

        TipoDeTareaEditDto GetTipoDeTareaId(int? Id);

        void Guardar(TipoDeTarea tipoDeTarea);

        void Borrar(int? Id);

        bool Existe(TipoDeTarea tipoDeTarea);
    }
}
