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

namespace CapaPresentacion.Ubicaciones
{
    public partial class fmubicacionactualizar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        private int dIdUbicacion;
        public fmubicacionactualizar(int dIdUsuario, fmSistema dsis, int dIdUbicacion)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            this.dIdUbicacion = dIdUbicacion;
            Load += Fmubicacionactualizar_Load;
            
        }
        private void Fmubicacionactualizar_Load(object sender, EventArgs e)
        {
            UbicacionPorId();
        }

        private void UbicacionPorId()
        {
            try
            {
                cnubicaciones obj = new cnubicaciones();

                DataTable tabla = obj.UbicacionPorId(dIdUbicacion);

                if (tabla != null)
                {
                    txtubicacion.Text = Convert.ToString(tabla.Rows[0]["Ubicacion"]);
                    txtdescripcion.Text = Convert.ToString(tabla.Rows[0]["Descripcion"]);
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
                cnubicaciones obj = new cnubicaciones();

                if (txtubicacion.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo ubicación vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtubicacion.Focus();
                }

                else
                {
                    obj.Actualizar(dIdUbicacion, txtubicacion.Text, txtdescripcion.Text, out mensaje);
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

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
