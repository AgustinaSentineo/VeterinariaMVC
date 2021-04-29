using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class ProveedorEntityTypeConfigurations: EntityTypeConfiguration<Proveedor>
    {
        public ProveedorEntityTypeConfigurations()
        {
            ToTable("Proveedores");
        }
    }
}
