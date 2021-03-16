using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaMVC.Windows
{
    public partial class frmRazaAE : Form
    {
        public frmRazaAE()
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

        private RazaEditDto razaEditDto;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboTipoMascotas(ref mcbTipo);
            if (razaEditDto != null)
            {
                txtRaza.Text = razaEditDto.Descripcion;
                mcbTipo.SelectedValue = razaEditDto.TipoDeMascotaId;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                if (razaEditDto == null)
                {
                    razaEditDto = new RazaEditDto();
                }

                razaEditDto.Descripcion = txtRaza.Text;
                razaEditDto.TipoDeMascotaId = ((TipoDeMascotaListDto)mcbTipo.SelectedItem).TipoDeMascotaId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtRaza.Text.Trim())
                && string.IsNullOrWhiteSpace(txtRaza.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtRaza, "El dato es requerido");
            }
            if (mcbTipo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbTipo, "Debe seleccionar una tipo de mascota");
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

        public RazaEditDto GetRaza()
        {
            return razaEditDto;
        }

        public void SetRaza(RazaEditDto razaEditDto)
        {
            this.razaEditDto = razaEditDto;
        }
    }
}
