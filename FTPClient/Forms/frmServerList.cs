using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class frmServerList : Form
    {
        public frmServerList()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmServerEdit edit = new frmServerEdit();
            this.Enabled = false;
            this.Hide();
            edit.Show();
        }
    }
}
