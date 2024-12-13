using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class fmimprimirReporte : Form
    {
        public fmimprimirReporte()
        {
            InitializeComponent();
            this.Load += FmimprimirReporte_Load;
        }

        private void FmimprimirReporte_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            foreach (string Printer in PrinterSettings.InstalledPrinters)
            {
                ListViewItem Item = listView1.Items.Add(Printer);
                Item.ImageIndex = 0;
            }

            // Obtener la impresora predeterminada
            string impresoraPredeterminada = new PrinterSettings().PrinterName;

            // Seleccionar la impresora predeterminada en el ListView
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == impresoraPredeterminada)
                {
                    item.Selected = true;
                    break; // Salir del bucle una vez que se haya encontrado la impresora predeterminada
                }
            }
        }

        public static fmimprimirReporte Cargar(string nombrereport)
        {
            // Define la ruta del archivo de reporte
            string archivo = @"..\Reportes\" + nombrereport + ".frx";

            // Verifica si el archivo existe
            if (!File.Exists(archivo))
            {
                _ = MessageBox.Show("El Reporte " + nombrereport + " no existe", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            // Crea una nueva instancia del formulario
            fmimprimirReporte imprimir = new fmimprimirReporte();
            imprimir.txtReporte.Text = nombrereport;
            imprimir.report1.Load(archivo);


            return imprimir;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            bool dialog = cbOpciones.Checked;
            string Impresora = listView1.SelectedItems[0].Text;

            report1.PrintSettings.Printer = Impresora;
            report1.PrintSettings.ShowDialog = dialog;
            report1.Print();
            Close();
        }

        private void btnPrevisualizar_Click(object sender, EventArgs e)
        {
            try
            {

                report1.Show();
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
