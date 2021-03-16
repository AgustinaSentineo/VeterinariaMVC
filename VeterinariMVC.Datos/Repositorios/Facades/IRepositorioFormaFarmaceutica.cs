using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioFormaFarmaceutica
    {
        List<FormaFarmaceuticaListDto> GetFormaFarmaceutica();
        FormaFarmaceuticaEditDto GetObjeto(int? id);
        void Agregar(FormaFarmaceutica formaFarmaceutica);
        void Borrar(int? Id);
        bool Existe(FormaFarmaceutica formaFarmaceutica);
        bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica);
    }
}
