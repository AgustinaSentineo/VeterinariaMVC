using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Empleado;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entidades.DTOs.TipoDeDocumento;
using VeterinariaMVC.Entidades.DTOs.TipoDeTarea;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Windows
{
    public partial class frmEmpleadoAE : Form
    {
        public frmEmpleadoAE()
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

        private EmpleadoEditDto empleadoEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref mcbProvincia);
            Helper.Helper.CargarComboLocalidad(ref mcbLocalidad);
            Helper.Helper.CargarComboTipoDeDocumento(ref mcbTipo);
            Helper.Helper.CargarComboTipoTarea(ref mcbTarea);
            if (empleadoEditDto == null)
            {
                return;
            }

            txtNombre.Text = empleadoEditDto.Nombre;
            txtApellido.Text = empleadoEditDto.Apellido;
            mcbTipo.SelectedValue = empleadoEditDto.TipoDeDocumentoId;
            txtNroDoc.Text = empleadoEditDto.NroDocumento;
            txtCalle.Text = empleadoEditDto.Calle;
            txtAltura.Text = empleadoEditDto.Altura;
            txtCel.Text = empleadoEditDto.TelefonoMovil;
            txtTelFjo.Text = empleadoEditDto.TelefonoFijo;
            txtEmail.Text = empleadoEditDto.CorreoElectronico;
            mcbTarea.SelectedValue = empleadoEditDto.TipoDeTareaId;
            mcbProvincia.SelectedValue = empleadoEditDto.ProvinciaId;
            mcbLocalidad.SelectedValue = empleadoEditDto.LocalidadId;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (empleadoEditDto == null)
                {
                    empleadoEditDto = new EmpleadoEditDto();
                }

                empleadoEditDto.Nombre = txtNombre.Text;
                empleadoEditDto.Apellido = txtApellido.Text;
                empleadoEditDto.TipoDeDocumentoId = ((TipoDeDocumentoListDto)mcbTipo.SelectedItem).TipoDeDocumentoId;
                empleadoEditDto.NroDocumento = txtNroDoc.Text;
                empleadoEditDto.Calle = txtCalle.Text;
                empleadoEditDto.Altura = txtAltura.Text;
                empleadoEditDto.TelefonoFijo = txtTelFjo.Text;
                empleadoEditDto.TelefonoMovil = txtCel.Text;
                empleadoEditDto.CorreoElectronico = txtEmail.Text;
                empleadoEditDto.TipoDeTareaId = ((TipoDeTareaListDto)mcbTarea.SelectedItem).TipoDeTareaId;
                empleadoEditDto.ProvinciaId = ((ProvinciaListDto)mcbProvincia.SelectedItem).ProvinciaId;
                empleadoEditDto.ProvinciaId = ((LocalidadListDto)mcbLocalidad.SelectedItem).LocalidadId;
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
            if (mcbTarea.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbTarea, "Debe seleccionar un tipo de documento");
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

        public EmpleadoEditDto GetEmpleado()
        {
            return empleadoEditDto;
        }

        public void SetEmpleado(EmpleadoEditDto empleadoEditDto)
        {
            this.empleadoEditDto = empleadoEditDto;
        }
    }
}
