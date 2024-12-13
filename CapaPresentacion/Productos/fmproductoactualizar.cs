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

namespace CapaPresentacion.Productos
{
    public partial class fmproductoactualizar : Form
    {
        private int dIdUsuario;
        private int dIdProducto;
        private DataTable tabla = new DataTable();
        private byte[] dImagen;
        private int dIdSeccion;
        private int dIdUbicacion;
        private int dIdCategoria;
        private fmSistema dsis;
        public fmproductoactualizar(int dIdUsuario, int dIdProducto, byte[] pimagen, int dIdSeccion, int dIdUbicacion, int dIdCategoria, fmSistema dsis)
        {
            InitializeComponent();
            Load += Fmproductoactualizar_Load;
            cboAplicaImpuesto.TextChanged += CboAplicaImpuesto_TextChanged;
            this.dIdUsuario = dIdUsuario;
            this.dIdProducto = dIdProducto;
            dImagen = pimagen;
            this.dIdSeccion = dIdSeccion;
            this.dIdUbicacion = dIdUbicacion;
            this.dIdCategoria = dIdCategoria;
            this.dsis = dsis;
        }

        private void CboAplicaImpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboAplicaImpuesto.Text == "Si")
                {
                    numImpuesto.Enabled = true;
                }
                else
                {
                    numImpuesto.Enabled = false;
                    numImpuesto.Value = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Fmproductoactualizar_Load(object sender, EventArgs e)
        {
            MostrarProductoPorId();
            MostrarSecciones();
            MostrarUbicaciones();
            MostrarCategorias();
        }



        public void MostrarUbicaciones()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnubicaciones obj = new cnubicaciones();
                if (dIdUbicacion > 0)
                { 
                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    cboubicacion.DataSource = tabla;
                    cboubicacion.ValueMember = "IdUbicacion";
                    cboubicacion.DisplayMember = "Ubicacion";
                    cboubicacion.SelectedValue = dIdUbicacion;
                }

                }
            }
            catch (Exception ex)
            {

                cboubicacion.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }



        public void MostrarCategorias()
        {
            try
            {
                DataTable tabla = new DataTable();
                cncategorias obj = new cncategorias();
                if (dIdCategoria>0)
                {

                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    cboCategoria.DataSource = tabla;
                    cboCategoria.ValueMember = "IdCategoria";
                    cboCategoria.DisplayMember = "Categoria";
                    cboCategoria.SelectedValue = dIdCategoria;
                 
                }

                }
            }
            catch (Exception ex)
            {

                cboCategoria.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }




        public void MostrarSecciones()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnsecciones obj = new cnsecciones();
                if (dIdSeccion>0)
                {

                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    cbosecciones.DataSource = tabla;
                    cbosecciones.ValueMember = "IdSeccion";
                    cbosecciones.DisplayMember = "Nombre";
                    cbosecciones.SelectedValue = dIdSeccion;

                }

                }
            }
            catch (Exception ex)
            {

                cbosecciones.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarProductoPorId()
        {
            try
            {
                cnproductos obj = new cnproductos();
                tabla = obj.ProductoPorId(dIdProducto);
                if (tabla != null)
                {
                    txtcodproducto.Text = Convert.ToString(tabla.Rows[0]["CodProducto"]);
                    txtnombre.Text = Convert.ToString(tabla.Rows[0]["Producto"]);
                    txtdescripcion.Text = Convert.ToString(tabla.Rows[0]["Descripcion"]);
                    cboAplicaImpuesto.Text = Convert.ToString(tabla.Rows[0]["AplicaImpuesto"]);
                    numPrecio.Text = Convert.ToString(tabla.Rows[0]["Precio"]);
                    numCosto.Text = Convert.ToString(tabla.Rows[0]["Costo"]);
                    numImpuesto.Text = Convert.ToString(tabla.Rows[0]["Impuesto"]);
                    numStock.Text = Convert.ToString(tabla.Rows[0]["Stock"]);

                    if (tabla.Rows[0]["Imagen"] != DBNull.Value)
                    {
                        byte[] imagen = (byte[])tabla.Rows[0]["Imagen"];
                    
                        using (MemoryStream ms = new MemoryStream(imagen))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }








        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcodproducto.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo codproducto vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcodproducto.Focus();
                }

                else if (txtnombre.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo nombre vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombre.Focus();
                }


                else if (cboCategoria.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo categoría vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboCategoria.Focus();
                }


                else if (cboubicacion.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo ubicación vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboubicacion.Focus();
                }

                else if (cbosecciones.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo sección vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbosecciones.Focus();
                }

                else if (cboAplicaImpuesto.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo aplica impuesto vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboAplicaImpuesto.Focus();
                }
                else
                {


                    if (cboAplicaImpuesto.Text == "Si")
                    {
                        if (numImpuesto.Value == 0)
                        {
                            MessageBox.Show("Debes de colocar el porciento del impuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            numImpuesto.Focus();
                        }
                    }
                    if (pictureBox1.Image == null)
                    {
                        dImagen = null;
                    }
                    else
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Crear una copia de la imagen para evitar que esté bloqueada
                            using (Bitmap bmp = new Bitmap(pictureBox1.Image))
                            {
                                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            dImagen = ms.ToArray();
                        }
                    }


                    string mensaje = "";
                    cnproductos obj = new cnproductos();
                    obj.Actualizar(dIdProducto,dIdUsuario, txtcodproducto.Text, txtnombre.Text, txtdescripcion.Text, dImagen,
                        Convert.ToInt32(cboubicacion.SelectedValue),
                        Convert.ToInt32(cbosecciones.SelectedValue),
                        Convert.ToInt32(cboCategoria.SelectedValue),
                        cboAplicaImpuesto.Text,
                       Convert.ToInt32(numImpuesto.Value),
                     Convert.ToInt32(numStock.Value),
                        numCosto.Value,
                        numPrecio.Value,
                      out mensaje

                        );
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    dsis.AbrirFormulario(new fmproductosbusqueda(dIdUsuario, dsis));
                    
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btneliminarimagen_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnseleccionarimagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            DialogResult result = open.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconbuscarlaboratorio_Click(object sender, EventArgs e)
        {
            fmlaboratorioseleccionar obj = new fmlaboratorioseleccionar(null, this);
            obj.ShowDialog();
        }

        private void icoubicacionagregar_Click(object sender, EventArgs e)
        {
            fmubicacionregistrar obj = new fmubicacionregistrar(dIdUsuario, null, this);
            obj.ShowDialog();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            fmcategoriacrear obj = new fmcategoriacrear(dIdUsuario, dsis,null, this);
            obj.ShowDialog();
        }


        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            fmseccionregistrar obj = new fmseccionregistrar(dIdUsuario, dsis, null, this);
            obj.ShowDialog();
        }
    }
}
