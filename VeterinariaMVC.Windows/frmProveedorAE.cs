using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.DTOs.Proveedor;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Windows
{
    public partial class frmProveedorAE : Form
    {
        public frmProveedorAE()
        {
            InitializeComponent();
            Estilo();
        }

        private void Estilo()
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.DeepPurple300, MaterialSkin.Primary.Purple100, MaterialSkin.Primary.Purple100, MaterialSkin.Accent.Purple100, MaterialSkin.TextShade.WHITE);
        }

        private ProveedorEditDto proveedorEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref mcbProvincia);
            Helper.Helper.CargarComboLocalidad(ref mcbLocalidad);
            if (proveedorEditDto == null)
            {
                return;
            }

            txtCUIT.Text = proveedorEditDto.CUIT;
            txtRazonSocial.Text = proveedorEditDto.RazonSocial;
            txtContacto.Text = proveedorEditDto.PersonaDeContacto;
            txtCalle.Text = proveedorEditDto.Calle;
            txtAltura.Text = proveedorEditDto.Altura;
            txtCel.Text = proveedorEditDto.TelefonoMovil;
            txtTelFjo.Text = proveedorEditDto.TelefonoFijo;
            txtEmail.Text = proveedorEditDto.CorreoElectronico;
            mcbProvincia.SelectedValue = proveedorEditDto.ProvinciaId;
            mcbLocalidad.SelectedValue = proveedorEditDto.LocalidadId;
        }

        public ProveedorEditDto GetProveedor()
        {
            return proveedorEditDto;
        }

        public void SetProveedor(ProveedorEditDto proveedorEditDto)
        {
            this.proveedorEditDto = proveedorEditDto;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                if (proveedorEditDto == null)
                {
                    proveedorEditDto = new ProveedorEditDto();
                }

                proveedorEditDto.CUIT= txtCUIT.Text;
                proveedorEditDto.RazonSocial = txtRazonSocial.Text;
                proveedorEditDto.PersonaDeContacto = txtContacto.Text;
                proveedorEditDto.Calle = txtCalle.Text;
                proveedorEditDto.Altura = txtAltura.Text;
                proveedorEditDto.TelefonoFijo = txtTelFjo.Text;
                proveedorEditDto.TelefonoMovil = txtCel.Text;
                proveedorEditDto.CorreoElectronico = txtEmail.Text;
                proveedorEditDto.ProvinciaId = ((ProvinciaListDto)mcbProvincia.SelectedItem).ProvinciaId;
                proveedorEditDto.ProvinciaId = ((LocalidadListDto)mcbLocalidad.SelectedItem).LocalidadId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCUIT.Text.Trim())
                && string.IsNullOrWhiteSpace(txtCUIT.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCUIT, "El dato es requerido");
            }
            if (string.IsNullOrEmpty(txtRazonSocial.Text.Trim())
             && string.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtRazonSocial, "El dato es requerido");
            }
            if (string.IsNullOrEmpty(txtContacto.Text.Trim())
             && string.IsNullOrWhiteSpace(txtContacto.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtContacto, "El dato es requerido");
            }
            if (string.IsNullOrEmpty(txtCalle.Text.Trim())
             && string.IsNullOrWhiteSpace(txtCalle.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCalle, "El dato es requerido");
            }
            if (mcbProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbProvincia, "Debe seleccionar una provincia");
            }
            if (mcbLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbLocalidad, "Debe seleccionar una localidad");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
