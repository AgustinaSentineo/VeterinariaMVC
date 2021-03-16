using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioTipoDeAlimento : IServicioTipoDeAlimento
    {
        private readonly IRepositorioTipoDeAlimento repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork iunitOfWork;

        public ServicioTipoDeAlimento(IRepositorioTipoDeAlimento _repositorio, IUnitOfWork _iunitOfWork)
        {
            repositorio = _repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            iunitOfWork = _iunitOfWork;
        }
        public List<TipoDeAlimentoListDto> GetLista()
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

        public TipoDeAlimentoEditDto GetTipoDeAlimentoId(int? Id)
        {
            try
            {
                return repositorio.GetTipoId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeAlimentoEditDto tipo)
        {
            try
            {
                TipoDeAlimento t = _mapper.Map<TipoDeAlimento>(tipo);
                repositorio.Guardar(t);
                iunitOfWork.Save();
                tipo.TipoDeAlimentoId = t.TipoDeAlimentoId;
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

        public bool Existe(TipoDeAlimentoEditDto tipo)
        {
            try
            {
                TipoDeAlimento t = _mapper.Map<TipoDeAlimento>(tipo);
                return repositorio.Existe(t);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
