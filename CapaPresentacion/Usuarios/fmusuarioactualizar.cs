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

namespace CapaPresentacion.Usuarios
{
    public partial class fmusuarioactualizar : Form
    {
        private fmSistema dsis;
        private int dIdUsuario;
        private int dIdRol;
        string password = "";
        public fmusuarioactualizar(fmSistema psis, int pIdUsuario, int pIdRol)
        {
            InitializeComponent();
            dsis = psis;
            dIdUsuario = pIdUsuario;
            dIdRol = pIdRol;
            Load += Fmusuarioactualizar_Load;
        }

        private void Fmusuarioactualizar_Load(object sender, EventArgs e)
        {
            MostrarRoles();
            MostrarUsuarioPorId();
        }

        private void MostrarRoles()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnroles objroles = new cnroles();
                tabla = objroles.Busqueda("");
                if (tabla != null)
                {
                    cborol.DataSource = tabla;
                    cborol.ValueMember = "IdRol";
                    cborol.DisplayMember = "Rol";
                    cborol.SelectedValue = dIdRol;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void MostrarUsuarioPorId()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnusuarios obj = new cnusuarios();
                tabla = obj.usuariosporId(dIdUsuario);
                if (tabla != null)
                {
                    txtnombre.Text = Convert.ToString(tabla.Rows[0]["Nombre"]);
                    txtapellidos.Text = Convert.ToString(tabla.Rows[0]["Apellidos"]);
                    txtusuario.Text = Convert.ToString(tabla.Rows[0]["Usuario"]);
                    password = Convert.ToString(tabla.Rows[0]["Password"]);
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
                string Mensaje = "";
                cnusuarios obj = new cnusuarios();
                if (txtnombre.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar el campo nombre", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombre.Focus();
                    return;
                }
                else if (txtusuario.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar el campo usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusuario.Focus();
                    return;
                }

                else if (cborol.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar el campo rol", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cborol.Focus();
                    return;
                }

                else if (txtpassword.Text != string.Empty)
                {
                    password = txtpassword.Text;
                }

                else
                {

                    obj.Actualizar(dIdUsuario,txtnombre.Text, txtapellidos.Text, Convert.ToInt32(cborol.SelectedValue), txtusuario.Text, password, out Mensaje);
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario(new fmusuariosBusqueda(dsis));

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
