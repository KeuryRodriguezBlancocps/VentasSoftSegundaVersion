using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class cnlaboratorios
    {
        public string Insertar(int pIdUsuario, string pNombre, string pTelefono, string pDireccion, string pEmail,out string Mensaje)
        {

            cdlaboratorios obj = new cdlaboratorios();
            obj.IdUsuario = pIdUsuario;
            obj.Nombre = pNombre;
            obj.Telefono = pTelefono;
            obj.Direccion = pDireccion;
            obj.Email = pEmail;
          return  obj.Insertar(obj, out Mensaje);
        
        }

        public string Actualizar(int pIdLaboratorio,int pIdUsuario, string pNombre, string pTelefono, string pDireccion, string pEmail, out string Mensaje)
        {

            cdlaboratorios obj = new cdlaboratorios();
            obj.IdLaboratorio = pIdLaboratorio;
            obj.IdUsuario = pIdUsuario;
            obj.Nombre = pNombre;
            obj.Telefono = pTelefono;
            obj.Direccion = pDireccion;
            obj.Email = pEmail;
            return obj.Actualizar(obj, out Mensaje);

        }

        public string Eliminar(int pIdLaboratorio,out string Mensaje)
        {

            cdlaboratorios obj = new cdlaboratorios();
            obj.IdLaboratorio = pIdLaboratorio;
            return obj.Eliminar(obj, out Mensaje);

        }


        public DataTable Busqueda (string busqueda)
        {
            cdlaboratorios obj = new cdlaboratorios();
            return obj.Busqueda(busqueda);
        }


        public DataTable LaboratorioPorId(int pidLaboratorio)
        {
            cdlaboratorios obj = new cdlaboratorios();
            return obj.LaboratorioPorId(pidLaboratorio);
        }




    }
}
