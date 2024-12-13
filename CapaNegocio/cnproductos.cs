using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnproductos
    {
        public DataTable Busqueda(string pBusqueda)
        {
            cdproductos obj = new cdproductos();
            return obj.Busqueda(pBusqueda);
        }


        public DataTable Inventario(string pBusqueda)
        {
            cdproductos obj = new cdproductos();
            return obj.Inventario(pBusqueda);
        }

        public DataTable ProductosMasVendidos()
        {
            cdproductos obj = new cdproductos();
            return obj.ProductosMasVendidos();
        }

        public DataTable ProductosenAlertaDeStock()
        {
            cdproductos obj = new cdproductos();
            return obj.ProductosAlertaStock();
        }



        public DataTable ProductoPorId(int pIdProducto)
        {
            cdproductos obj = new cdproductos();
            return obj.ProductoPorId(pIdProducto);
        }
        public string Insertar (int dIdUsuario, string dCodProducto,string dNombre, string dDescripcion, byte[] dImagen, int dIdUbicacion ,int dSeccion, int dIdCategoria, string dAplicaImpuesto, int dImpuesto,int dStock,decimal dCosto, decimal dPrecio, out string mensaje)
        {
            cdproductos obj = new cdproductos();
            obj.IdUsuario = dIdUsuario;
            obj.CodProducto = dCodProducto;
            obj.Nombre = dNombre;
            obj.Descripcion = dDescripcion;
            obj.Imagen = dImagen;
            obj.Ubicacion = dIdUbicacion;
            obj.Stock = dStock;
            obj.IdSeccion = dSeccion;
            obj.AplicaImpuesto = dAplicaImpuesto;
            obj.Impuesto = dImpuesto;
            obj.IdCategoria = dIdCategoria;
            obj.Costo = dCosto;
            obj.Precio = dPrecio;
            return obj.Insertar(obj, out mensaje);
        }

        public string Actualizar(int dIdProducto, int dIdUsuario, string dCodProducto, string dNombre, string dDescripcion, byte[] dImagen, int dIdUbicacion,int dSeccion, int dIdCategoria, string dAplicaImpuesto, int dImpuesto, int dStock, decimal dCosto, decimal dPrecio, out string mensaje)
        {
            cdproductos obj = new cdproductos();
            obj.IdProducto = dIdProducto;
            obj.IdUsuario = dIdUsuario;
            obj.IdProducto = dIdProducto;
            obj.CodProducto = dCodProducto;
            obj.Nombre = dNombre;
            obj.Descripcion = dDescripcion;
            obj.Imagen = dImagen;
            obj.Ubicacion = dIdUbicacion;
            obj.IdSeccion = dSeccion;
            obj.AplicaImpuesto = dAplicaImpuesto;
            obj.Impuesto = dImpuesto;
            obj.IdCategoria = dIdCategoria;
            obj.Stock = dStock;
            obj.Costo = dCosto;
            obj.Precio = dPrecio;
            return obj.Actualizar(obj, out mensaje);
        }

        public string Eliminar(int pIdProducto, out string Mensaje)
        {
            cdproductos obj = new cdproductos();
            obj.IdProducto = pIdProducto;
            return obj.Eliminar(obj, out Mensaje);
        }

    }
}
