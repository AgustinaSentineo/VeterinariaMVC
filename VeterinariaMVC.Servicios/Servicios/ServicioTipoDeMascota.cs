using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioTipoDeMascota : IServicioTipoDeMascota
    {
        private readonly IRepositorioTipoDeMascota _repositorio;
        private readonly IMapper mapper;
        private IUnitOfWork _unitOfWork;
        public ServicioTipoDeMascota(IRepositorioTipoDeMascota repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<TipoDeMascotaListDto> GetTipoDeMascota()
        {
            try
            {
                return _repositorio.GetTipoDeMascota();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoDeMascotaEditDto GetTipoDeMascotaPorId(int? Id)
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

        public void Guardar(TipoDeMascotaEditDto tipomascotaEditDto)
        {

            try
            {
                TipoDeMascota tipo = mapper.Map<TipoDeMascota>(tipomascotaEditDto);
                _repositorio.Guardar(tipo);
                _unitOfWork.Save();
                tipo.TipoDeMascotaId = tipomascotaEditDto.TipoDeMascotaId;
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

        public bool Existe(TipoDeMascotaEditDto tipomascotaEditDto)
        {
            try
            {
                TipoDeMascota tipo = mapper.Map<TipoDeMascota>(tipomascotaEditDto);
                return _repositorio.Existe(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
