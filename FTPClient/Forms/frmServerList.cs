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
        private List<ServerProfile> serverList = new List<ServerProfile>();

        private int selectedServer = -1;

        public frmServerList()
        {
            InitializeComponent();
        }

        private void OnServerAdded(string host, int port, string user, string pass)
        {
            var server = new ServerProfile(host, port, user, pass);
            serverList.Add(server);
            listServer.Items.Clear();
            foreach (var i in serverList)
            {
                listServer.Items.Add(server);
            }
            this.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmServerEdit edit = new frmServerEdit(OnServerAdded);
            this.Enabled = false;
            edit.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectedServer != -1)
            {
                listServer.Items.RemoveAt(selectedServer);
                serverList.RemoveAt(selectedServer);
            }

        }

        private void listServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedServer = listServer.SelectedIndex;
        }

        private void OnServerEdited(string host, int port, string user, string pass)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmServerEdit editor = new frmServerEdit(OnServerEdited);
        }
    }
}
