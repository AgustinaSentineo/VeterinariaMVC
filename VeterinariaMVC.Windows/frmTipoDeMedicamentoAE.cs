﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaMVC.Entidades.DTOs.TipoDeMedicamento;

namespace VeterinariaMVC.Windows
{
    public partial class frmTipoDeMedicamentoAE : Form
    {
        public frmTipoDeMedicamentoAE()
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

        private TipoDeMedicamentoEditDto tipoEditDto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoEditDto != null)
            {
                txtTipMed.Text = tipoEditDto.Descripcion;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoEditDto == null)
                {
                    tipoEditDto = new TipoDeMedicamentoEditDto();
                }

                tipoEditDto.Descripcion = txtTipMed.Text;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipMed.Text.Trim())
                && string.IsNullOrWhiteSpace(txtTipMed.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipMed, "El dato es requerido");
            }

            return valido;
        }

        public void Titulo(string title)
        {
            lbTitle.Text = title;
        }

        public TipoDeMedicamentoEditDto GetTipo()
        {
            return tipoEditDto;
        }

        public void SetTipo(TipoDeMedicamentoEditDto tipoEditDto)
        {
            this.tipoEditDto = tipoEditDto;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
