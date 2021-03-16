using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Datos.Repositorios
{
    public class RepositorioTipoDeDocumento : IRepositorioTipoDeDocumento
    {
        private readonly VeterinariaDbContext _context;
        private readonly IMapper _mapper;
        public RepositorioTipoDeDocumento(VeterinariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }

        public List<TipoDeDocumentoListDto> GetTipoDeDocumento()
        {
            try
            {
                var lista = _context.TiposDeDocumentos.ToList();
                return _mapper.Map<List<TipoDeDocumentoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los Tipo De Documento");
            }
        }

        public TipoDeDocumentoEditDto GetTipoDeDocumentoPorId(int? Id)
        {
            try
            {
                return _mapper
                    .Map<TipoDeDocumentoEditDto>(_context.TiposDeDocumentos.SingleOrDefault(tp => tp.TipoDeDocumentoId == Id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer el Id");
            }
        }

        public void Guardar(TipoDeDocumento documento)
        {
            try
            {
                if (documento.TipoDeDocumentoId == 0)
                {
                    _context.TiposDeDocumentos.Add(documento);
                }
                else
                {
                    var tipoDb = _context.TiposDeDocumentos.SingleOrDefault(tp => tp.TipoDeDocumentoId == documento.TipoDeDocumentoId);
                    tipoDb.Descripcion = documento.Descripcion;

                    _context.Entry(tipoDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error al Guardar/Editar el Tipo De Documento");
            }
        }
        public void Borrar(int? Id)
        {
            try
            {
                var tipoDb = _context.TiposDeDocumentos.SingleOrDefault(tp => tp.TipoDeDocumentoId == Id);
                _context.Entry(tipoDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar borrar una provincia");
            }
        }

        public bool Existe(TipoDeDocumento documento)
        {
            if (documento.TipoDeDocumentoId == 0)
            {
                return _context.TiposDeDocumentos.Any(tp => tp.Descripcion == documento.Descripcion);
            }
            return _context.TiposDeDocumentos.Any(tp => tp.Descripcion == documento.Descripcion &&
            tp.TipoDeDocumentoId == documento.TipoDeDocumentoId);
        }

        public bool EstaRelacionado(TipoDeDocumento documento)
        {
            throw new NotImplementedException();
        }

    }
}
