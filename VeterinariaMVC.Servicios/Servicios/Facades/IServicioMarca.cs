using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Marca;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioMarca
    {
        List<MarcaListDto> GetLista();

        MarcaEditDto GetMarcaId(int? Id);

        void Guardar(MarcaEditDto marcaEditDto);

        void Borrar(int? Id);

        bool Existe(MarcaEditDto marcaEditDto);
    }
}
