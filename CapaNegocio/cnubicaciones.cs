using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnubicaciones
    {
        public DataTable Busqueda(string pBusqueda)
        {
            cdubicaciones obj = new cdubicaciones();
            return obj.Busqueda(pBusqueda);
        }

        public DataTable UbicacionPorId(int pIdUbicacion)
        {
            cdubicaciones obj = new cdubicaciones();
            return obj.UbicacionPorId(pIdUbicacion);
        }

        public string Insertar (int dIdUsuario, string dNombre, string dDescripcion, out string mensaje)
        {
            cdubicaciones obj = new cdubicaciones();
            obj.IdUsuario = dIdUsuario;
            obj.Ubicacion = dNombre;
            obj.Descripcion = dDescripcion;
            return obj.Insertar(obj, out mensaje);
        }


        public string Actualizar(int dIdUbicacion, string dNombre, string dDescripcion, out string mensaje)
        {
            cdubicaciones obj = new cdubicaciones();
            obj.IdUbicacion = dIdUbicacion;
            obj.Ubicacion = dNombre;
            obj.Descripcion = dDescripcion;
            return obj.Actualizar(obj, out mensaje);
        }


        public string Eliminar(int dIdUbicacion, out string mensaje)
        {
            cdubicaciones obj = new cdubicaciones();
            obj.IdUbicacion = dIdUbicacion;
            return obj.Eliminar(obj, out mensaje);
        }




    }
}
