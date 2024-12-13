using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class cdsecciones
    {
        private int dIdSeccion, dIdUsuario;
        private string dSeccion, dDescripcion;
        private cdconexion oconexion = new cdconexion();

        public cdsecciones()
        {

        }
        public cdsecciones(int dIdSeccion, string dSeccion, string dDescripcion, int dIdUsuario)
        {
            this.dIdSeccion = dIdSeccion;
            this.dSeccion = dSeccion;
            this.dDescripcion = dDescripcion;
            this.dIdUsuario = dIdUsuario;
        }

        public int IdSeccion { get => dIdSeccion; set => dIdSeccion = value; }
        public string Seccion { get => dSeccion; set => dSeccion = value; }
        public string Descripcion { get => dDescripcion; set => dDescripcion = value; }
        public int IdUsuario { get => dIdUsuario; set => dIdUsuario = value; }

        public DataTable Busqueda(string busqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                
                SqlCommand comando = new SqlCommand("seccionesbusqueda", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Busqueda", busqueda);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                tabla = null;
            }
            return tabla;
        }



        public DataTable SeccionPorId(int pIdSeccion)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {

                SqlCommand comando = new SqlCommand("seccionesporid", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdSeccion", pIdSeccion);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                tabla = null;
            }
            return tabla;
        }







        public string Insertar(cdsecciones obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("seccionescrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdSeccion", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", obj.Seccion);
                comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
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





        public string Actualizar(cdsecciones obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("seccionescrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdSeccion", obj.IdSeccion);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", obj.Seccion);
                comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
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







        public string Eliminar(cdsecciones obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("seccionescrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdSeccion", obj.IdSeccion);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion", DBNull.Value);
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



        public DataTable seccionesporid(cdsecciones obj)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("seccionesporid", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdSeccion", obj.IdSeccion);
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
