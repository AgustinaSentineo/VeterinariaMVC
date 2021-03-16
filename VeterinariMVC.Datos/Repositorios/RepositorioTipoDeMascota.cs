using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos.Repositorios
{
    public class RepositorioTipoDeMascota : IRepositorioTipoDeMascota
    {
        private VeterinariaDbContext _context;
        private readonly IMapper mapper;
        public RepositorioTipoDeMascota(VeterinariaDbContext context)
        {
            _context = context;
            mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<TipoDeMascotaListDto> GetTipoDeMascota()
        {
            try
            {
                var lista = _context.TiposDeMascotas.ToList();
                return mapper.Map<List<TipoDeMascotaListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los Tipos De Mascotas");
            }
        }
        public TipoDeMascotaEditDto GetTipoDeDocumentoPorId(int? Id)
        {
            try
            {
                return mapper
                    .Map<TipoDeMascotaEditDto>(_context.TiposDeMascotas.SingleOrDefault(tp => tp.TipoDeMascotaId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }
        public void Guardar(TipoDeMascota tipomascota)
        {
            try
            {
                if (tipomascota.TipoDeMascotaId == 0)
                {
                    _context.TiposDeMascotas.Add(tipomascota);
                }
                else
                {
                    var tipoDb = _context.TiposDeMascotas.SingleOrDefault(tp => tp.TipoDeMascotaId == tipomascota.TipoDeMascotaId);
                    tipoDb.Descripcion = tipomascota.Descripcion;

                    _context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el Tipo De Mascota");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = _context.TiposDeMascotas.SingleOrDefault(tp => tp.TipoDeMascotaId == Id);
                _context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar un Tipo De Mascota");
            }
        }

        public bool EstaRelacionado(TipoDeMascota tipomascota)
        {
            throw new NotImplementedException();
        }

        public bool Existe(TipoDeMascota tipomascota)
        {
            if (tipomascota.TipoDeMascotaId == 0)
            {
                return _context.TiposDeMascotas.Any(tp => tp.Descripcion == tipomascota.Descripcion);
            }
            return _context.TiposDeMascotas.Any(tp => tp.Descripcion == tipomascota.Descripcion &&
            tp.TipoDeMascotaId == tipomascota.TipoDeMascotaId);
        }

    }
}
