using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos.Repositorios
{
    public class RepositorioTipoDeMedicamento : IRepositorioTipoDeMedicamento
    {
        private readonly VeterinariaDbContext _context;
        private readonly IMapper mapper;
        public RepositorioTipoDeMedicamento(VeterinariaDbContext context)
        {
            _context = context;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<TipoDeMedicamentoListDto> GetTipoDeMedicamento()
        {
            try
            {
                var lista = _context.TiposDeMedicamentos.ToList();
                return mapper.Map<List<TipoDeMedicamentoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los Tipo De Medicamento");
            }
        }

        public TipoDeMedicamentoEditDto GetTipoDeMedicamentoPorId(int? Id)
        {
            try
            {
                return mapper
                    .Map<TipoDeMedicamentoEditDto>(_context.TiposDeMedicamentos.SingleOrDefault(tp => tp.TipoDeMedicamentoId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(TipoDeMedicamento tipMeds)
        {
            try
            {
                if (tipMeds.TipoDeMedicamentoId == 0)
                {
                    _context.TiposDeMedicamentos.Add(tipMeds);
                }
                else
                {
                    var tipoDb = _context.TiposDeMedicamentos.SingleOrDefault(tp => tp.TipoDeMedicamentoId == tipMeds.TipoDeMedicamentoId);
                    tipoDb.Descripcion = tipMeds.Descripcion;

                    _context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el Tipo De Medicamento");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = _context.TiposDeMedicamentos.SingleOrDefault(tp => tp.TipoDeMedicamentoId == Id);
                _context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar un Tipo De Medicamento");
            }
        }

        public bool EstaRelacionado(TipoDeMedicamento tipMeds)
        {
            throw new NotImplementedException();
        }

        public bool Existe(TipoDeMedicamento tipMeds)
        {
            if (tipMeds.TipoDeMedicamentoId == 0)
            {
                return _context.TiposDeMedicamentos.Any(tp => tp.Descripcion == tipMeds.Descripcion);
            }
            return _context.TiposDeMedicamentos.Any(tp => tp.Descripcion == tipMeds.Descripcion &&
            tp.TipoDeMedicamentoId == tipMeds.TipoDeMedicamentoId);
        }

    }
}
