using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;


namespace VeterinariaMVC.Datos.EntityTypeConfigurations
{
    public class FormaFarmaceuticaEntityTypeConfigurations:EntityTypeConfiguration<FormaFarmaceutica>
    {
        public FormaFarmaceuticaEntityTypeConfigurations()
        {
            ToTable("FormasFarmaceuticas");
        }
    }
}
