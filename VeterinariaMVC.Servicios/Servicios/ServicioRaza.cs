using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioRaza : IServicioRaza
    {
        private readonly IRepositorioRaza repositorioRaza;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioRaza(IRepositorioRaza _repositorioRaza, IUnitOfWork _unitOfWork)
        {
            repositorioRaza = _repositorioRaza;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }
        public List<RazaListDto> GetLista(string tipoMascota)
        {
            try
            {
                return repositorioRaza.GetLista(tipoMascota);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public RazaEditDto GetRazaPorId(int? id)
        {
            try
            {
                return repositorioRaza.GetRazaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(RazaEditDto razaDto)
        {
            try
            {
                Raza raza = mapper.Map<Raza>(razaDto);
                repositorioRaza.Guardar(raza);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int vmRazaId)
        {
            try
            {
                repositorioRaza.Borrar(vmRazaId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(RazaEditDto razaDto)
        {
            try
            {
                Raza raza = mapper.Map<Raza>(razaDto);
                return repositorioRaza.Existe(raza);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
