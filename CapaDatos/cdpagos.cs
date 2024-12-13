using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class cdpagos
    {

        private int dIdPago, dIdVenta, dIdCompra, dIdUsuario;
        private string dTarjetaHabiente,dNroTarjeta,dDescripcion,dTipoTarjeta, MetodoPago, dEstado;
        private decimal dEfectivo, dMontoDebitado, dTransferencia, dPago, dDebe;
        private cdconexion oconexion = new cdconexion();
        public cdpagos(int dIdPago, int dIdVenta, int dIdCompra, string dTarjetaHabiente, string nroTarjeta, string dDescripcion, string dTipoTarjeta, decimal dEfectivo, decimal dMontoDebitado, decimal dTransferencia, decimal dPago, int dIdUsuario, string metodoPago, string dEstado)
        {
            this.dIdPago = dIdPago;
            this.dIdVenta = dIdVenta;
            this.dIdCompra = dIdCompra;
            this.dTarjetaHabiente = dTarjetaHabiente;
            dNroTarjeta = nroTarjeta;
            this.dDescripcion = dDescripcion;
            this.dTipoTarjeta = dTipoTarjeta;
            this.dEfectivo = dEfectivo;
            this.dMontoDebitado = dMontoDebitado;
            this.dTransferencia = dTransferencia;
            this.dPago = dPago;
            this.dIdUsuario = dIdUsuario;
            MetodoPago = metodoPago;
            this.dEstado = dEstado;
        }

        public cdpagos()
        {

        }


        #region Propiedades


        public int IdPago
        {
            get { return dIdPago; }
            set { dIdPago = value; }
        }
        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }
        public int IdVenta
        {
            get { return dIdVenta; }
            set { dIdVenta = value; }
        }

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        public decimal Debe
        {
            get { return dDebe; }
            set { dDebe = value; }
        }

        public int IdCompra
        {
            get { return dIdCompra; }
            set { dIdCompra = value; }
        }

        public string IdMetodoPago
        {
            get { return MetodoPago; }
            set { MetodoPago = value;}
        }

        public string TipoTarjeta
        {
            get { return dTipoTarjeta; }
            set { dTipoTarjeta = value; }
        }


        public string Descripcion
        {
            get { return dDescripcion; }
            set { dDescripcion = value; }
        }

        public string NroTarjeta
        {
            get { return dNroTarjeta; }
            set { dNroTarjeta = value; }
        }

        public string TarjetaHabiente
        {
            get { return dTarjetaHabiente; }
            set { dTarjetaHabiente = value;}
        }



        public decimal Efectivo
        {
            get { return dEfectivo; }
            set { dEfectivo = value; }
        }


        public decimal MontoDebitado
        {
            get { return dMontoDebitado; }
            set { dMontoDebitado = value; }
        }

        public decimal Transferencia
        {
            get { return dTransferencia; }
            set { dTransferencia = value; }
        }


        public decimal Pago
        {
            get { return dPago; }
            set { dPago = value; }
        }

        #endregion







        public DataTable PagosporId(cdpagos Obj)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("verpagos", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdCompra", DBNull.Value);
                comando.Parameters.AddWithValue("@IdVenta", Obj.IdVenta);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }




        public DataTable PagosporIdCompra(cdpagos Obj)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("verpagos", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdCompra", Obj.IdCompra);
                comando.Parameters.AddWithValue("@IdVenta", DBNull.Value);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }








        public string Insertar(cdpagos Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("pagoagregarCompra", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdPago", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);
                if (IdVenta == 0)
                {
                comando.Parameters.AddWithValue("@IdVenta",DBNull.Value);
                }
                comando.Parameters.AddWithValue("@IdCompra", Obj.IdCompra);
                comando.Parameters.AddWithValue("@MetodoPago", Obj.MetodoPago);
                comando.Parameters.AddWithValue("@TipoTarjeta", Obj.TipoTarjeta);
                comando.Parameters.AddWithValue("@Descripcion", Obj.Descripcion);
                comando.Parameters.AddWithValue("@NroTarjeta", Obj.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", Obj.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Debe", Obj.Debe);
                comando.Parameters.AddWithValue("@Efectivo", Obj.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", Obj.MontoDebitado);
                comando.Parameters.AddWithValue("@EstadoCompra", Obj.Estado);
                comando.Parameters.AddWithValue("@Transferencia", Obj.Transferencia);
                comando.Parameters.AddWithValue("@Pago", Obj.Pago);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }


        public string InsertarPagoVenta(cdpagos Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("pagoagregarVenta", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdPago", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);
                comando.Parameters.AddWithValue("@IdVenta", Obj.IdVenta);
                comando.Parameters.AddWithValue("@MetodoPago", Obj.MetodoPago);
                comando.Parameters.AddWithValue("@TipoTarjeta", Obj.TipoTarjeta);
                comando.Parameters.AddWithValue("@EstadoVenta", Obj.Estado);
                comando.Parameters.AddWithValue("@Descripcion", Obj.Descripcion);
                comando.Parameters.AddWithValue("@NroTarjeta", Obj.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", Obj.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Debe", Obj.Debe);
                comando.Parameters.AddWithValue("@Efectivo", Obj.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", Obj.MontoDebitado);
                comando.Parameters.AddWithValue("@Transferencia", Obj.Transferencia);
                comando.Parameters.AddWithValue("@Pago", Obj.Pago);
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





        public string Actualizar(cdpagos Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("pagosCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdPago", Obj.IdPago);
                comando.Parameters.AddWithValue("@IdUsuario", Obj.IdUsuario);
                comando.Parameters.AddWithValue("@IdVenta", Obj.IdVenta);
                comando.Parameters.AddWithValue("@IdCompra", Obj.IdCompra);
                comando.Parameters.AddWithValue("@IdMetodoPago", Obj.IdMetodoPago);
                comando.Parameters.AddWithValue("@Descripcion", Obj.Descripcion);
                comando.Parameters.AddWithValue("@NroTarjeta", Obj.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", Obj.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Efectivo", Obj.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", Obj.MontoDebitado);
                comando.Parameters.AddWithValue("@Transferencia", Obj.Transferencia);
                comando.Parameters.AddWithValue("@Pago", Obj.Pago);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }



        public string Eliminar(cdpagos Obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("pagosCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdPago", Obj.IdPago);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@IdVenta", Obj.IdVenta);
                comando.Parameters.AddWithValue("@IdCompra", Obj.IdCompra);
                comando.Parameters.AddWithValue("@IdMetodoPago", DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion", DBNull.Value);
                comando.Parameters.AddWithValue("@NroTarjeta", DBNull.Value);
                comando.Parameters.AddWithValue("@TarjetaHabiente", DBNull.Value);
                comando.Parameters.AddWithValue("@Efectivo", DBNull.Value);
                comando.Parameters.AddWithValue("@MontoDebitado", DBNull.Value);
                comando.Parameters.AddWithValue("@Transferencia", DBNull.Value);
                comando.Parameters.AddWithValue("@Pago", DBNull.Value);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
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
