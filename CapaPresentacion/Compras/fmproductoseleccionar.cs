using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Compras
{
    public partial class fmproductoseleccionar : Form
    {
        private string Busqueda = "";
        private fmcomprasregistrar fmcomprasregistrar;
        private fmcompractualizar fmcompractualizar;
        private fmventasregistrar dventaregistrar;
        private fmventasactualizar dventactualizar;
        public fmproductoseleccionar(fmcomprasregistrar fmcomprasregistrar, fmcompractualizar fmcompractualizar, fmventasregistrar pventaregistrar, fmventasactualizar dventactualizar)
        {
            InitializeComponent();
            guna2DataGridView1.CellContentClick += Guna2DataGridView1_CellContentClick;
            Load += Fmproductoseleccionar_Load;
            this.fmcomprasregistrar = fmcomprasregistrar;
            this.fmcompractualizar = fmcompractualizar;
            dventaregistrar = pventaregistrar;
            txtbusqueda.TextChanged += Txtbusqueda_TextChanged;
            this.dventactualizar = dventactualizar;
        }

        private void Txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( fmcomprasregistrar!=null && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                fmcomprasregistrar.numprecio.Value = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["Precio"].Value);
                fmcomprasregistrar.numcosto.Value = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["Costo"].Value);
                fmcomprasregistrar.numImpuesto.Value = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Impuesto"].Value);
                fmcomprasregistrar.cboAplicaImpuesto.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["AplicaImpuesto"].Value);
                fmcomprasregistrar.dIdProducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
                fmcomprasregistrar.CodigoProducto = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value);
                fmcomprasregistrar.txtproducto.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Producto"].Value);
                fmcomprasregistrar.txtcategoria.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Categoria"].Value);
                fmcomprasregistrar.txtdescripcion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Descripcion"].Value);
                Close();
            }
            else if (fmcompractualizar != null && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
                fmcompractualizar.numprecio.Value = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["Precio"].Value);
                fmcompractualizar.numcosto.Value = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["Costo"].Value);
                fmcompractualizar.numImpuesto.Value = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Impuesto"].Value);
                fmcompractualizar.cboAplicaImpuesto.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["AplicaImpuesto"].Value);
                fmcompractualizar.dIdProducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
                fmcompractualizar.CodigoProducto = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value);
                fmcompractualizar.txtproducto.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Producto"].Value);
                fmcompractualizar.txtcategoria.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Categoria"].Value);
                fmcompractualizar.txtdescripcion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Descripcion"].Value);
                Close();
            }

            else if (dventaregistrar != null && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
               dventaregistrar.numprecio.Value = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["Precio"].Value);
               dventaregistrar.numImpuesto.Value = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Impuesto"].Value);
               dventaregistrar.dIdProducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
               dventaregistrar.CodigoProducto = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value);
               dventaregistrar.txtproducto.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Producto"].Value);
               dventaregistrar.txtcategoria.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Categoria"].Value);
                dventaregistrar.txtdescripcion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Descripcion"].Value);
                Close();
            }

            else if (dventactualizar != null && guna2DataGridView1.Columns[e.ColumnIndex].Name == "Acciones")
            {
               dventactualizar.numprecio.Value = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["Precio"].Value);
               dventactualizar.numImpuesto.Value = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Impuesto"].Value);
               dventactualizar.dIdProducto = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["IdProducto"].Value);
               dventactualizar.CodigoProducto = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["CodProducto"].Value);
               dventactualizar.txtproducto.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Producto"].Value);
               dventactualizar.txtcategoria.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Categoria"].Value);
                dventactualizar.txtdescripcion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Descripcion"].Value);
                Close();
            }


        }

        private void Fmproductoseleccionar_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            MostrarProductos();
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
                    guna2DataGridView1.Columns["Estado"].Visible = false;
                    guna2DataGridView1.Columns["AplicaImpuesto"].Visible = false;
                    guna2DataGridView1.Columns["Ubicacion"].Visible = false;
                    guna2DataGridView1.Columns["Seccion"].Visible = false;
                    guna2DataGridView1.Columns["IdCategoria"].Visible = false;
                    guna2DataGridView1.Columns["IdUbicacion"].Visible = false;
                    guna2DataGridView1.Columns["IdSeccion"].Visible = false;
                    guna2DataGridView1.Columns["Imagen"].Visible = false;
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

    }
}
