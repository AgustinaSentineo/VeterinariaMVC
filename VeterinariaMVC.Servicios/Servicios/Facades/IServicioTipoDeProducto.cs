using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeProducto
    {
        List<TipoDeProductoListDto> GetLista();

        TipoDeProductoEditDto GetTipoDeProductoId(int? Id);

        void Guardar(TipoDeProductoEditDto tipoDeProductoEditDto);

        void Borrar(int? Id);

        bool Existe(TipoDeProductoEditDto tipoDeProductoEditDto);
    }
}
