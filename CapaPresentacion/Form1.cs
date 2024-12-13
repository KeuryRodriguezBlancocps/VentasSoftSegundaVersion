using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
using CapaPresentacion.Reportes;
using System.Windows.Media.Animation;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private bool ValidarSession()
        {
            cnusuarios ObjUsuarios = new cnusuarios();
            int IdUsuario;
            string Mensaje = "";
            bool Encontrado;
            string Usuario = txtUsuario.Text.Trim();
            string Password = txtPassword.Text.Trim();
            int IdRol = 0;
            string Rol;
            DataTable UsuarioDevuelto = new DataTable();
            if (Usuario == string.Empty)
            {
                MessageBox.Show("Debes de colocar tu usuario", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
            }
            else if (Password == string.Empty)
            {
                MessageBox.Show("Debes de colocar tu contraseña", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else
            {




                ObjUsuarios.ValidarSession(Usuario, Password, out Encontrado, out IdRol, out Rol, out IdUsuario, out Mensaje);
                if (ObjUsuarios.ValidarSession(Usuario, Password, out Encontrado, out IdRol, out Rol, out IdUsuario, out Mensaje) == true)
                {
                    this.Hide();
                    MessageBox.Show("Bienvenido/a al sistema","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fmSistema obj = new fmSistema(IdUsuario);
                    obj.AbrirFormulario(new reportesinformaciongeneral());
                    obj.ShowDialog();
                }
                else if (ObjUsuarios.ValidarSession(Usuario, Password, out Encontrado, out IdRol, out Rol, out IdUsuario, out Mensaje) == false)
                {
                    MessageBox.Show("Revise las credenciales e intentelo de nuevo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ObjUsuarios.ValidarSession(Usuario, Password, out Encontrado, out IdRol, out Rol, out IdUsuario, out Mensaje);
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ValidarSession();
        }
    }
}
