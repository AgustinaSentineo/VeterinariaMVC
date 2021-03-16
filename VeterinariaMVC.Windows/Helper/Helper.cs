using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;
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
    }
}
