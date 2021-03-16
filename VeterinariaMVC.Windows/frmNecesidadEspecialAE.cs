using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.NecesidadEspecial;

namespace VeterinariaMVC.Windows
{
    public partial class frmNecesidadEspecialAE : Form
    {
        public frmNecesidadEspecialAE()
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

        private NecesidadEspecialEditDto necesidadEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (necesidadEditDto != null)
            {
                txtNe.Text = necesidadEditDto.Descripcion;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (necesidadEditDto == null)
                {
                    necesidadEditDto = new NecesidadEspecialEditDto();
                }

                necesidadEditDto.Descripcion = txtNe.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNe.Text.Trim())
                && string.IsNullOrWhiteSpace(txtNe.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNe, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public NecesidadEspecialEditDto GetNecesidadESpecial()
        {
            return necesidadEditDto;
        }

        public void SetNecesidadEspecial(NecesidadEspecialEditDto necesidadEditDto)
        {
            this.necesidadEditDto = necesidadEditDto;
        }
    }
}
