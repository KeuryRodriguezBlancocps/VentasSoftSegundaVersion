using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnpagos
    {



        public DataTable pagosporId(int pIdVenta)
        {
            cdpagos obj = new cdpagos();
            obj.IdVenta = pIdVenta;
            return obj.PagosporId(obj);
        }


        public DataTable pagosporIdCompra(int pIdCompra)
        {
            cdpagos obj = new cdpagos();
            obj.IdCompra = pIdCompra;
            return obj.PagosporIdCompra(obj);
        }




        public string Insertar(int dIdCompra, string dIdMetodoPago, string dEstado, string dTarjetaHabiente, string nroTarjeta, string dDescripcion,
          string dTipoTarjeta, decimal dEfectivo, decimal dMontoDebitado, decimal dTransferencia, decimal dPago, decimal dDebe, int dIdUsuario, out string Mensaje)
        {
            cdpagos obj = new cdpagos();
            obj.IdCompra = dIdCompra;
            obj.IdMetodoPago = dIdMetodoPago;
            obj.TarjetaHabiente = dTarjetaHabiente; 
            obj.NroTarjeta = nroTarjeta;
            obj.Descripcion = dDescripcion;
            obj.TipoTarjeta = dTipoTarjeta;
            obj.Efectivo = dEfectivo;
            obj.MontoDebitado = dMontoDebitado;
            obj.Transferencia = dTransferencia;
            obj.Debe = dDebe;
            obj.Pago = dPago;
            obj.Estado = dEstado;
            obj.IdUsuario = dIdUsuario;
          return  obj.Insertar(obj, out Mensaje);
        }






        public string InsertarPagoVenta(int dIdVenta, string dIdMetodoPago, string dEstado, string dTarjetaHabiente, string nroTarjeta, string dDescripcion,
          string dTipoTarjeta, decimal dEfectivo, decimal dMontoDebitado, decimal dTransferencia, decimal dPago, decimal dDebe, int dIdUsuario, out string Mensaje)
        {
            cdpagos obj = new cdpagos();
            obj.IdVenta = dIdVenta;
            obj.IdMetodoPago = dIdMetodoPago;
            obj.TarjetaHabiente = dTarjetaHabiente;
            obj.NroTarjeta = nroTarjeta;
            obj.Descripcion = dDescripcion;
            obj.TipoTarjeta = dTipoTarjeta;
            obj.Efectivo = dEfectivo;
            obj.MontoDebitado = dMontoDebitado;
            obj.Transferencia = dTransferencia;
            obj.Debe = dDebe;
            obj.Pago = dPago;
            obj.Estado = dEstado;
            obj.IdUsuario = dIdUsuario;
            return obj.InsertarPagoVenta(obj, out Mensaje);
        }


        //public string Actualizar(int dIdPago,int dIdVenta, int dIdCompra, int dIdMetodoPago, string dTarjetaHabiente, string nroTarjeta, string dDescripcion,
        //string dTipoTarjeta, decimal dEfectivo, decimal dMontoDebitado, decimal dTransferencia, decimal dPago, int dIdUsuario, out string Mensaje)
        //{
        //    cdpagos obj = new cdpagos();
        //    obj.IdPago = dIdPago;
        //    obj.IdVenta = dIdVenta;
        //    obj.IdCompra = dIdCompra;
        //    obj.IdMetodoPago = dIdMetodoPago;
        //    obj.TarjetaHabiente = dTarjetaHabiente;
        //    obj.NroTarjeta = nroTarjeta;
        //    obj.Descripcion = dDescripcion;
        //    obj.TipoTarjeta = dTipoTarjeta;
        //    obj.Efectivo = dEfectivo;
        //    obj.MontoDebitado = dMontoDebitado;
        //    obj.Transferencia = dTransferencia;
        //    obj.Pago = dPago;
        //    obj.IdUsuario = dIdUsuario;
        //    return obj.Actualizar(obj, out Mensaje);
        //}

        public string Eliminar(int dIdPago, out string Mensaje)
        {
            cdpagos obj = new cdpagos();
            obj.IdPago = dIdPago;
            return obj.Eliminar(obj, out Mensaje);
        }

    }
}
