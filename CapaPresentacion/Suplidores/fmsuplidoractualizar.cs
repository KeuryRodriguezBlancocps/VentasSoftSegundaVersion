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

namespace CapaPresentacion.Suplidores
{
    public partial class fmsuplidoractualizar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdSuplidor;
        public fmsuplidoractualizar(int dIdUsuario, fmSistema dsis, int dIdSuplidor)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            this.dIdSuplidor = dIdSuplidor;
            this.Load += Fmsuplidoractualizar_Load;
        }

        private void Fmsuplidoractualizar_Load(object sender, EventArgs e)
        {
            SuplidoresPorId();
        }

        private void SuplidoresPorId()
        {
            try
            {
                cnsuplidores obj = new cnsuplidores();

                DataTable tabla = obj.suplidoresporId(dIdSuplidor);

                if (tabla != null)
                {
                    txtsuplidor.Text = Convert.ToString(tabla.Rows[0]["Nombre"]);
                    txttelefono.Text = Convert.ToString(tabla.Rows[0]["Telefono"]);
                    txtdireccion.Text = Convert.ToString(tabla.Rows[0]["Direccion"]);
                    cboManejaComprobantes.Text = Convert.ToString(tabla.Rows[0]["ManejaComprobantes"]);
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
                    obj.Actualizar(dIdUsuario, txtsuplidor.Text, txttelefono.Text, txtdireccion.Text, cboManejaComprobantes.Text, out mensaje);
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

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
