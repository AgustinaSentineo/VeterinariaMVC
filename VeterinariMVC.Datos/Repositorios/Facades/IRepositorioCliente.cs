using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioCliente
    {
        List<ClienteListDto> GetLista();
        ClienteEditDto GetClientePorId(int? id);
        bool Existe(Cliente cliente);
        void Guardar(Cliente cliente);
        void Borrar(int vmClienteId);
    }
}
