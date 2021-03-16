using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeProducto
    {
        List<TipoDeProductoListDto> GetLista();

        TipoDeProductoEditDto GetTipoDeProductoId(int? Id);

        void Guardar(TipoDeProducto tipoDeProducto);

        void Borrar(int? Id);

        bool Existe(TipoDeProducto tipoDeProducto);
    }
}
