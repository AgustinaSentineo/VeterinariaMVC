using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioRaza
    {
        List<RazaListDto> GetLista(string tipomascota);
        RazaEditDto GetRazaPorId(int? id);
        bool Existe(Raza raza);
        void Guardar(Raza raza);
        void Borrar(int vmRazaId);
    }
}
