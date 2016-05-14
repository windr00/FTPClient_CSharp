using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class LoginAgent : CommonAgent, IAsyncEvent
    {

        private string host;
        private int port;
        private string user;
        private string pass;

        public bool isLogin { get; private set; } = false;
        

       
        public LoginAgent(string host, int port, string user, string pass, ref TCPNetwork network, Done onDone) : base(ref network, onDone)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
        }
        public void OnConnect(bool Connected)
        {
            if (!Connected)
            {
                onDone(Statics.CMD_TYPE.LOGIN, false, "Error connecting server");
            }
        }

        public void OnSend()
        {
            if (!isLogin)
            {
                client.Recv();
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
                onDone(Statics.CMD_TYPE.LOGIN, true, str);
            }
            else if (str.StartsWith(Statics.LOGIN_FAILED))
            {
                onDone(Statics.CMD_TYPE.LOGIN, false, str);
            }
            else
            {
                onDone(Statics.CMD_TYPE.LOGIN, false, "Server state unknown");
                return;  
            }
            
        }

        public override void Start(string[] args)
        {
            client.SetEventHandler(this);
            if (!client.Connected)
            {
                client.Connect().Sync();
            }
            client.Recv();
        }

        private void SendUser()
        {
            client.Send(Encoding.UTF8.GetBytes(Statics.USER_CMD + user + "\n"));
        }

        private void SendPass()
        {
            client.Send(Encoding.UTF8.GetBytes(Statics.PASS_CMD + pass + "\n"));
        }
    }
}
