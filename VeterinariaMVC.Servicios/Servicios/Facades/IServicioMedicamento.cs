using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Medicamento;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioMedicamento
    {
        List<MedicamentoListDto> GetLista();
        bool Existe(MedicamentoEditDto medicamentoEditDto);
        void Guardar(MedicamentoEditDto medicamentoDto);
        MedicamentoEditDto GetMedicamentoPorId(int? id);
        void Borrar(int VmMedicamentoId);
    }
}
