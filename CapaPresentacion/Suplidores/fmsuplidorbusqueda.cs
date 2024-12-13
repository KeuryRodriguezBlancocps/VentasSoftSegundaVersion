using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Clientes;
using CapaPresentacion.Reportes;
using Guna.UI.WinForms;
namespace CapaPresentacion.Suplidores
{
    public partial class fmsuplidorbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdUsuario;
        private int dIdSuplidor;
        private fmSistema dsis;
        public fmsuplidorbusqueda(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            this.Load += Fmsuplidorbusqueda_Load;
            this.guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
        }

        private void Guna2DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    dIdSuplidor = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdSuplidor"].Value);
                    Rectangle cellBounds = guna2DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point cellPosition = new Point(cellBounds.Left, cellBounds.Bottom);
                    gunaContextMenuStrip1.Show(guna2DataGridView1, cellPosition);
                }
            }
        }

        private void Fmsuplidorbusqueda_Load(object sender, EventArgs e)
        {
            MostrarSuplidores();
        }

        private void MostrarSuplidores()
        {
            try
            {
                cnsuplidores obj = new cnsuplidores();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 8;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdSuplidor"].HeaderText = "Codigo del suplidor";
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
            dsis.AbrirFormulario(new fmsuplidoresregistrar(dIdUsuario, dsis));
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmsuplidoractualizar(dIdUsuario, dsis, dIdSuplidor));

        }

        private void iconEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar el suplidor seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cnsuplidores obj = new cnsuplidores();
                    obj.Eliminar(dIdSuplidor, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmsuplidorbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                fmimprimirReporte imprimir = fmimprimirReporte.Cargar("SuplidoresListar");
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
