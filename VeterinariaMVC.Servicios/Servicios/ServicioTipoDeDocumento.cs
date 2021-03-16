using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioTipoDeDocumento : IServicioTipoDeDocumento
    {
        private VeterinariaDbContext _context;
        private readonly IRepositorioTipoDeDocumento _repositorio;
        private readonly IMapper mapper;
        private IUnitOfWork _unitOfWork;

        public ServicioTipoDeDocumento(VeterinariaDbContext context, IRepositorioTipoDeDocumento repositorio, IUnitOfWork unitOfWork)
        {
            _context = context;
            _repositorio = repositorio;
            mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<TipoDeDocumentoListDto> GetTipoDeDocumento()
        {
            try
            {
                return _repositorio.GetTipoDeDocumento();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumentoEditDto GetTipoDeDocumentoPorId(int? Id)
        {
            try
            {
                return _repositorio.GetTipoDeDocumentoPorId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeDocumentoEditDto documentoEditDto)
        {
            try
            {
                TipoDeDocumento documento = mapper.Map<TipoDeDocumento>(documentoEditDto);
                _repositorio.Guardar(documento);
                _unitOfWork.Save();
                documentoEditDto.Descripcion = documento.Descripcion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Borrar(int? Id)
        {
            try
            {
                _repositorio.Borrar(Id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool Existe(TipoDeDocumentoEditDto documentoEditDto)
        {
            try
            {
                TipoDeDocumento documento = mapper.Map<TipoDeDocumento>(documentoEditDto);
                return _repositorio.Existe(documento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento documento)
        {
            throw new NotImplementedException();
        }
    }
}
