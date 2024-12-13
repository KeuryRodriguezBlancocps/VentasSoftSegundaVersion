using System;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class cdcompras
    {
        private int dIdCompra, dIdUsuario, dIdSuplidor, dIdEmpresa, dImpuesto;
        private string dNroComprobante, dTipoTarjeta, dDescripcion, dNroTarjeta, dTarjetaHabiente, dMetodoPago, dEstado, dAplicaImpuesto;
        private decimal dEfectivo, dMontoDebitado, dPago, dTotal, dDebe, dDevuelta, dTransferencia;
        private DateTime dFechaCreacion;
        private cdconexion oconexion = new cdconexion();
        private DataTable dCompraDetalles = new DataTable();
        public cdcompras(int dIdCompra, int dIdUsuario, string MetodoPago, string Estado, int dIdSuplidor, string dNroComprobante, string dTipoTarjeta, string dDescripcion, string dNroTarjeta, string dTarjetaHabiente, decimal dEfectivo, decimal dMontoDebitado, decimal dTotal, decimal dDebe, decimal dDevuelta, DateTime dFechaCreacion, decimal dPago, int dIdEmpresa, string dAplicaImpuesto, int dImpuesto)
        {
            this.dIdCompra = dIdCompra;
            this.dIdUsuario = dIdUsuario;
            this.dMetodoPago = MetodoPago;
            this.dEstado = Estado;
            this.dIdSuplidor = dIdSuplidor;
            this.dNroComprobante = dNroComprobante;
            this.dTipoTarjeta = dTipoTarjeta;
            this.dDescripcion = dDescripcion;
            this.dNroTarjeta = dNroTarjeta;
            this.dTarjetaHabiente = dTarjetaHabiente;
            this.dEfectivo = dEfectivo;
            this.dMontoDebitado = dMontoDebitado;
            this.dTotal = dTotal;
            this.dDebe = dDebe;
            this.dDevuelta = dDevuelta;
            this.dFechaCreacion = dFechaCreacion;
            this.dPago = dPago;
            this.dIdEmpresa = dIdEmpresa;
            this.dAplicaImpuesto = dAplicaImpuesto;
            this.dImpuesto = dImpuesto;
        }

        public cdcompras()
        {

        }


        #region Propiedades


        public int IdCompra
        {
            get { return dIdCompra; }
            set { dIdCompra = value; }
        }

        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }

        public int IdEmpresa
        {
            get { return dIdEmpresa; }
            set { dIdEmpresa = value; }
        }

        public int IdSuplidor
        {
            get { return dIdSuplidor; }
            set { dIdSuplidor = value; }
        }

        public string NroComprobante
        {
            get { return dNroComprobante; }
            set { dNroComprobante = value; }
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

        public decimal Transferencia
        {
            get { return dTransferencia; }
            set { dTransferencia = value; }
        }
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
            get { return  dTotal; }
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

        public DataTable CompraDetalles
        {
            get { return dCompraDetalles; }
            set { dCompraDetalles = value; }
        }

        public string AplicaImpuesto { get => dAplicaImpuesto; set => dAplicaImpuesto = value; }
        public int Impuesto { get => dImpuesto; set => dImpuesto = value; }

        #endregion



        public DataTable comprasTotal(cdcompras ObjCompras)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ComprasTotal", oconexion.AbrirConexion());
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




        public DataTable comprasporFechas(DateTime pFechaInicio, DateTime pFechaFinal, string pbusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("comprasporfecha", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Desde", pFechaInicio);
                comando.Parameters.AddWithValue("@Hasta", pFechaFinal);
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






        public DataTable ComprasporDia()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("ComprasTotal", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }




        public string ProductoEliminadoDeLaCompraDisminuyeStock(int pIdProducto, int pCantidad, int pidcompra,out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("productoEliminadoDeLaCompraDisminuyeStock", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCompra",pidcompra);
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


            public DataTable Busqueda(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("comprasBUSQUEDA", oconexion.AbrirConexion());
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

        public DataTable compraPorId(cdcompras ObjCompras)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("comprasporId", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCompra", ObjCompras.IdCompra);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }

        public DataTable compradetallePorId(cdcompras ObjCompras)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("comprasdetallesporIdCompra", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdCompra", ObjCompras.IdCompra);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }




        public DataTable ValidarSiElProductoSeEncuentraEnLaCompra(int dIdProducto)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("validarproductoenlacompra", oconexion.AbrirConexion());
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







        //Insertar Compras//
        public string Insertar(cdcompras ObjCompras, out string Mensaje, out int IdCompra)
        {
            Mensaje = "";
            IdCompra = 0;
            try
            {
                SqlCommand comando = new SqlCommand("compraCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdUsuario", ObjCompras.IdUsuario);
                comando.Parameters.AddWithValue("@IdSuplidor", ObjCompras.IdSuplidor);
                comando.Parameters.AddWithValue("@IdEmpresa", ObjCompras.IdEmpresa);
                comando.Parameters.AddWithValue("@NroComprobante", ObjCompras.NroComprobante);
                comando.Parameters.AddWithValue("@MetodoPago", ObjCompras.MetodoPago);
                comando.Parameters.AddWithValue("@AplicaImpuesto", ObjCompras.AplicaImpuesto);
                comando.Parameters.AddWithValue("@Impuesto", ObjCompras.Impuesto);
                comando.Parameters.AddWithValue("@TipoTarjeta", ObjCompras.TipoTarjeta);
                comando.Parameters.AddWithValue("@Estado", ObjCompras.Estado);
                comando.Parameters.AddWithValue("@Descripcion", ObjCompras.Descripcion);
                comando.Parameters.AddWithValue("@NroTarjeta", ObjCompras.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", ObjCompras.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Efectivo", ObjCompras.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", ObjCompras.MontoDebitado);
                comando.Parameters.AddWithValue("@Transferencia", ObjCompras.Transferencia);
                comando.Parameters.AddWithValue("@Total", ObjCompras.Total);
                comando.Parameters.AddWithValue("@Debe", ObjCompras.Debe);
                comando.Parameters.AddWithValue("@Devuelta", ObjCompras.Devuelta);
                comando.Parameters.AddWithValue("@Pago", ObjCompras.Pago);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
                SqlParameter parametro = comando.Parameters.AddWithValue("@vCompradetalles", ObjCompras.CompraDetalles);
                SqlParameter idcompra = comando.Parameters.AddWithValue("@IdCompra", ObjCompras.IdCompra);
                parametro.SqlDbType = SqlDbType.Structured;
                comando.ExecuteNonQuery();
                IdCompra = Convert.ToInt32(comando.Parameters["@IdCompra"].Value);
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (SqlException ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }


        //Actualizar Compras//
        public string Actualizar(cdcompras ObjCompras, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("compraCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdCompra", ObjCompras.IdCompra);
                comando.Parameters.AddWithValue("@IdEmpresa", 1);
                comando.Parameters.AddWithValue("@IdUsuario", ObjCompras.IdUsuario);
                comando.Parameters.AddWithValue("@IdSuplidor", ObjCompras.IdSuplidor);
                comando.Parameters.AddWithValue("@NroComprobante", ObjCompras.NroComprobante);
                comando.Parameters.AddWithValue("@AplicaImpuesto", ObjCompras.AplicaImpuesto);
                comando.Parameters.AddWithValue("@Impuesto", ObjCompras.Impuesto);
                comando.Parameters.AddWithValue("@MetodoPago", ObjCompras.MetodoPago);
                comando.Parameters.AddWithValue("@TipoTarjeta", ObjCompras.TipoTarjeta);
                comando.Parameters.AddWithValue("@Estado", ObjCompras.Estado);
                comando.Parameters.AddWithValue("@Descripcion", ObjCompras.Descripcion);
                comando.Parameters.AddWithValue("@NroTarjeta", ObjCompras.NroTarjeta);
                comando.Parameters.AddWithValue("@TarjetaHabiente", ObjCompras.TarjetaHabiente);
                comando.Parameters.AddWithValue("@Efectivo", ObjCompras.Efectivo);
                comando.Parameters.AddWithValue("@MontoDebitado", ObjCompras.MontoDebitado);
                comando.Parameters.AddWithValue("@Transferencia", ObjCompras.Transferencia);
                comando.Parameters.AddWithValue("@Pago", ObjCompras.Pago);
                comando.Parameters.AddWithValue("@Total", ObjCompras.Total);
                comando.Parameters.AddWithValue("@Debe", ObjCompras.Debe);
                comando.Parameters.AddWithValue("@Devuelta", ObjCompras.Devuelta);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 120).Direction = ParameterDirection.Output;
                SqlParameter parametro = comando.Parameters.AddWithValue("@vCompradetalles", ObjCompras.CompraDetalles);
                parametro.SqlDbType = SqlDbType.Structured;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = (ex.Message);
            }
            return Mensaje;
        }




        //Eliminar Compras//
        public string Eliminar(cdcompras ObjCompras, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("compraCRUD", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdCompra", ObjCompras.IdCompra);
                comando.Parameters.AddWithValue("@IdEmpresa", DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@IdSuplidor", DBNull.Value);
                comando.Parameters.AddWithValue("@NroComprobante", DBNull.Value);
                comando.Parameters.AddWithValue("@AplicaImpuesto", DBNull.Value);
                comando.Parameters.AddWithValue("@Impuesto", DBNull.Value);
                comando.Parameters.AddWithValue("@MetodoPago", DBNull.Value);
                comando.Parameters.AddWithValue("@TipoTarjeta", DBNull.Value);
                comando.Parameters.AddWithValue("@Estado", DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion", DBNull.Value);
                comando.Parameters.AddWithValue("@NroTarjeta", DBNull.Value);
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
                Console.WriteLine(ex.Message);
            }
            return Mensaje;


        }
    }

}