using System;
using System.Windows.Forms;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Windows
{
    public partial class frmProvinciasAE : Form
    {
        public frmProvinciasAE()
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

        private ProvinciaEditDto provinciaEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provinciaEditDto != null)
            {
                txtProvincia.Text = provinciaEditDto.NombreProvincia;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provinciaEditDto == null)
                {
                    provinciaEditDto = new ProvinciaEditDto();
                }

                provinciaEditDto.NombreProvincia = txtProvincia.Text;
                 DialogResult = DialogResult.OK;
             
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProvincia.Text.Trim())
                && string.IsNullOrWhiteSpace(txtProvincia.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public ProvinciaEditDto GetProvincia()
        {
            return provinciaEditDto;
        }

        public void SetProvincia(ProvinciaEditDto provinciaEditDto)
        {
            this.provinciaEditDto = provinciaEditDto;
        }
    }
}
