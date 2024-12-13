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
    public class cdventas
    {
        private int dIdVenta, dIdEmpresa,dIdUsuario, dIdCliente, dIdTipoComprobante;
        private string dTipoTarjeta, dDescripcion ,dNroTarjeta, dTarjetaHabiente, dEstado, dMetodoPago, dNroComprobante;
        private decimal dEfectivo, dMontoDebitado, dTransferencia,dPago, dTotal, dDebe, dDevuelta;
        private DateTime dFechaCreacion;
        private cdconexion oconexion = new cdconexion();
        private DataTable dVentaDetalles = new DataTable();


        public cdventas(int dIdVenta, int dIdUsuario, string dMetodoPago, string dEstado, int dIdCliente, int dIdTipoComprobante, string dNroComprobante, string dTipoTarjeta, string dDescripcion, string dNroTarjeta, string dTarjetaHabiente, decimal dEfectivo, decimal dMontoDebitado, decimal dPago, decimal dTotal, decimal dDebe, decimal dDevuelta, DateTime dFechaCreacion, cdconexion oconexion, DataTable dVentaDetalles)
        {
            this.dIdVenta = dIdVenta;
            this.dIdUsuario = dIdUsuario;
            this.dMetodoPago = dMetodoPago;
            this.dEstado = dEstado;
            this.dIdCliente = dIdCliente;
            this.dIdTipoComprobante = dIdTipoComprobante;
            this.dTipoTarjeta = dTipoTarjeta;
            this.dDescripcion = dDescripcion;
            this.dNroTarjeta = dNroTarjeta;
            this.dTarjetaHabiente = dTarjetaHabiente;
            this.dEfectivo = dEfectivo;
            this.dMontoDebitado = dMontoDebitado;
            this.dPago = dPago;
            this.dTotal = dTotal;
            this.dDebe = dDebe;
            this.dDevuelta = dDevuelta;
            this.dFechaCreacion = dFechaCreacion;
            this.oconexion = oconexion;
            this.dVentaDetalles = dVentaDetalles;
        }

        public cdventas() { }


        #region Propiedades


        public int IdVenta
        {
            get { return dIdVenta; }
            set { dIdVenta = value; }
        }

        public int IdTipoComprobante
        {
            get { return dIdTipoComprobante; }
            set { dIdTipoComprobante = value; }
        }
        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }

        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }


        public int IdEmpresa
        {
            get { return dIdEmpresa; }
            set { dIdEmpresa = value; }
        }


        public string MetodoPago
        {
            get { return dMetodoPago; }
            set { dMetodoPago = value; }
        }

        public string TipoTarjeta
        {
            get { return dTipoTarjeta; }
            set { dTipoTarjeta = value; }
        }





        //public string NroComprobante
        //{
        //    get { return dnrocom}
        //}


        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }

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
            set { dTarjetaHabiente = value; }
        }

        public decimal Efectivo
        {
            get { return dEfectivo; }
            set { dEfectivo = value; }
        }

        public decimal Transferencia
        {
            get { return dTransferencia; }
            set { dTransferencia = value; }
        }


        public decimal MontoDebitado
        {
            get { return dMontoDebitado; }
            set { dMontoDebitado = value; }
        }

        public decimal Pago
        {
            get { return dPago; }
            set { dPago = value; }
        }

        public decimal Total
        {
            get { return dTotal; }
            set { dTotal = value; }

        }

        public decimal Debe
        {
            get { return dDebe; }
            set { dDebe = value; }
        }


        public decimal Devuelta
        {
            get { return dDevuelta; }
            set { dDevuelta = value; }
        }

        public DataTable VentaDetalles
        {
            get { return dVentaDetalles; }
            set { dVentaDetalles = value; }
        }

        public string NroComprobante { get => dNroComprobante; set => dNroComprobante = value; }

        #endregion




        public DataTable VentasdelDia(string pbusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ventasdeldia", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Busqueda", pbusqueda);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }


        public DataTable VentasPorFecha(string PBusqueda,DateTime pFechaInicio, DateTime pFechaFinal)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ventasporfecha", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Busqueda", PBusqueda);
                comando.Parameters.AddWithValue("@Desde", pFechaInicio);
                comando.Parameters.AddWithValue("@Hasta", pFechaFinal);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }




        public DataTable ValidarSiElProductoSeEncuentraEnLaVenta(int dIdProducto)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("validarproductoenlaventa", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdProducto", dIdProducto);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }










        public DataTable VentasTotales()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("VentasTotal", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }



        public DataTable VentasDelDiaTarjetas()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("VentasTotal", oconexion.AbrirConexion());
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }


        public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ventasBUSQUEDA", oconexion.AbrirConexion());
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




        public DataTable VentaPorFechas(string pBusqueda, DateTime pDesde, DateTime pHasta)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ventasporfecha", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Busqueda", pBusqueda);
                comando.Parameters.AddWithValue("@Desde", pDesde);
                comando.Parameters.AddWithValue("@Hasta", pHasta);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }






        public string ProductoEliminadoDeLaVentasAumentaStock(int pIdProducto, int pCantidad, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("productoEliminadoDeLaVentaAumentaStock", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdProducto", pIdProducto);
                comando.Parameters.AddWithValue("@Cantidad", pCantidad);
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



        public string DismminuirStock(int pIdProducto, int pCantidad)
        {
    
            try
            {
                SqlCommand comando = new SqlCommand("dismunuirstockVenta", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdProducto", pIdProducto);
                comando.Parameters.AddWithValue("@Cantidad", pCantidad);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }





        public DataTable VentasporId(cdventas ObjVentas)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ventaporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idVenta", ObjVentas.IdVenta);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }



        public DataTable ventadetallesPorId(cdventas ObjVentas)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ventadetalleporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdVenta", ObjVentas.IdVenta);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return tabla;
        }






        //Insertar Ventas//
        public string Insertar(cdventas ObjVentas, out string Mensaje, out int IdVenta)
        {
            Mensaje = "";
            IdVenta = 0;
            try
            {
                SqlCommand comando = new SqlCommand("ventasCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdUsuario", ObjVentas.IdUsuario);
                comando.Parameters.AddWithValue("@IdEmpresa", ObjVentas.IdEmpresa);
                if (IdCliente==0)
                {
                comando.Parameters.AddWithValue("@IdCliente", DBNull.Value);

                }
                else
                {
                    comando.Parameters.AddWithValue("@IdCliente", ObjVentas.IdCliente);
                }
                comando.Parameters.AddWithValue("@IdTipoComprobante", ObjVentas.IdTipoComprobante);
                comando.Parameters.AddWithValue("@NroComprobante", ObjVentas.NroComprobante);
                comando.Parameters.AddWithValue("@Estado", ObjVentas.Estado);
                comando.Parameters.AddWithValue("@MetodoPago", ObjVentas.MetodoPago);
                comando.Parameters.AddWithValue("@Descripcion", ObjVentas.Descripcion);
                comando.Parameters.AddWithValue("@TipoTarjeta", ObjVentas.TipoTarjeta);
                comando.Parameters.AddWithValue("@NroTarjeta", ObjVentas.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", ObjVentas.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Efectivo", ObjVentas.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", ObjVentas.MontoDebitado);
                comando.Parameters.AddWithValue("@Transferencia", ObjVentas.Transferencia);
                comando.Parameters.AddWithValue("@Pago", ObjVentas.Pago);
                comando.Parameters.AddWithValue("@Total", ObjVentas.Total);
                comando.Parameters.AddWithValue("@Debe", ObjVentas.Debe);
                comando.Parameters.AddWithValue("@Devuelta", ObjVentas.Devuelta);
                SqlParameter parametro = comando.Parameters.AddWithValue("@ventasdetalle", ObjVentas.VentaDetalles);
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 120).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@IdVenta", SqlDbType.Int).Direction = ParameterDirection.Output;
                parametro.SqlDbType = SqlDbType.Structured;
                comando.ExecuteNonQuery();
                IdVenta = Convert.ToInt32(comando.Parameters["@IdVenta"].Value);
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }


        //Actualizar Ventas//
        public string Actualizar(cdventas ObjVentas, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ventasCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdVenta", ObjVentas.IdVenta);
                comando.Parameters.AddWithValue("@IdUsuario", ObjVentas.IdUsuario);
                comando.Parameters.AddWithValue("@IdEmpresa", ObjVentas.IdEmpresa);
                if (IdCliente == 0)
                {
                    comando.Parameters.AddWithValue("@IdCliente", DBNull.Value);

                }
                else
                {
                    comando.Parameters.AddWithValue("@IdCliente", ObjVentas.IdCliente);
                }
                comando.Parameters.AddWithValue("@IdTipoComprobante", ObjVentas.IdTipoComprobante);
                comando.Parameters.AddWithValue("@NroComprobante", ObjVentas.NroComprobante);
                comando.Parameters.AddWithValue("@Estado", ObjVentas.Estado);
                comando.Parameters.AddWithValue("@MetodoPago", ObjVentas.MetodoPago);
                comando.Parameters.AddWithValue("@Descripcion", ObjVentas.Descripcion);
                comando.Parameters.AddWithValue("@TipoTarjeta", ObjVentas.TipoTarjeta);
                comando.Parameters.AddWithValue("@NroTarjeta", ObjVentas.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", ObjVentas.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Efectivo", ObjVentas.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", ObjVentas.MontoDebitado);
                comando.Parameters.AddWithValue("@Transferencia", ObjVentas.Transferencia);
                comando.Parameters.AddWithValue("@Pago", ObjVentas.Pago);
                comando.Parameters.AddWithValue("@Total", ObjVentas.Total);
                comando.Parameters.AddWithValue("@Debe", ObjVentas.Debe);
                comando.Parameters.AddWithValue("@Devuelta", ObjVentas.Devuelta);
                SqlParameter parametro = comando.Parameters.AddWithValue("@ventasdetalle", ObjVentas.VentaDetalles);
                comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 120).Direction = ParameterDirection.Output;
                parametro.SqlDbType = SqlDbType.Structured;
                comando.ExecuteNonQuery();
                IdVenta = Convert.ToInt32(comando.Parameters["@IdVenta"].Value);
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
            return Mensaje;
        }

        //Actualizar Ventas//
        public string Eliminar(cdventas ObjVentas, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("ventasCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdVenta", ObjVentas.IdVenta);
                comando.Parameters.AddWithValue("@IdUsuario", ObjVentas.IdUsuario);
                comando.Parameters.AddWithValue("@IdEmpresa", DBNull.Value);
                comando.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion", DBNull.Value);
                comando.Parameters.AddWithValue("@IdTipoComprobante", DBNull.Value);
                comando.Parameters.AddWithValue("@NroComprobante", DBNull.Value);
                comando.Parameters.AddWithValue("@TipoTarjeta", DBNull.Value);
                comando.Parameters.AddWithValue("@NroTarjeta", DBNull.Value);
                comando.Parameters.AddWithValue("@MetodoPago", DBNull.Value);
                comando.Parameters.AddWithValue("@Estado", DBNull.Value);
                comando.Parameters.AddWithValue("@TarjetaHabiente", DBNull.Value);
                comando.Parameters.AddWithValue("@Efectivo", DBNull.Value);
                comando.Parameters.AddWithValue("@MontoDebitado", DBNull.Value);
                comando.Parameters.AddWithValue("@Transferencia", DBNull.Value);
                comando.Parameters.AddWithValue("@Pago", DBNull.Value);
                comando.Parameters.AddWithValue("@Total", DBNull.Value);
                comando.Parameters.AddWithValue("@Debe", DBNull.Value);
                comando.Parameters.AddWithValue("@Devuelta", DBNull.Value);
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
