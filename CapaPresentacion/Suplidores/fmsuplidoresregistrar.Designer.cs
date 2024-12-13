namespace CapaPresentacion.Suplidores
{
    partial class fmsuplidoresregistrar
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
            this.btnAbrirFormularioGestion = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboManejaComprobantes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegistrar = new Guna.UI2.WinForms.Guna2Button();
            this.txtdireccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttelefono = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtsuplidor = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrirFormularioGestion
            // 
            this.btnAbrirFormularioGestion.Animated = true;
            this.btnAbrirFormularioGestion.BorderRadius = 3;
            this.btnAbrirFormularioGestion.CheckedState.Parent = this.btnAbrirFormularioGestion;
            this.btnAbrirFormularioGestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirFormularioGestion.CustomImages.Parent = this.btnAbrirFormularioGestion;
            this.btnAbrirFormularioGestion.Font = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.btnAbrirFormularioGestion.ForeColor = System.Drawing.Color.White;
            this.btnAbrirFormularioGestion.HoverState.Parent = this.btnAbrirFormularioGestion;
            this.btnAbrirFormularioGestion.Location = new System.Drawing.Point(206, 19);
            this.btnAbrirFormularioGestion.Name = "btnAbrirFormularioGestion";
            this.btnAbrirFormularioGestion.ShadowDecoration.Parent = this.btnAbrirFormularioGestion;
            this.btnAbrirFormularioGestion.Size = new System.Drawing.Size(142, 31);
            this.btnAbrirFormularioGestion.TabIndex = 14;
            this.btnAbrirFormularioGestion.Text = "Gestión de suplidores";
            this.btnAbrirFormularioGestion.Click += new System.EventHandler(this.btnAbrirFormularioGestion_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(12, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Registrar suplidores";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboManejaComprobantes);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Controls.Add(this.txtdireccion);
            this.panel1.Controls.Add(this.txttelefono);
            this.panel1.Controls.Add(this.txtsuplidor);
            this.panel1.Location = new System.Drawing.Point(6, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1290, 400);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(588, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Maneja comprobantes";
            // 
            // cboManejaComprobantes
            // 
            this.cboManejaComprobantes.Animated = true;
            this.cboManejaComprobantes.BackColor = System.Drawing.Color.Transparent;
            this.cboManejaComprobantes.BorderRadius = 4;
            this.cboManejaComprobantes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboManejaComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManejaComprobantes.FocusedColor = System.Drawing.Color.Empty;
            this.cboManejaComprobantes.FocusedState.Parent = this.cboManejaComprobantes;
            this.cboManejaComprobantes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboManejaComprobantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboManejaComprobantes.FormattingEnabled = true;
            this.cboManejaComprobantes.HoverState.Parent = this.cboManejaComprobantes;
            this.cboManejaComprobantes.ItemHeight = 26;
            this.cboManejaComprobantes.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cboManejaComprobantes.ItemsAppearance.Parent = this.cboManejaComprobantes;
            this.cboManejaComprobantes.Location = new System.Drawing.Point(778, 119);
            this.cboManejaComprobantes.Name = "cboManejaComprobantes";
            this.cboManejaComprobantes.ShadowDecoration.Parent = this.cboManejaComprobantes;
            this.cboManejaComprobantes.Size = new System.Drawing.Size(318, 32);
            this.cboManejaComprobantes.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(38, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(696, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(46, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Animated = true;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(156)))), ((int)(((byte)(165)))));
            this.btnCancelar.BorderRadius = 4;
            this.btnCancelar.BorderThickness = 1;
            this.btnCancelar.CheckedState.Parent = this.btnCancelar;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.CustomImages.Parent = this.btnCancelar;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(156)))), ((int)(((byte)(165)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.HoverState.Parent = this.btnCancelar;
            this.btnCancelar.Location = new System.Drawing.Point(950, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShadowDecoration.Parent = this.btnCancelar;
            this.btnCancelar.Size = new System.Drawing.Size(147, 33);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Animated = true;
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(156)))), ((int)(((byte)(165)))));
            this.btnRegistrar.BorderRadius = 4;
            this.btnRegistrar.BorderThickness = 1;
            this.btnRegistrar.CheckedState.Parent = this.btnRegistrar;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.CustomImages.Parent = this.btnRegistrar;
            this.btnRegistrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(156)))), ((int)(((byte)(165)))));
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.HoverState.Parent = this.btnRegistrar;
            this.btnRegistrar.Location = new System.Drawing.Point(787, 199);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.ShadowDecoration.Parent = this.btnRegistrar;
            this.btnRegistrar.Size = new System.Drawing.Size(147, 33);
            this.btnRegistrar.TabIndex = 10;
            this.btnRegistrar.Text = "Registrrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtdireccion
            // 
            this.txtdireccion.BorderRadius = 4;
            this.txtdireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdireccion.DefaultText = "";
            this.txtdireccion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdireccion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdireccion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdireccion.DisabledState.Parent = this.txtdireccion;
            this.txtdireccion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdireccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdireccion.FocusedState.Parent = this.txtdireccion;
            this.txtdireccion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdireccion.HoverState.Parent = this.txtdireccion;
            this.txtdireccion.Location = new System.Drawing.Point(127, 119);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.PasswordChar = '\0';
            this.txtdireccion.PlaceholderText = "";
            this.txtdireccion.SelectedText = "";
            this.txtdireccion.ShadowDecoration.Parent = this.txtdireccion;
            this.txtdireccion.Size = new System.Drawing.Size(318, 63);
            this.txtdireccion.TabIndex = 6;
            // 
            // txttelefono
            // 
            this.txttelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttelefono.BorderRadius = 4;
            this.txttelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttelefono.DefaultText = "";
            this.txttelefono.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttelefono.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttelefono.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttelefono.DisabledState.Parent = this.txttelefono;
            this.txttelefono.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttelefono.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttelefono.FocusedState.Parent = this.txttelefono;
            this.txttelefono.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttelefono.HoverState.Parent = this.txttelefono;
            this.txttelefono.Location = new System.Drawing.Point(778, 42);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.PasswordChar = '\0';
            this.txttelefono.PlaceholderText = "";
            this.txttelefono.SelectedText = "";
            this.txttelefono.ShadowDecoration.Parent = this.txttelefono;
            this.txttelefono.Size = new System.Drawing.Size(318, 26);
            this.txttelefono.TabIndex = 2;
            // 
            // txtsuplidor
            // 
            this.txtsuplidor.BorderRadius = 4;
            this.txtsuplidor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsuplidor.DefaultText = "";
            this.txtsuplidor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsuplidor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsuplidor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsuplidor.DisabledState.Parent = this.txtsuplidor;
            this.txtsuplidor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsuplidor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsuplidor.FocusedState.Parent = this.txtsuplidor;
            this.txtsuplidor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsuplidor.HoverState.Parent = this.txtsuplidor;
            this.txtsuplidor.Location = new System.Drawing.Point(127, 42);
            this.txtsuplidor.Name = "txtsuplidor";
            this.txtsuplidor.PasswordChar = '\0';
            this.txtsuplidor.PlaceholderText = "";
            this.txtsuplidor.SelectedText = "";
            this.txtsuplidor.ShadowDecoration.Parent = this.txtsuplidor;
            this.txtsuplidor.Size = new System.Drawing.Size(318, 26);
            this.txtsuplidor.TabIndex = 0;
            // 
            // fmsuplidoresregistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 534);
            this.Controls.Add(this.btnAbrirFormularioGestion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmsuplidoresregistrar";
            this.Text = "fmsuplidoresregistrar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAbrirFormularioGestion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnRegistrar;
        private Guna.UI2.WinForms.Guna2TextBox txtdireccion;
        private Guna.UI2.WinForms.Guna2TextBox txttelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtsuplidor;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboManejaComprobantes;
    }
}