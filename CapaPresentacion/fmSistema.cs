using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Usuarios;
using CapaPresentacion.Roles;
using CapaPresentacion.Clientes;
using CapaPresentacion.Suplidores;
using CapaPresentacion.Laboratorios;
using CapaPresentacion.Productos;
using CapaPresentacion.Categorias;
using CapaPresentacion.Ubicaciones;
using CapaPresentacion.Secciones;
using CapaPresentacion.Compras;
using CapaPresentacion.Ventas;
using CapaPresentacion.Inventario;
using CapaPresentacion.Ventas.Consultas;
using CapaPresentacion.Compras.consultas;
using CapaPresentacion.Reportes;
using CapaNegocio;
using SQLBackup;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;
namespace CapaPresentacion
{
    public partial class fmSistema : Form
    {
        private int dIdUsuario;
        private bool ExpandirMenu = false;
        public fmSistema(int dIdUsuario)
        {
            InitializeComponent();
            this.dIdUsuario = dIdUsuario;
            Load += FmSistema_Load;
            saveFileDialog1.Title = "Guardar copia de seguridad"; 
            saveFileDialog1.Filter = "Archivos de respaldo (*.back)|*.back|Todos los archivos (*.*)|*.*";
            saveFileDialog1.FileName = "VentasSoft.back";
        }

        private void FmSistema_Load(object sender, EventArgs e)
        {
            ObtenerUsuario();
        }

        public void AbrirFormulario(Form formHijo)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.Clear();
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();

        }


        private void fmSistema_Load(object sender, EventArgs e)
        {
            menuStrip1.Cursor = Cursors.Hand;
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmusuariosBusqueda(this));
        }

        private void gestiónDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmrolesregistrar());
        }

        private void gestiónDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmclientesbusqueda(dIdUsuario, this));
        }

        private void gestiónDeSuplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmsuplidorbusqueda(dIdUsuario, this));
        }

        private void gestiónDeLaboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmlaboratoriosbusqueda(dIdUsuario, this));
        }

        private void gestiónDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmproductosbusqueda(dIdUsuario, this));
        }

        private void gestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmcategoriasbusqueda(dIdUsuario, this));
        }

        private void gestiónDeUbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmubicacionesbusqueda(dIdUsuario, this));
        }

        private void gestiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmseccionesbusqueda(dIdUsuario, this));
        }

        private void gestiónDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmcomprasbusqueda(dIdUsuario, this));
        }

        private void gestiónDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmventasbusqueda(dIdUsuario, this));
        }

        private void stockDeLosProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fminventario(this));
        }

        private void ventasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmventasporfechas(this, dIdUsuario));
        }

        private void comprasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new fmcomprasporfechas(this, dIdUsuario));
        }

        private void ventasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                fmimprimirReporte imprimir = fmimprimirReporte.Cargar("VentasCuadreDelDia");

                bool showdialog = true;

                if (showdialog)
                {
                    imprimir.ShowDialog();
                }
                else
                {
                    imprimir.report1.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cuadreDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                fmimprimirReporte imprimir = fmimprimirReporte.Cargar("CompraCuadreDelDia");


                bool showdialog = true;

                if (showdialog)
                {
                    imprimir.ShowDialog();
                }
                else
                {
                    imprimir.report1.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new reportesinformaciongeneral());
        }


        private void ObtenerUsuario()
        {
            try
            {
                cnusuarios obj = new cnusuarios();
                DataTable tabla = new DataTable();
                tabla = obj.usuariosporId(dIdUsuario);
                if (tabla!=null)
                {
                    txtusuario.Text = Convert.ToString(tabla.Rows[0]["Usuario"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Close();

        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string rutaBackup = saveFileDialog1.FileName;

                    // Generar un nombre único para el archivo de respaldo
                    string nombreCopia = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + "-VentasSoft.back";
                    rutaBackup = Path.Combine(Path.GetDirectoryName(rutaBackup), nombreCopia);

                    // Crear el archivo de respaldo y escribir en él
                    cnGenerarBackup obj = new cnGenerarBackup();
                    string resultado = obj.GenerarBackup(rutaBackup);

                    MessageBox.Show($"Copia de seguridad generada en la siguiente ubicación {rutaBackup}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Para hacer otra copia, cierre el formulario y vuelva a intentarlo. Error: " + ex.Message);
            }
        }


    }
}
