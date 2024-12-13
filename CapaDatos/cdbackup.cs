using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SQLBackup;
using System.IO;
namespace CapaDatos
{
    public class cdbackup
    {

        public string GenerarBackup(string nombre)
        {
            cdconexion obj = new cdconexion();

            try
            {
                string rutaBackup = Path.Combine(@"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\", nombre);

                SqlCommand comando = new SqlCommand($@"BACKUP DATABASE [VentasSoftKasandra] TO DISK = N'{rutaBackup}' WITH NOFORMAT, NOINIT, NAME = N'VentasSoftKasandra-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD, STATS = 10", obj.AbrirConexion());
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return "Error al generar la copia de seguridad: " + ex.Message;
            }
        }



    }
}
