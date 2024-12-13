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

namespace CapaPresentacion.Inventario
{
    public partial class fminventario : Form
    {

        private fmSistema dsis;
        private string Busqueda = "";
        public fminventario(fmSistema dsis)
        {
            InitializeComponent();
            this.dsis = dsis;
            txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            Load += Fminventario_Load;
            btnImprimir.Click += BtnImprimir_Click;
        }

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarInventatio();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                fmimprimirReporte imprimir = fmimprimirReporte.Cargar("InventarioListar");
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

        private void Fminventario_Load(object sender, EventArgs e)
        {
            MostrarInventatio();
        }

        private void MostrarInventatio()
        {
            try
            {
                cnproductos obj = new cnproductos();
                Busqueda = txtbusqueda.Text.Trim();
                DataTable tabla = obj.Inventario(Busqueda);

                if (tabla != null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 9;
                    guna2DataGridView1.Columns["IdProducto"].Visible = false;
                    guna2DataGridView1.Columns["Precio"].Visible = false;
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
