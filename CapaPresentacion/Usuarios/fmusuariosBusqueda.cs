using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Usuarios
{
    public partial class fmusuariosBusqueda : Form
    {
        private string Busqueda = "";
        private fmSistema fmsis;
        private int dIdUsuario;
        private int dIdRol;
        public fmusuariosBusqueda(fmSistema fmsis)
        {
            InitializeComponent();
            this.Load += FmusuariosBusqueda_Load;
            this.txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            this.guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            this.guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            this.fmsis = fmsis;
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dIdUsuario = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdUsuario"].Value);
                dIdRol = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdRol"].Value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);;
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
            MostrarUsuarios();
        }

        private void FmusuariosBusqueda_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            try
            {
                cnusuarios ObjUsuarios = new cnusuarios();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = ObjUsuarios.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 8;
                    guna2DataGridView1.Columns["Password"].Visible = false;
                    guna2DataGridView1.Columns["IdRol"].Visible = false;
                    guna2DataGridView1.Columns["IdUsuario"].HeaderText = "Codigo del usuario";
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
            fmsis.AbrirFormulario(new fmusuarioregistrar(fmsis));
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmsis.AbrirFormulario(new fmusuarioactualizar(fmsis, dIdUsuario, dIdRol));
        }
    }
}
