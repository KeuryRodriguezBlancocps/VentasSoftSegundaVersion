using CapaNegocio;
using FastReport.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Compras
{
    public partial class fmsuplidorseleccionar : Form
    {
        private string Busqueda = "";
        private fmcomprasregistrar fmcomprasregistrar;
        public fmsuplidorseleccionar(fmcomprasregistrar fmcomprasregistrar)
        {
            InitializeComponent();
            Load += Fmsuplidorseleccionar_Load;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            this.fmcomprasregistrar = fmcomprasregistrar;
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                if (Convert.ToString(guna2DataGridView1.CurrentRow.Cells["ManejaComprobantes"].Value) == "Si")
                {
                    fmcomprasregistrar.txtComprobante.Enabled = true;
                }
                fmcomprasregistrar.dIdSuplidor = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdSuplidor"].Value);
                fmcomprasregistrar.txtsuplidor.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Nombre"].Value);
                fmcomprasregistrar.txttelefono.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Telefono"].Value);
                fmcomprasregistrar.txtdireccion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Direccion"].Value);
                Close();
            }
        }

        private void Fmsuplidorseleccionar_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
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






        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
