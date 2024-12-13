using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class cnGenerarBackup
    {

        public string GenerarBackup(string nombre)
        {
            cdbackup obj = new cdbackup();
            return obj.GenerarBackup(nombre);
        }

    }
}
