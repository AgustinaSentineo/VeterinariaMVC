using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using VeterinariaMVC.Entidades.Entidades;
namespace VeterinariMVC.Datos
{
    public class VeterinariaDbContext:DbContext
    {
        public VeterinariaDbContext()
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VeterinariaDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Provincia> Provincias { get; set; }
        //public DbSet<Localidad> Localidades { get; set; }
        public DbSet<TipoDeMascota> TiposDeMascotas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<TipoDeMedicamento> TiposDeMedicamentos { get; set; }
        public DbSet<FormaFarmaceutica> FormasFarmaceuticas { get; set; }
        public DbSet<TipoDeDocumento> TiposDeDocumentos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoDeTarea> TiposDeTarea { get; set; }
        public DbSet<TipoDeProducto> TiposDeProductos { get; set; }

        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Raza> Razas { get; set; }
        //public DbSet<Mascota> Mascotas { get; set; }
        //public DbSet<Medicamento> Medicamentos { get; set; }
    }
}
