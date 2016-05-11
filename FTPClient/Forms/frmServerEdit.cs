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
        public frmServerEdit()
        {
            InitializeComponent();
        }


        private class EventHandle : AsyncEvent
        {
            public void OnConnect(IAsyncResult ar)
            {
                var client = ar.AsyncState as TcpClient;
                try
                {
                    if (!client.Connected)
                    {
                        MessageBox.Show("连接服务器失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    client.EndConnect(ar);
                }
                catch (Exception e)
                {
                    MessageBox.Show("连接服务器失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void OnSend(IAsyncResult ar)
            {
                throw new NotImplementedException();
            }

            public void OnRecv(IAsyncResult ar)
            {
                throw new NotImplementedException();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string addr = txtServerAddr.Text;
                int port = int.Parse(domPort.Text);
                string user = txtUserName.Text;
                string pass = txtPass.Text;
                if (addr != string.Empty)
                {
                    if (checkAnnoymous.Checked)
                    {
                        TCPNetwork client = new TCPNetwork();
                        client.SetAddress(addr, port).SetEventHandler(new EventHandle()).Connect().Sync().Recv();
                    }
                    else
                    {
                        if (user != string.Empty && pass != string.Empty)
                        {
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
