using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeMascota
    {
        List<TipoDeMascotaListDto> GetTipoDeMascota();

        TipoDeMascotaEditDto GetTipoDeMascotaPorId(int? Id);

        void Guardar(TipoDeMascotaEditDto tipomascotaEditDto);

        void Borrar(int? Id);

        bool Existe(TipoDeMascotaEditDto tipomascotaEditDto);
    }
}
