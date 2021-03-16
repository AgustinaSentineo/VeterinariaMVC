using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class MarcaEntityTypeConfigurations:EntityTypeConfiguration<Marca>
    {
        public MarcaEntityTypeConfigurations()
        {
            ToTable("Marcas");
        }
    }
}
