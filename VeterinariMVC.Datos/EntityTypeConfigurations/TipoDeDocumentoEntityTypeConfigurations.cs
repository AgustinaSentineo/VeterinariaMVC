using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariaMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeDocumentoEntityTypeConfigurations : EntityTypeConfiguration<TipoDeDocumento>
    {
        public TipoDeDocumentoEntityTypeConfigurations()
        {
            ToTable("TiposDeDocumentos");
        }
    }
}
