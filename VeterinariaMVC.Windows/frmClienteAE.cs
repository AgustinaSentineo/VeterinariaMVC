using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Windows
{
    public partial class frmClienteAE : Form
    {
        public frmClienteAE()
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

        private ClienteEditDto clienteEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref mcbProvincia);
            Helper.Helper.CargarComboLocalidad(ref mcbLocalidad);
            Helper.Helper.CargarComboTipoDeDocumento(ref mcbTipo);
            if (clienteEditDto == null)
            {
                return;
            }

            txtNombre.Text = clienteEditDto.Nombre;
            txtApellido.Text = clienteEditDto.Apellido;
            mcbTipo.SelectedValue = clienteEditDto.TipoDeDocumentoId;
            txtNroDoc.Text = clienteEditDto.NroDocumento;
            txtCalle.Text = clienteEditDto.Calle;
            txtAltura.Text = clienteEditDto.Altura;
            txtCel.Text = clienteEditDto.TelefonoMovil;
            txtTelFjo.Text = clienteEditDto.TelefonoFijo;
            txtEmail.Text = clienteEditDto.CorreoElectronico;
            mcbProvincia.SelectedValue = clienteEditDto.ProvinciaId;
            mcbLocalidad.SelectedValue = clienteEditDto.LocalidadId;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clienteEditDto == null)
                {
                    clienteEditDto = new ClienteEditDto();
                }

                clienteEditDto.Nombre= txtNombre.Text;
                clienteEditDto.Apellido = txtApellido.Text;
                clienteEditDto.TipoDeDocumentoId = ((TipoDeDocumentoListDto)mcbTipo.SelectedItem).TipoDeDocumentoId;
                clienteEditDto.NroDocumento = txtNroDoc.Text;
                clienteEditDto.Calle= txtCalle.Text;
                clienteEditDto.Altura= txtAltura.Text;
                clienteEditDto.TelefonoFijo = txtTelFjo.Text;
                clienteEditDto.TelefonoMovil = txtCel.Text;
                clienteEditDto.CorreoElectronico = txtEmail.Text;
                clienteEditDto.ProvinciaId = ((ProvinciaListDto)mcbProvincia.SelectedItem).ProvinciaId;
                clienteEditDto.ProvinciaId = ((LocalidadListDto)mcbLocalidad.SelectedItem).LocalidadId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())
                && string.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El dato es requerido");
            }
            if (string.IsNullOrEmpty(txtApellido.Text.Trim())
             && string.IsNullOrWhiteSpace(txtApellido.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "El dato es requerido");
            }
            if (string.IsNullOrEmpty(txtNroDoc.Text.Trim())
             && string.IsNullOrWhiteSpace(txtNroDoc.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNroDoc, "El dato es requerido");
            }
            if (string.IsNullOrEmpty(txtCalle.Text.Trim())
             && string.IsNullOrWhiteSpace(txtCalle.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCalle, "El dato es requerido");
            }
            if (mcbTipo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbTipo, "Debe seleccionar un tipo de documento");
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

        public ClienteEditDto GetCliente()
        {
            return clienteEditDto;
        }

        public void SetCliente(ClienteEditDto clienteEditDto)
        {
            this.clienteEditDto = clienteEditDto;
        }

        //private ProvinciaListDto provinciaListDto;
        //private LocalidadListDto localidadListDto;
        private void mcbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (mcbProvincia.SelectedIndex > 0)
            //{
            //    provinciaListDto = (ProvinciaListDto)mcbProvincia.SelectedItem;
            //    Helper.Helper.CargarComboLocalidad(ref mcbLocalidad, provinciaListDto);
            //    mcbLocalidad.Enabled = true;
            //}
            //else
            //{
            //    provinciaListDto = null;
            //    mcbLocalidad.DataSource = null;
            //    mcbLocalidad.Enabled = false;
            //}
        }
    }
}
