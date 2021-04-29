using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.Mascota;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioMascota
    {
        List<MascotaListDto> GetLista();
        MascotaEditDto GetMascotaPorId(int? id);
        bool Existe(MascotaEditDto mascotaDto);
        void Guardar(MascotaEditDto mascotaDto);
        void Borrar(int vmMascotaId);
    }
}
