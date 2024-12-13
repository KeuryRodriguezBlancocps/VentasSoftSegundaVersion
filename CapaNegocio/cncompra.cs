using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Security.Cryptography;
namespace CapaNegocio
{
    public class cncompra
    {

        public DataTable Busqueda(string pBusqueda)
        {
            cdcompras obj = new cdcompras();
            return obj.Busqueda(pBusqueda);
        }


        public DataTable compraPorFecha(string pBusqueda, DateTime pDesde, DateTime pHasta)
        {
            cdcompras obj = new cdcompras();
           return obj.comprasporFechas(pDesde, pHasta, pBusqueda);
        }

        public DataTable ValidarSiElProductoSeEncuentraEnLaCompra(int dIdProducto)
        {
            cdcompras obj = new cdcompras();
            return obj.ValidarSiElProductoSeEncuentraEnLaCompra(dIdProducto);
        }

        public DataTable comprasporfecha(DateTime pFechaInicio, DateTime pFechaFinal, string pBusqueda)
        {
            cdcompras ObjVentas = new cdcompras();
            return ObjVentas.comprasporFechas(pFechaInicio, pFechaFinal, pBusqueda);
        }


        public string ProductoEliminadoDeLaCompraDisminuyeStock(int pIdProducto, int pCantidad, int pidcompra,out string mensaje)
        {
            cdcompras ObjCompras = new cdcompras();
            return ObjCompras.ProductoEliminadoDeLaCompraDisminuyeStock(pIdProducto,  pCantidad, pidcompra,out mensaje);
        }


        public DataTable comprasdelDia()
        {
            cdcompras obj = new cdcompras();
            return obj.ComprasporDia();
        }




        public DataTable compraporId(int pIdCompra)
        {
            cdcompras obj = new cdcompras();
            obj.IdCompra = pIdCompra;
            return obj.compraPorId(obj);
        }

        public DataTable TotalCompra()
        {
            cdcompras obj = new cdcompras();
            return obj.comprasTotal(obj);
        }




        public DataTable compraporDetallePorId(int pIdCompra)
        {
            cdcompras obj = new cdcompras();
            obj.IdCompra = pIdCompra;
            return obj.compradetallePorId(obj);
        }


        public string Insertar(int dIdUsuario, int dIdEmpresa,string MetodoPago, string Estado, int dIdSuplidor, string dNroComprobante, string dTipoTarjeta,
            string dDescripcion, string dAplicaImpuesto, int dImpuesto ,string dNroTarjeta, string dTarjetaHabiente, decimal dEfectivo, decimal dMontoDebitado,decimal pTransferencia, decimal dTotal, decimal dDebe,
            decimal dDevuelta, decimal dPago, DataTable dcompradetalles, out string Mensaje, out int IdCompra)
        {
            cdcompras obj = new cdcompras();
            obj.IdUsuario = dIdUsuario;
            obj.IdEmpresa = dIdEmpresa;
            obj.MetodoPago = MetodoPago;
            obj.Estado = Estado;
            obj.IdSuplidor = dIdSuplidor;
            obj.NroComprobante = dNroComprobante;
            obj.TipoTarjeta = dTipoTarjeta;
            obj.Descripcion = dDescripcion;
            obj.AplicaImpuesto = dAplicaImpuesto;
            obj.Impuesto = dImpuesto;
            obj.NroTarjeta = dNroTarjeta;
            obj.TarjetaHabiente = dTarjetaHabiente;
            obj.Efectivo = dEfectivo;
            obj.MontoDebitado = dMontoDebitado;
            obj.Transferencia = pTransferencia;
            obj.Total = dTotal;
            obj.Debe = dDebe;
            obj.Devuelta = dDevuelta;
            obj.Pago = dPago;
            obj.CompraDetalles = dcompradetalles;
            return obj.Insertar(obj, out Mensaje, out IdCompra);
        }

        public string Actualizar(int dIdCompra,int dIdUsuario, string MetodoPago, string Estado, int dIdSuplidor, string dNroComprobante, string dTipoTarjeta,
            string dDescripcion, string dAplicaImpuesto, int dImpuesto, string dNroTarjeta, string dTarjetaHabiente, decimal dEfectivo, decimal dMontoDebitado, decimal pTransferencia, decimal dTotal, decimal dDebe,
            decimal dDevuelta, decimal dPago, DataTable dcompradetalles, out string Mensaje)
        {
            cdcompras obj = new cdcompras();
            obj.IdCompra = dIdCompra;
            obj.IdUsuario = dIdUsuario;
            obj.MetodoPago = MetodoPago;
            obj.Estado = Estado;
            obj.IdSuplidor = dIdSuplidor;
            obj.NroComprobante = dNroComprobante;
            obj.TipoTarjeta = dTipoTarjeta;
            obj.Descripcion = dDescripcion;
            obj.AplicaImpuesto = dAplicaImpuesto;
            obj.Impuesto = dImpuesto;
            obj.NroTarjeta = dNroTarjeta;
            obj.TarjetaHabiente = dTarjetaHabiente;
            obj.Efectivo = dEfectivo;
            obj.MontoDebitado = dMontoDebitado;
            obj.Transferencia = pTransferencia;
            obj.Total = dTotal;
            obj.Debe = dDebe;
            obj.Devuelta = dDevuelta;
            obj.Pago = dPago;
            obj.CompraDetalles = dcompradetalles;
            return obj.Actualizar(obj, out Mensaje);
        }


        public string Eliminar(int dIdCompra, out string Mensaje)
        {
            cdcompras obj = new cdcompras();
            obj.IdCompra = dIdCompra;
            return obj.Eliminar(obj, out Mensaje);
        }




    }
}
