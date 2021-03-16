using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class ClasificacionEntityTypeConfigurations:EntityTypeConfiguration<Clasificacion>
    {
        public ClasificacionEntityTypeConfigurations()
        {
            ToTable("Clasificaciones");
        }
    }
}
