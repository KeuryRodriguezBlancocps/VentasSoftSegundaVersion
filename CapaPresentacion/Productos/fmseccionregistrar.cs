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

namespace CapaPresentacion.Productos
{
    public partial class fmseccionregistrar : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        private fmproductosregistrar fmproductoregistrar;
        private fmproductoactualizar fmproductoactualizar;
        public fmseccionregistrar(int pidusuario, fmSistema psis, fmproductosregistrar fmproductoregistrar, fmproductoactualizar pfmproductoactualizar)
        {
            InitializeComponent();
            dIdUsuario = pidusuario;
            dsis = psis;
            this.fmproductoregistrar = fmproductoregistrar;
            fmproductoactualizar = pfmproductoactualizar;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

            string mensaje = "";
            cnsecciones obj = new cnsecciones();
            if (txtseccion.Text == string.Empty)
            {
                MessageBox.Show("No puedes dejar el campo categrías vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (fmproductoactualizar!=null)
                        {
                            fmproductoactualizar.MostrarSecciones();
                            Close();
                        }
                        else if (fmproductoregistrar!=null)
                        {

                    fmproductoregistrar.MostrarSecciones();
                    Close();
                        }

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
