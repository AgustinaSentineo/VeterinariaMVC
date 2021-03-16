using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioTipoDeMedicamento : IServicioTipoDeMedicamento
    {
        private readonly IRepositorioTipoDeMedicamento _repositorio;
        private readonly IMapper mapper;
        private IUnitOfWork _unitOfWork;

        public ServicioTipoDeMedicamento(IRepositorioTipoDeMedicamento repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<TipoDeMedicamentoListDto> GetTipoDeMedicamento()
        {
            try
            {
                return _repositorio.GetTipoDeMedicamento();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoDeMedicamentoEditDto GetTipoDeMedicamentoPorId(int? Id)
        {
            try
            {
                return _repositorio.GetTipoDeMedicamentoPorId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeMedicamentoEditDto tipMedsEditDto)
        {
            try
            {
                TipoDeMedicamento tipo = mapper.Map<TipoDeMedicamento>(tipMedsEditDto);
                _repositorio.Guardar(tipo);
                _unitOfWork.Save();
                tipMedsEditDto.Descripcion = tipo.Descripcion;
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

        public bool EstaRelacionado(TipoDeMedicamento tipMeds)
        {
            throw new NotImplementedException();
        }

        public bool Existe(TipoDeMedicamentoEditDto tipMedsEditDto)
        {
            try
            {
                TipoDeMedicamento tipo = mapper.Map<TipoDeMedicamento>(tipMedsEditDto);
                return _repositorio.Existe(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
