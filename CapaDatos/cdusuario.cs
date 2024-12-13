using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class cdusuario
    {

        private int dIdUsuario, dIdRol;
        private string dNombre, dApellidos, dImagen, dUsuario, dPassword;
        private DateTime dFechaCreacion;
        private string dEstado;
        private cdconexion oconexion = new cdconexion();


        public cdusuario(int dIdUsuario, int dIdRol, string dNombre, string dApellidos, string dImagen, DateTime dFechaCreacion, string dEstado, string dUsuario, string dPassword)
        {
            this.dIdUsuario = dIdUsuario;
            this.dIdRol = dIdRol;
            this.dNombre = dNombre;
            this.dApellidos = dApellidos;
            this.dImagen = dImagen;
            this.dFechaCreacion = dFechaCreacion;
            this.dEstado = dEstado;
            this.dUsuario = dUsuario;
            this.dPassword = dPassword;
        }

        public cdusuario()
        {

        }


        #region Propiedades



        public int IdUsuario
        {
            get { return dIdUsuario;}
            set { dIdUsuario = value; }
        }

        public int IdRol
        {
            get { return dIdRol; }
            set { dIdRol = value; }
        }

        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }

        public string Apellidos
        {
            get { return dApellidos; }
            set { dApellidos = value; }

        }
        public string Usuario
        {
            get { return dUsuario; }
            set { dUsuario = value;}
        }

        public string Password
        {
            get { return dPassword; }
            set { dPassword = value; }
        }


        public string Imagen
        {
            get { return dImagen; }
            set { dImagen = value; }
        }

        public DateTime FechaCreacion
        {
            get { return dFechaCreacion; }
            set { dFechaCreacion = value; }
        }

        #endregion



        //Validar Usuario//
        public bool ValidarUsuario(string pNombre, string pPassword, out bool Encontrado,out int IdRol,out string Rol,out int IdUsuario, out string Mensaje)
        {
            IdUsuario = 0;
            IdRol = 0;
            Mensaje = "";
            Rol = "";
            Encontrado = false;
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("usuariosLOGIN", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Usuario", pNombre);
                comando.Parameters.AddWithValue("@Password", pPassword);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
                if (tabla.Rows.Count > 0)
                {
                    Encontrado = true;
                    IdRol = Convert.ToInt32(tabla.Rows[0]["IdRol"]);
                    Rol = Convert.ToString(tabla.Rows[0]["Rol"]);
                    IdUsuario = Convert.ToInt32(tabla.Rows[0]["IdUsuario"]);
                }
                else
                    Encontrado = false;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Encontrado;
        }



        //Busqueda Usuarios//
        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("usuariosBUSQUEDA", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Busqueda", pBusqueda);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }

        //Insertar Usuarios//
        public string Insertar(cdusuario ObjUsuario, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("usuariosCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", ObjUsuario.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", ObjUsuario.Apellidos);
                comando.Parameters.AddWithValue("@IdRol", ObjUsuario.IdRol);
                comando.Parameters.AddWithValue("@Usuario", ObjUsuario.Usuario);
                comando.Parameters.AddWithValue("@Password", ObjUsuario.Password);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 140).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }

        //Actualizar Usuarios//
        public string Actualizar(cdusuario ObjUsuario, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("usuariosCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdUsuario", ObjUsuario.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", ObjUsuario.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", ObjUsuario.Apellidos);
                comando.Parameters.AddWithValue("@IdRol", ObjUsuario.IdRol);
                comando.Parameters.AddWithValue("@Usuario", ObjUsuario.Usuario);
                comando.Parameters.AddWithValue("@Password", ObjUsuario.Password);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }

        //Eliminar Usuarios//
        public string Eliminar(cdusuario ObjUsuario, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("usuariosCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdUsuario", ObjUsuario.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", DBNull.Value);
                comando.Parameters.AddWithValue("@Apellidos", DBNull.Value);
                comando.Parameters.AddWithValue("@IdRol", DBNull.Value);
                comando.Parameters.AddWithValue("@Usuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Password", DBNull.Value);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }


        public DataTable UsuarioporID(int IdUsuario)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("usuariosporID", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }

    }
}
