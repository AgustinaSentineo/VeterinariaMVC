using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioNecesidadEspecial : IServicioNecesidadEspecial
    {
        private readonly IRepositorioNecesidadEspecial repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork iunitOfWork;

        public ServicioNecesidadEspecial(IRepositorioNecesidadEspecial _repositorio, IUnitOfWork _iunitOfWork)
        {
            repositorio = _repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            iunitOfWork = _iunitOfWork;
        }
        public List<NecesidadEspecialListDto> GetLista()
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

        public NecesidadEspecialEditDto GetNecesidadEspecialId(int? Id)
        {
            try
            {
                return repositorio.GetNecesidadEspecialId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(NecesidadEspecialEditDto necesidadEspecial)
        {
            try
            {
                NecesidadesEspeciales n = _mapper.Map<NecesidadesEspeciales>(necesidadEspecial);
                repositorio.Guardar(n);
                iunitOfWork.Save();
                necesidadEspecial.NecesidadesEspecialesId = n.NecesidadesEspecialesId;
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

        public bool Existe(NecesidadEspecialEditDto necesidadEspecial)
        {
            try
            {
                NecesidadesEspeciales n = _mapper.Map<NecesidadesEspeciales>(necesidadEspecial);
                return repositorio.Existe(n);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
