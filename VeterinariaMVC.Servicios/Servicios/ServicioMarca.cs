using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Marca;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioMarca : IServicioMarca
    {
        private readonly IRepositorioMarca repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork iunitOfWork;

        public ServicioMarca(IRepositorioMarca _repositorio, IUnitOfWork _unitOfWork)
        {
            repositorio = _repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            iunitOfWork = _unitOfWork;
        }
        public List<MarcaListDto> GetLista()
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

        public MarcaEditDto GetMarcaId(int? Id)
        {
            try
            {
                return repositorio.GetMarcaId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(MarcaEditDto marcaEditDto)
        {
            try
            {
                Marca m = _mapper.Map<Marca>(marcaEditDto);
                repositorio.Guardar(m);
                iunitOfWork.Save();
                marcaEditDto.MarcaId = m.MarcaId;
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

        public bool Existe(MarcaEditDto marcaEditDto)
        {
            try
            {
                Marca m = _mapper.Map<Marca>(marcaEditDto);
                return repositorio.Existe(m);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
