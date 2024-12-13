using CapaNegocio;
using CapaPresentacion.Laboratorios;
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

namespace CapaPresentacion.Productos
{
    public partial class fmproductosbusqueda : Form
    {
        private string Busqueda = "";
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdProducto;
        private byte[] dImagen;
        private int dIdUbicacion;
        private int dIdSeccion;
        private int dIdCategoria;
        private int dIdLaboratorio;
        public fmproductosbusqueda(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            this.Load += Fmproductosbusqueda_Load;
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            guna2DataGridView1.CellMouseDown += Guna2DataGridView1_CellMouseDown;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            iconEliminar.Click += IconEliminar_Click;
        }

        private void IconEliminar_Click(object sender, EventArgs e)
        {

            try
            {

                string mensaje = "";
                DialogResult result = MessageBox.Show("Quieres eliminar el producto seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cnproductos obj = new cnproductos();
                    obj.Eliminar(dIdProducto, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmproductosbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                dIdProducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
                dIdSeccion = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdSeccion"].Value);
                dIdUbicacion = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdUbicacion"].Value);
                dIdCategoria = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCategoria"].Value);
                if (guna2DataGridView1.CurrentRow.Cells["Imagen"].Value!=DBNull.Value)
                {

                dImagen = (byte[])(guna2DataGridView1.CurrentRow.Cells["Imagen"].Value);
                }
                else
                {
                    dImagen = null;
                }
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

        private void Fmproductosbusqueda_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            gunaContextMenuStrip1.Cursor = Cursors.Hand;
        }

        private void MostrarProductos()
        {
            try
            {
                cnproductos obj = new cnproductos();
                Busqueda = txtbusqueda.Text.Trim();

                DataTable tabla = obj.Busqueda(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 18;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Stock"].Visible = false;
                    guna2DataGridView1.Columns["Estado"].Visible = false;
                    guna2DataGridView1.Columns["AplicaImpuesto"].Visible = false;
                    guna2DataGridView1.Columns["IdCategoria"].Visible = false;
                    guna2DataGridView1.Columns["IdUbicacion"].Visible = false;
                    guna2DataGridView1.Columns["IdSeccion"].Visible = false;
                    guna2DataGridView1.Columns["Imagen"].Visible = false;
                    guna2DataGridView1.Columns["Impuesto"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdProducto"].Visible = false;
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
            dsis.AbrirFormulario(new fmproductosregistrar(dIdUsuario, dsis));
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmproductoVer obj = new fmproductoVer(dIdProducto, dImagen);
            obj.ShowDialog();
        }

        private void IconActualizar_Click(object sender, EventArgs e)
        {
            fmproductoactualizar obj = new fmproductoactualizar(dIdUsuario,dIdProducto, dImagen, dIdSeccion, dIdUbicacion, dIdCategoria, dsis);
            obj.ShowDialog();                                                                   
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                fmimprimirReporte imprimir = fmimprimirReporte.Cargar("CatalogoProductos");
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
