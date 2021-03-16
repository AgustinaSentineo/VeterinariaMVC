using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeAlimentoEntityTypeConfigurations:EntityTypeConfiguration<TipoDeAlimento>
    {
        public TipoDeAlimentoEntityTypeConfigurations()
        {
            ToTable("TiposDeAlimentos");
        }
    }
}
