using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class AlimentoEntityTypeConfigurations:EntityTypeConfiguration<Alimento>
    {
        public AlimentoEntityTypeConfigurations()
        {
            ToTable("Alimentos");
        }
    }
}
