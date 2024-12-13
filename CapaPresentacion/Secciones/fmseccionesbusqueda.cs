using CapaNegocio;
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

namespace CapaPresentacion.Secciones
{
    public partial class fmseccionesbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdSeccion;
        private int dIdUsuario;
        private fmSistema dsis;
        public fmseccionesbusqueda(int pIdUsuario, fmSistema psis)
        {
            InitializeComponent();
            Load += Fmseccionesbusqueda_Load;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            IconActualizar.Click += IconActualizar_Click;
            iconEliminar.Click += IconEliminar_Click;
            dIdUsuario = pIdUsuario;
            dsis = psis;
        }

        private void IconEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar la sección seleccionada?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cnsecciones obj = new cnsecciones();
                    obj.Eliminar(dIdSeccion, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmseccionesbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmseccionesactualizar obj = new fmseccionesactualizar(dIdUsuario, dIdSeccion, dsis);
            obj.ShowDialog();
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                dIdSeccion = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdSeccion"].Value);
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

        private void Fmseccionesbusqueda_Load(object sender, EventArgs e)
        {
            MostrarSecciones();
        }

        private void MostrarSecciones()
        {
            try
            {
                cnsecciones obj = new cnsecciones();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 6;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdSeccion"].HeaderText = "Codigo de la sección";
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
            dsis.AbrirFormulario(new fmseccionesregistrar(dIdUsuario, dsis));
          
        }


    }
}
