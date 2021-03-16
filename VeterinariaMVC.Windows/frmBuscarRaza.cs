using System;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaMVC.Windows
{
    public partial class frmBuscarRaza : Form
    {
        public frmBuscarRaza()
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
        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private TipoDeMascotaListDto tipoDto;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoDto = mcbTipo.SelectedItem as TipoDeMascotaListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (mcbTipo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbTipo, "Debe seleccionar un tipo");
            }

            return valido;
        }

        public TipoDeMascotaListDto GetTipo()
        {
            return tipoDto;
        }
        private void frmBuscarRaza_Load(object sender, EventArgs e)
        {
            Helper.Helper.CargarComboTipoMascotas(ref mcbTipo);
        }
    }
}
