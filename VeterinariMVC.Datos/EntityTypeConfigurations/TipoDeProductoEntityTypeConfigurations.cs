using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class TipoDeProductoEntityTypeConfigurations:EntityTypeConfiguration<TipoDeProducto>
    {
        public TipoDeProductoEntityTypeConfigurations()
        {
            ToTable("TiposDeProductos");
        }
    }
}
