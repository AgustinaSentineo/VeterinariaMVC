using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Servicios.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorioCliente repositorioCliente;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ServicioCliente(IRepositorioCliente _repositorioCliente, IUnitOfWork _unitOfWork)
        {
            repositorioCliente = _repositorioCliente;
            mapper = Mapeador.Mapeador.CrearMapper();
            unitOfWork = _unitOfWork;
        }
        public List<ClienteListDto> GetLista()
        {
            try
            {
                return repositorioCliente.GetLista();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return repositorioCliente.GetClientePorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ClienteEditDto clienteDto)
        {
            try
            {
                Cliente cliente = mapper.Map<Cliente>(clienteDto);
                repositorioCliente.Guardar(cliente);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Borrar(int vmClienteId)
        {
            try
            {
                repositorioCliente.Borrar(vmClienteId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClienteEditDto clienteDto)
        {
            try
            {
                Cliente cliente = mapper.Map<Cliente>(clienteDto);
                return repositorioCliente.Existe(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
