using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.TipoDeProducto;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioTipoDeProducto : IServicioTipoDeProducto
    {
        private readonly IRepositorioTipoDeProducto repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork iunitOfWork;

        public ServicioTipoDeProducto(IRepositorioTipoDeProducto _repositorio, IUnitOfWork _unitOfWork)
        {
            repositorio = _repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            iunitOfWork = _unitOfWork;
        }
        public List<TipoDeProductoListDto> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoDeProductoEditDto GetTipoDeProductoId(int? Id)
        {
            try
            {
                return repositorio.GetTipoDeProductoId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeProductoEditDto tipoDeProductoEditDto)
        {
            try
            {
                TipoDeProducto tp = _mapper.Map<TipoDeProducto>(tipoDeProductoEditDto);
                repositorio.Guardar(tp);
                iunitOfWork.Save();
                tipoDeProductoEditDto.TipoDeProductoId = tp.TipoDeProductoId;
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
                repositorio.Borrar(Id);
                iunitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeProductoEditDto tipoDeProductoEditDto)
        {
            try
            {
                TipoDeProducto tp = _mapper.Map<TipoDeProducto>(tipoDeProductoEditDto);
                return repositorio.Existe(tp);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
