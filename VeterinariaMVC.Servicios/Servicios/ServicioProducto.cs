using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Producto;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioProducto: IServicioProducto
    {
        private readonly IRepositorioProducto _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioProducto(IRepositorioProducto repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<ProductoListDto> GetLista(string tipo)
        {
            try
            {
                return _repositorio.GetLista(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProductoEditDto productoEditDto)
        {
            try
            {
                Producto producto = _mapper.Map<Producto>(productoEditDto);
                return _repositorio.Existe(producto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProductoEditDto productoDto)
        {
            try
            {
                Producto producto = _mapper.Map<Producto>(productoDto);
                _repositorio.Guardar(producto);
                _unitOfWork.Save();
                productoDto.ProductoId = producto.ProductoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ProductoEditDto GetProductoPorId(int? id)
        {
            try
            {
                return _repositorio.GetProductoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int tipoVmProductoId)
        {
            try
            {
                _repositorio.Borrar(tipoVmProductoId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
