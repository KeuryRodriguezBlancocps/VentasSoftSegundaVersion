using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;
using static System.Net.Mime.MediaTypeNames;
namespace CapaNegocio
{
    public class cnusuarios
    {



        public bool ValidarSession(string pUsuario, string pPassword,out  bool Encontrado, out int IdRol,out string Rol,out int IdUsuario,out string Mensaje)
        {
             
            cdusuario obj = new cdusuario();
            return obj.ValidarUsuario(pUsuario, pPassword,out Encontrado, out IdRol,out Rol,out IdUsuario,out Mensaje);
        }



        public DataTable Busqueda(string pBusqueda)
        {
            cdusuario obj = new cdusuario();
            return obj.Busqueda(pBusqueda);
        }

        public string Insertar(string pNombre, string pApellidos,int pIdRol, string pUsuario, string pPassword, out string Mensaje)
        {
            cdusuario ObjUsuario = new cdusuario();
            ObjUsuario.Nombre = pNombre;
            ObjUsuario.Apellidos = pApellidos;
            ObjUsuario.IdRol = pIdRol;
            ObjUsuario.Usuario = pUsuario;
            ObjUsuario.Password = pPassword;
            return ObjUsuario.Insertar(ObjUsuario, out Mensaje);

        }

        public string Actualizar(int pIdUsuario,string pNombre, string pApellidos, int pIdRol, string pUsuario, string pPassword, out string Mensaje)
        {
            cdusuario ObjUsuario = new cdusuario();
            ObjUsuario.IdUsuario = pIdUsuario;
            ObjUsuario.Nombre = pNombre;
            ObjUsuario.Apellidos = pApellidos;
            ObjUsuario.IdRol = pIdRol;
            ObjUsuario.Usuario = pUsuario;
            ObjUsuario.Password = pPassword;
            return ObjUsuario.Actualizar(ObjUsuario, out Mensaje);

        }

        public string Eliminar(int pIdUsuario, out string Mensaje)
        {
            cdusuario ObjUsuario = new cdusuario();
            ObjUsuario.IdUsuario = pIdUsuario;
            return ObjUsuario.Eliminar(ObjUsuario, out Mensaje);

        }

        public DataTable usuariosporId(int pIdUsuario)
        {
            cdusuario obj = new cdusuario();
            return obj.UsuarioporID(pIdUsuario);
        }


    }
}
