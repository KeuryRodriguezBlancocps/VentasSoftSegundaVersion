using CapaNegocio;
using CapaPresentacion.Compras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ventas
{
    public partial class fmclienteseleccionar : Form
    {
        private string Busqueda = "";
        private fmventasregistrar dventaregistrar;
        private fmventasactualizar dventaactualizar;
        public fmclienteseleccionar(fmventasregistrar dventaregistrar, fmventasactualizar pventaactualizar)
        {
            InitializeComponent();
            Load += Fmclienteseleccionar_Load;
            txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            this.dventaregistrar = dventaregistrar;
            dventaactualizar = pventaactualizar;
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                if (dventaregistrar!=null && dventaactualizar == null)
                {

                
                dventaregistrar.dIdCliente = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCliente"].Value);
                dventaregistrar.txtcliente.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Nombre"].Value);
                dventaregistrar.txttelefono.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Telefono"].Value);
                dventaregistrar.txtdireccion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Direccion"].Value);
                Close();
                }
                else
                {

                    dventaactualizar.dIdCliente = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdCliente"].Value);
                   dventaactualizar.txtcliente.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Nombre"].Value);
                   dventaactualizar.txttelefono.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Telefono"].Value);
                    dventaactualizar.txtdireccion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Direccion"].Value);
                }
            }
        }

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void Fmclienteseleccionar_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            MostrarClientes();
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

    }
}
