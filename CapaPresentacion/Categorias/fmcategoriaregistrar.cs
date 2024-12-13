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
    public partial class fmcategoriaregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public fmcategoriaregistrar(int DIdUsuario, fmSistema Dsis)
        {
            InitializeComponent();
            dIdUsuario = DIdUsuario;
            dsis = Dsis;
            btnAbrirFormularioGestion.Click += BtnAbrirFormularioGestion_Click;
        }

        private void BtnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmcategoriasbusqueda(dIdUsuario, dsis));
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                cncategorias obj = new cncategorias();
                if (txtcategoria.Text== string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo categrías vacío","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcategoria.Focus();
                    return;
                }
                else
                {
                    obj.Insertar(dIdUsuario, txtcategoria.Text, txtdireccion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmcategoriasbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
