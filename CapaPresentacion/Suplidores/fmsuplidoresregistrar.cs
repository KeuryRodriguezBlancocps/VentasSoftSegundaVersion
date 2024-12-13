using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion.Suplidores
{
    public partial class fmsuplidoresregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public fmsuplidoresregistrar(int dIdUsuario, fmSistema dsis)
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
                cnsuplidores obj = new cnsuplidores();

                if (txtsuplidor.Text.Length < 3 && txtsuplidor.Text.Length > 0)
                {
                    MessageBox.Show("El nombre es muy corto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsuplidor.Focus();
                }
                else if (txtsuplidor.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo nombre vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsuplidor.Focus();
                }

                else if (txttelefono.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo telefono vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttelefono.Focus();
                }

                else if (cboManejaComprobantes.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo maneja comprobantes vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManejaComprobantes.Focus();
                }
                else
                {
                    obj.Insertar(dIdUsuario, txtsuplidor.Text, txtdireccion.Text, txttelefono.Text, cboManejaComprobantes.Text,out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmsuplidorbusqueda(dIdUsuario, dsis));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmsuplidorbusqueda(dIdUsuario, dsis));
        }
    }
}
