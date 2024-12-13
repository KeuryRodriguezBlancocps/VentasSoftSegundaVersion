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
    public partial class fmclientesactualizar : Form
    {
        private int dIdCliente;
        private int dIdUsuario;
        private fmSistema dsis;
        public fmclientesactualizar(int dIdCliente, fmSistema dsis, int dIdUsuario)
        {
            InitializeComponent();
            this.dIdCliente = dIdCliente;
            this.dsis = dsis;
            Load += Fmclientesactualizar_Load;
            this.dIdUsuario = dIdUsuario;
        }

        private void Fmclientesactualizar_Load(object sender, EventArgs e)
        {
            ClientePorId();
        }

        private void ClientePorId()
        {
            try
            {
                cnclientes obj = new cnclientes();

                DataTable tabla = obj.clientesPorId(dIdCliente);

                if (tabla != null)
                {
                    txtcliente.Text = Convert.ToString(tabla.Rows[0]["Nombre"]);
                    txttelefono.Text = Convert.ToString(tabla.Rows[0]["Telefono"]);
                    txtdireccion.Text = Convert.ToString(tabla.Rows[0]["Direccion"]);
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
                cnclientes obj = new cnclientes();

                if (txtcliente.Text.Length < 3 && txtcliente.Text.Length > 0)
                {
                    MessageBox.Show("El nombre es muy corto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcliente.Focus();
                }
                else if (txtcliente.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo nombre vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcliente.Focus();
                }

                else if (txttelefono.Text.Length<12 && txttelefono.Text.Length>0)
                {
                    MessageBox.Show("Coloque un número de teléfono válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttelefono.Focus();
                }


                else if (txttelefono.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo telefono vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttelefono.Focus();
                }
                else
                {
                    obj.Actualizar(dIdUsuario, dIdCliente,txtcliente.Text, txttelefono.Text, txtdireccion.Text, out mensaje);
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
