using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class cncategorias
    {

        public DataTable Busqueda(string pBusqueda)
        {
            cdcategorias ObjCategorias = new cdcategorias();
            return ObjCategorias.Busqueda(pBusqueda);
        }

        public DataTable categoriasporId(int pIdCategoria)
        {
            cdcategorias ObjCategorias = new cdcategorias();
            ObjCategorias.IdCategoria = pIdCategoria;
            return ObjCategorias.categoriasporId(ObjCategorias);
        }
        public string Insertar(int pIdUsuario,string pCategoria, string pDescripcion, out string Mensaje)
        {
            cdcategorias ObjCategorias = new cdcategorias();
            ObjCategorias.IdUsuario = pIdUsuario;
            ObjCategorias.Categoria = pCategoria;
            ObjCategorias.Descripcion = pDescripcion;
            return ObjCategorias.Insertar(ObjCategorias, out Mensaje);
        }

        public string Actualizar(int pIdUsuario, int pIdCategoria,string pCategoria, string pDescripcion, out string Mensaje)
        {
            cdcategorias ObjCategorias = new cdcategorias();
            ObjCategorias.IdUsuario = pIdUsuario;
            ObjCategorias.IdCategoria = pIdCategoria;
            ObjCategorias.Categoria = pCategoria;
            ObjCategorias.Descripcion = pDescripcion;
            return ObjCategorias.Actualizar(ObjCategorias, out Mensaje);
        }

        public string Eliminar(int pIdCategoria, out string Mensaje)
        {
            cdcategorias ObjCategorias = new cdcategorias();
            ObjCategorias.IdCategoria = pIdCategoria;
            return ObjCategorias.Eliminar(ObjCategorias, out Mensaje);
        }

    }
}
