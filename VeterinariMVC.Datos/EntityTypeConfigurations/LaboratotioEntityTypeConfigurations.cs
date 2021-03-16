using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.EntityTypeConfigurations
{
    public class LaboratotioEntityTypeConfigurations:EntityTypeConfiguration<Laboratorio>
    {
        public LaboratotioEntityTypeConfigurations()
        {
            ToTable("Laboratorios");
        }
    }
}
