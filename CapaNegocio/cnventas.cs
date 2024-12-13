using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnventas
    {
        public DataTable VentasDelDia(string pBusqueda)
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.VentasdelDia(pBusqueda);
        }

        public DataTable VentasDelDiaTarjetas()
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.VentasDelDiaTarjetas();
        }


        public DataTable ValidarSiElProductoSeEncuentraEnLaVenta(int dIdProducto)
        {
            cdventas obj = new cdventas();
            return obj.ValidarSiElProductoSeEncuentraEnLaVenta(dIdProducto);
        }


        public DataTable VentasPorFecha(string pBusqueda, DateTime pFechaInicio, DateTime pFechaFinal)
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.VentasPorFecha(pBusqueda,pFechaInicio, pFechaFinal);
        }


        public DataTable Busqueda(string pBusqueda)
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.Busqueda(pBusqueda);
        }



        public string ProductoEliminadoDeLaVentasAumentaStock(int pIdProducto, int pCantidad ,out string mensaje)
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.ProductoEliminadoDeLaVentasAumentaStock(pIdProducto, pCantidad, out mensaje);
        }


        public string DismminuirStock(int pIdProducto, int pCantidad)
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.DismminuirStock(pIdProducto, pCantidad);
        }




        public DataTable VentasTotales()
        {
            cdventas ObjVentas = new cdventas();
            return ObjVentas.VentasTotales();
        }

        public DataTable ventaporId(int IdVenta)
        {
            cdventas ObjVentas = new cdventas();
            ObjVentas.IdVenta = IdVenta;
            return ObjVentas.VentasporId(ObjVentas);
        }



        public DataTable ventadetalleporId(int IdVenta)
        {
            cdventas ObjVentas = new cdventas();
            ObjVentas.IdVenta = IdVenta;
            return ObjVentas.ventadetallesPorId(ObjVentas);
        }





        public string Insertar(int pIdUsuario, int pidEmpresa,string pMetodoPago, int dIdTipoComprobante,string dNroComprobante, string pEstado, int pIdCliente, string pTipoTarjeta, string pDescripcion, string pNroTarjeta, string pTarjetaHabiente, decimal pEfectivo, decimal pMontoDebitado, decimal pTransferencia,decimal pPago, decimal pTotal, decimal pDebe, decimal pDevuelta ,DataTable pVentaDetalles, out string Mensaje, out int IdVenta)
        {

            cdventas ObjVentas = new cdventas();
            ObjVentas.IdUsuario = pIdUsuario;
            ObjVentas.IdEmpresa = pidEmpresa;
            ObjVentas.MetodoPago = pMetodoPago;
            ObjVentas.Estado = pEstado;
            ObjVentas.IdCliente = pIdCliente;
            ObjVentas.IdTipoComprobante = dIdTipoComprobante;
            ObjVentas.NroComprobante = dNroComprobante;
            ObjVentas.TipoTarjeta = pTipoTarjeta;
            ObjVentas.Descripcion = pDescripcion;
            ObjVentas.NroTarjeta = pNroTarjeta;
            ObjVentas.TarjetaHabiente = pTarjetaHabiente;
            ObjVentas.Efectivo = pEfectivo;
            ObjVentas.Pago = pPago;
            ObjVentas.MontoDebitado = pMontoDebitado;
            ObjVentas.Transferencia = pTransferencia;
            ObjVentas.Total = pTotal;
            ObjVentas.Debe = pDebe;
            ObjVentas.Devuelta = pDevuelta;
            ObjVentas.VentaDetalles = pVentaDetalles;
            return ObjVentas.Insertar(ObjVentas, out Mensaje, out IdVenta);
        }



        public string Actualizar(int dIdVenta, int pIdUsuario, int pidEmpresa,string pMetodoPago, int dIdTipoComprobante,string dNroComprobante, string pEstado, int pIdCliente, string pTipoTarjeta, string pDescripcion, string pNroTarjeta, string pTarjetaHabiente, decimal pEfectivo, decimal pMontoDebitado, decimal pTransferencia,decimal pPago, decimal pTotal, decimal pDebe, decimal pDevuelta, DataTable pVentaDetalles, out string Mensaje)
        {
            cdventas ObjVentas = new cdventas();
            ObjVentas.IdVenta = dIdVenta;
            ObjVentas.IdUsuario = pIdUsuario;
            ObjVentas.IdEmpresa = pidEmpresa;
            ObjVentas.MetodoPago = pMetodoPago;
            ObjVentas.Estado = pEstado;
            ObjVentas.IdCliente = pIdCliente;
            ObjVentas.IdTipoComprobante = dIdTipoComprobante;
            ObjVentas.NroComprobante = dNroComprobante;
            ObjVentas.TipoTarjeta = pTipoTarjeta;
            ObjVentas.Descripcion = pDescripcion;
            ObjVentas.NroTarjeta = pNroTarjeta;
            ObjVentas.TarjetaHabiente = pTarjetaHabiente;
            ObjVentas.Efectivo = pEfectivo;
            ObjVentas.Pago = pPago;
            ObjVentas.MontoDebitado = pMontoDebitado;
            ObjVentas.Transferencia = pTransferencia;
            ObjVentas.Total = pTotal;
            ObjVentas.Debe = pDebe;
            ObjVentas.Devuelta = pDevuelta;
            ObjVentas.VentaDetalles = pVentaDetalles;
            return ObjVentas.Actualizar(ObjVentas, out Mensaje);
        }



        public string Eliminar(int pIdVenta, int pidusuario,out string Mensaje)
        {

            cdventas ObjVentas = new cdventas();
            ObjVentas.IdVenta = pIdVenta;
            ObjVentas.IdUsuario = pidusuario;
            return ObjVentas.Eliminar(ObjVentas, out Mensaje);
        }



    }
}
