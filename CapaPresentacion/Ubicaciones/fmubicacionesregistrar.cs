using CapaNegocio;
using CapaPresentacion.Clientes;
using CapaPresentacion.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ubicaciones
{
    public partial class fmubicacionesregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public fmubicacionesregistrar(int dIdUsuario, fmSistema dsis)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            btnAbrirFormularioGestion.Click += BtnAbrirFormularioGestion_Click;
        }

        private void BtnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {

            try
            {
                dsis.AbrirFormulario(new fmubicacionesbusqueda(dIdUsuario, dsis));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                cnubicaciones obj = new cnubicaciones();

               if (txtubicacion.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo ubicación vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtubicacion.Focus();
                }

                else
                {
                    obj.Insertar(dIdUsuario, txtubicacion.Text, txtdescripcion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (mensaje == "La ubicación ya existe. Intente con un nombre diferente.")
                    {
                        return;
                    }
                    else
                    {
                    dsis.AbrirFormulario(new fmubicacionesbusqueda(dIdUsuario, dsis));
                    Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
