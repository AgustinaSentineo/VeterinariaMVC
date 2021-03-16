using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeTareaEntityTypeConfigurations : EntityTypeConfiguration<TipoDeTarea>
    {
        public TipoDeTareaEntityTypeConfigurations()
        {
            ToTable("TiposDeTarea");
        }
    }
}
