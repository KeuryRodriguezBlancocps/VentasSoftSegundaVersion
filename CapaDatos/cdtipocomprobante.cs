using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
   public class cdtipocomprobante
    {

        private int dIdTipoComprobante;
        private string dTipoComprobante, destado;
        DateTime dFechaCreacion;


        private cdconexion objconexion = new cdconexion();


        public cdtipocomprobante()
        {

        }


        public cdtipocomprobante(int pidtipocomprobante, string ptipocomprobante,string pestado,DateTime pfechacreacion)
        {

            dIdTipoComprobante = pidtipocomprobante;
            dTipoComprobante = ptipocomprobante;
            destado = pestado;
            dFechaCreacion = pfechacreacion;


        }



        #region

        public int IdTipoComprobante
        {
            get { return dIdTipoComprobante; }
            set { dIdTipoComprobante = value; }
        }


        public string TipoComprobante
        {
            get { return dTipoComprobante; }
            set { dTipoComprobante = value; }
        }


        public string Estado
        {
            get { return destado; }
            set { destado = value; }
        }


        public DateTime EsFechaCreacion
        {
            get { return dFechaCreacion; }
            set { dFechaCreacion = value; }
        }



        #endregion


        public string Insertar(cdtipocomprobante objtipocomprobante)
        {
            string mensaje = "";


            return mensaje;
        }


        public string Actualizar(cdtipocomprobante objtipocomprobante)
        {
            string mensaje = "";


            return mensaje;
        }


        public string GenerarCodigoFactura(string campo)
        {
            string codigo = string.Empty;
            int total = 0;
            string rangoHasta = ""; // Variable para almacenar el valor "Hasta
            try
            {
                // Obtén el correlativo actual y el rango máximo permitido para el tipo de comprobante
                SqlCommand comando = new SqlCommand("TipoComprobante", objconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@campo", campo);

                using (SqlDataReader leer = comando.ExecuteReader())
                {
                    if (leer.Read())
                    {
                        // Obtener el valor actual de "Correolativo"
                        total = Convert.ToInt32(leer["Correolativo"]);

                        // Obtener el valor "Hasta" autorizado (con el prefijo B01)
                        rangoHasta = leer["Hasta"].ToString();
                    }
                }
                total += 1;

                // Formatea el código con ceros a la izquierda y prefijo "B01"
                codigo = total.ToString("D8");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error: " + ex.Message);
                // Aquí podrías mostrar el mensaje de error en tu interfaz o registrarlo en logs.
            }

            return codigo;
        }





        public DataTable Mostrar()
        {


            DataTable tabla = new DataTable();
            try
            {

                SqlCommand comando = new SqlCommand("select * from tiposcomprobantes", objconexion.AbrirConexion());
                SqlDataReader leer;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                tabla = null;
                Console.WriteLine(ex.Message);
                objconexion.CerrarConexion();

            }

            return tabla;
        }



        public DataTable MostrarTipoComprobantePorId(int dIdTipoComprobante)
        {


            DataTable tabla = new DataTable();
            try
            {

                SqlCommand comando = new SqlCommand("tipocomprobanteporid", objconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdTipoComprobante", dIdTipoComprobante);
                SqlDataReader leer;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                tabla = null;
                Console.WriteLine(ex.Message);
                objconexion.CerrarConexion();

            }

            return tabla;
        }



    }
}
