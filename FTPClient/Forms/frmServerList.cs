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
            serverList.Add(new ServerProfile("192.168.1.101", 1026, "ran", "ran"));
            RefreshList();
        }

        private void RefreshList()
        {
            listServer.Items.Clear();
            foreach (var i in serverList)
            {
                listServer.Items.Add(i);
            }
        }

        private void OnServerAdded(string host, int port, string user, string pass)
        {
            if (port != 0)
            {
                var server = new ServerProfile(host, port, user, pass);
                serverList.Add(server);
                RefreshList();
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
                serverList.RemoveAt(selectedServer);
                RefreshList();
            }

        }

        private void listServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedServer = listServer.SelectedIndex;
        }

        private void OnServerEdited(string host, int port, string user, string pass)
        {
            if (port != 0)
            {
                var server = new ServerProfile(host, port, user, pass);
                serverList[selectedServer] = server;
                RefreshList();
            }
            this.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedServer != -1)
            {
                var server = serverList[selectedServer];
                frmServerEdit editor = new frmServerEdit(OnServerEdited, server.host, server.port, server.user, server.pass);
                this.Enabled = false;
                editor.Show();
                
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (selectedServer != -1)
            {
                var server = serverList[selectedServer];
                frmMain main = new frmMain(server.host, server.port, server.user, server.pass);
                main.Show();
            }
        }

        private void listServer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnConnect_Click(null, null);
        }

    }
}
