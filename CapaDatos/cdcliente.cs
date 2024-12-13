using System;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class cdcliente
    {
        //Variables privadas (campos originales de la tabla)//
        private int dIdCliente, dIdUsuario;
        private string dNombre, dTelefono, dDireccion, dEstado;
        private cdconexion oconexion = new cdconexion();

        //Constructor con parametros//
        public cdcliente(int dIdCliente, int dIdUsuario, string dNombre, string dTelefono, string dDireccion, string dEstado)
        {
            this.dIdCliente = dIdCliente;
            this.dIdUsuario = dIdUsuario;
            this.dNombre = dNombre;
            this.dTelefono = dTelefono;
            this.dDireccion = dDireccion;
            this.dEstado = dEstado;
        }
        //Constructor sin parametros//
        public cdcliente()
        {

        }


        #region Propiedades


        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }


        public string Cliente
        {
            get { return dNombre; }
            set { dNombre = value; }
        }


        public string Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }



        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }



        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }



        #endregion

        //Buscar Clientes//
        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ClientesBUSQUEDA", oconexion.AbrirConexion());
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


        public DataTable ClientesPorId()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("clientesporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCliente", IdCliente);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }



        //Insertar Clientes//
        public string Insertar(cdcliente ObjCliente, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ClientesCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", ObjCliente.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", ObjCliente.Cliente);
                comando.Parameters.AddWithValue("@Telefono", ObjCliente.Telefono);
                comando.Parameters.AddWithValue("@Direccion", ObjCliente.Direccion);
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

        //Actualizar Clientes//
        public string Actualizar(cdcliente ObjCliente, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ClientesCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdCliente", ObjCliente.IdCliente);
                comando.Parameters.AddWithValue("@IdUsuario", ObjCliente.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", ObjCliente.Cliente);
                comando.Parameters.AddWithValue("@Telefono", ObjCliente.Telefono);
                comando.Parameters.AddWithValue("@Direccion", ObjCliente.Direccion);
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


        //Eliminar Clientes//
        public string Eliminar(cdcliente ObjCliente, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ClientesCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdCliente", ObjCliente.IdCliente);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", DBNull.Value);
                comando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", DBNull.Value);
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

    }
}
