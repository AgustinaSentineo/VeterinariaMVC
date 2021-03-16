using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioFormaFarmaceutica : IServicioFormaFarmaceutica
    {
        private readonly IRepositorioFormaFarmaceutica _repositorio;
        private readonly IMapper mapper;
        private IUnitOfWork _unitofwork;
        public ServicioFormaFarmaceutica(IRepositorioFormaFarmaceutica repositorio, IUnitOfWork unitofwork)
        {
            _repositorio = repositorio;
            mapper = Mapeador.Mapeador.CrearMapper();
            _unitofwork = unitofwork;
        }

        public List<FormaFarmaceuticaListDto> GetFormaFarmaceutica()
        {
            try
            {
                return _repositorio.GetFormaFarmaceutica();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public FormaFarmaceuticaEditDto GetObjeto(int? id)
        {
            try
            {
                return _repositorio.GetObjeto(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Agregar(FormaFarmaceuticaEditDto formaDto)
        {
            try
            {
                FormaFarmaceutica forma = mapper.Map<FormaFarmaceutica>(formaDto);
                _repositorio.Agregar(forma);
                _unitofwork.Save();
                formaDto.FormaFarmaceuticaId = forma.FormaFarmaceuticaId;
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
                _unitofwork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(FormaFarmaceuticaEditDto formaDto)
        {
            try
            {
                FormaFarmaceutica forma = mapper.Map<FormaFarmaceutica>(formaDto);
                return _repositorio.Existe(forma);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica)
        {
            throw new NotImplementedException();
        }
    }
}
