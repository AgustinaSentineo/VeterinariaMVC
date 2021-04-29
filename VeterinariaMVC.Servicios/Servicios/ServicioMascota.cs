using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioMascota : IServicioMascota
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioMascota(IRepositorioMascota _repositorioMascota, IUnitOfWork _unitOfWork)
        {
            repositorioMascota = _repositorioMascota;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }
        public List<MascotaListDto> GetLista()
        {
            try
            {
                return repositorioMascota.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MascotaEditDto GetMascotaPorId(int? id)
        {
            try
            {
                return repositorioMascota.GetMascotaPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(MascotaEditDto mascotaDto)
        {
            try
            {
                Mascota mascota = mapper.Map<Mascota>(mascotaDto);
                repositorioMascota.Guardar(mascota);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int vmMascotaId)
        {
            try
            {
                repositorioMascota.Borrar(vmMascotaId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(MascotaEditDto mascotaDto)
        {
            try
            {
                Mascota mascota = mapper.Map<Mascota>(mascotaDto);
                return repositorioMascota.Existe(mascota);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
