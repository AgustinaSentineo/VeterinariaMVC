using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioTipoDeAlimento : IRepositorioTipoDeAlimento
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;

        public RepositorioTipoDeAlimento(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<TipoDeAlimentoListDto> GetLista()
        {
            try
            {
                var lista = context.TiposDeAlimentos.ToList();
                return mapper.Map<List<TipoDeAlimentoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer las Tipo de Alimento");
            }
        }

        public TipoDeAlimentoEditDto GetTipoId(int? Id)
        {
            try
            {
                return mapper
                    .Map<TipoDeAlimentoEditDto>(context.TiposDeAlimentos.SingleOrDefault(t => t.TipoDeAlimentoId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(TipoDeAlimento tipo)
        {
            try
            {
                if (tipo.TipoDeAlimentoId == 0)
                {
                    context.TiposDeAlimentos.Add(tipo);
                }
                else
                {
                    var tipoDb = context.TiposDeAlimentos.SingleOrDefault(t => t.TipoDeAlimentoId== tipo.TipoDeAlimentoId);
                    tipoDb.Descripcion = tipo.Descripcion;

                    context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el tipo de alimento");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = context.TiposDeAlimentos.SingleOrDefault(t => t.TipoDeAlimentoId == Id);
                context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar un tipo de alimento");
            }
        }

        public bool Existe(TipoDeAlimento tipo)
        {
            if (tipo.TipoDeAlimentoId == 0)
            {
                return context.TiposDeAlimentos.Any(t => t.Descripcion == tipo.Descripcion);
            }
            return context.TiposDeAlimentos.Any(t => t.Descripcion == tipo.Descripcion &&
            t.TipoDeAlimentoId == tipo.TipoDeAlimentoId);
        }

    }
}
