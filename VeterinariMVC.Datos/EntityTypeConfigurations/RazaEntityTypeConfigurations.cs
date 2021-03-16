using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class RazaEntityTypeConfigurations: EntityTypeConfiguration<Raza>
    {
        public RazaEntityTypeConfigurations()
        {
            ToTable("Razas");
        }
    }
}
