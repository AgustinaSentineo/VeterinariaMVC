using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeMedicamentoEntityTypeConfigurations:EntityTypeConfiguration<TipoDeMedicamento>
    {
        public TipoDeMedicamentoEntityTypeConfigurations()
        {
            ToTable("TiposDeMedicamentos");
        }
    }
}
