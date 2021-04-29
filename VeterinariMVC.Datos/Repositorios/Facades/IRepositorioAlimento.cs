using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Alimento;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioAlimento
    {
        List<AlimentoListDto> GetLista();
        bool Existe(Alimento alimento);
        void Guardar(Alimento alimento);
        AlimentoEditDto GetAlimentoPorId(int? id);
        void Borrar(int VmAlimentoId);
    }
}
