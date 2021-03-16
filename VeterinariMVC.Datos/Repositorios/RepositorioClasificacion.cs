using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioClasificacion : IRepositorioClasificacion
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;

        public RepositorioClasificacion(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public ClasificacionEditDto GetClasificacionId(int? Id)
        {
            try
            {
                return mapper
                    .Map<ClasificacionEditDto>(context.Clasificiones.SingleOrDefault(c => c.ClasificacionId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public List<ClasificacionListDto> GetLista()
        {
            try
            {
                var lista = context.Clasificiones.ToList();
                return mapper.Map<List<ClasificacionListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las Clasificaciones");
            }
        }

        public void Guardar(Clasificacion clasificacion)
        {
            try
            {
                if (clasificacion.ClasificacionId == 0)
                {
                    context.Clasificiones.Add(clasificacion);
                }
                else
                {
                    var tipoDb = context.Clasificiones.SingleOrDefault(c => c.ClasificacionId == clasificacion.ClasificacionId);
                    tipoDb.Descripcion = clasificacion.Descripcion;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar la clasificacion");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.Clasificiones.SingleOrDefault(c => c.ClasificacionId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar una clasificacion");
            }
        }

        public bool Existe(Clasificacion clasificacion)
        {
            if (clasificacion.ClasificacionId == 0)
            {
                return context.Clasificiones.Any(c => c.Descripcion == clasificacion.Descripcion);
            }
            return context.Clasificiones.Any(c => c.Descripcion == clasificacion.Descripcion &&
            c.ClasificacionId == clasificacion.ClasificacionId);
        }

    }
}
