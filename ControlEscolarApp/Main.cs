using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlEscolarApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers frmUser = new FrmUsers();
            frmUser.ShowDialog();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaAlu frmVistaAlu = new VistaAlu();
            frmVistaAlu.ShowDialog();
        }
    }
}
