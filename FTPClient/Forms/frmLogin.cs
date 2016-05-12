using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient.Forms
{
    public partial class frmLogin : Form
    {
        private string user;
        private string pass;
        public frmLogin(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            InitializeComponent();
            txtUser.Text = user;
            txtPass.Text = pass;
        }
    }
}
