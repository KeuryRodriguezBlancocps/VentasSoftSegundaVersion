using System;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class cdestados
    {
        private int dIdEstado, dIdUsuario;
        private string dEstado, dDescripcion;
        private cdconexion oconexion = new cdconexion();
        private DateTime dFechaCreacion;

        public cdestados(int dIdEstado, int dIdUsuario, string dEstado, string dDescripcion, DateTime dFechaCreacion, cdconexion oconexion)
        {
            this.dIdEstado = dIdEstado;
            this.dIdUsuario = dIdUsuario;
            this.dEstado = dEstado;
            this.dDescripcion = dDescripcion;
            this.dFechaCreacion = dFechaCreacion;
            this.oconexion = oconexion;
        }

        public cdestados()
        {

        }

        #region MyRegion

        public int IdEstado
        {
            get { return dIdEstado; }
            set { dIdEstado = value; }
        }
        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }

        }


        public string Estado
        {
            get
            {
                return dEstado;
            }
            set
            {
                dEstado = value;
            }
        }


        public string Descripcion
        {
            get
            {
                return dDescripcion;
            }
            set
            {
                dDescripcion = value;
            }
        }


        public DateTime FechaCreacion
        {
            get { return dFechaCreacion; }
            set { dFechaCreacion = value; }
        }

        #endregion


        //Buscar Clientes//
        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("estadosBUSQUEDA", oconexion.AbrirConexion());
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

        //Insertar estados//
        public string Insertar(cdestados ObjEstados, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ClientesCRUD", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdEstado", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", ObjEstados.IdUsuario);
                comando.Parameters.AddWithValue("@Estado", ObjEstados.Estado);
                comando.Parameters.AddWithValue("@Descripcion", ObjEstados.Descripcion);
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



        //Actualizar estados//
        public string Actualizar (cdestados ObjEstados, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ClientesCRUD", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdEstado",ObjEstados.IdEstado);
                comando.Parameters.AddWithValue("@IdUsuario", ObjEstados.IdUsuario);
                comando.Parameters.AddWithValue("@Estado", ObjEstados.Estado);
                comando.Parameters.AddWithValue("@Descripcion", ObjEstados.Descripcion);
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


        //Eliminar estados//
        public string Eliminar(cdestados ObjEstados, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ClientesCRUD", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdEstado", ObjEstados.IdEstado);
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
