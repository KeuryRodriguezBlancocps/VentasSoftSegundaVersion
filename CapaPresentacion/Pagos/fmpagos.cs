using CapaNegocio;
using CapaPresentacion.Compras;
using CapaPresentacion.Compras.consultas;
using CapaPresentacion.Ventas;
using CapaPresentacion.Ventas.Consultas;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Pagos
{
    public partial class fmpagos : Form
    {
        private int dIdVenta, dIdUsuario, dIdCompra;
        private fmventasbusqueda fmventabusqueda;
        private fmcomprasbusqueda fmcomprabusqueda;
        private bool PagoVenta = false;
        private bool PagoCompra = false;
        private decimal DebeDelPago = 0;
        private fmventasporfechas dfmventaporfecha;
        private fmcomprasporfechas dfmcompraporfecha;
        public fmpagos(int dIdVenta, int pIdCompra ,int dIdUsuario, fmcomprasbusqueda pfmCompraBusqueda, fmventasbusqueda pfmventabusqueda, fmventasporfechas pfmventaporfecha, fmcomprasporfechas pfmcomprasporfecha)
        {
            InitializeComponent();
            this.dIdVenta = dIdVenta;
            this.dIdUsuario = dIdUsuario;
            this.dIdCompra = pIdCompra;
            this.fmventabusqueda = pfmventabusqueda;
            this.fmcomprabusqueda = pfmCompraBusqueda;
            dfmventaporfecha = pfmventaporfecha;
            dfmcompraporfecha = pfmcomprasporfecha;
            Load += Fmpagos_Load;
            cboMetodoPago.TextChanged += CboMetodoPago_TextChanged;
            this.KeyPress += Fmpagos_KeyPress; ; ;
        }

        private void Fmpagos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dIdVenta!=0)
            {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnconfirmarpago_Click(sender, e);
            }
            }
        }

        private void CboMetodoPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string MetodoDePago = cboMetodoPago.Text;

                switch (MetodoDePago)
                {
                    case "Efectivo":
                        // Vaciar y bloquear los campos que no aplican
                        txtTarjetaHabiente.Text = string.Empty;
                        txtnrotarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        txtdebitado.Value = 0;
                        txttransferencia.Value = 0;

                        // Bloquear campos que no aplican
                        txtnrotarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        txtdebitado.Enabled = false;
                        txttransferencia.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Habilitar efectivo
                        txtefectivo.Enabled = true;
                        break;

                    case "Tarjeta":
                        // Vaciar y bloquear los campos que no aplican
                        txttransferencia.Value = 0;
                        txtefectivo.Value = 0;

                        // Bloquear campos que no aplican
                        txttransferencia.Enabled = false;
                        txtefectivo.Enabled = false;

                        // Habilitar los campos de tarjeta
                        txtnrotarjeta.Enabled = true;
                        txtTarjetaHabiente.Enabled = true;
                        cboTipoTarjeta.Enabled = true;
                        txtdebitado.Enabled = true;
                        break;

                    case "Transferencia":
                        // Vaciar y bloquear los campos que no aplican
                        txtTarjetaHabiente.Text = string.Empty;
                        txtnrotarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        txtdebitado.Value = 0;
                        txtefectivo.Value = 0;

                        // Bloquear campos que no aplican
                        txtnrotarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        txtdebitado.Enabled = false;
                        txtefectivo.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Habilitar transferencia
                        txttransferencia.Enabled = true;
                        break;

                    case "Transferencia y efectivo":
                        // Vaciar y bloquear los campos que no aplican
                        txtTarjetaHabiente.Text = string.Empty;
                        txtnrotarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        txtdebitado.Value = 0;

                        // Bloquear campos que no aplican
                        txtnrotarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        txtdebitado.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Habilitar transferencia y efectivo
                        txttransferencia.Enabled = true;
                        txtefectivo.Enabled = true;
                        break;

                    case "Efectivo y tarjeta":
                        // Vaciar y bloquear los campos que no aplican
                        txttransferencia.Value = 0;

                        // Bloquear campos que no aplican
                        txttransferencia.Enabled = false;

                        // Habilitar efectivo y tarjeta
                        txtnrotarjeta.Enabled = true;
                        txtTarjetaHabiente.Enabled = true;
                        cboTipoTarjeta.Enabled = true;
                        txtdebitado.Enabled = true;
                        txtefectivo.Enabled = true;
                        break;

                    case "Transferencia y tarjeta":
                        // Vaciar y bloquear los campos que no aplican
                        txtefectivo.Value = 0;

                        // Bloquear campos que no aplican
                        txtefectivo.Enabled = false;

                        // Habilitar transferencia y tarjeta
                        txtnrotarjeta.Enabled = true;
                        txtTarjetaHabiente.Enabled = true;
                        cboTipoTarjeta.Enabled = true;
                        txtdebitado.Enabled = true;
                        txttransferencia.Enabled = true;
                        break;

                    case "A credito":
                        // Vaciar y bloquear todos los campos
                        txtTarjetaHabiente.Text = string.Empty;
                        txtnrotarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        txtdebitado.Value = 0;
                        txttransferencia.Value = 0;
                        txtefectivo.Value = 0;

                        // Bloquear todos los campos
                        txtnrotarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        txtdebitado.Enabled = false;
                        txttransferencia.Enabled = false;
                        txtefectivo.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Configurar el estado de la compra como "Debe"
                        cboEstadoDeLaCompra.Text = "Debe";
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Fmpagos_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            MostrarVentaPorId();
            MostrarCompraPorId();
        }

        private void btnconfirmarpago_Click(object sender, EventArgs e)
        {
            decimal Pago = 0, Efectivo = 0, Debitado = 0, Transferencia = 0, TotalCompra = 0, Debe = 0, Devuelta = 0, Calculo = 0;
            string TarjetaHabiente = "", NroTarjeta = "", TipoTarjeta = "", MetodoPago = "", NroComprobante = "", Descripcion = "", Mensaje;
            int IdVenta = 0;
            try
            {
                string MetodoDePago = cboMetodoPago.Text;
                TotalCompra = txttotal.Value; // Total de la compra
                Pago = txtpago.Value; // Pago acumulado previo

                switch (MetodoDePago)
                {
                    case "Efectivo":
                        Efectivo = txtefectivo.Value;
                        if (Efectivo == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtefectivo.Focus();
                            return;
                        }
                        else
                        {
                            Pago += Efectivo;
                            if (Pago < TotalCompra)
                            {
                                cboEstadoDeLaCompra.Text = "Parcial";
                                Debe = TotalCompra - Pago;
                                txtdebedelpago.Text = Debe.ToString();
                            }
                            else
                            {
                                cboEstadoDeLaCompra.Text = "Completa";
                                Devuelta = Pago - TotalCompra;
                                txtdevuelta.Text = Devuelta.ToString();
                            }
                        }
                        break;

                    case "Tarjeta":
                        Debitado = txtdebitado.Value;
                        NroTarjeta = txtnrotarjeta.Text;
                        TarjetaHabiente = txtTarjetaHabiente.Text;

                        if (Debitado == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo debitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtdebitado.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(TarjetaHabiente))
                        {
                            MessageBox.Show("Debe de llenar el campo Tarjeta Habiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTarjetaHabiente.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(cboTipoTarjeta.Text))
                        {
                            MessageBox.Show("Debe de llenar el campo tipo de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cboTipoTarjeta.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(NroTarjeta))
                        {
                            MessageBox.Show("Debe de llenar el campo nro de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtnrotarjeta.Focus();
                            return;
                        }

                        Pago += Debitado;
                        if (Pago < TotalCompra)
                        {
                            cboEstadoDeLaCompra.Text = "Parcial";
                            Debe = TotalCompra - Pago;
                            txtdebedelpago.Text = Debe.ToString();
                        }
                        else
                        {
                            cboEstadoDeLaCompra.Text = "Completa";
                            Devuelta = Pago - TotalCompra;
                            txtdevuelta.Text = Devuelta.ToString();
                        }
                        break;

                    case "Transferencia":
                        Transferencia = txttransferencia.Value;
                        if (Transferencia == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo transferencia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txttransferencia.Focus();
                            return;
                        }

                        Pago += Transferencia;
                        if (Pago < TotalCompra)
                        {
                            cboEstadoDeLaCompra.Text = "Parcial";
                            Debe = TotalCompra - Pago;
                            txtdebedelpago.Text = Debe.ToString();
                        }
                        else
                        {
                            cboEstadoDeLaCompra.Text = "Completa";
                            Devuelta = Pago - TotalCompra;
                            txtdevuelta.Text = Devuelta.ToString();
                        }
                        break;

                    case "Transferencia y efectivo":
                        Transferencia = txttransferencia.Value;
                        Efectivo = txtefectivo.Value;

                        if (Transferencia == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo transferencia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txttransferencia.Focus();
                            return;
                        }
                        if (Efectivo == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtefectivo.Focus();
                            return;
                        }

                        Pago += Transferencia + Efectivo;
                        if (Pago < TotalCompra)
                        {
                            cboEstadoDeLaCompra.Text = "Parcial";
                            Debe = TotalCompra - Pago;
                            txtdebedelpago.Text = Debe.ToString();
                        }
                        else
                        {
                            cboEstadoDeLaCompra.Text = "Completa";
                            Devuelta = Pago - TotalCompra;
                            txtdevuelta.Text = Devuelta.ToString();
                        }
                        break;

                    case "Efectivo y tarjeta":
                        Debitado = txtdebitado.Value;
                        Efectivo = txtefectivo.Value;

                        if (string.IsNullOrEmpty(txtnrotarjeta.Text))
                        {
                            MessageBox.Show("Debe de llenar el campo nro de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtnrotarjeta.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(txtTarjetaHabiente.Text))
                        {
                            MessageBox.Show("Debe de llenar el campo Tarjeta Habiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTarjetaHabiente.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(cboTipoTarjeta.Text))
                        {
                            MessageBox.Show("Debe de llenar el campo tipo de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cboTipoTarjeta.Focus();
                            return;
                        }
                        if (Debitado == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo debitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtdebitado.Focus();
                            return;
                        }
                        if (Efectivo == 0)
                        {
                            MessageBox.Show("Debe de llenar el campo efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtefectivo.Focus();
                            return;
                        }

                        Pago += Debitado + Efectivo;
                        if (Pago < TotalCompra)
                        {
                            cboEstadoDeLaCompra.Text = "Parcial";
                            Debe = TotalCompra - Pago;
                            txtdebedelpago.Text = Debe.ToString();
                        }
                        else
                        {
                            cboEstadoDeLaCompra.Text = "Completa";
                            Devuelta = Pago - TotalCompra;
                            txtdevuelta.Text = Devuelta.ToString();
                        }
                        break;

                    case "A credito":
                        cboEstadoDeLaCompra.Text = "Pendiente";
                        Pago = 0;
                        Debe = TotalCompra;
                        txtdebedelpago.Text = Debe.ToString();
                        txtdevuelta.Text = "0";
                        break;
                }



                if (cboMetodoPago.Text == string.Empty)
                {
                    MessageBox.Show("Debe de seleccionar un método de pago para poder continuar","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (fmventabusqueda != null)
                {



            cnpagos obj = new cnpagos();
                obj.InsertarPagoVenta(

                    dIdVenta,
                    cboMetodoPago.Text,
                    cboEstadoDeLaCompra.Text,
                    txtTarjetaHabiente.Text,
                    txtnrotarjeta.Text,
                    "",
                    cboTipoTarjeta.Text,
                   Efectivo,
                   Debitado,
                   Transferencia,
                    Pago,
                    Debe,
                    dIdUsuario,
                    out Mensaje

                    );
                    Close();
                    fmventabusqueda.RecargarFormulario();

                MessageBox.Show(Mensaje, "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

                else if (dfmventaporfecha !=null)
                {
                    cnpagos obj = new cnpagos();
                    obj.InsertarPagoVenta(

                        dIdVenta,
                        cboMetodoPago.Text,
                        cboEstadoDeLaCompra.Text,
                        txtTarjetaHabiente.Text,
                        txtnrotarjeta.Text,
                        "",
                        cboTipoTarjeta.Text,
                       Efectivo,
                       Debitado,
                       Transferencia,
                        Pago,
                        Debe,
                        dIdUsuario,
                        out Mensaje

                        );
                    Close();
                    dfmventaporfecha.RecargarFormulario();

                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dfmcompraporfecha!=null)
                {
                    cnpagos obj = new cnpagos();
                    obj.Insertar(

                        dIdCompra,
                        cboMetodoPago.Text,
                        cboEstadoDeLaCompra.Text,
                        txtTarjetaHabiente.Text,
                        txtnrotarjeta.Text,
                        "",
                        cboTipoTarjeta.Text,
                       Efectivo,
                       Debitado,
                       Transferencia,
                        Pago,
                        Debe,
                        dIdUsuario,
                        out Mensaje

                        );
                    dfmcompraporfecha.RecargarFormulario();
                    Close();
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else if (fmcomprabusqueda != null)
                {
                    cnpagos obj = new cnpagos();
                    obj.Insertar(

                        dIdCompra,
                        cboMetodoPago.Text,
                        cboEstadoDeLaCompra.Text,
                        txtTarjetaHabiente.Text,
                        txtnrotarjeta.Text,
                        "",
                        cboTipoTarjeta.Text,
                       Efectivo,
                       Debitado,
                       Transferencia,
                        Pago,
                        Debe,
                        dIdUsuario,
                        out Mensaje

                        );
                    fmcomprabusqueda.RecargarFormulario();

                    Close();
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

    private void MostrarVentaPorId()
    {
            try
            {

                if (dIdVenta > 0 && dIdCompra == 0)
                {
                    PagoVenta = true;
                    cnventas obj = new cnventas();
                    DataTable tabla = new DataTable();
                    tabla = obj.ventaporId(dIdVenta);
                    if (tabla != null)
                    {
                        cboEstadoDeLaCompra.Text = Convert.ToString(tabla.Rows[0]["EstadoVenta"]);
                        txttotal.Text = Convert.ToString(tabla.Rows[0]["Total"]);
                        decimal debe = Convert.ToDecimal(tabla.Rows[0]["Debe"]);
                        txtdebe.Text = debe.ToString();
                        txtpago.Text = Convert.ToString(tabla.Rows[0]["Pago"]);
                    }

                }
                else
                {
                    PagoCompra = true;
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }


        private void MostrarCompraPorId()
        {
            try
            {

                if (dIdCompra>0 && dIdVenta == 0)
                {

                cncompra obj = new cncompra();
                DataTable tabla = new DataTable();
                tabla = obj.compraporId(dIdCompra);
                if (tabla != null)
                {
                    cboEstadoDeLaCompra.Text = Convert.ToString(tabla.Rows[0]["EstadoCompra"]);
                    txttotal.Text = Convert.ToString(tabla.Rows[0]["Total"]);
                    txtdebe.Text = Convert.ToString(tabla.Rows[0]["Debe"]);
                    txtpago.Text = Convert.ToString(tabla.Rows[0]["Pago"]);
                    }
                }
                else
                {
                    PagoVenta = true;
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }

}
