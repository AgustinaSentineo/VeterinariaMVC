using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Clasificacion;

namespace VeterinariaMVC.Windows
{
    public partial class frmClasificacionAE : Form
    {
        public frmClasificacionAE()
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

        private ClasificacionEditDto clasificacionEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (clasificacionEditDto != null)
            {
                txtClasificacion.Text = clasificacionEditDto.Descripcion;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clasificacionEditDto == null)
                {
                    clasificacionEditDto = new ClasificacionEditDto();
                }

                clasificacionEditDto.Descripcion = txtClasificacion.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtClasificacion.Text.Trim())
                && string.IsNullOrWhiteSpace(txtClasificacion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtClasificacion, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public ClasificacionEditDto GetClasificacion()
        {
            return clasificacionEditDto;
        }

        public void SetClasificacion(ClasificacionEditDto clasificacionEditDto)
        {
            this.clasificacionEditDto = clasificacionEditDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
