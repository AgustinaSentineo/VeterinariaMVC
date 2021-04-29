using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioProveedor : IRepositorioProveedor
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;
        public RepositorioProveedor(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<ProveedorListDto> GetLista()
        {
            try
            {
                var lista = context.Proveedores.Include(l => l.Localidad)
                  .Select(l => new ProveedorListDto
                  {
                      ProveedorId = l.ProveedorId,
                      CUIT = l.CUIT,
                      RazonSocial = l.RazonSocial,
                      Localidad = l.Localidad.NombreLocalidad,
                      Provincia = l.Provincia.NombreProvincia,
                      CorreoElectronico = l.CorreoElectronico,

                  }).ToList();

                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los proveedores");
            }
        }

        public ProveedorEditDto GetProveedorPorId(int? id)
        {
            try
            {
                return mapper
                    .Map<ProveedorEditDto>(context.Proveedores
                        .SingleOrDefault(c => c.ProveedorId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un proveedor");
            }
        }

        public void Guardar(Proveedor proveedor)
        {
            try
            {
                if (proveedor.ProveedorId == 0)
                {
                    context.Proveedores.Add(proveedor);
                }
                else
                {
                    var proveedorInDb = context
                        .Proveedores
                        .SingleOrDefault(c => c.ProveedorId == proveedor.ProveedorId);
                    proveedorInDb.ProveedorId = proveedor.ProveedorId;
                    proveedorInDb.CUIT = proveedor.CUIT;
                    proveedorInDb.RazonSocial = proveedor.RazonSocial;
                    proveedorInDb.PersonaDeContacto = proveedor.PersonaDeContacto;
                    proveedorInDb.Calle = proveedor.Calle;
                    proveedorInDb.Altura = proveedor.Altura;
                    proveedorInDb.LocalidadId = proveedor.LocalidadId;
                    proveedorInDb.ProvinciaId = proveedor.ProvinciaId;
                    proveedorInDb.TelefonoFijo = proveedor.TelefonoFijo;
                    proveedorInDb.TelefonoMovil = proveedor.TelefonoMovil;
                    proveedorInDb.CorreoElectronico = proveedor.CorreoElectronico;
                    context.Entry(proveedorInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un proveedor");
            }
        }
        public void Borrar(int vmProveedorId)
        {
            try
            {
                var proveedorInDb = context.Proveedores.SingleOrDefault(c => c.ProveedorId == vmProveedorId);
                if (proveedorInDb == null)
                {
                    throw new Exception("Proveedor inexistente...");

                }

                context.Entry(proveedorInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un proveedor");
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            if (proveedor.ProveedorId == 0)
            {
                return context.Proveedores.Any(c => c.CUIT == proveedor.CUIT && c.RazonSocial == proveedor.RazonSocial);
            }

            return context.Proveedores.Any(c => c.CUIT == proveedor.CUIT && c.RazonSocial == proveedor.RazonSocial 
            && c.ProveedorId != proveedor.ProveedorId);
        }

    }
}
