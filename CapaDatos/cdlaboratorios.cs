using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
namespace CapaDatos
{
    public class cdlaboratorios
    {

        private int dIdUsuario,dIdLaboratorio;
        private string dNombre, dTelefono, dDireccion, dEmail;
        private cdconexion oconexion = new cdconexion();

        public cdlaboratorios(int dIdLaboratorio, string dNombre, string dTelefono, string dDireccion, string dEmail)
        {
            this.dIdLaboratorio = dIdLaboratorio;
            this.dNombre = dNombre;
            this.dTelefono = dTelefono;
            this.dDireccion = dDireccion;
            this.dEmail = dEmail;
        }


        public cdlaboratorios()

        {

        }

        public int IdLaboratorio { get => dIdLaboratorio; set => dIdLaboratorio = value; }
        public int IdUsuario { get => dIdUsuario; set => dIdUsuario = value; }
        public string Nombre { get => dNombre; set => dNombre = value; }
        public string Telefono { get => dTelefono; set => dTelefono = value; }
        public string Direccion { get => dDireccion; set => dDireccion = value; }
        public string Email { get => dEmail; set => dEmail = value; }





        public string Insertar(cdlaboratorios obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("laboratorioscrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdLaboratorio", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario",obj.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", obj.Nombre);
                comando.Parameters.AddWithValue("@Telefono",obj.Telefono);
                comando.Parameters.AddWithValue("@Direccion", obj.Direccion);
                comando.Parameters.AddWithValue("@Email", obj.Email);
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

        public string Actualizar(cdlaboratorios obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("laboratorioscrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdLaboratorio", obj.IdLaboratorio);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", obj.Nombre);
                comando.Parameters.AddWithValue("@Telefono", obj.Telefono);
                comando.Parameters.AddWithValue("@Direccion", obj.Direccion);
                comando.Parameters.AddWithValue("@Email", obj.Email);
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

        public string Eliminar(cdlaboratorios obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("laboratorioscrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdLaboratorio", obj.IdLaboratorio);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", DBNull.Value);
                comando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", DBNull.Value);
                comando.Parameters.AddWithValue("@Email", DBNull.Value);
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


        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("laboratoriosBUSQUEDA", oconexion.AbrirConexion());
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



        public DataTable LaboratorioPorId(int pIdLaboratorio)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("laboratorioporid", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdLaboratorio", pIdLaboratorio);
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
