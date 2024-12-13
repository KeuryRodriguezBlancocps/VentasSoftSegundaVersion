using CapaNegocio;
using Guna.UI2.AnimatorNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ventas
{
    public partial class fmventasver : Form
    {
        private int dIdVenta;
        public fmventasver(int dIdVenta)
        {
            InitializeComponent();
            Load += Fmventasver_Load;
            this.dIdVenta = dIdVenta;
        }

        private void Fmventasver_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            MostrarVentaPorId();
            VentaDetallePorId();
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
                    txtnrocompra.Text = Convert.ToString(tabla.Rows[0]["IdVenta"]);
                    txtusuarioresponsable.Text = Convert.ToString(tabla.Rows[0]["Usuario"]);
                    txtcliente.Text = Convert.ToString(tabla.Rows[0]["Cliente"]);
                    txttipodecomprobante.Text = Convert.ToString(tabla.Rows[0]["TipoComprobante"]);
                    txtnrocomprobante.Text = Convert.ToString(tabla.Rows[0]["NroComprobante"]);
                    txtusuarioresponsable.Text = Convert.ToString(tabla.Rows[0]["Usuario"]);
                    txtestadoventa.Text = Convert.ToString(tabla.Rows[0]["EstadoVenta"]);
                    txtmetododepago.Text = Convert.ToString(tabla.Rows[0]["MetodoPago"]);
                    txttipotarjeta.Text = Convert.ToString(tabla.Rows[0]["TipoTarjeta"]);
                    txtnrotarjeta.Text = Convert.ToString(tabla.Rows[0]["NroTarjeta"]);
                    txttarjetahabiente.Text = Convert.ToString(tabla.Rows[0]["TarjetaHabiente"]);
                    txtmontodebitado.Text = Convert.ToString(tabla.Rows[0]["MontoDebitado"]);
                    txttransferencia.Text = Convert.ToString(tabla.Rows[0]["Transferencia"]);
                    txtefectivo.Text = Convert.ToString(tabla.Rows[0]["Efectivo"]);
                    txtpago.Text = Convert.ToString(tabla.Rows[0]["Pago"]);
                    txttotal.Text = Convert.ToString(tabla.Rows[0]["Total"]);
                    txtsubtotal.Text = Convert.ToString(tabla.Rows[0]["SubTotal"]);
                    txtdebe.Text = Convert.ToString(tabla.Rows[0]["Debe"]);
                    txtdevuelta.Text = Convert.ToString(tabla.Rows[0]["Devuelta"]);
                    txtfecha.Text = Convert.ToString(tabla.Rows[0]["FechaCreacion"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void VentaDetallePorId()
        {
            try
            {
                cnventas obj = new cnventas();
                DataTable tabla = new DataTable();
                tabla = obj.ventadetalleporId(dIdVenta);
                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
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



    }
}
