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
    public partial class fmusuarioregistrar : Form
    {

        private fmSistema dsis;

        public fmusuarioregistrar(fmSistema psis)
        {
            InitializeComponent();
            dsis = psis;
            Load += Fmusuarioregistrar_Load;
        }

        private void Fmusuarioregistrar_Load(object sender, EventArgs e)
        {
            MostrarRoles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }


        private void MostrarRoles()
        {
            try
            {
                DataTable tabla = new DataTable();
                cnroles objroles = new cnroles();
                tabla = objroles.Busqueda("");
                if (tabla!=null)
                {
                    cborol.DataSource = tabla;
                    cborol.ValueMember = "IdRol";
                    cborol.DisplayMember = "Rol";
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
                string Mensaje = "";
                cnusuarios obj = new cnusuarios();
                if (txtnombre.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar el campo nombre", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombre.Focus();
                    return;
                }
                else if(txtusuario.Text == string.Empty)
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

                else if (txtpassword.Text == string.Empty)
                {
                    MessageBox.Show("Debe llenar el campo password", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Focus();
                    return;
                }

                else
                {
                    obj.Insertar(txtnombre.Text, txtapellidos.Text,Convert.ToInt32(cborol.SelectedValue), txtusuario.Text, txtpassword.Text, out Mensaje);
                    MessageBox.Show(Mensaje, "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dsis.AbrirFormulario( new fmusuariosBusqueda(dsis));

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
