using CapaNegocio;
using CapaPresentacion.Categorias;
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
    public partial class fmcategoriacrear : Form
    {
        private int dIdUsuario;
        private fmSistema dsis;
        private fmproductosregistrar Fmproductoregistrar;
        private fmproductoactualizar fmproductoactualizar;
        public fmcategoriacrear(int dIdUsuario, fmSistema dsis, fmproductosregistrar fmproductosregistrar, fmproductoactualizar pfmproductoactualizar)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            this.dsis = dsis;
            Fmproductoregistrar = fmproductosregistrar;
            fmproductoactualizar = pfmproductoactualizar;
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
                cncategorias obj = new cncategorias();
                if (txtcategoria.Text == string.Empty)
                {
                    MessageBox.Show("No puedes dejar el campo categrías vacío", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcategoria.Focus();
                    return;
                }
                else
                {
                    obj.Insertar(dIdUsuario, txtcategoria.Text, txtdireccion.Text, out mensaje);
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (mensaje == "La categoria que quiere registrar ya existe, verifique y vuelva a proceder.")
                    {
                        return;
                    }
                    else
                    {
                        if (fmproductoactualizar!=null)
                        {
                            fmproductoactualizar.MostrarCategorias();
                            Close();
                        }
                        else if (Fmproductoregistrar!=null)
                        {
                    Fmproductoregistrar.MostrarCategorias();
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
