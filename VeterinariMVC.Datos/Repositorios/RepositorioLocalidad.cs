using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioLocalidad : IRepositorioLocalidad
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;
        public RepositorioLocalidad(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<LocalidadListDto> GetLista(string provincia)
        {
            try
            {
                if (provincia == null)
                {
                    var lista = context.Localidades.Include(p => p.Provincia)
                      .Select(p => new LocalidadListDto
                      {
                          LocalidadId = p.LocalidadId,
                          NombreLocalidad = p.NombreLocalidad,
                          Provincia = p.Provincia.NombreProvincia,
                      }).ToList();

                    return lista;
                }
                else
                {
                    var lista = context.Localidades.Include(p => p.Provincia)
                        .Where(p => p.Provincia.NombreProvincia == provincia)
                        .Select(p => new LocalidadListDto
                        {
                            LocalidadId = p.LocalidadId,
                            NombreLocalidad = p.NombreLocalidad,
                            Provincia = p.Provincia.NombreProvincia,
                        }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las localidades");
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return mapper
                    .Map<LocalidadEditDto>(context.Localidades
                        .Include(l => l.Provincia)
                        .SingleOrDefault(l => l.LocalidadId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer una localidad");
            }
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    context.Localidades.Add(localidad);
                }
                else
                {
                    var localidadInDb = context
                        .Localidades
                        .SingleOrDefault(l => l.LocalidadId == localidad.LocalidadId);
                    localidadInDb.ProvinciaId = localidad.ProvinciaId;
                    localidadInDb.NombreLocalidad = localidad.NombreLocalidad;
                    localidadInDb.LocalidadId = localidad.LocalidadId;
                    context.Entry(localidadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar una localidad");
            }
        }
        public void Borrar(int vmLocalidadId)
        {
            try
            {
                var localidadInDb = context.Localidades.SingleOrDefault(l => l.LocalidadId == vmLocalidadId);
                if (localidadInDb == null)
                {
                    throw new Exception("Localidad inexistente...");

                }

                context.Entry(localidadInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una localidad");
            }
        }

        public bool Existe(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                return context.Localidades.Any(l => l.NombreLocalidad == localidad.NombreLocalidad);
            }

            return context.Localidades.Any(l => l.NombreLocalidad == localidad.NombreLocalidad 
            && l.LocalidadId != localidad.LocalidadId);
        }
    }
}
