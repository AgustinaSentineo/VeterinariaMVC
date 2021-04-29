using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class MedicamentoEntityTypeConfigurations:EntityTypeConfiguration<Medicamento>
    {
        public MedicamentoEntityTypeConfigurations()
        {
            ToTable("Medicamentos");
        }
    }
}
