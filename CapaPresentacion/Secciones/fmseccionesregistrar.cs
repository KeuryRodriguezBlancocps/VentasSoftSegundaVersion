using CapaNegocio;
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

namespace CapaPresentacion.Secciones
{
    public partial class fmseccionesregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        public fmseccionesregistrar(int pIdUsuario, fmSistema psis)
        {
            InitializeComponent();
            dIdUsuario = pIdUsuario;
            dsis = psis;
            this.btnAbrirFormularioGestion.Click += BtnAbrirFormularioGestion_Click;
        }

        private void BtnAbrirFormularioGestion_Click(object sender, EventArgs e)
        {
            dsis.AbrirFormulario(new fmseccionesbusqueda(dIdUsuario, dsis));
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
                    obj.Insertar(dIdUsuario, txtseccion.Text, txtdescripcion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (mensaje == "La sección ya existe. Intente con un nombre diferente.")
                    {
                        return;
                    }
                    else
                    {
                        dsis.AbrirFormulario(new fmseccionesbusqueda(dIdUsuario, dsis));

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
