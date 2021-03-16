using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VeterinariaMVC.Windows
{
    public partial class frmMessageBox : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
    );

        public frmMessageBox()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public void ShowError(string title, string info)
        {
            lbTitle.Text = title;
            lblInfo.Text = info;
            btnAceptar.Visible = true;
            btnNo.Visible = false;
            btnOk.Visible = false;
            pbIcono.Image = Properties.Resources.Error;
        }

        public void ShowInfo(string title, string info)
        {
            lbTitle.Text = title;
            lblInfo.Text = info;
            btnAceptar.Visible = true;
            btnNo.Visible = false;
            btnOk.Visible = false;
            pbIcono.Image = Properties.Resources.Informacion;
        }

        public void ShowQuestion(string title, string info)
        {
            lbTitle.Text = title;
            lblInfo.Text = info;
            btnAceptar.Visible = false;
            btnNo.Visible = true;
            btnOk.Visible = true;
            pbIcono.Image = Properties.Resources.Question;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
}
