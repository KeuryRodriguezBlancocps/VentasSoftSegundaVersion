using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class cdroles
    {
        private int dIdRol;
        private string dRol, dDescripcion;
        private DateTime FechaCreacion;
        private cdconexion oconexion = new cdconexion();
        public cdroles() { }

        public cdroles(int dIdRol, string dRol, string dDescripcion, DateTime fechaCreacion)
        {
            this.dIdRol = dIdRol;
            this.dRol = dRol;
            this.dDescripcion = dDescripcion;
            FechaCreacion = fechaCreacion;
        }


        #region Propiedades



        public int IdRol
        {
            get { return dIdRol; }
            set { dIdRol = value; }
        }

        public string Rol
        {
            get { return dRol; }
            set { dRol = value; }

        }

        public string Descripcion 
        { 
            get { return dDescripcion; }
            set { dDescripcion = value; } 
        }



        #endregion

        //Busqueda de Roles//
        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("rolesBUSQUEDA", oconexion.AbrirConexion());
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


        //Insertar Roles//
        public string Insertar(cdroles objRoles, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("rolesCRUD", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdRol", DBNull.Value);
                comando.Parameters.AddWithValue("@Rol", objRoles.Rol);
                comando.Parameters.AddWithValue("@Descripcion", objRoles.Descripcion);
                comando.ExecuteNonQuery();
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                Mensaje = comando.Parameters["Mensaje"].ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }


        //Actualizar Roles//
        public string Actualizar(cdroles objRoles, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("rolesCRUD", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdRol", objRoles.IdRol);
                comando.Parameters.AddWithValue("@Rol", objRoles.Rol);
                comando.Parameters.AddWithValue("@Descripcion", objRoles.Descripcion);
                comando.ExecuteNonQuery();
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                Mensaje = comando.Parameters["Mensaje"].ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }

        //Eliminar Roles//
        public string Eliminar(cdroles objRoles, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("rolesCRUD", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdRol", objRoles.IdRol);
                comando.ExecuteNonQuery();
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                Mensaje = comando.Parameters["Mensaje"].ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }

    }
}
