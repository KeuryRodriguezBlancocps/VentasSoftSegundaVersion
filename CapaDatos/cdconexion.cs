using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class cdconexion
    {

      static private string sql = @"Data Source=.;Initial Catalog=VentasSoftSegundaVersion;Integrated Security=True;";

      private SqlConnection cn = new SqlConnection(sql);

       public SqlConnection AbrirConexion()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;

        }


        public SqlConnection CerrarConexion()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }

            return cn;
        }

    }
}
