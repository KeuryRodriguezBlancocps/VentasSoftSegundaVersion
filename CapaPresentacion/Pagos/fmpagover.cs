using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pagos
{
    public partial class fmpagover : Form
    {
        private int dIdVenta;
        private int dIdCompra;
        public fmpagover(int pIdVenta, int dIdCompra)
        {
            InitializeComponent();
            Load += Fmpagover_Load;
            dIdVenta = pIdVenta;
            this.dIdCompra = dIdCompra;
        }

        private void Fmpagover_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            PagosPorIdVenta();
        }


        private void PagosPorIdVenta()
        {
            try
            {
                if (dIdVenta !=0)
                {

                cnpagos obj = new cnpagos();
                DataTable tabla = new DataTable();
                tabla = obj.pagosporId(dIdVenta);
                if (tabla != null)
                {

                    guna2DataGridView1.DataSource = tabla;

                }

                }
                else
                {
                    cnpagos obj = new cnpagos();
                    DataTable tabla = new DataTable();
                    tabla = obj.pagosporIdCompra(dIdCompra);
                    if (tabla != null)
                    {

                        guna2DataGridView1.DataSource = tabla;

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }





    }
}
