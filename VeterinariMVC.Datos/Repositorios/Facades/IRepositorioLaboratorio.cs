using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioLaboratorio
    {
        List<LaboratorioListDto> GetLista();

        LaboratorioEditDto GetLaboratorioPorId(int? Id);

        void Guardar(Laboratorio laboratorio);

        void Borrar(int? id);

        bool Existe(Laboratorio laboratorio);

        bool EstaRelacionado(Laboratorio laboratorio);
    }
}
