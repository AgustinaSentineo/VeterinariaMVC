using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Servicios.Servicios.Facades 
{ 
    public interface IServicioFormaFarmaceutica
    {
        List<FormaFarmaceuticaListDto> GetFormaFarmaceutica();
        FormaFarmaceuticaEditDto GetObjeto(int? id);
        void Agregar(FormaFarmaceuticaEditDto formaDto);
        void Borrar(int? id);
        bool Existe(FormaFarmaceuticaEditDto formaDto);
        bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica);
    }
}
