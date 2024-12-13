using CapaNegocio;
using CapaPresentacion.Productos;
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

namespace CapaPresentacion.Ubicaciones
{
    public partial class fmubicacionesbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdUbicacion;
        public fmubicacionesbusqueda(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            Load += Fmubicacionesbusqueda_Load;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            iconEliminar.Click += IconEliminar_Click;
        }

        private void IconEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar la ubicación seleccionada?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cnubicaciones obj = new cnubicaciones();
                    obj.Eliminar(dIdUbicacion, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmubicacionesbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dIdUbicacion = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdUbicacion"].Value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void Fmubicacionesbusqueda_Load(object sender, EventArgs e)
        {
            MostrarUbicaciones();
        }

        private void MostrarUbicaciones()
        {
            try
            {
                cnubicaciones obj = new cnubicaciones();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 6;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdUbicacion"].HeaderText = "Codigo de la ubicación";
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
            dsis.AbrirFormulario(new fmubicacionesregistrar(dIdUsuario, dsis));
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmubicacionactualizar obj = new fmubicacionactualizar(dIdUsuario, dsis, dIdUbicacion);
            obj.ShowDialog();
        }
    }
}
