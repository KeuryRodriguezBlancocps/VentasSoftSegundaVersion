using CapaNegocio;
using CapaPresentacion.Clientes;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Laboratorios
{
    public partial class fmlaboratoriosbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdLaboratorio;
        private int dIdUsuario;
        private fmSistema dsis;
        public fmlaboratoriosbusqueda(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            this.Load += Fmlaboratoriosbusqueda_Load;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
        }

        private void Guna2DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    dIdLaboratorio = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdLaboratorio"].Value);
                    DataGridViewCell clickedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Rectangle cellBounds = guna2DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point cellPosition = new Point(cellBounds.Left, cellBounds.Bottom);
                    gunaContextMenuStrip1.Show(guna2DataGridView1, cellPosition);
                }
            }
        }

        private void Fmlaboratoriosbusqueda_Load(object sender, EventArgs e)
        {
            MostrarLaboratorios();
        }

        private void MostrarLaboratorios()
        {
            try
            {
                cnlaboratorios obj = new cnlaboratorios();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 8;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdLaboratorio"].HeaderText = "Codigo del laboratorio";
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
            dsis.AbrirFormulario(new fmlaboratorioregistrar(dIdUsuario, dsis));
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmlaboratorioactualizar(dIdUsuario, dsis, dIdLaboratorio));
        }

        private void iconEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar el laboratorio seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cnlaboratorios obj = new cnlaboratorios();
                    obj.Eliminar(dIdLaboratorio, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmlaboratoriosbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
