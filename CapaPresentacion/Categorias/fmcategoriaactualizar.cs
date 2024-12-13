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

namespace CapaPresentacion.Categorias
{
    public partial class fmcategoriaactualizar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdCategoria;
        public fmcategoriaactualizar(int dIdUsuario, fmSistema dsis, int pIdCategoria )
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            dIdCategoria = pIdCategoria;
            Load += Fmcategoriaactualizar_Load;
        }

        private void Fmcategoriaactualizar_Load(object sender, EventArgs e)
        {
            CategoriaPorId();
        }

        private void CategoriaPorId()
        {
            try
            {
                cncategorias  obj = new cncategorias();

                DataTable tabla = obj.categoriasporId(dIdCategoria);

                if (tabla != null)
                {
                    txtcategoria.Text = Convert.ToString(tabla.Rows[0]["Categoria"]);
                    txtdireccion.Text = Convert.ToString(tabla.Rows[0]["Descripcion"]);
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
                string mensaje = "";
                cncategorias obj = new cncategorias();
                if (txtcategoria.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo categrías vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcategoria.Focus();
                    return;
                }
                else
                {
                    obj.Actualizar(dIdUsuario,dIdCategoria, txtcategoria.Text, txtdireccion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmcategoriasbusqueda(dIdUsuario, dsis));
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmcategoriasbusqueda(dIdUsuario, dsis));
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
