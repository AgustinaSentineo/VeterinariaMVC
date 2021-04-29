using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class MascotaEntityTypeConfigurations: EntityTypeConfiguration<Mascota>
    {
        public MascotaEntityTypeConfigurations()
        {
            ToTable("Mascotas");
        }
    }
}
