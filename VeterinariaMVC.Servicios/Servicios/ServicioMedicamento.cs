using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Medicamento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioMedicamento : IServicioMedicamento
    {
        private readonly IRepositorioMedicamento _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioMedicamento(IRepositorioMedicamento repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<MedicamentoListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MedicamentoEditDto GetMedicamentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetMedocamentoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(MedicamentoEditDto medicamentoDto)
        {
            try
            {
                Medicamento medicamento = _mapper.Map<Medicamento>(medicamentoDto);
                _repositorio.Guardar(medicamento);
                _unitOfWork.Save();
                medicamentoDto.MedicamentoId = medicamento.MedicamentoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        
        public void Borrar(int VmMedicamentoId)
        {
            try
            {
                _repositorio.Borrar(VmMedicamentoId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(MedicamentoEditDto medicamentoEditDto)
        {
            try
            {
                Medicamento medicamento = _mapper.Map<Medicamento>(medicamentoEditDto);
                return _repositorio.Existe(medicamento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
