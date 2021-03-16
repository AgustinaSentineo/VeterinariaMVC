using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioMarca
    {
        List<MarcaListDto> GetLista();

        MarcaEditDto GetMarcaId(int? Id);

        void Guardar(Marca marca);

        void Borrar(int? Id);

        bool Existe(Marca marca);
    }
}
