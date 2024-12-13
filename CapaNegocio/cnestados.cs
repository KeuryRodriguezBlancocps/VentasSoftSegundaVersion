using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnestados
    {

        public DataTable Busqueda(string pBusqueda)
        {
            cdestados ObjEstados = new cdestados();
           return ObjEstados.Busqueda(pBusqueda);
        }


        public string Insertar(int pIdUsuario, string pEstado, string pDescripcion, out string Mensaje)
        {
            cdestados ObjEstados = new cdestados();
            ObjEstados.IdUsuario = pIdUsuario;
            ObjEstados.Estado = pEstado;
            ObjEstados.Descripcion = pDescripcion;
            return ObjEstados.Insertar(ObjEstados, out Mensaje);
        }

        public string Actualizar(int pIdEstado, string pEstado, string pDescripcion, out string Mensaje)
        {
            cdestados ObjEstados = new cdestados();
            ObjEstados.IdEstado = pIdEstado;
            ObjEstados.Estado = pEstado;
            ObjEstados.Descripcion = pDescripcion;
            return ObjEstados.Actualizar(ObjEstados, out Mensaje);
        }

        public string Eliminar(int pIdEstado, out string Mensaje)
        {
            cdestados ObjEstados = new cdestados();
            ObjEstados.IdEstado = pIdEstado;
            return ObjEstados.Eliminar(ObjEstados, out Mensaje);
        }

    }
}
