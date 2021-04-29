using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.Cliente;
using VeterinariaMVC.Entidades.DTOs.Mascota;
using VeterinariaMVC.Entidades.DTOs.Raza;
using VeterinariaMVC.Entidades.DTOs.TipoDeMascota;

namespace VeterinariaMVC.Windows
{
    public partial class frmMascotaAE : Form
    {
        public frmMascotaAE()
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

        private MascotaEditDto mascotaEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboCliente(ref mcbDueño);
            Helper.Helper.CargarComboTipoMascotas(ref mcbTipo);
            Helper.Helper.CargarComboRaza(ref mcbRaza);
            if (mascotaEditDto == null)
            {
                return;
            }

            txtNombre.Text = mascotaEditDto.Nombre;
            dtpFecha.Value = mascotaEditDto.FechaDeNacimiento;
            mcbTipo.SelectedValue = mascotaEditDto.TipoDeMascotaId;
            mcbDueño.SelectedValue = mascotaEditDto.ClienteId;
            mcbRaza.SelectedValue = mascotaEditDto.RazaId;
        }
        public MascotaEditDto GetMascota()
        {
            return mascotaEditDto;
        }
        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }
        public void SetMascota(MascotaEditDto mascotaEditDto)
        {
            this.mascotaEditDto = mascotaEditDto;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (mascotaEditDto == null)
                {
                    mascotaEditDto = new MascotaEditDto();
                }

                mascotaEditDto.Nombre = txtNombre.Text;
                mascotaEditDto.FechaDeNacimiento = dtpFecha.Value;
                mascotaEditDto.TipoDeMascotaId = ((TipoDeMascotaListDto)mcbTipo.SelectedItem).TipoDeMascotaId;
                mascotaEditDto.ClienteId = ((ClienteListDto)mcbDueño.SelectedItem).ClienteId;
                mascotaEditDto.RazaId = ((RazaListDto)mcbRaza.SelectedItem).RazaId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text.Trim())
                && string.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El dato es requerido");
            }
            if (mcbTipo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbTipo, "Debe seleccionar un tipo de mascota");
            }
            if (mcbDueño.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbDueño, "Debe seleccionar un Dueño");
            }
            if (mcbRaza.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(mcbRaza, "Debe seleccionar una raza");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
