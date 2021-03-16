using System;
using System.Windows.Forms;
using VeterinariaMVC.Entities.DTOs.Provincia;

namespace VeterinariaMVC.Windows
{
    public partial class frmBuscarLocalidad : Form
    {
        public frmBuscarLocalidad()
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

        private void frmBuscarLocalidad_Load(object sender, EventArgs e)
        {
            Helper.Helper.CargarComboProvincias(ref mcbProvincia);
        }

        private ProvinciaListDto provinciaDto;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                provinciaDto = mcbProvincia.SelectedItem as ProvinciaListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (mcbProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbProvincia, "Debe seleccionar un tipo");
            }

            return valido;
        }

        public ProvinciaListDto GetProvincia()
        {
            return provinciaDto;
        }
    }
}
