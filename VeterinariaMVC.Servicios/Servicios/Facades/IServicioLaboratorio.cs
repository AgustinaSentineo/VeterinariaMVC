using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioLaboratorio
    {
        List<LaboratorioListDto> GetLaboratorio();

        LaboratorioEditDto GetLaboratorioPorId(int? Id);

        void Guardar(LaboratorioEditDto laboratorio);

        void Borrar(int? id);

        bool Existe(LaboratorioEditDto laboratorio);

        bool EstaRelacionado(Laboratorio laboratorio);
    }
}
