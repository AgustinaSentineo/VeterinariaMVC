using MetroFramework.Controls;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entities.DTOs.Provincia;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;

namespace VeterinariaMVC.Windows.Helper
{
    public class Helper
    {       
        public static void CargarComboProvincias(ref MetroComboBox cbo)
        {
            IServicioProvincia serviceProvincia = DI.Create<IServicioProvincia>();
            var listaProvincia = serviceProvincia.GetLista();
            var defaultProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione una Provincia>"
            };
            listaProvincia.Insert(0, defaultProvincia);
            cbo.DataSource = listaProvincia;
            cbo.ValueMember = "ProvinciaId";
            cbo.DisplayMember = "NombreProvincia";           
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboTipoMascotas(ref MetroComboBox cbo)
        {
            IServicioTipoDeMascota serviceTipo = DI.Create<IServicioTipoDeMascota>();
            var listaMascota = serviceTipo.GetTipoDeMascota();
            var defaultMascota = new TipoDeMascotaListDto
            {
                TipoDeMascotaId = 0,
                Descripcion = "<Seleccione un Tipo de Mascota>"
            };
            listaMascota.Insert(0, defaultMascota);
            cbo.DataSource = listaMascota;
            cbo.ValueMember = "TipoDeMascotaId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboTipoTarea(ref MetroComboBox cbo)
        {
            IServicioTipoDeTarea serviceTipo = DI.Create<IServicioTipoDeTarea>();
            var listaTarea = serviceTipo.GetLista();
            var defaultTarea = new TipoDeTareaListDto
            {
                TipoDeTareaId = 0,
                Descripcion = "<Seleccione un Tipo de Tarea>"
            };
            listaTarea.Insert(0, defaultTarea);
            cbo.DataSource = listaTarea;
            cbo.ValueMember = "TipoDeTareaId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboLocalidad(ref MetroComboBox cbo)
        {
            IServicioLocalidad serviceLocalidad = DI.Create<IServicioLocalidad>();
            var listaLocalidad = serviceLocalidad.GetLista(null);
            var defaultLocalidad = new LocalidadListDto
            {
                LocalidadId = 0,
                NombreLocalidad = "<Seleccione una Localidad>"
            };
            listaLocalidad.Insert(0, defaultLocalidad);
            cbo.DataSource = listaLocalidad;
            cbo.ValueMember = "LocalidadId";
            cbo.DisplayMember = "NombreLocalidad";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboTipoDeDocumento(ref MetroComboBox cbo)
        {
            IServicioTipoDeDocumento serviceTipoDeDocumento = DI.Create<IServicioTipoDeDocumento>();
            var listaTipoDeDocumento = serviceTipoDeDocumento.GetTipoDeDocumento();
            var defaultTipoDeDocumento = new TipoDeDocumentoListDto
            {
                TipoDeDocumentoId = 0,
                Descripcion = "<Seleccione un Tipo de Documento>"
            };
            listaTipoDeDocumento.Insert(0, defaultTipoDeDocumento);
            cbo.DataSource = listaTipoDeDocumento;
            cbo.ValueMember = "TipoDeDocumentoId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboCliente(ref MetroComboBox cbo)
        {
            IServicioCliente serviceCliente = DI.Create<IServicioCliente>();
            var listaCliente = serviceCliente.GetLista();
            var clienteListDto = new ClienteListDto
            {
                ClienteId = 0,
                Nombre = "<Seleccione un Cliente>"
            };
            listaCliente.Insert(0, clienteListDto);
            cbo.DataSource = listaCliente;
            cbo.ValueMember = "ClienteId";
            cbo.DisplayMember = "NombreCompleto";         
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboRaza(ref MetroComboBox cbo)
        {
            IServicioRaza serviceRaza = DI.Create<IServicioRaza>();
            var listaRaza = serviceRaza.GetLista(null);
            var razaListDto = new RazaListDto
            {
                RazaId = 0,
                Descripcion = "<Seleccione una Raza>"
            };
            listaRaza.Insert(0, razaListDto);
            cbo.DataSource = listaRaza;
            cbo.ValueMember = "RazaId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }
    }
}
