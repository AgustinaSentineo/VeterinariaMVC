using System.Collections.Generic;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincia
    {
        List<ProvinciaListDto> GetLista();

        ProvinciaEditDto GetProvinciaId(int? Id);

        void Guardar(Provincia provincia);

        void Borrar(int? Id);

        bool Existe(Provincia provincia);
    }
}
