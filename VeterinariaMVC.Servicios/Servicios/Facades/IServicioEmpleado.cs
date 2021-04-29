using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Empleado;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioEmpleado
    {
        List<EmpleadoListDto> GetLista();
        EmpleadoEditDto GetEmpleadoPorId(int? id);
        bool Existe(EmpleadoEditDto empleadoDto);
        void Guardar(EmpleadoEditDto empleadoDto);
        void Borrar(int vmEmpleadoId);
    }
}
