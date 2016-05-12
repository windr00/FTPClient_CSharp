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



        private void OnServerAdded(string host, int port, string user, string pass)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmServerEdit edit = new frmServerEdit(OnServerAdded);
            this.Enabled = false;
            edit.Show();
        }
    }
}
