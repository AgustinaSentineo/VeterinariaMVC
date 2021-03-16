using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using VeterinariaMVC.Datos;
using VeterinariaMVC.Datos.Repositorios;
using VeterinariaMVC.Datos.Repositorios.Facades;
using VeterinariaMVC.Servicios.Servicios;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariMVC.Datos;
using VeterinariMVC.Datos.Repositorios;
using VeterinariMVC.Datos.Repositorios.Facades;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VeterinariaMVC.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VeterinariaMVC.Web.App_Start.NinjectWebCommon), "Stop")]

namespace VeterinariaMVC.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServicioProvincia>().To<ServicioProvincia>().InRequestScope();
            kernel.Bind<IRepositorioProvincia>().To<RepositorioProvincias>().InRequestScope();

            kernel.Bind<IServicioLaboratorio>().To<ServicioLaboratorio>().InRequestScope();
            kernel.Bind<IRepositorioLaboratorio>().To<RepositorioLaboratorio>().InRequestScope();

            kernel.Bind<IServicioFormaFarmaceutica>().To<ServicioFormaFarmaceutica>().InRequestScope();
            kernel.Bind<IRepositorioFormaFarmaceutica>().To<RepositorioFormaFarmaceutica>().InRequestScope();

            kernel.Bind<IServicioTipoDeDocumento>().To<ServicioTipoDeDocumento>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeDocumento>().To<RepositorioTipoDeDocumento>().InRequestScope();

            kernel.Bind<IServicioTipoDeMascota>().To<ServicioTipoDeMascota>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeMascota>().To<RepositorioTipoDeMascota>().InRequestScope();

            kernel.Bind<IServicioTipoDeMedicamento>().To<ServicioTipoDeMedicamento>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeMedicamento>().To<RepositorioTipoDeMedicamento>().InRequestScope();


            kernel.Bind<IRepositorioTipoDeTarea>().To<RepositorioTipoDeTarea>();
            kernel.Bind<IServicioTipoDeTarea>().To<ServicioTipoDeTarea>();


            kernel.Bind<IRepositorioTipoDeProducto>().To<RepositorioTipoDeProducto>();
            kernel.Bind<IServicioTipoDeProducto>().To<ServicioTipoDeProducto>();


            kernel.Bind<IRepositorioMarca>().To<RepositorioMarca>();
            kernel.Bind<IServicioMarca>().To<ServicioMarca>();


            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(VeterinariaDbContext)).ToSelf().InRequestScope();
        }
    }
}