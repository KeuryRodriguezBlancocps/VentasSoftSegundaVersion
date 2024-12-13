using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnsuplidores
    {

        public DataTable Busqueda(string pBusqueda)
        {
            cdsuplidores ObjSuplidores = new cdsuplidores();
            return ObjSuplidores.Busqueda(pBusqueda);
        }


        public DataTable suplidoresporId(int pIdSuplidor)
        {
            cdsuplidores ObjSuplidores = new cdsuplidores();
            ObjSuplidores.IdSuplidor = pIdSuplidor;
            return ObjSuplidores.suplidoresporId(ObjSuplidores);
        }

        public string Insertar(int pIdUsuario,string pNombre,string pDireccion, string pTelefono, string pManejaComprobantes,out string Mensaje)
        {
            cdsuplidores ObjSuplidores = new cdsuplidores();
            ObjSuplidores.IdUsuario = pIdUsuario;
            ObjSuplidores.Nombre = pNombre;
            ObjSuplidores.Direccion = pDireccion;
            ObjSuplidores.Telefono = pTelefono;
            ObjSuplidores.ManejaComprobantes = pManejaComprobantes;
            return ObjSuplidores.Insertar(ObjSuplidores, out Mensaje);
        }


        public string Actualizar(int pIdSuplidor, string pNombre, string pDireccion, string pTelefono, string pManejaComprobantes,out string Mensaje)
        {
            cdsuplidores ObjSuplidores = new cdsuplidores();
            ObjSuplidores.IdSuplidor = pIdSuplidor;
            ObjSuplidores.Nombre = pNombre;
            ObjSuplidores.Direccion = pDireccion;
            ObjSuplidores.Telefono = pTelefono;
            ObjSuplidores.ManejaComprobantes = pManejaComprobantes;
            return ObjSuplidores.Actualizar(ObjSuplidores, out Mensaje);
        }

        public string Eliminar(int pIdSuplidor, out string Mensaje)
        {
            cdsuplidores ObjSuplidores = new cdsuplidores();
            ObjSuplidores.IdSuplidor = pIdSuplidor;
            return ObjSuplidores.Eliminar(ObjSuplidores, out Mensaje);
        }



    }
}
