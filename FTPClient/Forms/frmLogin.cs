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

        public delegate void FormClose(string user, string pass);

        public event FormClose OnClose;
        public frmLogin(string user, string pass, FormClose c)
        {
            this.user = user;
            this.pass = pass;
            InitializeComponent();
            txtUser.Text = user;
            txtPass.Text = pass;
            if (user.Equals("anonymous"))
            {
                checkAnonymous.Checked = true;
            }
            OnClose += c;
        }

        private void checkAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = !checkAnonymous.Checked;
            txtPass.Enabled = !checkAnonymous.Checked;
            txtUser.Text = "anonymous";
            txtPass.Text = "test";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != string.Empty && txtPass.Text != string.Empty)
            {
                OnClose(txtUser.Text, txtPass.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入完整登录信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnClose(user, pass);
            this.Close();
        }


    }
}
