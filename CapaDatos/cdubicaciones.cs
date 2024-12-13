using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace CapaDatos
{
    public class cdubicaciones
    {
        private int dIdUbicacion,dIdUsuario;
        private string dUbicacion, dDescripcion;
        private cdconexion oconexion = new cdconexion();

        public cdubicaciones()
        {

        }
        public cdubicaciones(int dIdUbicacion, string dUbicacion, string dDescripcion, int dIdUsuario)
        {
            this.dIdUbicacion = dIdUbicacion;
            this.dUbicacion = dUbicacion;
            this.dDescripcion = dDescripcion;
            this.dIdUsuario = dIdUsuario;
        }

        public int IdUbicacion { get => dIdUbicacion; set => dIdUbicacion = value; }
        public string Ubicacion { get => dUbicacion; set => dUbicacion = value; }
        public string Descripcion { get => dDescripcion; set => dDescripcion = value; }
        public int IdUsuario { get => dIdUsuario; set => dIdUsuario = value; }

        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ubicacionesbusqueda", oconexion.AbrirConexion());
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

        public DataTable UbicacionPorId(int pIdUbicacion)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ubicacionesporid", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUbicacion", pIdUbicacion);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }


        public string Insertar(cdubicaciones obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ubicacionescrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdUbicacion", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                comando.Parameters.AddWithValue("@Ubicacion", obj.Ubicacion);
                comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Console.WriteLine(Mensaje);
            }
            return Mensaje;
        }


        public string Actualizar(cdubicaciones obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ubicacionescrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdUbicacion", obj.IdUbicacion);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value) ;
                comando.Parameters.AddWithValue("@Ubicacion", obj.Ubicacion);
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

        public string Eliminar(cdubicaciones obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ubicacionescrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdUbicacion", obj.IdUbicacion);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Ubicacion", DBNull.Value);
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



    }
}
