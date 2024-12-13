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

namespace CapaPresentacion.Productos
{
    public partial class fmlaboratorioseleccionar : Form
    {
        private fmproductosregistrar fmproductosregistrar;
        private fmproductoactualizar fmproductoactualizar;
        private string Busqueda = "";
        public fmlaboratorioseleccionar(fmproductosregistrar fmproductosregistrar, fmproductoactualizar Fmproductoactualizar)
        {
            InitializeComponent();
            this.fmproductosregistrar = fmproductosregistrar;
            fmproductoactualizar = Fmproductoactualizar;
            this.Load += Fmlaboratorioseleccionar_Load;
            txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex>=0 && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            //{
            //    if (fmproductosregistrar !=null && fmproductosregistrar.GetType() == typeof(fmproductosregistrar))
            //    {
            //        fmproductosregistrar.dIdLaboratorio =Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdLaboratorio"].Value);

            //    }
            //    else if (fmproductoactualizar != null && fmproductoactualizar.GetType() == typeof(fmproductoactualizar))
            //    {

            //    }
            //}
            //Close();
        }

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarLaboratorios();
        }

        private void Fmlaboratorioseleccionar_Load(object sender, EventArgs e)
        {
            MostrarLaboratorios();
        }

        private void MostrarLaboratorios()
        {
            try
            {
                cnlaboratorios obj = new cnlaboratorios();
                DataTable tabla = new DataTable();
                Busqueda = txtbusqueda.Text.Trim();
                
                tabla = obj.Busqueda(Busqueda);
                if (tabla!=null)
                {
                    guna2DataGridView1.DataSource = tabla;
                    guna2DataGridView1.Columns["Acciones"].DisplayIndex = 8;
                    guna2DataGridView1.Columns["IdUsuario"].Visible = false;
                    guna2DataGridView1.Columns["Usuario"].Visible = false;
                    guna2DataGridView1.Columns["IdLaboratorio"].Width= 150;
                    guna2DataGridView1.Columns["IdLaboratorio"].HeaderText = "Codigo del laboratorio";
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
