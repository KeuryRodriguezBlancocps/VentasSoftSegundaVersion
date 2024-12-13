using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class cdsuplidores
    {

        private int dIdSuplidor, dIdUsuario;
        private string dNombre, dDireccion, dTelefono, dManejaComprobantes;
        private DateTime dFechaCreacion;
        private cdconexion oconexion = new cdconexion();
        public cdsuplidores(int dIdSuplidor, int dIdUsuario, string dNombre, string dDireccion, string dTelefono, DateTime dFechaCreacion)
        {
            this.dIdSuplidor = dIdSuplidor;
            this.dIdUsuario = dIdUsuario;
            this.dNombre = dNombre;
            this.dDireccion = dDireccion;
            this.dTelefono = dTelefono;
            this.dFechaCreacion = dFechaCreacion;
        }

        public cdsuplidores()
        {

        }


        #region Propiedades

        public int IdSuplidor
        {
            get { return dIdSuplidor; }
            set { dIdSuplidor = value; }
        }

        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }

        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }

        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }

        public string Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }


        public string ManejaComprobantes
        {
            get { return dManejaComprobantes; }
            set { dManejaComprobantes = value; }
        }

        #endregion




        //Busqueda de Suplidores//
        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("suplidoresBUSQUEDA", oconexion.AbrirConexion());
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

        public DataTable suplidoresporId(cdsuplidores ObjSuplidores)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("suplidoresporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdSuplidor", ObjSuplidores.IdSuplidor);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }



        //Insertar suplidores//
        public string Insertar(cdsuplidores ObjSuplidores, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("suplidoresCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdSuplidor", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", ObjSuplidores.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", ObjSuplidores.Nombre);
                comando.Parameters.AddWithValue("@Direccion", ObjSuplidores.Direccion);
                comando.Parameters.AddWithValue("@Telefono", ObjSuplidores.Telefono);
                comando.Parameters.AddWithValue("@ManejaComprobante", ObjSuplidores.ManejaComprobantes);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }

        //Actualizar suplidores//
        public string Actualizar(cdsuplidores ObjSuplidores, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("suplidoresCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdSuplidor", ObjSuplidores.IdSuplidor);
                comando.Parameters.AddWithValue("@IdUsuario", ObjSuplidores.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", ObjSuplidores.Nombre);
                comando.Parameters.AddWithValue("@Direccion", ObjSuplidores.Direccion);
                comando.Parameters.AddWithValue("@Telefono", ObjSuplidores.Telefono);
                comando.Parameters.AddWithValue("@ManejaComprobante", ObjSuplidores.ManejaComprobantes);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }


        //Eliminar suplidores//
        public string Eliminar(cdsuplidores ObjSuplidores, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("suplidoresCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdSuplidor", ObjSuplidores.IdSuplidor);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre",DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", DBNull.Value);
                comando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                comando.Parameters.AddWithValue("@ManejaComprobante", DBNull.Value);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }

    }
}
