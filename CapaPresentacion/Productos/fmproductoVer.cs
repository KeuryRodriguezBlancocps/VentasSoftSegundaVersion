using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CapaPresentacion.Productos
{
    public partial class fmproductoVer : Form
    {
        private int dIdProducto;
        private byte[] dImagen;
        public fmproductoVer(int dIdProducto, byte[] dImagen)
        {
            InitializeComponent();
            this.dIdProducto = dIdProducto;
            Load += FmproductoVer_Load;
            this.dImagen = dImagen;
        }

        private void FmproductoVer_Load(object sender, EventArgs e)
        {
            MostrarProductoPorId();
        }

        private void MostrarProductoPorId()
        {
            try
            {
                cnproductos obj = new cnproductos();
                DataTable tabla = new DataTable();
                tabla = obj.ProductoPorId(dIdProducto);
                if (tabla!=null)
                {
                    txtcodproducto.Text = Convert.ToString(tabla.Rows[0]["CodProducto"]);
                    txtnombre.Text = Convert.ToString(tabla.Rows[0]["Producto"]);
                    txtdescripcion.Text = Convert.ToString(tabla.Rows[0]["Descripcion"]);
                    txtseccion.Text = Convert.ToString(tabla.Rows[0]["Seccion"]);
                    txtubicacion.Text = Convert.ToString(tabla.Rows[0]["Ubicacion"]);
                    txtcategoria.Text = Convert.ToString(tabla.Rows[0]["Categoria"]);
                    txtaplicaimpuesto.Text = Convert.ToString(tabla.Rows[0]["AplicaImpuesto"]);
                    txtprecio.Text = Convert.ToString(tabla.Rows[0]["Precio"]);
                    txtcosto.Text = Convert.ToString(tabla.Rows[0]["Costo"]);
                    txtimpuesto.Text = Convert.ToString(tabla.Rows[0]["Impuesto"]);
                    txtstock.Text = Convert.ToString(tabla.Rows[0]["Stock"]);

                    if (tabla.Rows[0]["Imagen"]!=DBNull.Value)
                    {
                         
                        dImagen = (byte[])tabla.Rows[0]["Imagen"]; 
                        using (MemoryStream ms = new MemoryStream(dImagen))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        dImagen = null;
                        pictureBox1.Image = null;
                    }
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
