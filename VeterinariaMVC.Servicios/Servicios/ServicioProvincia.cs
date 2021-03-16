using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Entities.DTOs.Provincia;
using VeterinariaMVC.Servicios.Servicios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioProvincia : IServicioProvincia
    {
        private readonly IRepositorioProvincia repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork iunitOfWork;

        public ServicioProvincia(IRepositorioProvincia _repositorio, IUnitOfWork _iunitOfWork)
        {
            repositorio = _repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            iunitOfWork = _iunitOfWork;
        }

        public List<ProvinciaListDto> GetLista()
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

        public ProvinciaEditDto GetProvinciaId(int? Id)
        {
            try
            {
                return repositorio.GetProvinciaId(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProvinciaEditDto provincia)
        {
            try
            {
                Provincia p = _mapper.Map<Provincia>(provincia);
                repositorio.Guardar(p);
                iunitOfWork.Save();
                provincia.ProvinciaId = p.ProvinciaId;
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

        public bool Existe(ProvinciaEditDto provincia)
        {
            try
            {
                Provincia p = _mapper.Map<Provincia>(provincia);
                return repositorio.Existe(p);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
