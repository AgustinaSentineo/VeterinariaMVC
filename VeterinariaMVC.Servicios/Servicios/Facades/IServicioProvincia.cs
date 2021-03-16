using System.Collections.Generic;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioProvincia
    {
        List<ProvinciaListDto> GetLista();

        ProvinciaEditDto GetProvinciaId(int? Id);

        void Guardar(ProvinciaEditDto provincia);

        void Borrar(int? Id);

        bool Existe(ProvinciaEditDto provincia);
    }
}
