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

namespace CapaPresentacion.Secciones
{
    public partial class fmseccionesactualizar : Form
    {
        private int dIdSeccion;
        private int dIdUsuario;
        private fmSistema dsis;
        public fmseccionesactualizar(int pIdUsuario,int pidseccion, fmSistema psis)
        {
            InitializeComponent();
            dIdSeccion = pidseccion;
            dIdUsuario = pIdUsuario;
            dsis = psis;
            Load += Fmseccionesactualizar_Load;
        }

        private void Fmseccionesactualizar_Load(object sender, EventArgs e)
        {
            SeccionPorId();
        }

        private void SeccionPorId()
        {
            try
            {
                cnsecciones obj = new cnsecciones();

                DataTable tabla = obj.SeccionPorId(dIdSeccion);

                if (tabla != null)
                {
                    txtseccion.Text = Convert.ToString(tabla.Rows[0]["Nombre"]);
                    txtdescripcion.Text = Convert.ToString(tabla.Rows[0]["Descripcion"]);
                }
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
                cnsecciones obj = new cnsecciones();
                if (txtseccion.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo sección vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtseccion.Focus();
                    return;
                }
                else
                {
                    obj.Actualizar(dIdSeccion,txtseccion.Text, txtdescripcion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                        dsis.AbrirFormulario(new fmseccionesbusqueda(dIdUsuario, dsis));
                    Close();
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
