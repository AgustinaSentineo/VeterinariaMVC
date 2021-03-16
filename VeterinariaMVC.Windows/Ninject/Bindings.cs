using Ninject.Modules;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Servicios.Servicios;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos;
using VeterinariMVC.Datos.Repositorios;
using VeterinariMVC.Datos.Repositorios.Facades;

namespace VeterinariaMVC.Windows.Ninject
{
    public class Bindings: NinjectModule
    {
        public override void Load()
        {
            Bind<VeterinariaDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioProvincia>().To<RepositorioProvincias>();
            Bind<IServicioProvincia>().To<ServicioProvincia>();

            Bind<IRepositorioLaboratorio>().To<RepositorioLaboratorio>();
            Bind<IServicioLaboratorio>().To<ServicioLaboratorio>();

            Bind<IRepositorioFormaFarmaceutica>().To<RepositorioFormaFarmaceutica>();
            Bind<IServicioFormaFarmaceutica>().To<ServicioFormaFarmaceutica>();

            Bind<IRepositorioTipoDeMedicamento>().To<RepositorioTipoDeMedicamento>();
            Bind<IServicioTipoDeMedicamento>().To<ServicioTipoDeMedicamento>();

            Bind<IRepositorioTipoDeDocumento>().To<RepositorioTipoDeDocumento>();
            Bind<IServicioTipoDeDocumento>().To<ServicioTipoDeDocumento>();

            Bind<IRepositorioTipoDeMascota>().To<RepositorioTipoDeMascota>();
            Bind<IServicioTipoDeMascota>().To<ServicioTipoDeMascota>();


            Bind<IRepositorioTipoDeTarea>().To<RepositorioTipoDeTarea>();
            Bind<IServicioTipoDeTarea>().To<ServicioTipoDeTarea>();


            Bind<IRepositorioTipoDeProducto>().To<RepositorioTipoDeProducto>();
            Bind<IServicioTipoDeProducto>().To<ServicioTipoDeProducto>();


            Bind<IRepositorioMarca>().To<RepositorioMarca>();
            Bind<IServicioMarca>().To<ServicioMarca>();

        }
    }
}
