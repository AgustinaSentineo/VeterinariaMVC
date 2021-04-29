using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioProveedor : IServicioProveedor
    {
        private readonly IRepositorioProveedor repositorioProveedor;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioProveedor(IRepositorioProveedor _repositorioProveedor, IUnitOfWork _unitOfWork)
        {
            repositorioProveedor = _repositorioProveedor;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }
        public List<ProveedorListDto> GetLista()
        {
            try
            {
                return repositorioProveedor.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ProveedorEditDto GetProveedorPorId(int? id)
        {
            try
            {
                return repositorioProveedor.GetProveedorPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProveedorEditDto proveedorDto)
        {
            try
            {
                Proveedor proveedor = mapper.Map<Proveedor>(proveedorDto);
                repositorioProveedor.Guardar(proveedor);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int vmProveedorId)
        {
            try
            {
                repositorioProveedor.Borrar(vmProveedorId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProveedorEditDto proveedorDto)
        {
            try
            {
                Proveedor proveedor = mapper.Map<Proveedor>(proveedorDto);
                return repositorioProveedor.Existe(proveedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
