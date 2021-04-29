using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Cliente;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioCliente
    {
        List<ClienteListDto> GetLista();
        ClienteEditDto GetClientePorId(int? id);
        bool Existe(ClienteEditDto clienteDto);
        void Guardar(ClienteEditDto clienteDto);
        void Borrar(int vmClienteId);
    }
}
