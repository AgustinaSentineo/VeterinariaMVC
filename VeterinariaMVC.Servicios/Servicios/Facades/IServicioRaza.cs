using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Raza;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioRaza
    {
        List<RazaListDto> GetLista(string tipoMascota);
        RazaEditDto GetRazaPorId(int? id);
        bool Existe(RazaEditDto razaDto);
        void Guardar(RazaEditDto razaDto);
        void Borrar(int vmRazaId);
    }
}
