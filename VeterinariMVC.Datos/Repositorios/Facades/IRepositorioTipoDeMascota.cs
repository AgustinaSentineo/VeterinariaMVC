using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeMascota
    {
        List<TipoDeMascotaListDto> GetTipoDeMascota();

        TipoDeMascotaEditDto GetTipoDeDocumentoPorId(int? Id);

        void Guardar(TipoDeMascota tipomascota);

        void Borrar(int? Id);

        bool Existe(TipoDeMascota tipomascota);

        bool EstaRelacionado(TipoDeMascota tipomascota);
    }
}
