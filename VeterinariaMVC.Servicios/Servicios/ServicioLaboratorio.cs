using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.Laboratorio;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Servicios.Servicios 
{ 
    public class ServicioLaboratorio : IServicioLaboratorio
    {
        private readonly IRepositorioLaboratorio _repositorio;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public ServicioLaboratorio(IRepositorioLaboratorio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;
        }

        public List<LaboratorioListDto> GetLaboratorio()
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

        public LaboratorioEditDto GetLaboratorioPorId(int? Id)
        {
            try
            {
                return _repositorio.GetLaboratorioPorId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(LaboratorioEditDto laboratorio)
        {
            try
            {
                Laboratorio l = _mapper.Map<Laboratorio>(laboratorio);
                _repositorio.Guardar(l);
                _unitOfWork.Save();
                laboratorio.LaboratorioId = l.LaboratorioId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(LaboratorioEditDto laboratorio)
        {
            try
            {
                Laboratorio l = _mapper.Map<Laboratorio>(laboratorio);
                return _repositorio.Existe(l);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Laboratorio laboratorio)
        {
            throw new NotImplementedException();
        }
    }
}
