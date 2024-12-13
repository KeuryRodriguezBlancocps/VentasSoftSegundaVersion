using CapaNegocio;
using CapaPresentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CapaPresentacion.Clientes
{
    public partial class fmclientesbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdCliente;
        public fmclientesbusqueda(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            Load += Fmclientesbusqieda_Load;
            this.guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            this.txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            
        }

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void Guna2DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    dIdCliente = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCliente"].Value);
                    DataGridViewCell clickedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Rectangle cellBounds = guna2DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point cellPosition = new Point(cellBounds.Left, cellBounds.Bottom);
                    gunaContextMenuStrip1.Show(guna2DataGridView1, cellPosition);
                }
            }
        }

        private void Fmclientesbusqieda_Load(object sender, EventArgs e)
        {
            MostrarClientes();
            gunaContextMenuStrip1.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void MostrarClientes()
        {
            try
            {
                cnclientes obj = new cnclientes();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 7;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdCliente"].HeaderText = "Codigo del cliente";
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

        private void btnAbrirFormularioAgregar_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmclienteregistrar(dIdUsuario, dsis));
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmclientesactualizar(dIdCliente, dsis, dIdUsuario));
        }

        private void iconEliminar_Click(object sender, EventArgs e)
        {
            try
            {
           
            string mensaje = "";
            DialogResult result = MessageBox.Show("Quieres eliminar el cliente seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cnclientes obj = new cnclientes();
                obj.Eliminar(dIdCliente, out mensaje);
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsis.AbrirFormulario(new fmclientesbusqueda(dIdUsuario, dsis));
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
               }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                fmimprimirReporte imprimir = fmimprimirReporte.Cargar("ClienteLista");
                imprimir.report1.SetParameterValue("Busqueda", Busqueda);


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
    }
    }
