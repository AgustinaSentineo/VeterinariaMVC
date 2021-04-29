using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Medicamento;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioMedicamento
    {
        List<MedicamentoListDto> GetLista();
        bool Existe(Medicamento medicamento);
        void Guardar(Medicamento medicamento);
        MedicamentoEditDto GetMedocamentoPorId(int? id);
        void Borrar(int VmMedicamentoId);
    }
}
