using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnsecciones
    {
        public DataTable Busqueda(string pBusqueda)
        {
            cdsecciones obj = new cdsecciones();
            return obj.Busqueda(pBusqueda);
        }

        public DataTable SeccionPorId(int pIdSeccion)
        {
            cdsecciones obj = new cdsecciones();
            return obj.SeccionPorId(pIdSeccion);
        }


        public string Insertar(int pIdUsuario, string pSeccion, string pDescripcion, out string Mensaje)
        {
            cdsecciones obj = new cdsecciones();
            obj.IdUsuario = pIdUsuario;
            obj.Seccion = pSeccion;
            obj.Descripcion = pDescripcion;
            return obj.Insertar(obj, out Mensaje);
        }

        public string Actualizar(int pIdSeccion, string pSeccion, string pDescripcion, out string Mensaje)
        {
            cdsecciones obj = new cdsecciones();
            obj.IdSeccion = pIdSeccion;
            obj.Seccion = pSeccion;
            obj.Descripcion = pDescripcion;
            return obj.Actualizar(obj, out Mensaje);
        }


        public string Eliminar(int dIdSeccion, out string Mensaje)
        {
            cdsecciones obj = new cdsecciones();
            obj.IdSeccion = dIdSeccion;
            return obj.Eliminar(obj, out Mensaje);
        }


    }
}
