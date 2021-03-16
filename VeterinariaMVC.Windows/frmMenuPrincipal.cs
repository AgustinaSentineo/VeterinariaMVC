using System;
using System.Windows.Forms;
using VeterinariaMVC.Servicios.Servicios.Facades;
using VeterinariaMVC.Windows.Ninject;
using VeterinariaMVC.Windows.Properties;

namespace VeterinariaMVC.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnTipoDeDocumentos_Click(object sender, EventArgs e)
        {
            frmTipoDeDocumento frm = DI.Create<frmTipoDeDocumento>();
            AbrirFormInPanel(frm);
        }

        private void btnTipoDeMascotas_Click(object sender, EventArgs e)
        {
            frmTipoDeMascota frm = DI.Create<frmTipoDeMascota>();
            AbrirFormInPanel(frm);
        }

        private void btnTipoDeMedicamentos_Click(object sender, EventArgs e)
        {
            frmTipoDeMedicamento frm = DI.Create<frmTipoDeMedicamento>();
            AbrirFormInPanel(frm);
        }

        private void btnFormaFarmaceutica_Click(object sender, EventArgs e)
        {
            frmFormaFarmaceutica frm = DI.Create<frmFormaFarmaceutica>();
            AbrirFormInPanel(frm);
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            frmLaboratorio frm = DI.Create<frmLaboratorio>();
            AbrirFormInPanel(frm);
        }

        private void btnProvincias_Click(object sender, EventArgs e)
        {
            frmProvincia frm = DI.Create<frmProvincia>();
            AbrirFormInPanel(frm);
        }

        private void btnClasificacion_Click(object sender, EventArgs e)
        {
            frmClasificacion frm = DI.Create<frmClasificacion>();
            AbrirFormInPanel(frm);
        }

        private void btnNecesidadesEspeciales_Click(object sender, EventArgs e)
        {
            frmNecesidadEspecial frm = DI.Create<frmNecesidadEspecial>();
            AbrirFormInPanel(frm);
        }

        private void btnTipoDeAlimentos_Click(object sender, EventArgs e)
        {
            frmTipoDeAlimento frm = DI.Create<frmTipoDeAlimento>();
            AbrirFormInPanel(frm);
        }
        private void btnTipoDeTarea_Click(object sender, EventArgs e)
        {
            frmTipoDeTarea frm = DI.Create<frmTipoDeTarea>();
            AbrirFormInPanel(frm);
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarca frm = DI.Create<frmMarca>();
            AbrirFormInPanel(frm);
        }

        private void btnTipoDeProductos_Click(object sender, EventArgs e)
        {
            frmTipoDeProducto frm = DI.Create<frmTipoDeProducto>();
            AbrirFormInPanel(frm);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            frmLocalidad frm = DI.Create<frmLocalidad>();
            AbrirFormInPanel(frm);
        }

        private void CerrarSubsMenu()
        {
            if (plMascotas.Visible == true)
                plMascotas.Visible = false;
            if (plGralEmpleados.Visible == true)
                plGralEmpleados.Visible = false;
            if (plGralMeds.Visible == true)
                plGralMeds.Visible = false;
            if (plTienda.Visible == true)
                plTienda.Visible = false;
            if (plGralAlimentos.Visible == true)
                plGralAlimentos.Visible = false;
            if (plTransacciones.Visible == true)
                plTransacciones.Visible = false;
        }

        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                CerrarSubsMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnGralMascotas_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(plMascotas);
            if (plMascotas.Visible == true)
            {
                btnGralMascotas.Image = Resources.FlechaArriba;
            }
            else
            {
                btnGralMascotas.Image = Resources.Abajo;
            }

        }

        private void btnGralEmpleados_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(plGralEmpleados);
            if (plGralEmpleados.Visible == true)
            {
                btnGralEmpleados.Image = Resources.FlechaArriba;
            }
            else
            {
                btnGralEmpleados.Image = Resources.Abajo;
            }
        }

        private void btnGralMeds_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(plGralMeds);
            if (plGralMeds.Visible == true)
            {
                btnGralMeds.Image = Resources.FlechaArriba;
            }
            else
            {
                btnGralMeds.Image = Resources.Abajo;
            }
        }

        private void btnTienda_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(plTienda);
            if (plTienda.Visible == true)
            {
                btnTienda.Image = Resources.FlechaArriba;
            }
            else
            {
                btnTienda.Image = Resources.Abajo;
            }
        }

        private void btnGralAlimentos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(plGralAlimentos);
            if (plGralAlimentos.Visible == true)
            {
                btnGralAlimentos.Image = Resources.FlechaArriba;
            }
            else
            {
                btnGralAlimentos.Image = Resources.Abajo;
            }
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(plTransacciones);
            if (plTransacciones.Visible == true)
            {
                btnTransacciones.Image = Resources.FlechaArriba;
            }
            else
            {
                btnTransacciones.Image = Resources.Abajo;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.plContenedor.Controls.Count > 0)
                this.plContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.plContenedor.Controls.Add(fh);
            this.plContenedor.Tag = fh;
            fh.Show();
        }

    }
}
