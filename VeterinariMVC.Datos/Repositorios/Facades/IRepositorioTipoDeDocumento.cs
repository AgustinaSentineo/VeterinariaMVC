using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeDocumento
    {
        List<TipoDeDocumentoListDto> GetTipoDeDocumento();

        TipoDeDocumentoEditDto GetTipoDeDocumentoPorId(int? Id);

        void Guardar(TipoDeDocumento documento);

        void Borrar(int? Id);

        bool Existe(TipoDeDocumento documento);

        bool EstaRelacionado(TipoDeDocumento documento);
    }
}
