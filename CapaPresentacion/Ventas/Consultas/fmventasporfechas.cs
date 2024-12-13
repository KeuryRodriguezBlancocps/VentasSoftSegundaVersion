using CapaNegocio;
using CapaPresentacion.Pagos;
using CapaPresentacion.Productos;
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

namespace CapaPresentacion.Ventas.Consultas
{
    public partial class fmventasporfechas : Form
    {
        private fmSistema dsis;
        private string Busqueda = "";
        private int dIdVenta;
        private int dIdUsuario;

        public fmventasporfechas(fmSistema dsis, int dIdUsuario)
        {
            InitializeComponent();
            this.dsis = dsis;
            Load += Fmventasporfechas_Load;
            txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            this.dIdUsuario = dIdUsuario;
            fmventasbusqueda obj = new fmventasbusqueda(dIdUsuario, dsis);
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                dIdVenta = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdVenta"].Value);

            }

            if (Convert.ToString(guna2DataGridView1.CurrentRow.Cells["EstadoVenta"].Value) != "Completa")
            {
                realizarPagosToolStripMenuItem.Visible = true;
            }
            else
            {
                realizarPagosToolStripMenuItem.Visible = false;
            }
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

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                MostrarVentasPorFechas();
            }
        }

        private void Fmventasporfechas_Load(object sender, EventArgs e)
        {
            
        }

        private void MostrarVentasPorFechas()
        {
            try
            {
                cnventas Obj = new cnventas();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = Obj.VentasPorFecha(Busqueda, dateDesde.Value, dateHasta.Value);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Efectivo"].Visible = false;
                    guna2DataGridView1.Columns["TarjetaHabiente"].Visible = false;
                    guna2DataGridView1.Columns["MontoDebitado"].Visible = false;
                    guna2DataGridView1.Columns["Transferencia"].Visible = false;
                    guna2DataGridView1.Columns["TipoTarjeta"].Visible = false;
                    guna2DataGridView1.Columns["NroTarjeta"].Visible = false;
                    guna2DataGridView1.Columns["Efectivo"].Visible = false;
                    guna2DataGridView1.Columns["Debe"].Visible = false;
                    guna2DataGridView1.Columns["Devuelta"].Visible = false;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["IdCliente"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["Descripcion"].Visible = false;
                    guna2DataGridView1.Columns["Estadoventa"].HeaderText = "Estado";
                    guna2DataGridView1.Columns["NroComprobante"].HeaderText = "Comprobante";
                    guna2DataGridView1.Columns["MetodoPago"].HeaderText = "Método";
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 22;
                    guna2DataGridView1.Columns["IdVenta"].HeaderText = "Codigo de la venta";
                    guna2DataGridView1.Columns["IdVenta"].Width = 130;

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
            MostrarVentasPorFechas();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmventasver obj = new fmventasver(dIdVenta);
            obj.ShowDialog();
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmventasactualizar obj = new fmventasactualizar(dIdVenta, dIdUsuario);
            obj.ShowDialog();
        }

        private void realizarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmpagos obj = new fmpagos(dIdVenta, 0,dIdUsuario, null, null, this, null) ;
            obj.ShowDialog();
        }

        private void verPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmpagover obj = new fmpagover(dIdVenta, 0);
            obj.ShowDialog();
        }



        public void RecargarFormulario()
        {
            EventArgs e = new EventArgs();
            this.OnLoad(e);
        }






        private void iconEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar la venta seleccionada?, disminuirá el stock de todos los productos que se encuentren en ella", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cnventas obj = new cnventas();
                    obj.Eliminar(dIdVenta, dIdUsuario, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmproductosbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
