using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class NecesiadadEspecialEntityTypeConfigurations:EntityTypeConfiguration<NecesidadesEspeciales>
    {
        public NecesiadadEspecialEntityTypeConfigurations()
        {
            ToTable("NecesidadesEspeciales");
        }
    }
}
