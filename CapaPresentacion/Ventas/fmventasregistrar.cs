using CapaNegocio;
using CapaPresentacion.Compras;
using CapaPresentacion.Reportes;
using FastReport.DevComponents.DotNetBar.Events;
using FastReport.Editor;
using FastReport.Messaging.Xmpp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ventas
{
    public partial class fmventasregistrar : Form
    {
        private int dIdUsuario;
        public int dIdCliente = 0;
        public int dIdProducto = 0;
        public string CodigoProducto;
        private fmSistema dsis;
        private bool ProductoEncontrado = false;
        private string MensajeComprobante = "";
        private int dImpuesto = 0;
        public fmventasregistrar(int pIdUsuario, fmSistema psis)
        {
            InitializeComponent();
            dIdUsuario = pIdUsuario;
            dsis = psis;
            icoproductoseleccionar.Click += Icoproductoseleccionar_Click;
            btnEnviarAlaLista.Click += BtnEnviarAlaLista_Click;
            cboMetodoPago.TextChanged += CboMetodoPago_TextChanged;
            Load += Fmventasregistrar_Load;
            cbotipocomprobante.TextChanged += Cbotipocomprobante_TextChanged;
            this.KeyDown += Fmventasregistrar_KeyDown;
            this.KeyPreview = true;
        }

        private void Fmventasregistrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnconfirmar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F1)
            {
                BtnEnviarAlaLista_Click(sender, e);
            }

            else if (e.KeyCode == Keys.F3)
            {
                Icoproductoseleccionar_Click(sender, e);
            }


            else if (e.KeyCode == Keys.F4)
            {
                icobuscarcliente_Click(sender, e);
            }


        }

        private void Cbotipocomprobante_TextChanged(object sender, EventArgs e)
        {
            cntipocomprobante obj = new cntipocomprobante();
            DataTable tabla = new DataTable();
            string comprobante = cbotipocomprobante.Text;
            string prefijo = "";

            tabla = obj.MostarTipoComprobante();

            foreach (DataRow item in tabla.Rows)
            {
                if (item["TipoComprobante"].ToString() == comprobante)
                {

                    prefijo = item["Prefijo"].ToString();
                    break;
                }
            }

            txtnrocomprobante.Text = prefijo;
        }

        private void Fmventasregistrar_Load(object sender, EventArgs e)
        {
            btnEnviarAlaLista.Focus();
            ObtenerTiposComprobantes();
            Cbotipocomprobante_TextChanged(sender, e);
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
                        txtNroTarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        numDebitado.Value = 0;
                        numTransferencia.Value = 0;

                        // Bloquear campos que no aplican
                        txtNroTarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        numDebitado.Enabled = false;
                        numTransferencia.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Habilitar efectivo
                        numEfectivo.Enabled = true;
                        break;

                    case "Tarjeta":
                        // Vaciar y bloquear los campos que no aplican
                        numTransferencia.Value = 0;
                        numEfectivo.Value = 0;

                        // Bloquear campos que no aplican
                        numTransferencia.Enabled = false;
                        numEfectivo.Enabled = false;

                        // Habilitar los campos de tarjeta
                        txtNroTarjeta.Enabled = true;
                        txtTarjetaHabiente.Enabled = true;
                        cboTipoTarjeta.Enabled = true;
                        numDebitado.Enabled = true;
                        break;

                    case "Transferencia":
                        // Vaciar y bloquear los campos que no aplican
                        txtTarjetaHabiente.Text = string.Empty;
                        txtNroTarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        numDebitado.Value = 0;
                        numEfectivo.Value = 0;

                        // Bloquear campos que no aplican
                        txtNroTarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        numDebitado.Enabled = false;
                        numEfectivo.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Habilitar transferencia
                        numTransferencia.Enabled = true;
                        break;

                    case "Transferencia y efectivo":
                        // Vaciar y bloquear los campos que no aplican
                        txtTarjetaHabiente.Text = string.Empty;
                        txtNroTarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        numDebitado.Value = 0;

                        // Bloquear campos que no aplican
                        txtNroTarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        numDebitado.Enabled = false;
                        cboTipoTarjeta.Enabled = false;

                        // Habilitar transferencia y efectivo
                        numTransferencia.Enabled = true;
                        numEfectivo.Enabled = true;
                        break;

                    case "Efectivo y tarjeta":
                        // Vaciar y bloquear los campos que no aplican
                        numTransferencia.Value = 0;

                        // Bloquear campos que no aplican
                        numTransferencia.Enabled = false;

                        // Habilitar efectivo y tarjeta
                        txtNroTarjeta.Enabled = true;
                        txtTarjetaHabiente.Enabled = true;
                        cboTipoTarjeta.Enabled = true;
                        numDebitado.Enabled = true;
                        numEfectivo.Enabled = true;
                        break;

                    case "Transferencia y tarjeta":
                        // Vaciar y bloquear los campos que no aplican
                        numEfectivo.Value = 0;

                        // Bloquear campos que no aplican
                        numEfectivo.Enabled = false;

                        // Habilitar transferencia y tarjeta
                        txtNroTarjeta.Enabled = true;
                        txtTarjetaHabiente.Enabled = true;
                        cboTipoTarjeta.Enabled = true;
                        numDebitado.Enabled = true;
                        numTransferencia.Enabled = true;
                        break;

                    case "A credito":
                        // Vaciar y bloquear todos los campos
                        txtTarjetaHabiente.Text = string.Empty;
                        txtNroTarjeta.Text = string.Empty;
                        cboTipoTarjeta.Text = string.Empty;
                        numDebitado.Value = 0;
                        numTransferencia.Value = 0;
                        numEfectivo.Value = 0;

                        // Bloquear todos los campos
                        txtNroTarjeta.Enabled = false;
                        txtTarjetaHabiente.Enabled = false;
                        numDebitado.Enabled = false;
                        numTransferencia.Enabled = false;
                        numEfectivo.Enabled = false;
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

        private void BtnEnviarAlaLista_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tabla = new DataTable();
                cnproductos obj = new cnproductos();

                int Cantidad;
                int OperacionParaCantidadAlMismoProducto;
                decimal dSubtotal = 0;
                decimal dTotal;
                decimal Precio;

                if (txtproducto.Text == string.Empty)
                {
                    MessageBox.Show("Debe de seleccionar un producto para proceder la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtproducto.Focus();
                    return;
                }
                else if (numprecio.Value == 0)
                {
                    MessageBox.Show("Debe de colocar un precio valido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numprecio.Focus();
                    return;
                }
                else if (numCantidad.Value == 0)
                {
                    MessageBox.Show("Debe de colocar una cantidad valida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numCantidad.Focus();
                    return;
                }


                else
                {

                    tabla = obj.ProductoPorId(dIdProducto);

                    if (Convert.ToInt32(tabla.Rows[0]["Stock"])==0 || numCantidad.Value > Convert.ToInt32(tabla.Rows[0]["Stock"]))
                    {
                        MessageBox.Show("No existe stock suficiente para hacer una venta de este producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value) == CodigoProducto)
                        {
                            ProductoEncontrado = true;
                            Cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value);
                            Precio = Convert.ToDecimal(item.Cells["Precio"].Value);

                            decimal descuento = (Convert.ToDecimal(NumDescuento.Value) / 100) * Precio;
                            decimal precioConDescuento = Precio - descuento;

                            
                            OperacionParaCantidadAlMismoProducto = Cantidad + Convert.ToInt32(numCantidad.Value);
                            dSubtotal = precioConDescuento * OperacionParaCantidadAlMismoProducto;
                            dTotal = dSubtotal + dImpuesto;

                            item.Cells["Cantidad"].Value = OperacionParaCantidadAlMismoProducto;
                            item.Cells["Subtotal"].Value = dSubtotal;
                            item.Cells["Total"].Value = dTotal;
                        }
                    }

                    if (!ProductoEncontrado)
                    {
                        Precio = numprecio.Value;

                        decimal descuento = (Convert.ToDecimal(NumDescuento.Value) / 100) * Precio;
                        decimal precioConDescuento = Precio - descuento;

                        Cantidad = Convert.ToInt32(numCantidad.Value);
                        dSubtotal = precioConDescuento * Cantidad;
                        dTotal = dSubtotal + dImpuesto;

                        guna2DataGridView1.Rows.Add(new object[]
                        {
            dIdProducto,
            CodigoProducto,
            txtproducto.Text,
            txtdescripcion.Text,
            Cantidad,
            Precio,
            descuento,
           dImpuesto,
            dSubtotal,
            dTotal
                        });
                    }
                }

                CalcularTotal();
                LimpiarCamposProductos();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void LimpiarCamposProductos()
        {
            txtproducto.Clear();
            txtdescripcion.Clear();
            txtcategoria.Clear();
            numImpuesto.Value = 0;
            numCantidad.Value = 0;
            numprecio.Value = 0;

        }



        private void ObtenerTiposComprobantes()
        {
            try
            {
                cntipocomprobante obj = new cntipocomprobante();
                DataTable tabla = new DataTable();
                tabla = obj.MostarTipoComprobante();
                if (tabla!=null)
                {

                cbotipocomprobante.DataSource = tabla;
                cbotipocomprobante.DisplayMember = "TipoComprobante";
                cbotipocomprobante.ValueMember = "IdTipoComprobante";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void GenerarComprobante()
        {
            cntipocomprobante obj = new cntipocomprobante();
            DataTable tabla = new DataTable();
            string comprobante = cbotipocomprobante.Text;
            string prefijo = "";
            string CodigoFactura = obj.GenerarCodigoFactura(cbotipocomprobante.SelectedValue.ToString());

            tabla = obj.MostarTipoComprobante();

            foreach (DataRow item in tabla.Rows)
            {
                if (item["TipoComprobante"].ToString() == comprobante)
                {

                    prefijo = item["Prefijo"].ToString();
                    break;
                }
            }

            txtnrocomprobante.Text = prefijo + CodigoFactura;

        }






        private void CalcularTotal()
        {
            decimal SubTotalCompra = 0;
            decimal TotalCompra = 0;
            decimal Impuesto = 0;
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                SubTotalCompra += Convert.ToDecimal(item.Cells["SubTotal"].Value);
                TotalCompra += Convert.ToDecimal(item.Cells["Total"].Value);
                Impuesto += Convert.ToDecimal(item.Cells["Impuesto"].Value);
            }

            txtsubtotal.Text = Convert.ToString(SubTotalCompra);
            txtimpuestoaplicado.Text = Convert.ToString(Impuesto);
            txttotal.Text = Convert.ToString(TotalCompra);
        }





        private void Icoproductoseleccionar_Click(object sender, EventArgs e)
        {
            fmproductoseleccionar obj = new fmproductoseleccionar(null, null, this, null);
            obj.ShowDialog();
        }

        private void btnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmventasbusqueda(dIdUsuario, dsis));
        }

        private void icobuscarcliente_Click(object sender, EventArgs e)
        {
            fmclienteseleccionar obj = new fmclienteseleccionar(this, null);
            obj.Show();
        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            decimal Efectivo = 0, MontoDebitado = 0, Transferencia = 0, TotalCompra = 0, Pago = 0, Debe = 0, Devuelta = 0;
            string TipoTarjeta = "", NumeroTarjeta = "", Mensaje = "", TarjetaHabiente = "";
            string MetodoPago = cboMetodoPago.Text;
            int IdVenta = 0;
            try
            {
                if (guna2DataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Debes de enviar los productos a la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtproducto.Focus();
                    return;
                }

                else
                {
                    if (cboMetodoPago.Text == string.Empty)
                    {

                        MessageBox.Show("Debes de seleccionar un método de pago", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboMetodoPago.Focus();
                        return;
                    }


                    else if (txtnrocomprobante.Enabled != false && txtnrocomprobante.Text == string.Empty)
                    {
                        MessageBox.Show("Debe de colocar el número de comprobante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtnrocomprobante.Focus();
                        return;
                    }
                    else
                    {

                        switch (MetodoPago)
                        {
                            case "Efectivo":

                                Efectivo = numEfectivo.Value;

                                if (Efectivo == 0)
                                {

                                    MessageBox.Show("Debes de llenar el campo efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    numEfectivo.Focus();
                                    return;

                                }
                                else
                                {
                                    TotalCompra = Convert.ToDecimal(txttotal.Text);
                                    Pago = Efectivo;

                                    if (Pago > 0)
                                    {
                                        if (Pago < TotalCompra)
                                        {
                                            cboEstadoDeLaCompra.Text = "Parcial";
                                            Debe = TotalCompra - Pago;
                                            txtdebe.Text = Debe.ToString();
                                            txtdevuelta.Text = 0.ToString();
                                        }
                                        else
                                        {
                                            cboEstadoDeLaCompra.Text = "Completa";
                                            Devuelta = Pago - TotalCompra;
                                            txtdevuelta.Text = Devuelta.ToString();
                                            txtdebe.Text = 0.ToString();
                                        }
                                    }

                                }
                                break;

                            case "Tarjeta":

                                MontoDebitado = numDebitado.Value;
                                TipoTarjeta = cboTipoTarjeta.Text;
                                TarjetaHabiente = txtTarjetaHabiente.Text;
                                NumeroTarjeta = txtNroTarjeta.Text;

                                if (MontoDebitado == 0)
                                {
                                    MessageBox.Show("Debes de llenar el campo monto debitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    numDebitado.Focus();
                                    return;
                                }
                                else if (TipoTarjeta == string.Empty)
                                {
                                    MessageBox.Show("Debes de llenar el campo tipo de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cboTipoTarjeta.Focus();
                                    return;
                                }

                                else if (TarjetaHabiente == string.Empty)
                                {
                                    MessageBox.Show("Debes de llenar el campo tarjeta habiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtTarjetaHabiente.Focus();
                                    return;
                                }

                                else if (NumeroTarjeta == string.Empty)
                                {
                                    MessageBox.Show("Debes de llenar el campo número de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtNroTarjeta.Focus();
                                    return;
                                }
                                else
                                {
                                    NumeroTarjeta = txtNroTarjeta.Text;
                                    TarjetaHabiente = txtTarjetaHabiente.Text;
                                    TotalCompra = Convert.ToDecimal(txttotal.Text);
                                    Pago = MontoDebitado;

                                    if (Pago > 0)
                                    {
                                        if (Pago < TotalCompra)
                                        {
                                            cboEstadoDeLaCompra.Text = "Parcial";
                                            Debe = TotalCompra - Pago;
                                            txtdebe.Text = Debe.ToString();
                                            txtdevuelta.Text = 0.ToString();
                                        }
                                        else
                                        {
                                            cboEstadoDeLaCompra.Text = "Completa";
                                            Devuelta = Pago - TotalCompra;
                                            txtdevuelta.Text = Devuelta.ToString();
                                            txtdebe.Text = 0.ToString();
                                        }
                                    }

                                }

                                break;


                            case "Credito":

                                TotalCompra = Convert.ToDecimal(txttotal.Text);
                                cboEstadoDeLaCompra.Text = "Debe";
                                txtdebe.Text = TotalCompra.ToString();
                                txtdevuelta.Text = 0.ToString();

                                break;



                            case "Efectivo y tarjeta":

                                NumeroTarjeta = txtNroTarjeta.Text;
                                TarjetaHabiente = txtTarjetaHabiente.Text;
                                MontoDebitado = numDebitado.Value;
                                Efectivo = numEfectivo.Value;
                                TotalCompra = Convert.ToDecimal(txttotal.Text);
                                if (NumeroTarjeta == string.Empty)
                                {
                                    MessageBox.Show("Debes de llenar el campo número de la tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtNroTarjeta.Focus();
                                    return;
                                }
                                else if (TarjetaHabiente == string.Empty)
                                {

                                    MessageBox.Show("Debes de llenar el campo tarjeta habiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtTarjetaHabiente.Focus();
                                    return;
                                }
                                else if (Efectivo == 0)
                                {

                                    MessageBox.Show("Debes de llenar el campo efectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    numEfectivo.Focus();
                                    return;
                                }

                                else
                                {
                                    Pago = Efectivo + MontoDebitado;

                                    if (Pago > 0)
                                    {
                                        if (Pago < TotalCompra)
                                        {

                                            cboEstadoDeLaCompra.Text = "Parcial";
                                            Debe = TotalCompra - Pago;
                                            txtdebe.Text = Debe.ToString();
                                            txtdevuelta.Text = 0.ToString();
                                        }
                                        else
                                        {
                                            cboEstadoDeLaCompra.Text = "Completa";
                                            Devuelta = Pago - TotalCompra;
                                            txtdevuelta.Text = Devuelta.ToString();
                                            txtdebe.Text = 0.ToString();
                                        }
                                    }
                                }
                                break;

                            case "Transferencia":

                                Transferencia = numTransferencia.Value;
                                Pago = Transferencia;
                                TotalCompra = Convert.ToDecimal(txttotal.Text);

                                if (Pago > 0)
                                {
                                    if (Pago < TotalCompra)
                                    {
                                        cboEstadoDeLaCompra.Text = "Parcial";
                                        Debe = TotalCompra - Pago;
                                        txtdebe.Text = Debe.ToString();
                                        txtdevuelta.Text = 0.ToString();
                                    }
                                    else
                                    {

                                        cboEstadoDeLaCompra.Text = "Completa";
                                        Devuelta = Pago - TotalCompra;
                                        txtdevuelta.Text = Devuelta.ToString();
                                        txtdebe.Text = 0.ToString();
                                    }
                                }


                                break;

                            case "Transferencia y tarjeta":
                                Transferencia = numTransferencia.Value;
                                MontoDebitado = numDebitado.Value;

                                if (txtNroTarjeta.Text == string.Empty)
                                {
                                    MessageBox.Show("Debe de llenar el campo número de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtNroTarjeta.Focus();
                                    return;
                                }
                                else if (txtTarjetaHabiente.Text == string.Empty)
                                {
                                    MessageBox.Show("Debe de llenar el campo Tarjeta Habiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtTarjetaHabiente.Focus();
                                    return;
                                }
                                else if (cboTipoTarjeta.Text == string.Empty)
                                {
                                    MessageBox.Show("Debe de llenar el campo tipo de tarjeta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cboTipoTarjeta.Focus();
                                    return;
                                }
                                else if (MontoDebitado == 0)
                                {
                                    MessageBox.Show("Debe de llenar el campo monto debitado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    numDebitado.Focus();
                                    return;
                                }
                                else if (Transferencia == 0)
                                {
                                    MessageBox.Show("Debe de llenar el campo transferencia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    numTransferencia.Focus();
                                    return;
                                }
                                else
                                {
                                    Pago = Transferencia + MontoDebitado;
                                    TotalCompra = Convert.ToDecimal(txttotal.Text);

                                    if (Pago > 0)
                                    {
                                        if (Pago < TotalCompra)
                                        {
                                            cboEstadoDeLaCompra.Text = "Parcial";
                                            Debe = TotalCompra - Pago;
                                            txtdebe.Text = Debe.ToString();
                                            txtdevuelta.Text = "0";
                                        }
                                        else
                                        {
                                            cboEstadoDeLaCompra.Text = "Completa";
                                            Devuelta = Pago - TotalCompra;
                                            txtdebe.Text = "0";
                                            txtdevuelta.Text = Devuelta.ToString();
                                        }
                                    }
                                }

                                break;

                        }



                    }


                }


                DataTable CompraDetalles = new DataTable();
                CompraDetalles.Columns.Add("IdVenta");
                CompraDetalles.Columns.Add("IdProducto");
                CompraDetalles.Columns.Add("CodProducto");
                CompraDetalles.Columns.Add("Cantidad");
                CompraDetalles.Columns.Add("Precio");
                CompraDetalles.Columns.Add("Descuento");
                CompraDetalles.Columns.Add("Impuesto");
                CompraDetalles.Columns.Add("Subtotal");
                CompraDetalles.Columns.Add("Total");



                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {

                    CompraDetalles.Rows.Add(new object[]
                    {
                       Convert.ToInt32(IdVenta),
                       Convert.ToInt32(item.Cells["IdProducto"].Value),
                        Convert.ToInt32(item.Cells["CodProducto"].Value),
                       Convert.ToInt32(item.Cells["Cantidad"].Value),
                       Convert.ToInt32(item.Cells["Precio"].Value),
                       Convert.ToInt32(item.Cells["Descuento"].Value),
                       Convert.ToInt32(item.Cells["Impuesto"].Value),
                       Convert.ToInt32(item.Cells["SubTotal"].Value),
                       Convert.ToInt32(item.Cells["Total"].Value)
                    });


                }

                int IdEmpresa = 0;
                //Llamamos la tabla empresa para obtener la informacion de toda la empresa//
                cnempresa ObjEmpresa = new cnempresa();
                DataTable tabla = new DataTable();
                tabla = ObjEmpresa.Busqueda("");
                IdEmpresa = Convert.ToInt32(tabla.Rows[0]["IdEmpresa"]);

                
                GenerarComprobante();

                cnventas obj = new cnventas();
                obj.Insertar(
                    dIdUsuario, IdEmpresa,
                    MetodoPago,
                    Convert.ToInt32(cbotipocomprobante.SelectedValue),
                    txtnrocomprobante.Text,
                    cboEstadoDeLaCompra.Text,
                    dIdCliente,
                    TipoTarjeta,
                    txtdescripcion.Text,
                    txtNroTarjeta.Text,
                    txtTarjetaHabiente.Text,
                    Efectivo,
                    MontoDebitado,
                    Transferencia,
                    Pago,
                    TotalCompra,
                    Debe,
                    Devuelta,
                    CompraDetalles,
                    out Mensaje,
                   out IdVenta



                    );




                MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Quieres imprimir el ticket?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    try
                    {

                        fmimprimirReporte imprimir = fmimprimirReporte.Cargar("FacturaPorId");
                        imprimir.report1.SetParameterValue("IdVenta", IdVenta);


                        bool showdialog = true;

                        if (showdialog)
                        {
                            imprimir.ShowDialog();
                        }
                        else
                        {
                            imprimir.report1.Show();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }


                dsis.AbrirFormulario(new fmventasbusqueda(dIdUsuario, dsis));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCamposProductos();
        }
    }
}
