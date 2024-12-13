using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
   public class cntipocomprobante
    {

        public string GenerarCodigoFactura(string campo)
        {
            cdtipocomprobante obj = new cdtipocomprobante();
            return obj.GenerarCodigoFactura(campo);
        }

        public DataTable MostarTipoComprobante()
        {
            cdtipocomprobante obj = new cdtipocomprobante();
            return obj.Mostrar();
        }

        public DataTable MostarTipoComprobantePorId(int dIdTipoComprobante)
        {
            cdtipocomprobante obj = new cdtipocomprobante();
            return obj.MostrarTipoComprobantePorId(dIdTipoComprobante);
        }


    }
}
