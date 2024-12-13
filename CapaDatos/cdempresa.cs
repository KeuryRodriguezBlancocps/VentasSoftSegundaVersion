using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class cdempresa
    {
        private int dIdEmpresa, dIdUsuario;
        private string dNombre, dDireccion, dEstado, dTelefono, dRnc;
        private cdconexion oconexion = new cdconexion();
        public cdempresa()
        {

        }
        public cdempresa(int dIdEmpresa, string dNombre, string dDireccion, string dEstado, string dRnc, int dIdUsuario, string dTelefono)
        {
            this.dIdEmpresa = dIdEmpresa;
            this.dNombre = dNombre;
            this.dDireccion = dDireccion;
            this.dEstado = dEstado;
            this.dRnc = dRnc;
            this.dIdUsuario = dIdUsuario;
            this.dTelefono = dTelefono;
        }

        #region Propiedades

        public int IdEmpresa
        {
            get { return dIdEmpresa; }
            set { dIdEmpresa = value; }
        }

        public string RNC
        {
            get { return dRnc; }
            set { dRnc = value; }
        }

        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value;}
        }

        public string Nombre
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
            set { dDireccion = value;}
        }

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }


        #endregion




        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("empresaBUSQUEDA", oconexion.AbrirConexion());
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



        public DataTable EmpresaproId(cdempresa Obj)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("empresaporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdEmpresa", Obj.IdEmpresa);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }



        public string Insertar(cdempresa Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("empresaCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdEmpresa", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                comando.Parameters.AddWithValue("@RNC", Obj.RNC);
                comando.Parameters.AddWithValue("@Direccion", Obj.Direccion);
                comando.Parameters.AddWithValue("@Telefono", Obj.Telefono);
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString());
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje= (ex.Message);
            }
            return Mensaje;
        }

        public string Actualizar(cdempresa Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("empresaCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdEmpresa", Obj.IdEmpresa);
                comando.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);
                comando.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                comando.Parameters.AddWithValue("@RNC", Obj.RNC);
                comando.Parameters.AddWithValue("@Direccion", Obj.Direccion);
                comando.Parameters.AddWithValue("@Telefono", Obj.Telefono);
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



        public string Eliminar(cdempresa Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("empresaCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdEmpresa", Obj.IdEmpresa);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@Nombre", DBNull.Value);
                comando.Parameters.AddWithValue("@RNC", DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", DBNull.Value);
                comando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
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
