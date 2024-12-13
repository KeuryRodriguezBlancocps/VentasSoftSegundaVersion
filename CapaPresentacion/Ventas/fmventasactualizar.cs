using CapaNegocio;
using CapaPresentacion.Compras;
using FastReport.DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ventas
{
    public partial class fmventasactualizar : Form
    {
        private int dIdVenta;
        private int dIdUsuario;
        public int dIdProducto;
        public string CodigoProducto;
        public int dIdCliente;
        private bool ProductoEncontrado = false;
        private int dImpuesto = 0;
        private int dIdTipoComprobante;
        public fmventasactualizar(int dIdVenta, int dIdUsuario)
        {
            InitializeComponent();
            this.dIdVenta = dIdVenta;
            Load += Fmventasactualizar_Load;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            btnconfirmar.Click += Btnconfirmar_Click;
            btnEnviarAlaLista.Click += BtnEnviarAlaLista_Click;
            cboMetodoPago.TextChanged += CboMetodoPago_TextChanged;
            this.dIdUsuario = dIdUsuario;
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

                int Cantidad;
                int OperacionParaCantidadAlMismoProducto;
                decimal dSubtotal;
                decimal Precio;
                if (txtproducto.Text == string.Empty)
                {
                    MessageBox.Show("Debe de seleccionar un producto para proceder la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value) == CodigoProducto)
                        {
                            ProductoEncontrado = true;
                            Cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value);
                            Precio = Convert.ToInt32(item.Cells["Precio"].Value);
                            OperacionParaCantidadAlMismoProducto = Cantidad + Convert.ToInt32(numCantidad.Value);
                            dSubtotal = Precio * OperacionParaCantidadAlMismoProducto;
                            item.Cells["Cantidad"].Value = OperacionParaCantidadAlMismoProducto;
                            item.Cells["Subtotal"].Value = dSubtotal;
                            item.Cells["Total"].Value = dSubtotal;
                            CalcularTotal();
                        }

                    }

                    if (!ProductoEncontrado)
                    {
                        Precio = numprecio.Value;
                        Cantidad = Convert.ToInt32(numCantidad.Value);
                        dSubtotal = Precio * Cantidad;
                        DataTable NuevosProductos = new DataTable();
                        NuevosProductos = guna2DataGridView1.DataSource as DataTable;
                        DataRow DataRow;
                        DataRow = NuevosProductos.NewRow();
                        DataRow["CodProducto"] = CodigoProducto;
                        DataRow["Impuesto"] = dImpuesto;
                        DataRow["Descuento"] = txtdescuento.Value;
                        DataRow["IdProducto"] = dIdProducto;
                        DataRow["Producto"] = txtproducto.Text;
                        DataRow["Cantidad"] = numCantidad.Text;
                        DataRow["Precio"] = numprecio.Value;
                        DataRow["SubTotal"] = dSubtotal;
                        DataRow["Total"] = dSubtotal;
                        NuevosProductos.Rows.Add(DataRow);

                        CalcularTotal();
                        LimpiarCamposProductos();

                    }


                }


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




        private void Btnconfirmar_Click(object sender, EventArgs e)
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


                DataTable ventaDetalles = new DataTable();
               ventaDetalles.Columns.Add("IdVenta");
               ventaDetalles.Columns.Add("IdProducto");
               ventaDetalles.Columns.Add("CodProducto");
               ventaDetalles.Columns.Add("Cantidad");
               ventaDetalles.Columns.Add("Precio");
               ventaDetalles.Columns.Add("Descuento");
               ventaDetalles.Columns.Add("Impuesto");
               ventaDetalles.Columns.Add("Subtotal");
                ventaDetalles.Columns.Add("Total");



                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {

                    ventaDetalles.Rows.Add(new object[]
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


                cnventas obj = new cnventas();
                obj.Actualizar(
                    dIdVenta,
                    dIdUsuario, 
                    IdEmpresa,
                    MetodoPago,
                    dIdTipoComprobante,
                    txtComprobante.Text,
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
                    ventaDetalles,
                    out Mensaje


                    );

                MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularTotal()
        {
            decimal SubTotalCompra = 0;
            decimal TotalCompra = 0;

            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                SubTotalCompra += Convert.ToDecimal(item.Cells["SubTotal"].Value);
            }

            TotalCompra = SubTotalCompra;
            txtsubtotal.Text = Convert.ToString(SubTotalCompra);
            txttotal.Text = Convert.ToString(TotalCompra);
        }


        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    int EliminarFila = e.RowIndex;
                    dIdProducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
                    numCantidad.Value = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Cantidad"].Value);
                    cnproductos obj = new cnproductos();
                    DataTable tabla = new DataTable();
                    tabla = obj.ProductoPorId(dIdProducto);
                    CodigoProducto = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value);
                    txtproducto.Text = Convert.ToString(tabla.Rows[0]["Producto"]);
                    txtcategoria.Text = Convert.ToString(tabla.Rows[0]["Categoria"]);
                    txtdescripcion.Text = Convert.ToString(tabla.Rows[0]["Descripcion"]);
                    numprecio.Value = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Precio"].Value);
                    guna2DataGridView1.Rows.RemoveAt(EliminarFila);
                    CalcularTotal();
                }
                if (e.RowIndex >= 0)
                {
                    if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
                    {



                        DialogResult result = new DialogResult();
                        result = MessageBox.Show("Estas seguro/a de eliminar este producto de la venta?, esto aumentará su stock", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (result == DialogResult.Yes)
                        {
                            if (guna2DataGridView1.Rows.Count == 1)
                            {
                                MessageBox.Show("No puedes quitar este producto de la compra, ya que es el unico. Puedes ir a eliminar esta venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }

                        }
                        cnproductos objproductos = new cnproductos();
                        DataTable obtenerproductoAEliminar = new DataTable();
                        cnventas objventa = new cnventas();
                        int cantidad = 0;
                        int idproducto = 0;
                        string mensaje = "";
                        idproducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
                        cantidad = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Cantidad"].Value);
                        obtenerproductoAEliminar = objproductos.ProductoPorId(idproducto);
                        DataTable tablavalidar = new DataTable();
                        tablavalidar = objventa.ValidarSiElProductoSeEncuentraEnLaVenta(idproducto);
                        if (obtenerproductoAEliminar.Rows.Count > 0)
                        {
                            if (tablavalidar.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(obtenerproductoAEliminar.Rows[0]["Stock"]) < cantidad)
                                {
                                    MessageBox.Show("", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                    return;
                                }
                            }
                            int EliminarFila = e.RowIndex;
                            guna2DataGridView1.Rows.RemoveAt(EliminarFila);
                            objventa.ProductoEliminadoDeLaVentasAumentaStock(idproducto, cantidad, out mensaje);
                            CalcularTotal();
                            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Fmventasactualizar_Load(object sender, EventArgs e)
        {
            MostrarVentaDetalle();
            MostrarVentaPorId();
        }



        private void MostrarVentaPorId()
        {
            try
            {
                cnventas obj = new cnventas();
                DataTable tabla = new DataTable();
                tabla = obj.ventaporId(dIdVenta);
                if (tabla != null)
                {
                    dIdTipoComprobante = Convert.ToInt32(tabla.Rows[0]["IdTipoComprobante"]);
                    txtcodigoventa.Text = Convert.ToString(tabla.Rows[0]["IdVenta"]);
                    dIdCliente = Convert.ToInt32(tabla.Rows[0]["IdCliente"]);
                    txtcliente.Text = Convert.ToString(tabla.Rows[0]["Cliente"]);
                    txttelefono.Text = Convert.ToString(tabla.Rows[0]["ClienteTelefono"]);
                    txtdireccion.Text = Convert.ToString(tabla.Rows[0]["ClienteDireccion"]);
                    txttipocomprobante.Text = Convert.ToString(tabla.Rows[0]["TipoComprobante"]);
                    txtComprobante.Text = Convert.ToString(tabla.Rows[0]["NroComprobante"]);
                    cboEstadoDeLaCompra.Text = Convert.ToString(tabla.Rows[0]["EstadoVenta"]);
                    cboMetodoPago.Text = Convert.ToString(tabla.Rows[0]["MetodoPago"]);
                    cboTipoTarjeta.Text = Convert.ToString(tabla.Rows[0]["TipoTarjeta"]);
                    txtNroTarjeta.Text = Convert.ToString(tabla.Rows[0]["NroTarjeta"]);
                    txtTarjetaHabiente.Text = Convert.ToString(tabla.Rows[0]["TarjetaHabiente"]);
                    numDebitado.Text = Convert.ToString(tabla.Rows[0]["MontoDebitado"]);
                    numTransferencia.Text = Convert.ToString(tabla.Rows[0]["Transferencia"]);
                    numEfectivo.Text = Convert.ToString(tabla.Rows[0]["Efectivo"]);
                    txtpagototal.Text = Convert.ToString(tabla.Rows[0]["Pago"]);
                    txttotal.Text = Convert.ToString(tabla.Rows[0]["Total"]);
                    txtsubtotal.Text = Convert.ToString(tabla.Rows[0]["Total"]);
                    txtdebe.Text = Convert.ToString(tabla.Rows[0]["Debe"]);
                    txtdevuelta.Text = Convert.ToString(tabla.Rows[0]["Devuelta"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }






        private void MostrarVentaDetalle()
        {
            try
            {
                cnventas obj = new cnventas();
                DataTable tabla = new DataTable();
                tabla = obj.ventadetalleporId(dIdVenta);
                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Seleccionar"].DisplayIndex = 11;
                    guna2DataGridView1.Columns["Eliminar"].DisplayIndex = 11;
                    guna2DataGridView1.Columns["CodProducto"].Width = 100;
                    guna2DataGridView1.Columns["Producto"].Width = 100;
                    guna2DataGridView1.Columns["IdVentaDetalle"].Visible = false;
                    guna2DataGridView1.Columns["IdProducto"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void icoproductoseleccionar_Click(object sender, EventArgs e)
        {
            fmproductoseleccionar obj = new fmproductoseleccionar(null, null, null, this);
            obj.ShowDialog();
        }

        private void icobuscarcliente_Click(object sender, EventArgs e)
        {
            fmclienteseleccionar obj = new fmclienteseleccionar(null, this);
            obj.ShowDialog();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
