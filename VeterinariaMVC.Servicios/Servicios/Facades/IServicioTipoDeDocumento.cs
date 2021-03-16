using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{ 
    public interface IServicioTipoDeDocumento
    {
        List<TipoDeDocumentoListDto> GetTipoDeDocumento();

        TipoDeDocumentoEditDto GetTipoDeDocumentoPorId(int? Id);

        void Guardar(TipoDeDocumentoEditDto documentoEditDto);

        void Borrar(int? Id);

        bool Existe(TipoDeDocumentoEditDto documentoEditDto);

        bool EstaRelacionado(TipoDeDocumento documento);
    }
}
