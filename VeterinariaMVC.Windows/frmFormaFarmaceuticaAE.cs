using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.FormaFarmaceutica;

namespace VeterinariaMVC.Windows
{
    public partial class frmFormaFarmaceuticaAE : Form
    {
        public frmFormaFarmaceuticaAE()
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

        private FormaFarmaceuticaEditDto formaEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (formaEditDto != null)
            {
                txtForma.Text = formaEditDto.Descripcion;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formaEditDto == null)
                {
                    formaEditDto = new FormaFarmaceuticaEditDto();
                }

                formaEditDto.Descripcion = txtForma.Text;
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
            if (string.IsNullOrEmpty(txtForma.Text.Trim())
                && string.IsNullOrWhiteSpace(txtForma.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtForma, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public FormaFarmaceuticaEditDto GetForma()
        {
            return formaEditDto;
        }

        public void SetForma(FormaFarmaceuticaEditDto formaEditDto)
        {
            this.formaEditDto = formaEditDto;
        }
    }
}
