using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioClasificacion : IServicioClasificacion
    {
        private readonly IRepositorioClasificacion repositorio;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioClasificacion(IRepositorioClasificacion _repositorio, IUnitOfWork _unitOfWork)
        {
            repositorio = _repositorio;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }
        public ClasificacionEditDto GetClasificacionId(int? Id)
        {
            try
            {
                return repositorio.GetClasificacionId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ClasificacionListDto> GetLista()
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

        public void Guardar(ClasificacionEditDto clasificacion)
        {
            try
            {
                Clasificacion c = mapper.Map<Clasificacion>(clasificacion);
                repositorio.Guardar(c);
                unitOfWork.Save();
                clasificacion.ClasificacionId = c.ClasificacionId;
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
                unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClasificacionEditDto clasificacion)
        {
            try
            {
                Clasificacion c = mapper.Map<Clasificacion>(clasificacion);
                return repositorio.Existe(c);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
