using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeAlimento
    {
        List<TipoDeAlimentoListDto> GetLista();

        TipoDeAlimentoEditDto GetTipoId(int? Id);

        void Guardar(TipoDeAlimento tipo);

        void Borrar(int? Id);

        bool Existe(TipoDeAlimento tipo);
    }
}
