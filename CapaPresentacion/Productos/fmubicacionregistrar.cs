using CapaNegocio;
using CapaPresentacion.Ubicaciones;
using Guna.UI.WinForms;
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
    public partial class fmubicacionregistrar : Form
    {
        private int dIdUsuario;
        private fmproductosregistrar fmproductoregistrar;
        private fmproductoactualizar fmproductoactualizar;
        public fmubicacionregistrar(int dIdUsuario, fmproductosregistrar Fmproductosregistrar, fmproductoactualizar pfmproductoactualizar)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.fmproductoregistrar = Fmproductosregistrar;
            this.fmproductoactualizar = pfmproductoactualizar;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                cnubicaciones obj = new cnubicaciones();

                if (txtnombre.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo ubicación vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnombre.Focus();
                }

                else
                {
                    obj.Insertar(dIdUsuario, txtnombre.Text, txtdescripcion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (mensaje == "La ubicación ya existe. Intente con un nombre diferente.")
                    {
                        return;
                    }
                    else
                    {
                        if (fmproductoactualizar!=null)
                        {
                            fmproductoactualizar.MostrarUbicaciones();
                            Close();
                        }
                        else if (fmproductoregistrar!=null)
                        {
                        fmproductoregistrar.MostrarUbicaciones();
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
    }
}
