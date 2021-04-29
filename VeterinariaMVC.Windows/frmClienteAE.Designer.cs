
namespace VeterinariaMVC.Windows
{
    partial class frmClienteAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.mcbProvincia = new MetroFramework.Controls.MetroComboBox();
            this.txtNombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtApellido = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mcbTipo = new MetroFramework.Controls.MetroComboBox();
            this.txtNroDoc = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mcbLocalidad = new MetroFramework.Controls.MetroComboBox();
            this.txtAltura = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCalle = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCel = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelFjo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.MediumPurple;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 20;
            this.lineShape1.X2 = 646;
            this.lineShape1.Y1 = 33;
            this.lineShape1.Y2 = 33;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(692, 535);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(363, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Seleccione una Provincia:";
            // 
            // mcbProvincia
            // 
            this.mcbProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbProvincia.FormattingEnabled = true;
            this.mcbProvincia.ItemHeight = 23;
            this.mcbProvincia.Location = new System.Drawing.Point(367, 85);
            this.mcbProvincia.Name = "mcbProvincia";
            this.mcbProvincia.Size = new System.Drawing.Size(247, 29);
            this.mcbProvincia.TabIndex = 32;
            this.mcbProvincia.SelectedIndexChanged += new System.EventHandler(this.mcbProvincia_SelectedIndexChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Depth = 0;
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Hint = "Ingrese el nombre";
            this.txtNombre.Location = new System.Drawing.Point(64, 85);
            this.txtNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.Size = new System.Drawing.Size(247, 23);
            this.txtNombre.TabIndex = 31;
            this.txtNombre.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.MediumPurple;
            this.lbTitle.Location = new System.Drawing.Point(60, 8);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(43, 22);
            this.lbTitle.TabIndex = 29;
            this.lbTitle.Text = "Title";
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnCancelar.Location = new System.Drawing.Point(64, 493);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(550, 32);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnAceptar.Location = new System.Drawing.Point(64, 455);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(550, 32);
            this.btnAceptar.TabIndex = 27;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Depth = 0;
            this.txtApellido.ForeColor = System.Drawing.Color.White;
            this.txtApellido.Hint = "Ingrese el apellido";
            this.txtApellido.Location = new System.Drawing.Point(64, 145);
            this.txtApellido.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PasswordChar = '\0';
            this.txtApellido.SelectedText = "";
            this.txtApellido.SelectionLength = 0;
            this.txtApellido.SelectionStart = 0;
            this.txtApellido.Size = new System.Drawing.Size(247, 23);
            this.txtApellido.TabIndex = 35;
            this.txtApellido.UseSystemPasswordChar = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(60, 121);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(73, 20);
            this.label.TabIndex = 34;
            this.label.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(60, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Seleccione un Tipo de Documento:";
            // 
            // mcbTipo
            // 
            this.mcbTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbTipo.FormattingEnabled = true;
            this.mcbTipo.ItemHeight = 23;
            this.mcbTipo.Location = new System.Drawing.Point(64, 198);
            this.mcbTipo.Name = "mcbTipo";
            this.mcbTipo.Size = new System.Drawing.Size(260, 29);
            this.mcbTipo.TabIndex = 36;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Depth = 0;
            this.txtNroDoc.ForeColor = System.Drawing.Color.White;
            this.txtNroDoc.Hint = "Ingrese el numero de documento";
            this.txtNroDoc.Location = new System.Drawing.Point(64, 270);
            this.txtNroDoc.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.PasswordChar = '\0';
            this.txtNroDoc.SelectedText = "";
            this.txtNroDoc.SelectionLength = 0;
            this.txtNroDoc.SelectionStart = 0;
            this.txtNroDoc.Size = new System.Drawing.Size(247, 23);
            this.txtNroDoc.TabIndex = 39;
            this.txtNroDoc.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Numero de Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(363, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Seleccione una Localidad:";
            // 
            // mcbLocalidad
            // 
            this.mcbLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbLocalidad.FormattingEnabled = true;
            this.mcbLocalidad.ItemHeight = 23;
            this.mcbLocalidad.Location = new System.Drawing.Point(367, 145);
            this.mcbLocalidad.Name = "mcbLocalidad";
            this.mcbLocalidad.Size = new System.Drawing.Size(247, 29);
            this.mcbLocalidad.TabIndex = 40;
            // 
            // txtAltura
            // 
            this.txtAltura.Depth = 0;
            this.txtAltura.ForeColor = System.Drawing.Color.White;
            this.txtAltura.Hint = "Ingrese la altura";
            this.txtAltura.Location = new System.Drawing.Point(367, 270);
            this.txtAltura.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.PasswordChar = '\0';
            this.txtAltura.SelectedText = "";
            this.txtAltura.SelectionLength = 0;
            this.txtAltura.SelectionStart = 0;
            this.txtAltura.Size = new System.Drawing.Size(247, 23);
            this.txtAltura.TabIndex = 45;
            this.txtAltura.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(363, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Altura:";
            // 
            // txtCalle
            // 
            this.txtCalle.Depth = 0;
            this.txtCalle.ForeColor = System.Drawing.Color.White;
            this.txtCalle.Hint = "Ingrese la calle";
            this.txtCalle.Location = new System.Drawing.Point(367, 210);
            this.txtCalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.PasswordChar = '\0';
            this.txtCalle.SelectedText = "";
            this.txtCalle.SelectionLength = 0;
            this.txtCalle.SelectionStart = 0;
            this.txtCalle.Size = new System.Drawing.Size(247, 23);
            this.txtCalle.TabIndex = 43;
            this.txtCalle.UseSystemPasswordChar = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(363, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Calle:";
            // 
            // txtCel
            // 
            this.txtCel.Depth = 0;
            this.txtCel.ForeColor = System.Drawing.Color.White;
            this.txtCel.Hint = "Ingrese el numero ";
            this.txtCel.Location = new System.Drawing.Point(64, 337);
            this.txtCel.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCel.Name = "txtCel";
            this.txtCel.PasswordChar = '\0';
            this.txtCel.SelectedText = "";
            this.txtCel.SelectionLength = 0;
            this.txtCel.SelectionStart = 0;
            this.txtCel.Size = new System.Drawing.Size(247, 23);
            this.txtCel.TabIndex = 49;
            this.txtCel.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(60, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Numero Celular:";
            // 
            // txtTelFjo
            // 
            this.txtTelFjo.Depth = 0;
            this.txtTelFjo.ForeColor = System.Drawing.Color.White;
            this.txtTelFjo.Hint = "Ingrese el numero";
            this.txtTelFjo.Location = new System.Drawing.Point(367, 339);
            this.txtTelFjo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTelFjo.Name = "txtTelFjo";
            this.txtTelFjo.PasswordChar = '\0';
            this.txtTelFjo.SelectedText = "";
            this.txtTelFjo.SelectionLength = 0;
            this.txtTelFjo.SelectionStart = 0;
            this.txtTelFjo.Size = new System.Drawing.Size(247, 23);
            this.txtTelFjo.TabIndex = 47;
            this.txtTelFjo.UseSystemPasswordChar = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(363, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Telefono Fijo:";
            // 
            // txtEmail
            // 
            this.txtEmail.Depth = 0;
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Hint = "Ingrese el correo electronico";
            this.txtEmail.Location = new System.Drawing.Point(64, 400);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(569, 23);
            this.txtEmail.TabIndex = 51;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(60, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Corrro Electronico:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmClienteAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(692, 535);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTelFjo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mcbLocalidad);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mcbTipo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mcbProvincia);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmClienteAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClienteAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox mcbProvincia;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtApellido;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox mcbTipo;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNroDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroComboBox mcbLocalidad;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAltura;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCalle;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCel;
        private System.Windows.Forms.Label label8;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTelFjo;
        private System.Windows.Forms.Label label9;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}