using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioTipoDeTarea : IServicioTipoDeTarea
    {
        private readonly IRepositorioTipoDeTarea repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork iunitOfWork;

        public ServicioTipoDeTarea(IRepositorioTipoDeTarea _repositorio, IUnitOfWork _unitOfWork)
        {
            repositorio = _repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            iunitOfWork = _unitOfWork;
        }
        public List<TipoDeTareaListDto> GetLista()
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

        public TipoDeTareaEditDto GetTipoDeTareaId(int? Id)
        {
            try
            {
                return repositorio.GetTipoDeTareaId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeTareaEditDto tipoDeTareaEditDto)
        {
            try
            {
                TipoDeTarea tp = _mapper.Map<TipoDeTarea>(tipoDeTareaEditDto);
                repositorio.Guardar(tp);
                iunitOfWork.Save();
                tipoDeTareaEditDto.TipoDeTareaId = tp.TipoDeTareaId;
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

        public bool Existe(TipoDeTareaEditDto tipoDeTareaEditDto)
        {
            try
            {
                TipoDeTarea tp = _mapper.Map<TipoDeTarea>(tipoDeTareaEditDto);
                return repositorio.Existe(tp);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
