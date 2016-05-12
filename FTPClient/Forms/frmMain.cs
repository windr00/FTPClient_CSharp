using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTPClient.Forms;

namespace FTPClient
{
    public partial class frmMain : Form
    {
        private string host;
        private int port;
        private string user;
        private string pass;
        private CMDAgent agent;


        public frmMain(string host, int port, string user, string pass)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            InitializeComponent();
            this.Text = user + "@" + host + ":" + port;

        }



        public void OnfrmLoginClose(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            this.Enabled = true;
            frmMain_Load(null, null);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!(user != string.Empty && pass != string.Empty))
            {
                frmLogin login = new frmLogin(user, pass, OnfrmLoginClose);
                this.Enabled = false;
                login.Show();
            }
            agent = new CMDAgent(host, port, user, pass);
            agent.Login();
        }


    }
}
