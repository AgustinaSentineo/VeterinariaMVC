using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;
        public RepositorioEmpleado(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<EmpleadoListDto> GetLista()
        {
            try
            {
                var lista = context.Empleados.Include(l=>l.TipoDeTarea)
                  .Select(l => new EmpleadoListDto
                  {
                      EmpleadoId= l.EmpleadoId,
                      Nombre= l.Nombre,
                      Apellido = l.Apellido,
                      CorreoElectronico = l.CorreoElectronico,
                      TipoDeTarea = l.TipoDeTarea.Descripcion,

                  }).ToList();

                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los empleados");
            }
        }
        public EmpleadoEditDto GetEmpeladoPorId(int? id)
        {
            try
            {
                return mapper
                    .Map<EmpleadoEditDto>(context.Empleados
                        .SingleOrDefault(e => e.EmpleadoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un empleado");
            }
        }
        public void Guardar(Empleado empleado)
        {
            try
            {
                if (empleado.EmpleadoId == 0)
                {
                    context.Empleados.Add(empleado);
                }
                else
                {
                    var empleadoInDb = context
                        .Empleados
                        .SingleOrDefault(e => e.EmpleadoId == empleado.EmpleadoId);
                    empleadoInDb.EmpleadoId = empleado.EmpleadoId;
                    empleadoInDb.Nombre = empleado.Nombre;
                    empleadoInDb.Apellido = empleado.Apellido;
                    empleadoInDb.TipoDeDocumentoId = empleado.TipoDeDocumentoId;
                    empleadoInDb.NroDocumento = empleado.NroDocumento;
                    empleadoInDb.LocalidadId = empleado.LocalidadId;
                    empleadoInDb.ProvinciaId = empleado.ProvinciaId;
                    empleadoInDb.TelefonoFijo = empleado.TelefonoFijo;
                    empleadoInDb.TelefonoMovil = empleado.TelefonoMovil;
                    empleadoInDb.CorreoElectronico = empleado.CorreoElectronico;
                    empleadoInDb.TipoDeTareaId = empleado.TipoDeTareaId;
                    context.Entry(empleadoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un empleado");
            }
        }
        public void Borrar(int vmEmpleadoId)
        {
            try
            {
                var empleadoInDb = context.Empleados.SingleOrDefault(e => e.EmpleadoId == vmEmpleadoId);
                if (empleadoInDb == null)
                {
                    throw new Exception("Empleado inexistente...");

                }

                context.Entry(empleadoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un empleado");
            }
        }

        public bool Existe(Empleado empleado)
        {
            if (empleado.EmpleadoId == 0)
            {
                return context.Empleados.Any(c => c.Nombre == empleado.Nombre && c.Apellido == empleado.Apellido
                && c.NroDocumento == empleado.NroDocumento);
            }

            return context.Empleados.Any(c => c.Nombre == empleado.Nombre && c.Apellido == empleado.Apellido
                && c.NroDocumento == empleado.NroDocumento && c.EmpleadoId != empleado.EmpleadoId);
        }

    }
}
