using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioEmpleado
    {
        List<EmpleadoListDto> GetLista();
        EmpleadoEditDto GetEmpeladoPorId(int? id);
        bool Existe(Empleado empleado);
        void Guardar(Empleado empleado);
        void Borrar(int vmEmpleadoId);
    }
}
