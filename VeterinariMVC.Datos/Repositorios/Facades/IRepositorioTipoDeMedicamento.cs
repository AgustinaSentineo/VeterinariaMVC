using System.Collections.Generic;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeMedicamento
    {
        List<TipoDeMedicamentoListDto> GetTipoDeMedicamento();

        TipoDeMedicamentoEditDto GetTipoDeMedicamentoPorId(int? Id);

        void Guardar(TipoDeMedicamento tipMeds);

        void Borrar(int? Id);

        bool Existe(TipoDeMedicamento tipMeds);

        bool EstaRelacionado(TipoDeMedicamento tipMeds);
    }
}
