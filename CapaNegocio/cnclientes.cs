using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class cnclientes
    {

        public DataTable Busqueda (string pBusqueda)
        {
            cdcliente ObjClientes = new cdcliente();
            return ObjClientes.Busqueda(pBusqueda);
        }

        public DataTable clientesPorId(int pIdCliente)
        {
            cdcliente ObjClientes = new cdcliente();
            ObjClientes.IdCliente = pIdCliente;
            return ObjClientes.ClientesPorId();
        }

        public string Insertar(int pIdUsuario,string pNombre, string pTelefono, string pDireccion, out string Mensaje)
        {
            cdcliente ObjClientes = new cdcliente();
            ObjClientes.IdUsuario = pIdUsuario;
            ObjClientes.Cliente = pNombre;
            ObjClientes.Telefono = pTelefono;
            ObjClientes.Direccion = pDireccion;
            return ObjClientes.Insertar(ObjClientes, out Mensaje);
        }

        public string Actualizar(int pIdUsuario,int pIdCliente,string pNombre, string pTelefono, string pDireccion, out string Mensaje)
        {
            cdcliente ObjClientes = new cdcliente();
            ObjClientes.IdUsuario = pIdUsuario;
            ObjClientes.IdCliente = pIdCliente;
            ObjClientes.Cliente = pNombre;
            ObjClientes.Telefono = pTelefono;
            ObjClientes.Direccion = pDireccion;
            return ObjClientes.Actualizar(ObjClientes, out Mensaje);
        }


        public string Eliminar(int pIdCliente, out string Mensaje)
        {
            cdcliente ObjClientes = new cdcliente();
            ObjClientes.IdCliente = pIdCliente;
            return ObjClientes.Eliminar(ObjClientes, out Mensaje);
        }

    }
}
