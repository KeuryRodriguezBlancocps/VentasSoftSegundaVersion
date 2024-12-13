using CapaNegocio;
using CapaPresentacion.Pagos;
using CapaPresentacion.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Compras.consultas
{
    public partial class fmcomprasporfechas : Form
    {
        private string Busqueda = "";
        private fmSistema dsis;
        private int dIdUsuario;
        private int dIdCompra;
        public fmcomprasporfechas(fmSistema dsis, int dIdUsuario)
        {
            InitializeComponent();
            this.dsis = dsis;
            this.dIdUsuario = dIdUsuario;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
        }

        private void Guna2DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    DataGridViewCell clickedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Rectangle cellBounds = guna2DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point cellPosition = new Point(cellBounds.Left, cellBounds.Bottom);
                    gunaContextMenuStrip1.Show(guna2DataGridView1, cellPosition);
                }
            }
        }



        public void RecargarFormulario()
        {
            EventArgs e = new EventArgs();
            this.OnLoad(e);
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                dIdCompra = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCompra"].Value);

            }

            if (Convert.ToString(guna2DataGridView1.CurrentRow.Cells["EstadoCompra"].Value) != "Completa")
            {
                realizarPagoToolStripMenuItem.Visible = true;
            }
            else
            {
                realizarPagoToolStripMenuItem.Visible = false;
            }

            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                dIdCompra = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCompra"].Value);

            }
        }

        private void MostrarComprasPorFechas()
        {
            try
            {
                cncompra obj = new cncompra();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.compraPorFecha(Busqueda, dateDesde.Value, dateHasta.Value);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["IdSuplidor"].Visible = false;
                    guna2DataGridView1.Columns["Efectivo"].Visible = false;
                    guna2DataGridView1.Columns["TarjetaHabiente"].Visible = false;
                    guna2DataGridView1.Columns["MontoDebitado"].Visible = false;
                    guna2DataGridView1.Columns["Transferencia"].Visible = false;
                    guna2DataGridView1.Columns["TipoTarjeta"].Visible = false;
                    guna2DataGridView1.Columns["NroTarjeta"].Visible = false;
                    guna2DataGridView1.Columns["Efectivo"].Visible = false;
                    guna2DataGridView1.Columns["IdEmpresa"].Visible = false;
                    guna2DataGridView1.Columns["Debe"].Visible = false;
                    guna2DataGridView1.Columns["Devuelta"].Visible = false;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["Descripcion"].Visible = false;
                    guna2DataGridView1.Columns["IdCompra"].HeaderText = "Codigo de la compra";
                    guna2DataGridView1.Columns["EstadoCompra"].HeaderText = "Estado";
                    guna2DataGridView1.Columns["NroComprobante"].HeaderText = "Comprobante";
                    guna2DataGridView1.Columns["MetodoPago"].HeaderText = "Método";
                    guna2DataGridView1.Columns["NombreSuplidor"].HeaderText = "Suplidor";
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 21;
                    guna2DataGridView1.Columns["NombreSuplidor"].Width = 90;
                }
                else
                {
                    guna2DataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarComprasPorFechas();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmcomprasver obj = new fmcomprasver(dIdCompra);
            obj.ShowDialog();
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmcompractualizar obj = new fmcompractualizar(dIdCompra, dIdUsuario, dsis);
            obj.ShowDialog();
        }

        private void iconEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar la compra seleccionada?, disminuirá el stock de todos los productos que se encuentren en ella", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cncompra obj = new cncompra();
                    obj.Eliminar(dIdCompra, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmproductosbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void verPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void realizarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmpagos obj = new fmpagos(0, dIdCompra ,dIdUsuario, null, null, null, this);
            obj.ShowDialog();
        }
    }
}
