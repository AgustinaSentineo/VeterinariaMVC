using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Marca;

namespace VeterinariaMVC.Windows
{
    public partial class frmMarcaAE : Form
    {
        public frmMarcaAE()
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

        private MarcaEditDto marcaEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (marcaEditDto != null)
            {
                txtMarca.Text = marcaEditDto.Nombre;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (marcaEditDto == null)
                {
                    marcaEditDto = new MarcaEditDto();
                }

                marcaEditDto.Nombre = txtMarca.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtMarca.Text.Trim())
                && string.IsNullOrWhiteSpace(txtMarca.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtMarca, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public MarcaEditDto GetMarca()
        {
            return marcaEditDto;
        }

        public void SetMarca(MarcaEditDto marcaEditDto)
        {
            this.marcaEditDto = marcaEditDto;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
