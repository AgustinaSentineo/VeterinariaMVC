using System.Data.Entity.ModelConfiguration;
using VeterinariaMVC.Entidades.Entidades;

namespace VeterinariMVC.Datos.EntityTypeConfigurations
{
    public class EmpleadoEntityTypeConfigurations: EntityTypeConfiguration<Empleado>
    {
        public EmpleadoEntityTypeConfigurations()
        {
            ToTable("Empleados");
        }
    }
}
