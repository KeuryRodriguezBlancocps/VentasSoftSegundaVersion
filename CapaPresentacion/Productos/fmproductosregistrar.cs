using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace CapaPresentacion.Productos
{
    public partial class fmproductosregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public int dIdLaboratorio = 0;
        public fmproductosregistrar(int pIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            Load += Fmproductosregistrar_Load;
            dIdUsuario = pIdUsuario;
            this.dsis = dsis;
            btnAbrirFormularioGestion.Click += BtnAbrirFormularioGestion_Click;
        }

        private void BtnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            try
            {
                dsis.AbrirFormulario(new fmproductosbusqueda(dIdUsuario, dsis));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Fmproductosregistrar_Load(object sender, EventArgs e)
        {
            MostrarSecciones();
            MostrarCategorias();
            MostrarUbicaciones();
        }

        public void MostrarSecciones()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnsecciones obj = new cnsecciones();
                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    cbosecciones.DataSource = tabla;
                    cbosecciones.ValueMember = "IdSeccion";
                    cbosecciones.DisplayMember = "Nombre";
                }

            }
            catch (Exception ex)
            {

                cbosecciones.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }



        public void MostrarCategorias()
        {
            try
            {
                DataTable tabla = new DataTable();
                cncategorias obj = new cncategorias();
                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    cboCategoria.DataSource = tabla;
                    cboCategoria.ValueMember = "IdCategoria";
                    cboCategoria.DisplayMember = "Categoria";
                }

            }
            catch (Exception ex)
            {

                cboCategoria.DataSource = null;
                MessageBox.Show(ex.Message);
            }
        }



        public void MostrarUbicaciones()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnubicaciones obj = new cnubicaciones();
                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    cboubicacion.DataSource = tabla;
                    cboubicacion.ValueMember = "IdUbicacion";
                    cboubicacion.DisplayMember = "Ubicacion";
                }

            }
            catch (Exception ex)
            {

                cboubicacion.DataSource = null;
                MessageBox.Show(ex.Message);
            }
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

        private void btnRegistrar_Click(object sender, EventArgs e)
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

                    byte[] imagen = null;
                    if (pictureBox1.Image!=null)
                    {

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                     pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imagen = ms.ToArray();
                    }

                    string mensaje = "";
                    cnproductos obj = new cnproductos();
                    
                    obj.Insertar(dIdUsuario, txtcodproducto.Text, txtnombre.Text, txtdescripcion.Text, imagen,
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

        private void cboAplicaImpuesto_TextChanged(object sender, EventArgs e)
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
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscarLaboratorio_Click(object sender, EventArgs e)
        {
            fmlaboratorioseleccionar obj = new fmlaboratorioseleccionar(this, null);
            obj.ShowDialog();
        }

        private void btnregistrarcategoria_Click(object sender, EventArgs e)
        {
            fmcategoriacrear obj = new fmcategoriacrear(dIdUsuario, dsis, this,null);
            obj.ShowDialog();
        }

        private void icoregistrarseccion_Click(object sender, EventArgs e)
        {
            fmseccionregistrar obj = new fmseccionregistrar(dIdUsuario, dsis, this, null);
            obj.ShowDialog();
        }

        private void icoubicacionagregar_Click(object sender, EventArgs e)
        {
            fmubicacionregistrar obj = new fmubicacionregistrar(dIdUsuario, this, null);
            obj.ShowDialog();
        }
    }
}
