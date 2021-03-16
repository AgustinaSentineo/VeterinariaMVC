using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.TipoDeAlimento;

namespace VeterinariaMVC.Windows
{
    public partial class frmTipoDeAlimentoAE : Form
    {
        public frmTipoDeAlimentoAE()
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

        private TipoDeAlimentoEditDto tipoEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoEditDto != null)
            {
                txtTipo.Text = tipoEditDto.Descripcion;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoEditDto == null)
                {
                    tipoEditDto = new TipoDeAlimentoEditDto();
                }

                tipoEditDto.Descripcion = txtTipo.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipo.Text.Trim())
                && string.IsNullOrWhiteSpace(txtTipo.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipo, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public TipoDeAlimentoEditDto GetTipo()
        {
            return tipoEditDto;
        }

        public void SetTipo(TipoDeAlimentoEditDto tipoEditDto)
        {
            this.tipoEditDto = tipoEditDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
