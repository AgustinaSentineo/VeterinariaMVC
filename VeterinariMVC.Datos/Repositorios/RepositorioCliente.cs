using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.Entidades;
using VeterinariaMVC.Mapeador;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariMVC.Datos.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly VeterinariaDbContext context;
        private readonly IMapper mapper;
        public RepositorioCliente(VeterinariaDbContext _context)
        {
            context = _context;
            mapper = Mapeador.CrearMapper();
        }
        public List<ClienteListDto> GetLista()
        {
            try
            {
                var lista = context.Clientes
                  .Select(l => new ClienteListDto
                  {
                      ClienteId = l.ClienteId,
                      Nombre = l.Nombre,
                      Apellido = l.Apellido,
                      Calle = l.Calle,
                      Altura = l.Altura,
                      CorreoElectronico = l.CorreoElectronico,

                  }).ToList();

                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los clientes");
            }
        }
        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return mapper
                    .Map<ClienteEditDto>(context.Clientes
                        .SingleOrDefault(c => c.ClienteId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un cliente");
            }
        }
        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    context.Clientes.Add(cliente);
                }
                else
                {
                    var clienteInDb = context
                        .Clientes
                        .SingleOrDefault(c => c.ClienteId == cliente.ClienteId);
                    clienteInDb.ClienteId = cliente.ClienteId;
                    clienteInDb.Nombre = cliente.Nombre;
                    clienteInDb.Apellido = cliente.Apellido;
                    clienteInDb.TipoDeDocumentoId = cliente.TipoDeDocumentoId;
                    clienteInDb.NroDocumento = cliente.NroDocumento;
                    clienteInDb.LocalidadId = cliente.LocalidadId;
                    clienteInDb.ProvinciaId = cliente.ProvinciaId;
                    clienteInDb.TelefonoFijo = cliente.TelefonoFijo;
                    clienteInDb.TelefonoMovil = cliente.TelefonoMovil;
                    clienteInDb.CorreoElectronico = cliente.CorreoElectronico;
                    context.Entry(clienteInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un cliente");
            }
        }
        public void Borrar(int vmClienteId)
        {
            try
            {
                var clienteInDb = context.Clientes.SingleOrDefault(c => c.ClienteId == vmClienteId);
                if (clienteInDb == null)
                {
                    throw new Exception("Cliente inexistente...");

                }

                context.Entry(clienteInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un cliente");
            }
        }

        public bool Existe(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                return context.Clientes.Any(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido 
                && c.NroDocumento== cliente.NroDocumento);
            }

            return context.Clientes.Any(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido
                && c.NroDocumento == cliente.NroDocumento && c.ClienteId != cliente.ClienteId);
        }

    }
}
