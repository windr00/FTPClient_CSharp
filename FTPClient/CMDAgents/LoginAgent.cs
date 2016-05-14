using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class LoginAgent : IAsyncEvent
    {

        private string host;
        private int port;
        private string user;
        private string pass;
        private bool _login = false;

        public bool isLogin
        {
            get
            {
                return _login;
            }
            private set { _login = value; }
        }

        private TCPNetwork network;

        public delegate void Done(Statics.CMD_TYPE type, bool state, string content);

        public event Done OnDone;

        public LoginAgent(string host, int port, string user, string pass, ref TCPNetwork network)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            this.network = network;
            network.SetEventHandler(this);
            if (!network.Connected)
            {
                network.Connect().Sync();
            }
            network.Recv();
        }
        public void OnConnect(bool Connected)
        {
            if (!Connected)
            {
                OnDone(Statics.CMD_TYPE.LOGIN, false, "Error connecting server");
            }
        }

        public void OnSend()
        {
            if (!isLogin)
            {
                network.Recv();
            }
        }



        public void OnRecv(byte[] buff)
        {
            string str = Encoding.UTF8.GetString(buff);
            if (str.StartsWith(Statics.CONNECT_SUCC))
            {
                SendUser();
            }
            else if (str.StartsWith(Statics.USER_SUCC))
            {
                SendPass();
            }
            else if (str.StartsWith(Statics.PASS_SUCC))
            {
                isLogin = true;
                OnDone(Statics.CMD_TYPE.LOGIN, true, str);
            }
            else if (str.StartsWith(Statics.LOGIN_FAILED))
            {
                OnDone(Statics.CMD_TYPE.LOGIN, false, str);
            }
            else
            {
                OnDone(Statics.CMD_TYPE.LOGIN, false, "Server state unknown");
                return;  
            }
            
        }

        private void SendUser()
        {
            network.Send(Encoding.UTF8.GetBytes(Statics.USER_CMD + user + "\n"));
        }

        private void SendPass()
        {
            network.Send(Encoding.UTF8.GetBytes(Statics.PASS_CMD + pass + "\n"));
        }
    }
}
