using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeMascotaEntityTypeConfigurations:EntityTypeConfiguration<TipoDeMascota>
    {
        public TipoDeMascotaEntityTypeConfigurations()
        {
            ToTable("TiposDeMascotas");
        }
    }
}
