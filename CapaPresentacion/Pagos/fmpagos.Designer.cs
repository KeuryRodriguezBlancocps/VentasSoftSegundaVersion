namespace CapaPresentacion.Pagos
{
    partial class fmpagos
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
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.cboTipoTarjeta = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtnrotarjeta = new Guna.UI2.WinForms.Guna2TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboMetodoPago = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboEstadoDeLaCompra = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdebitado = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtTarjetaHabiente = new Guna.UI2.WinForms.Guna2TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txttransferencia = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.txtefectivo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdebe = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txttotal = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnconfirmarpago = new Guna.UI2.WinForms.Guna2Button();
            this.txtpago = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdevuelta = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtdebedelpago = new Guna.UI2.WinForms.Guna2TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtdebitado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtefectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdebe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpago)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gunaLabel4.Location = new System.Drawing.Point(12, 14);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(101, 20);
            this.gunaLabel4.TabIndex = 20;
            this.gunaLabel4.Text = "Realizar pago";
            // 
            // cboTipoTarjeta
            // 
            this.cboTipoTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoTarjeta.BorderRadius = 4;
            this.cboTipoTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTipoTarjeta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTarjeta.FocusedColor = System.Drawing.Color.Empty;
            this.cboTipoTarjeta.FocusedState.Parent = this.cboTipoTarjeta;
            this.cboTipoTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipoTarjeta.FormattingEnabled = true;
            this.cboTipoTarjeta.HoverState.Parent = this.cboTipoTarjeta;
            this.cboTipoTarjeta.ItemHeight = 20;
            this.cboTipoTarjeta.Items.AddRange(new object[] {
            "Credito",
            "Debito"});
            this.cboTipoTarjeta.ItemsAppearance.Parent = this.cboTipoTarjeta;
            this.cboTipoTarjeta.Location = new System.Drawing.Point(500, 142);
            this.cboTipoTarjeta.Name = "cboTipoTarjeta";
            this.cboTipoTarjeta.ShadowDecoration.Parent = this.cboTipoTarjeta;
            this.cboTipoTarjeta.Size = new System.Drawing.Size(206, 26);
            this.cboTipoTarjeta.TabIndex = 71;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(395, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 25);
            this.label16.TabIndex = 70;
            this.label16.Text = "Tipo tarjeta";
            // 
            // txtnrotarjeta
            // 
            this.txtnrotarjeta.BorderRadius = 4;
            this.txtnrotarjeta.BorderThickness = 2;
            this.txtnrotarjeta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnrotarjeta.DefaultText = "";
            this.txtnrotarjeta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtnrotarjeta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtnrotarjeta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnrotarjeta.DisabledState.Parent = this.txtnrotarjeta;
            this.txtnrotarjeta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnrotarjeta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtnrotarjeta.FocusedState.Parent = this.txtnrotarjeta;
            this.txtnrotarjeta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtnrotarjeta.HoverState.Parent = this.txtnrotarjeta;
            this.txtnrotarjeta.Location = new System.Drawing.Point(889, 143);
            this.txtnrotarjeta.Name = "txtnrotarjeta";
            this.txtnrotarjeta.PasswordChar = '\0';
            this.txtnrotarjeta.PlaceholderText = "";
            this.txtnrotarjeta.SelectedText = "";
            this.txtnrotarjeta.ShadowDecoration.Parent = this.txtnrotarjeta;
            this.txtnrotarjeta.Size = new System.Drawing.Size(155, 25);
            this.txtnrotarjeta.TabIndex = 68;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(730, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 25);
            this.label14.TabIndex = 67;
            this.label14.Text = "Número de Tarjeta";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.BackColor = System.Drawing.Color.Transparent;
            this.cboMetodoPago.BorderRadius = 4;
            this.cboMetodoPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMetodoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.FocusedColor = System.Drawing.Color.Empty;
            this.cboMetodoPago.FocusedState.Parent = this.cboMetodoPago;
            this.cboMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.HoverState.Parent = this.cboMetodoPago;
            this.cboMetodoPago.ItemHeight = 20;
            this.cboMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Efectivo y tarjeta",
            "Transferencia",
            "Transferencia y efectivo",
            "Transferencia y tarjeta"});
            this.cboMetodoPago.ItemsAppearance.Parent = this.cboMetodoPago;
            this.cboMetodoPago.Location = new System.Drawing.Point(156, 140);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.ShadowDecoration.Parent = this.cboMetodoPago;
            this.cboMetodoPago.Size = new System.Drawing.Size(206, 26);
            this.cboMetodoPago.TabIndex = 65;
            // 
            // cboEstadoDeLaCompra
            // 
            this.cboEstadoDeLaCompra.BackColor = System.Drawing.Color.Transparent;
            this.cboEstadoDeLaCompra.BorderRadius = 4;
            this.cboEstadoDeLaCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboEstadoDeLaCompra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoDeLaCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoDeLaCompra.Enabled = false;
            this.cboEstadoDeLaCompra.FocusedColor = System.Drawing.Color.Empty;
            this.cboEstadoDeLaCompra.FocusedState.Parent = this.cboEstadoDeLaCompra;
            this.cboEstadoDeLaCompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstadoDeLaCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstadoDeLaCompra.FormattingEnabled = true;
            this.cboEstadoDeLaCompra.HoverState.Parent = this.cboEstadoDeLaCompra;
            this.cboEstadoDeLaCompra.ItemHeight = 20;
            this.cboEstadoDeLaCompra.Items.AddRange(new object[] {
            "Completa",
            "Parcial",
            "Debe"});
            this.cboEstadoDeLaCompra.ItemsAppearance.Parent = this.cboEstadoDeLaCompra;
            this.cboEstadoDeLaCompra.Location = new System.Drawing.Point(209, 13);
            this.cboEstadoDeLaCompra.Name = "cboEstadoDeLaCompra";
            this.cboEstadoDeLaCompra.ShadowDecoration.Parent = this.cboEstadoDeLaCompra;
            this.cboEstadoDeLaCompra.Size = new System.Drawing.Size(206, 26);
            this.cboEstadoDeLaCompra.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(14, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 25);
            this.label10.TabIndex = 62;
            this.label10.Text = "Tarjeta Habiente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(14, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 25);
            this.label11.TabIndex = 61;
            this.label11.Text = "Metodo de pago";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(140, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 25);
            this.label12.TabIndex = 60;
            this.label12.Text = "Estado";
            // 
            // txtdebitado
            // 
            this.txtdebitado.BackColor = System.Drawing.Color.Transparent;
            this.txtdebitado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdebitado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdebitado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdebitado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdebitado.DisabledState.Parent = this.txtdebitado;
            this.txtdebitado.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtdebitado.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txtdebitado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdebitado.FocusedState.Parent = this.txtdebitado;
            this.txtdebitado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdebitado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtdebitado.Location = new System.Drawing.Point(573, 223);
            this.txtdebitado.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtdebitado.Name = "txtdebitado";
            this.txtdebitado.ShadowDecoration.Parent = this.txtdebitado;
            this.txtdebitado.Size = new System.Drawing.Size(160, 25);
            this.txtdebitado.TabIndex = 66;
            // 
            // txtTarjetaHabiente
            // 
            this.txtTarjetaHabiente.BorderRadius = 4;
            this.txtTarjetaHabiente.BorderThickness = 2;
            this.txtTarjetaHabiente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTarjetaHabiente.DefaultText = "";
            this.txtTarjetaHabiente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTarjetaHabiente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTarjetaHabiente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarjetaHabiente.DisabledState.Parent = this.txtTarjetaHabiente;
            this.txtTarjetaHabiente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTarjetaHabiente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarjetaHabiente.FocusedState.Parent = this.txtTarjetaHabiente;
            this.txtTarjetaHabiente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTarjetaHabiente.HoverState.Parent = this.txtTarjetaHabiente;
            this.txtTarjetaHabiente.Location = new System.Drawing.Point(156, 222);
            this.txtTarjetaHabiente.Name = "txtTarjetaHabiente";
            this.txtTarjetaHabiente.PasswordChar = '\0';
            this.txtTarjetaHabiente.PlaceholderText = "";
            this.txtTarjetaHabiente.SelectedText = "";
            this.txtTarjetaHabiente.ShadowDecoration.Parent = this.txtTarjetaHabiente;
            this.txtTarjetaHabiente.Size = new System.Drawing.Size(259, 25);
            this.txtTarjetaHabiente.TabIndex = 63;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(430, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 25);
            this.label15.TabIndex = 69;
            this.label15.Text = "Monto debitado";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(767, 224);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 25);
            this.label18.TabIndex = 75;
            this.label18.Text = "Transferencia";
            // 
            // txttransferencia
            // 
            this.txttransferencia.BackColor = System.Drawing.Color.Transparent;
            this.txttransferencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttransferencia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttransferencia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttransferencia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttransferencia.DisabledState.Parent = this.txttransferencia;
            this.txttransferencia.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txttransferencia.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txttransferencia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttransferencia.FocusedState.Parent = this.txttransferencia;
            this.txttransferencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txttransferencia.Location = new System.Drawing.Point(884, 224);
            this.txttransferencia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txttransferencia.Name = "txttransferencia";
            this.txttransferencia.ShadowDecoration.Parent = this.txttransferencia;
            this.txttransferencia.Size = new System.Drawing.Size(160, 25);
            this.txttransferencia.TabIndex = 74;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(70, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 25);
            this.label17.TabIndex = 73;
            this.label17.Text = "Efectivo";
            // 
            // txtefectivo
            // 
            this.txtefectivo.BackColor = System.Drawing.Color.Transparent;
            this.txtefectivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtefectivo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtefectivo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtefectivo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtefectivo.DisabledState.Parent = this.txtefectivo;
            this.txtefectivo.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtefectivo.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txtefectivo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtefectivo.FocusedState.Parent = this.txtefectivo;
            this.txtefectivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtefectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtefectivo.Location = new System.Drawing.Point(156, 298);
            this.txtefectivo.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtefectivo.Name = "txtefectivo";
            this.txtefectivo.ShadowDecoration.Parent = this.txtefectivo;
            this.txtefectivo.Size = new System.Drawing.Size(160, 25);
            this.txtefectivo.TabIndex = 72;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(3, 41);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1041, 14);
            this.guna2Separator1.TabIndex = 76;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(12, 58);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(66, 19);
            this.gunaLabel1.TabIndex = 77;
            this.gunaLabel1.Text = "Opciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(446, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 78;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(800, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 80;
            this.label2.Text = "Debe";
            // 
            // txtdebe
            // 
            this.txtdebe.BackColor = System.Drawing.Color.Transparent;
            this.txtdebe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdebe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdebe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdebe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdebe.DisabledState.Parent = this.txtdebe;
            this.txtdebe.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtdebe.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txtdebe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdebe.FocusedState.Parent = this.txtdebe;
            this.txtdebe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdebe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtdebe.Location = new System.Drawing.Point(858, 14);
            this.txtdebe.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtdebe.Name = "txtdebe";
            this.txtdebe.ShadowDecoration.Parent = this.txtdebe;
            this.txtdebe.Size = new System.Drawing.Size(107, 25);
            this.txtdebe.TabIndex = 82;
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.Color.Transparent;
            this.txttotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotal.DisabledState.Parent = this.txttotal;
            this.txttotal.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txttotal.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txttotal.Enabled = false;
            this.txttotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotal.FocusedState.Parent = this.txttotal;
            this.txttotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txttotal.Location = new System.Drawing.Point(500, 14);
            this.txttotal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txttotal.Name = "txttotal";
            this.txttotal.ShadowDecoration.Parent = this.txttotal;
            this.txttotal.Size = new System.Drawing.Size(77, 25);
            this.txttotal.TabIndex = 81;
            // 
            // btnconfirmarpago
            // 
            this.btnconfirmarpago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnconfirmarpago.Animated = true;
            this.btnconfirmarpago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(156)))), ((int)(((byte)(165)))));
            this.btnconfirmarpago.BorderRadius = 4;
            this.btnconfirmarpago.BorderThickness = 1;
            this.btnconfirmarpago.CheckedState.Parent = this.btnconfirmarpago;
            this.btnconfirmarpago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconfirmarpago.CustomImages.Parent = this.btnconfirmarpago;
            this.btnconfirmarpago.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(156)))), ((int)(((byte)(165)))));
            this.btnconfirmarpago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnconfirmarpago.ForeColor = System.Drawing.Color.White;
            this.btnconfirmarpago.HoverState.Parent = this.btnconfirmarpago;
            this.btnconfirmarpago.Location = new System.Drawing.Point(897, 316);
            this.btnconfirmarpago.Name = "btnconfirmarpago";
            this.btnconfirmarpago.ShadowDecoration.Parent = this.btnconfirmarpago;
            this.btnconfirmarpago.Size = new System.Drawing.Size(147, 33);
            this.btnconfirmarpago.TabIndex = 83;
            this.btnconfirmarpago.Text = "Confirmar pago";
            this.btnconfirmarpago.Click += new System.EventHandler(this.btnconfirmarpago_Click);
            // 
            // txtpago
            // 
            this.txtpago.BackColor = System.Drawing.Color.Transparent;
            this.txtpago.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpago.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpago.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpago.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpago.DisabledState.Parent = this.txtpago;
            this.txtpago.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtpago.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txtpago.Enabled = false;
            this.txtpago.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpago.FocusedState.Parent = this.txtpago;
            this.txtpago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.txtpago.Location = new System.Drawing.Point(670, 14);
            this.txtpago.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtpago.Name = "txtpago";
            this.txtpago.ShadowDecoration.Parent = this.txtpago;
            this.txtpago.Size = new System.Drawing.Size(107, 25);
            this.txtpago.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI Semilight", 13F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(612, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 84;
            this.label3.Text = "Pago";
            // 
            // txtdevuelta
            // 
            this.txtdevuelta.BorderRadius = 4;
            this.txtdevuelta.BorderThickness = 2;
            this.txtdevuelta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdevuelta.DefaultText = "0";
            this.txtdevuelta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdevuelta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdevuelta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdevuelta.DisabledState.Parent = this.txtdevuelta;
            this.txtdevuelta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdevuelta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdevuelta.FocusedState.Parent = this.txtdevuelta;
            this.txtdevuelta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtdevuelta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdevuelta.HoverState.Parent = this.txtdevuelta;
            this.txtdevuelta.Location = new System.Drawing.Point(638, 333);
            this.txtdevuelta.Name = "txtdevuelta";
            this.txtdevuelta.PasswordChar = '\0';
            this.txtdevuelta.PlaceholderText = "";
            this.txtdevuelta.SelectedText = "";
            this.txtdevuelta.SelectionStart = 1;
            this.txtdevuelta.ShadowDecoration.Parent = this.txtdevuelta;
            this.txtdevuelta.Size = new System.Drawing.Size(240, 25);
            this.txtdevuelta.TabIndex = 93;
            // 
            // txtdebedelpago
            // 
            this.txtdebedelpago.BorderRadius = 4;
            this.txtdebedelpago.BorderThickness = 2;
            this.txtdebedelpago.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdebedelpago.DefaultText = "0";
            this.txtdebedelpago.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtdebedelpago.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtdebedelpago.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdebedelpago.DisabledState.Parent = this.txtdebedelpago;
            this.txtdebedelpago.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtdebedelpago.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdebedelpago.FocusedState.Parent = this.txtdebedelpago;
            this.txtdebedelpago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtdebedelpago.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtdebedelpago.HoverState.Parent = this.txtdebedelpago;
            this.txtdebedelpago.Location = new System.Drawing.Point(639, 304);
            this.txtdebedelpago.Name = "txtdebedelpago";
            this.txtdebedelpago.PasswordChar = '\0';
            this.txtdebedelpago.PlaceholderText = "";
            this.txtdebedelpago.SelectedText = "";
            this.txtdebedelpago.SelectionStart = 1;
            this.txtdebedelpago.ShadowDecoration.Parent = this.txtdebedelpago;
            this.txtdebedelpago.Size = new System.Drawing.Size(239, 25);
            this.txtdebedelpago.TabIndex = 90;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Bold);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(555, 333);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 21);
            this.label28.TabIndex = 92;
            this.label28.Text = "Devuelta";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Bold);
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(581, 307);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 21);
            this.label29.TabIndex = 91;
            this.label29.Text = "Debe";
            // 
            // fmpagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 358);
            this.Controls.Add(this.txtdevuelta);
            this.Controls.Add(this.txtdebedelpago);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtpago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnconfirmarpago);
            this.Controls.Add(this.txtdebe);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txttransferencia);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtefectivo);
            this.Controls.Add(this.cboTipoTarjeta);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtnrotarjeta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTarjetaHabiente);
            this.Controls.Add(this.txtdebitado);
            this.Controls.Add(this.cboMetodoPago);
            this.Controls.Add(this.cboEstadoDeLaCompra);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.gunaLabel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmpagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pagos";
            ((System.ComponentModel.ISupportInitialize)(this.txtdebitado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtefectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdebe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipoTarjeta;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2TextBox txtnrotarjeta;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2ComboBox cboMetodoPago;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstadoDeLaCompra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtdebitado;
        private Guna.UI2.WinForms.Guna2TextBox txtTarjetaHabiente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2NumericUpDown txttransferencia;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtefectivo;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtdebe;
        private Guna.UI2.WinForms.Guna2NumericUpDown txttotal;
        private Guna.UI2.WinForms.Guna2Button btnconfirmarpago;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtpago;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtdevuelta;
        private Guna.UI2.WinForms.Guna2TextBox txtdebedelpago;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
    }
}