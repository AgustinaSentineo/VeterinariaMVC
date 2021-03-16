using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class LocalidadEntityTypeConfigurations: EntityTypeConfiguration<Localidad>
    {
        public LocalidadEntityTypeConfigurations()
        {
            ToTable("Localidades");
        }
    }
}
