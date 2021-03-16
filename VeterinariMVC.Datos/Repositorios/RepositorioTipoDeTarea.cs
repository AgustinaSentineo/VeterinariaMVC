using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioTipoDeTarea : IRepositorioTipoDeTarea
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;

        public RepositorioTipoDeTarea(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<TipoDeTareaListDto> GetLista()
        {
            try
            {
                var lista = context.TiposDeTarea.ToList();
                return mapper.Map<List<TipoDeTareaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los Tipos de Tarea");
            }
        }

        public TipoDeTareaEditDto GetTipoDeTareaId(int? Id)
        {
            try
            {
                return mapper
                    .Map<TipoDeTareaEditDto>(context.TiposDeTarea.SingleOrDefault(tp => tp.TipoDeTareaId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(TipoDeTarea tipoDeTarea)
        {
            try
            {
                if (tipoDeTarea.TipoDeTareaId == 0)
                {
                    context.TiposDeTarea.Add(tipoDeTarea);
                }
                else
                {
                    var tipoDb = context.TiposDeTarea.SingleOrDefault(tp => tp.TipoDeTareaId == tipoDeTarea.TipoDeTareaId);
                    tipoDb.Descripcion = tipoDeTarea.Descripcion;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el tipo de tarea");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.TiposDeTarea.SingleOrDefault(tp => tp.TipoDeTareaId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar un tipo de tarea");
            }
        }

        public bool Existe(TipoDeTarea tipoDeTarea)
        {
            if (tipoDeTarea.TipoDeTareaId == 0)
            {
                return context.TiposDeTarea.Any(tp => tp.Descripcion == tipoDeTarea.Descripcion);
            }
            return context.TiposDeTarea.Any(tp => tp.Descripcion == tipoDeTarea.Descripcion &&
            tp.TipoDeTareaId == tipoDeTarea.TipoDeTareaId);
        }

    }
}
