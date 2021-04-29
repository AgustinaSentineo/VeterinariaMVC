using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Alimento;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioAlimento:IServicioAlimento
    {
        private readonly IRepositorioAlimento _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioAlimento(IRepositorioAlimento repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<AlimentoListDto> GetLista()
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

        public AlimentoEditDto GetAlimentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetAlimentoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(AlimentoEditDto alimentoDto)
        {
            try
            {
                Alimento alimento = _mapper.Map<Alimento>(alimentoDto);
                _repositorio.Guardar(alimento);
                _unitOfWork.Save();
                alimentoDto.AlimentoId = alimento.AlimentoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int VmAlimentoId)
        {
            try
            {
                _repositorio.Borrar(VmAlimentoId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(AlimentoEditDto alimentoEditDto)
        {
            try
            {
                Alimento alimento = _mapper.Map<Alimento>(alimentoEditDto);
                return _repositorio.Existe(alimento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
