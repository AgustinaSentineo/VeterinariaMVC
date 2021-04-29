using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioEmpleado: IServicioEmpleado
    {
        private readonly IRepositorioEmpleado repositorioEmpleado;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioEmpleado(IRepositorioEmpleado _repositorioEmpleado, IUnitOfWork _unitOfWork)
        {
            repositorioEmpleado = _repositorioEmpleado;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }

        public List<EmpleadoListDto> GetLista()
        {
            try
            {
                return repositorioEmpleado.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmpleadoEditDto GetEmpleadoPorId(int? id)
        {
            try
            {
                return repositorioEmpleado.GetEmpeladoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(EmpleadoEditDto empleadoDto)
        {
            try
            {
                Empleado empleado = mapper.Map<Empleado>(empleadoDto);
                repositorioEmpleado.Guardar(empleado);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int vmEmpleadoId)
        {
            try
            {
                repositorioEmpleado.Borrar(vmEmpleadoId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(EmpleadoEditDto empleadoDto)
        {
            try
            {
                Empleado empleado = mapper.Map<Empleado>(empleadoDto);
                return repositorioEmpleado.Existe(empleado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
