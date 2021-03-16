using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Localidad;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Windows
{
    public partial class frmLocalidadAE : Form
    {
        public frmLocalidadAE()
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

        private LocalidadEditDto localidadEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincias(ref mcbProvincia);
            if (localidadEditDto != null)
            {
                txtLocalidad.Text = localidadEditDto.NombreLocalidad;
                mcbProvincia.SelectedValue = localidadEditDto.ProvinciaId;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidadEditDto == null)
                {
                    localidadEditDto = new LocalidadEditDto();
                }

                localidadEditDto.NombreLocalidad = txtLocalidad.Text;
                localidadEditDto.ProvinciaId = ((ProvinciaListDto)mcbProvincia.SelectedItem).ProvinciaId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLocalidad.Text.Trim())
                && string.IsNullOrWhiteSpace(txtLocalidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad, "El dato es requerido");
            }
            if (mcbProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbProvincia, "Debe seleccionar una provincia");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public LocalidadEditDto GetLocalidad()
        {
            return localidadEditDto;
        }

        public void SetLocalidad(LocalidadEditDto localidadEditDto)
        {
            this.localidadEditDto = localidadEditDto;
        }

    }
}
