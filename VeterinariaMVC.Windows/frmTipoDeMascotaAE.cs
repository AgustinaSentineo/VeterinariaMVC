using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaMVC.Windows
{
    public partial class frmTipoDeMascotaAE : Form
    {
        public frmTipoDeMascotaAE()
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

        private TipoDeMascotaEditDto tipoEditDto;
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
                    tipoEditDto = new TipoDeMascotaEditDto();
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

        public TipoDeMascotaEditDto GetTipo()
        {
            return tipoEditDto;
        }

        public void SetTipo(TipoDeMascotaEditDto tipoEditDto)
        {
            this.tipoEditDto = tipoEditDto;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
