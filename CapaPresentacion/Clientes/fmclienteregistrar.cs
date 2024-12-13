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

namespace CapaPresentacion.Clientes
{
    public partial class fmclienteregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public fmclienteregistrar(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                cnclientes obj = new cnclientes();

                if (txtcliente.Text.Length < 3 && txtcliente.Text.Length>0)
                {
                    MessageBox.Show("El nombre es muy corto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcliente.Focus();
                }
               else if (txtcliente.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo nombre vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcliente.Focus();
                }

                else if (txttelefono.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo telefono vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttelefono.Focus();
                }
                else
                {
                    obj.Insertar(dIdUsuario, txtcliente.Text, txttelefono.Text, txtdireccion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmclientesbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmclientesbusqueda(dIdUsuario, dsis));
        }
    }
}
