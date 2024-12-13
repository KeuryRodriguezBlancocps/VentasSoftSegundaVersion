using CapaNegocio;
using CapaPresentacion.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Categorias
{
    public partial class fmcategoriasbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdCategoria;
        public fmcategoriasbusqueda(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            this.Load += Fmcategoriasbusqueda_Load;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            iconEliminar.Click += IconEliminar_Click;
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
        }

        private void IconEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar la categoría seleccionada?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cncategorias obj = new cncategorias();
                    obj.Eliminar(dIdCategoria, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmcategoriasbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dIdCategoria = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCategoria"].Value);
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

        private void Fmcategoriasbusqueda_Load(object sender, EventArgs e)
        {
            MostrarCategorias();
        }

        private void MostrarCategorias()
        {
            try
            {
                cncategorias obj = new cncategorias();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 5;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["IdCategoria"].HeaderText = "Codigo de la categoría";
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
            dsis.AbrirFormulario(new fmcategoriaregistrar(dIdUsuario, dsis));
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmcategoriaactualizar obj = new fmcategoriaactualizar(dIdUsuario, dsis, dIdCategoria);
            obj.ShowDialog();

        }
    }
}
