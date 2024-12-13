using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Compras
{
    public partial class fmcomprasver : Form
    {
        private int dIdCompra;
        public fmcomprasver(int dIdCompra)
        {
            InitializeComponent();
            this.dIdCompra = dIdCompra;
            Load += Fmcomprasver_Load;
        }

        private void Fmcomprasver_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            MostrarCompraPorId();
            MostrarCompraDetallePorId();
        }

        private void MostrarCompraPorId()
        {
            try
            {
                cncompra obj = new cncompra();
                DataTable tabla = new DataTable();
                tabla = obj.compraporId(dIdCompra);
                if (tabla!=null)
                {
                    txtnrocompra.Text = Convert.ToString(tabla.Rows[0]["IdCompra"]);
                    txtusuarioresponsable.Text = Convert.ToString(tabla.Rows[0]["Usuario"]);
                    txtsuplidor.Text = Convert.ToString(tabla.Rows[0]["Nombre"]);
                    txtnrocomprobante.Text = Convert.ToString(tabla.Rows[0]["NroComprobante"]);
                    txtusuarioresponsable.Text = Convert.ToString(tabla.Rows[0]["Usuario"]);
                    txtmetododepago.Text = Convert.ToString(tabla.Rows[0]["MetodoPago"]);
                    txttipotarjeta.Text = Convert.ToString(tabla.Rows[0]["TipoTarjeta"]);
                    txtnrotarjeta.Text = Convert.ToString(tabla.Rows[0]["NroTarjeta"]);
                    txttarjetahabiente.Text = Convert.ToString(tabla.Rows[0]["TarjetaHabiente"]);
                    txtmontodebitado.Text = Convert.ToString(tabla.Rows[0]["MontoDebitado"]);
                    txttransferencia.Text = Convert.ToString(tabla.Rows[0]["Transferencia"]);
                    txtefectivo.Text = Convert.ToString(tabla.Rows[0]["Efectivo"]);
                    txtpago.Text = Convert.ToString(tabla.Rows[0]["Pago"]);
                    txttotal.Text = Convert.ToString(tabla.Rows[0]["Total"]);
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



        private void MostrarCompraDetallePorId()
        {
            try
            {
                cncompra obj = new cncompra();
                DataTable tabla = new DataTable();
                tabla = obj.compraporDetallePorId(dIdCompra);
                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["CodProducto"].Width = 100;
                    guna2DataGridView1.Columns["Producto"].Width = 100;
                    guna2DataGridView1.Columns["IdCompraDetalles"].Visible = false;
                    guna2DataGridView1.Columns["IdProducto"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
