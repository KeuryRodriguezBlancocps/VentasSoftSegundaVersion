using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnroles
    {

        public DataTable Busqueda(string pBusqueda)
        {
            cdroles ObjRoles = new cdroles();
            return ObjRoles.Busqueda(pBusqueda);

        }

        public string Insertar(string pRol,string pDescripcion, out string Mensaje)
        {
            cdroles ObjRoles = new cdroles();
            ObjRoles.Rol = pRol;
            ObjRoles.Descripcion = pDescripcion;
            return ObjRoles.Insertar(ObjRoles, out Mensaje);
        }


        public string Actualizar(int pIdRol,string pRol, string pDescripcion, out string Mensaje)
        {
            cdroles ObjRoles = new cdroles();
            ObjRoles.IdRol = pIdRol;
            ObjRoles.Rol = pRol;
            ObjRoles.Descripcion = pDescripcion;
            return ObjRoles.Insertar(ObjRoles, out Mensaje);
        }

        public string Actualizar(int pIdRol, out string Mensaje)
        {
            cdroles ObjRoles = new cdroles();
            ObjRoles.IdRol = pIdRol;
            return ObjRoles.Eliminar(ObjRoles, out Mensaje);
        }


    }
}
