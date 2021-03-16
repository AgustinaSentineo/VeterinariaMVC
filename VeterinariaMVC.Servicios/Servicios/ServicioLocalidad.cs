using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioLocalidad : IServicioLocalidad
    {
        private readonly IRepositorioLocalidad repositorioLocalidad;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioLocalidad(IRepositorioLocalidad _repositorioLocalidad, IUnitOfWork _unitOfWork)
        {
            repositorioLocalidad = _repositorioLocalidad;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }
        public List<LocalidadListDto> GetLista(string provincia)
        {
            try
            {
                return repositorioLocalidad.GetLista(provincia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return repositorioLocalidad.GetLocalidadPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                Localidad localidad = mapper.Map<Localidad>(localidadDto);
                repositorioLocalidad.Guardar(localidad);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int vmLocalidadId)
        {
            try
            {
                repositorioLocalidad.Borrar(vmLocalidadId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(LocalidadEditDto localidadDto)
        {
            try
            {
                Localidad localidad = mapper.Map<Localidad>(localidadDto);
                return repositorioLocalidad.Existe(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
