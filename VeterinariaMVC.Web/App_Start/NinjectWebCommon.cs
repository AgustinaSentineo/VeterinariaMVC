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
            kernel.Bind<IRepositorioProducto>().To<RepositorioProducto>().InRequestScope();
            kernel.Bind<IServicioProducto>().To<ServicioProducto>().InRequestScope();

            kernel.Bind<IServicioCliente>().To<ServicioCliente>().InRequestScope();
            kernel.Bind<IRepositorioCliente>().To<RepositorioCliente>().InRequestScope();

            kernel.Bind<IServicioEmpleado>().To<ServicioEmpleado>().InRequestScope();
            kernel.Bind<IRepositorioEmpleado>().To<RepositorioEmpleado>().InRequestScope();

            kernel.Bind<IServicioMascota>().To<ServicioMascota>().InRequestScope();
            kernel.Bind<IRepositorioMascota>().To<RepositorioMascota>().InRequestScope();

            kernel.Bind<IServicioProveedor>().To<ServicioProveedor>().InRequestScope();
            kernel.Bind<IRepositorioProveedor>().To<RepositorioProveedor>().InRequestScope();

            kernel.Bind<IServicioRaza>().To<ServicioRaza>().InRequestScope();
            kernel.Bind<IRepositorioRaza>().To<RepositorioRaza>().InRequestScope();

            kernel.Bind<IServicioLocalidad>().To<ServicioLocalidad>().InRequestScope();
            kernel.Bind<IRepositorioLocalidad>().To<RepositorioLocalidad>().InRequestScope();

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

            kernel.Bind<IServicioMedicamento>().To<ServicioMedicamento>().InRequestScope();
            kernel.Bind<IRepositorioMedicamento>().To<RepositorioMedicamento>().InRequestScope();

            kernel.Bind<IServicioTipoDeMedicamento>().To<ServicioTipoDeMedicamento>().InRequestScope();
            kernel.Bind<IRepositorioTipoDeMedicamento>().To<RepositorioTipoDeMedicamento>().InRequestScope();


            kernel.Bind<IRepositorioTipoDeTarea>().To<RepositorioTipoDeTarea>().InRequestScope();
            kernel.Bind<IServicioTipoDeTarea>().To<ServicioTipoDeTarea>().InRequestScope();


            kernel.Bind<IRepositorioTipoDeProducto>().To<RepositorioTipoDeProducto>().InRequestScope();
            kernel.Bind<IServicioTipoDeProducto>().To<ServicioTipoDeProducto>().InRequestScope();


            kernel.Bind<IRepositorioMarca>().To<RepositorioMarca>().InRequestScope();
            kernel.Bind<IServicioMarca>().To<ServicioMarca>().InRequestScope();

            kernel.Bind<IRepositorioNecesidadEspecial>().To<RepositorioNecesidadEspecial>().InRequestScope();
            kernel.Bind<IServicioNecesidadEspecial>().To<ServicioNecesidadEspecial>().InRequestScope();

            kernel.Bind<IRepositorioClasificacion>().To<RepositorioClasificacion>().InRequestScope();
            kernel.Bind<IServicioClasificacion>().To<ServicioClasificacion>().InRequestScope();

            kernel.Bind<IRepositorioTipoDeAlimento>().To<RepositorioTipoDeAlimento>().InRequestScope();
            kernel.Bind<IServicioTipoDeAlimento>().To<ServicioTipoDeAlimento>().InRequestScope();

            kernel.Bind<IRepositorioAlimento>().To<RepositorioAlimento>().InRequestScope();
            kernel.Bind<IServicioAlimento>().To<ServicioAlimento>().InRequestScope();


            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(VeterinariaDbContext)).ToSelf().InRequestScope();
        }
    }
}