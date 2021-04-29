using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioMascota
    {
        List<MascotaListDto> GetLista();
        MascotaEditDto GetMascotaPorId(int? id);
        bool Existe(Mascota mascota);
        void Guardar(Mascota mascota);
        void Borrar(int vmMascotaId);
    }
}
