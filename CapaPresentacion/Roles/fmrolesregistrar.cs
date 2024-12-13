using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Roles
{
    public partial class fmrolesregistrar : Form
    {
        private bool ExpandirModuloUsuario = false;
        public fmrolesregistrar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!ExpandirModuloUsuario)
            {
                ModuloUsuario.Height += 40;
                if (ModuloUsuario.Height>= 129)
                {
                    ExpandirModuloUsuario=true;;
                    timer1.Stop();
                }
            }
            else
            {
                ModuloUsuario.Height -= 40;
                if (ModuloUsuario.Height <= 39)
                {
                    ExpandirModuloUsuario = false;
                    timer1.Stop();
                }
            }
        }

        private void ModuloUsuario_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
