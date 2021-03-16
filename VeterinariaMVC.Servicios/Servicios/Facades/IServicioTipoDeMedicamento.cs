using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.Entidades;
namespace VeterinariaMVC.Servicios.Servicios.Facades
{
    public interface IServicioTipoDeMedicamento
    {
        List<TipoDeMedicamentoListDto> GetTipoDeMedicamento();

        TipoDeMedicamentoEditDto GetTipoDeMedicamentoPorId(int? Id);

        void Guardar(TipoDeMedicamentoEditDto tipMedsEditDto);

        void Borrar(int? Id);

        bool Existe(TipoDeMedicamentoEditDto tipMedsEditDto);

        bool EstaRelacionado(TipoDeMedicamento tipMeds);
    }
}
