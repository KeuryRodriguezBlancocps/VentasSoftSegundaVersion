using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class cdproductos
    {

        private int dIdUsuario, dIdProducto, dStockSobres, dStockUnidades, dStock,dIdCategoria, dImpuesto, dSeccion, dIdLaboratorio,dUbicacion;
        private string dNombre, dCodProducto,dDescripcion, dAplicaImpuesto;
        private decimal dCosto, dPrecio;
        private DateTime dFechaVencimiento;
        private byte[] dImagen;
        private cdconexion oconexion = new cdconexion();



        public cdproductos() 
        { 
        
        }

        public cdproductos(int dIdUsuario, int dIdProducto, int dStockSobres, int dStockUnidades, int dIdCategoria, int dImpuesto, string dNombre, string dDescripcion, byte[] dImagen, int pIdUbicacion, int dSeccion, string dAplicaImpuesto, decimal dCosto, decimal dPrecio, DateTime dFechaVencimiento, string dCodProducto, int dIdLaboratorio, int dStock)
        {
            this.dIdUsuario = dIdUsuario;
            this.dIdProducto = dIdProducto;
            this.dStockSobres = dStockSobres;
            this.dStockUnidades = dStockUnidades;
            this.dIdCategoria = dIdCategoria;
            this.dImpuesto = dImpuesto;
            this.dNombre = dNombre;
            this.dDescripcion = dDescripcion;
            this.dImagen = dImagen;
            this.dUbicacion = pIdUbicacion;
            this.dSeccion = dSeccion;
            this.dAplicaImpuesto = dAplicaImpuesto;
            this.dCosto = dCosto;
            this.dPrecio = dPrecio;
            this.dFechaVencimiento = dFechaVencimiento;
            this.dCodProducto = dCodProducto;
            this.dIdLaboratorio = dIdLaboratorio;
            this.dStock = dStock;
        }

        public int IdUsuario { get => dIdUsuario; set => dIdUsuario = value; }
        public int IdProducto { get => dIdProducto; set => dIdProducto = value; }
        public int StockSobres { get => dStockSobres; set => dStockSobres = value; }
        public int StockUnidades { get => dStockUnidades; set => dStockUnidades = value; }
        public int IdCategoria { get => dIdCategoria; set => dIdCategoria = value; }
        public int Impuesto { get => dImpuesto; set => dImpuesto = value; }
        public string Nombre { get => dNombre; set => dNombre = value; }
        public string Descripcion { get => dDescripcion; set => dDescripcion = value; }
        public byte[] Imagen { get => dImagen; set => dImagen = value; }
        public int Ubicacion { get => dUbicacion; set => dUbicacion = value; }
        public int IdSeccion { get => dSeccion; set => dSeccion = value; }
        public string AplicaImpuesto { get => dAplicaImpuesto; set => dAplicaImpuesto = value; }
        public decimal Costo { get => dCosto; set => dCosto = value; }
        public decimal Precio { get => dPrecio; set => dPrecio = value; }
        public DateTime FechaVencimiento { get => dFechaVencimiento; set => dFechaVencimiento = value; }
        public string CodProducto { get => dCodProducto; set => dCodProducto = value; }
        public int IdLaboratorio { get => dIdLaboratorio; set => dIdLaboratorio = value; }
        public int Stock { get => dStock; set => dStock = value; }

        public string Insertar(cdproductos obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("productoscrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 1);
                comando.Parameters.AddWithValue("@IdProducto", DBNull.Value);
                comando.Parameters.AddWithValue("@CodProducto", obj.CodProducto);
                comando.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                comando.Parameters.AddWithValue("@Producto", obj.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                if (Imagen == null)
                {
                    comando.Parameters.AddWithValue("@Imagen", obj.Imagen);
                }
                else
                {

                comando.Parameters.AddWithValue("@Imagen", obj.Imagen);
                }
                comando.Parameters.AddWithValue("@Ubicacion", obj.Ubicacion);
                comando.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria);
                comando.Parameters.AddWithValue("@IdSeccion", obj.IdSeccion);
                comando.Parameters.AddWithValue("@AplicaImpuesto", obj.AplicaImpuesto);
                comando.Parameters.AddWithValue("@Impuesto", obj.Impuesto);
                comando.Parameters.AddWithValue("@Stock", obj.Stock);
                comando.Parameters.AddWithValue("@Costo", obj.Costo);
                comando.Parameters.AddWithValue("@Precio", obj.Precio);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 140).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Mensaje;
        }



        public string Actualizar(cdproductos obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("productoscrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 2);
                comando.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
                comando.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                comando.Parameters.AddWithValue("@CodProducto", obj.CodProducto);
                comando.Parameters.AddWithValue("@Producto", obj.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", obj.Descripcion);

                if (Imagen == null)
                {
                    comando.Parameters.AddWithValue("@Imagen", obj.Imagen);
                }
                else
                {

                    comando.Parameters.AddWithValue("@Imagen", obj.Imagen);
                }


                comando.Parameters.AddWithValue("@Ubicacion", obj.Ubicacion);
                comando.Parameters.AddWithValue("@IdSeccion", obj.IdSeccion);
                comando.Parameters.AddWithValue("@AplicaImpuesto", obj.AplicaImpuesto);
                comando.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria);
                comando.Parameters.AddWithValue("@Impuesto", obj.Impuesto);
                comando.Parameters.AddWithValue("@Stock", obj.Stock);
                comando.Parameters.AddWithValue("@Costo", obj.Costo);
                comando.Parameters.AddWithValue("@Precio", obj.Precio);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 140).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                Mensaje = comando.Parameters["@Mensaje"].Value.ToString();
            }

            catch (Exception ex)
            {
                Mensaje = ex.Message;
                Console.WriteLine(Mensaje);
            }
            return Mensaje;
        }



        public string Eliminar(cdproductos obj, out string Mensaje)
        {
            Mensaje = "";
            try
            {
                SqlCommand comando = new SqlCommand("productoscrud", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Valor", 3);
                comando.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
                comando.Parameters.AddWithValue("@IdUsuario", DBNull.Value);
                comando.Parameters.AddWithValue("@CodProducto", DBNull.Value);
                comando.Parameters.AddWithValue("@Producto", DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion", DBNull.Value);
                comando.Parameters.AddWithValue("@Imagen", obj.Imagen);
                comando.Parameters.AddWithValue("@Ubicacion", DBNull.Value);
                comando.Parameters.AddWithValue("@IdSeccion", DBNull.Value);
                comando.Parameters.AddWithValue("@AplicaImpuesto", DBNull.Value);
                comando.Parameters.AddWithValue("@IdCategoria", DBNull.Value);
                comando.Parameters.AddWithValue("@Impuesto", DBNull.Value);
                comando.Parameters.AddWithValue("@Stock", DBNull.Value);
                comando.Parameters.AddWithValue("@Costo", DBNull.Value);
                comando.Parameters.AddWithValue("@Precio", DBNull.Value);
                comando.Parameters.AddWithValue("@FechaVencimiento", DBNull.Value);
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 140).Direction = ParameterDirection.Output;
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
                SqlCommand comando = new SqlCommand("productosbusqueda", oconexion.AbrirConexion());
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



        public DataTable Inventario(string pBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("inventarioproductos", oconexion.AbrirConexion());
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




        public DataTable ProductosMasVendidos()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                string query = @"
SELECT 
    p.Producto AS Producto, 
    SUM(cd.Cantidad) AS Cantidad
FROM ventasdetalles cd
INNER JOIN productos p ON cd.IdProducto = p.IdProducto
WHERE p.Estado = 'Disponible' 
  AND cd.Estado = 'Disponible'
GROUP BY p.Producto
ORDER BY Cantidad DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

                SqlCommand comando = new SqlCommand(query, oconexion.AbrirConexion());
                comando.CommandType = CommandType.Text;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }





        public DataTable ProductosAlertaStock()
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("productosalertastock", oconexion.AbrirConexion());
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





        public DataTable ProductoPorId(int pIdProducto)
        {
            DataTable tabla = new DataTable();
            SqlDataReader leer;
            try
            {
                SqlCommand comando = new SqlCommand("productosporid", oconexion.AbrirConexion());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdProducto", pIdProducto);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tabla;
        }




    }
}
