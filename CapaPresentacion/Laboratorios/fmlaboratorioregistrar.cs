using CapaNegocio;
using CapaPresentacion.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Laboratorios
{
    public partial class fmlaboratorioregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public fmlaboratorioregistrar(int dIdUsuario, fmSistema dsis)
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
                cnlaboratorios obj = new cnlaboratorios();

                if (txtlaboratorio.Text.Length < 3 && txtlaboratorio.Text.Length > 0)
                {
                    MessageBox.Show("El nombre es muy corto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtlaboratorio.Focus();
                }
                else if (txtlaboratorio.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo nombre vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtlaboratorio.Focus();
                }

                else if (txttelefono.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo telefono vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttelefono.Focus();
                }

                else if (txtemail.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo email vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtemail.Focus();
                }
                else
                {
                    obj.Insertar(dIdUsuario, txtlaboratorio.Text, txttelefono.Text, txtdireccion.Text, txtemail.Text,out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmclientesbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
