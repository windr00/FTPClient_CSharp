using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class frmServerEdit : Form
    {
        public delegate void OnServerAdded(string host, int port, string user, string pass);

        private event OnServerAdded OnAdd;

        public frmServerEdit(OnServerAdded handle)
        {
            InitializeComponent();
            OnAdd += handle;
        }

        public frmServerEdit(OnServerAdded handle, string host, int port, string user, string pass)
        {
            InitializeComponent();
            txtServerAddr.Text = host;
            txtUserName.Text = user;
            txtPass.Text = pass;
            numPort.Value = port;
            OnAdd += handle;
        }


        private class EventHandle : IAsyncEvent
        {
            public void OnConnect(bool Connected)
            {
                if (!Connected)
                {
                    MessageBox.Show("连接服务器失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void OnSend()
            {
                throw new NotImplementedException();
            }

            public void OnRecv(byte[] recv)
            {


                if (Encoding.UTF8.GetString(recv).StartsWith("220"))
                {
                    MessageBox.Show("连接成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("服务器通讯断开或不支持FTP服务", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string addr = txtServerAddr.Text;
                int port = (int)numPort.Value;
                string user = txtUserName.Text;
                string pass = txtPass.Text;
                if (addr != string.Empty)
                {
                    TCPNetwork client = new TCPNetwork();
                    client.SetAddress(addr, port)
                        .SetEventHandler(new EventHandle())
                        .Connect()
                        .Sync()
                        .Recv();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkAnnoymous_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = !checkAnnoymous.Checked;
            txtPass.Enabled = !checkAnnoymous.Checked;
            txtUserName.Text = "anonymous";
            txtPass.Text = "test";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string host = txtServerAddr.Text;
            int port = (int)numPort.Value;
            string user = txtUserName.Text;
            string pass = txtPass.Text;
            if (host != string.Empty)
            {
                OnAdd(host, port, user, pass);
                this.Close();
            }
            else
            {
                MessageBox.Show("连接信息不完整", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmServerEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnAdd(string.Empty, 0, string.Empty, string.Empty);
        }

    }
}
