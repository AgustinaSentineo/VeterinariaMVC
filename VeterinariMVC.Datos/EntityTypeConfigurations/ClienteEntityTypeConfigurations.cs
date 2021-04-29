using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class ClienteEntityTypeConfigurations: EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityTypeConfigurations()
        {
            ToTable("Clientes");
        }
    }
}
