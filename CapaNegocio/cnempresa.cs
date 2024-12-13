using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnempresa
    {



        public DataTable Busqueda(string pbusqueda)
        {
            cdempresa obj = new cdempresa();
           return obj.Busqueda(pbusqueda);
        }

        public DataTable empresaporId(int pIdEmpresa)
        {
            cdempresa obj = new cdempresa();
            obj.IdEmpresa = pIdEmpresa;
            return obj.EmpresaproId(obj);
        }


        public string Insertar(int dIdUsuario,string dNombre, string dDireccion, string dRnc, string dTelefono, out string Mensaje)
        {
            cdempresa obj = new cdempresa();
            obj.IdUsuario = dIdUsuario;
            obj.Nombre = dNombre;
            obj.Direccion = dDireccion;
            obj.RNC = dRnc;
            obj.Telefono = dTelefono;
            return obj.Insertar(obj, out Mensaje);

        }



        public string Actualizar(int dIdEmpresa,int dIdUsuario, string dNombre, string dDireccion, string dRnc, string dTelefono, out string Mensaje)
        {
            cdempresa obj = new cdempresa();
            obj.IdEmpresa = dIdEmpresa;
            obj.IdUsuario = dIdUsuario;
            obj.Nombre = dNombre;
            obj.Direccion = dDireccion;
            obj.RNC = dRnc;
            obj.Telefono = dTelefono;
            return obj.Actualizar(obj, out Mensaje);

        }


        public string Eliminar(int dIdEmpresa, out string Mensaje)
        {
            cdempresa obj = new cdempresa();
            obj.IdEmpresa = dIdEmpresa;
            return obj.Eliminar(obj, out Mensaje);

        }

    }
}
