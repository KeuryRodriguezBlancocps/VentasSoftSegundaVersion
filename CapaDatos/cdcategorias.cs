using System.Data.SqlClient;
using System.Data;
using System;
using System.Security;
namespace CapaDatos
{
    public class cdcategorias
    {
        private int dIdCategoria, dIdUsuario;
        private string dCategoria, ddescripcion;
        private cdconexion oconexion = new cdconexion();
     

        public cdcategorias()
        {

        }
        public cdcategorias(int dIdCategoria, string dCategoria, string pdescripcion, int dIdUsuario)
        {
            this.dIdCategoria = dIdCategoria;
            this.dCategoria = dCategoria;
            this.ddescripcion = pdescripcion;
            this.dIdUsuario = dIdUsuario;
        }

        #region Propiedades
        public int IdCategoria
        {
            get { return dIdCategoria; }
            set { dIdCategoria = value; }
        }

        public string Categoria
        {
            get { return dCategoria; }
            set { dCategoria = value; }
        }

        public string Descripcion
        {
            get { return ddescripcion; }
            set { ddescripcion = value; }
        }

        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }

        #endregion



        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("categoriasBUSQUEDA", oconexion.AbrirConexion());
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

        public DataTable categoriasporId(cdcategorias ObjCategorias)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("categoriasporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCategoria", ObjCategorias.IdCategoria);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }


        public string Insertar(cdcategorias ObjCategorias, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("categoriasCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdCategoria", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", ObjCategorias.IdUsuario);
                comando.Parameters.AddWithValue("@Categoria", ObjCategorias.Categoria);
                comando.Parameters.AddWithValue("@Descripcion", ObjCategorias.Descripcion);
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


        public string Actualizar(cdcategorias ObjCategorias, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("categoriasCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdCategoria", ObjCategorias.IdCategoria);
                comando.Parameters.AddWithValue("@IdUsuario", ObjCategorias.IdUsuario);
                comando.Parameters.AddWithValue("@Categoria", ObjCategorias.Categoria);
                comando.Parameters.AddWithValue("@Descripcion", ObjCategorias.Descripcion);
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

        public string Eliminar(cdcategorias ObjCategorias, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("categoriasCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdCategoria",ObjCategorias.IdCategoria);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Categoria", DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion",DBNull.Value);
                comando.Parameters.AddWithValue("@FechaCreacion", DBNull.Value);
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
