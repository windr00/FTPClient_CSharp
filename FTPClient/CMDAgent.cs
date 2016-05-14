using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    class CMDAgent : IAsyncEvent
    {
        private string host;
        private int port;
        private string user;
        private string pass;
        private TCPNetwork client;

        public Encoding encoding = Encoding.UTF8;

        public Queue<string> cmdQueue = new Queue<string>();



        private void OnRequest(string req)
        {
            
        }

        private void OnResponse(string rsp)
        {
            Console.WriteLine(rsp);
            
        }

        public CMDAgent(string host, int port, string user, string pass)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            client = new TCPNetwork();
        }

        public void Login()
        {
            if (!client.Connected)
            {
                client.SetAddress(host, port).SetEventHandler(this).Connect();
            }
        }

        public void OnConnect(bool ConnectState)
        {
            throw new NotImplementedException();
        }

        public void OnSend()
        {
            throw new NotImplementedException();
        }

        public void OnRecv(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
