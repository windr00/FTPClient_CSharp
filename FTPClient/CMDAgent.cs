using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class CMDAgent
    {
        private string user;
        private string pass;

        public delegate void CMDRequest(string req);

        public event CMDRequest OnCMDRequest;

        private class NetworkHandler : AsyncEvent
        {
            public override void OnConnect(IAsyncResult ar)
            {
                base.OnConnect(ar);
            }

            public override void OnRecv(IAsyncResult ar)
            {
                base.OnRecv(ar);
            }

            public override void OnSend(IAsyncResult ar)
            {
                base.OnSend(ar);
            }
        }

        public void OnResponse(string rsp)
        {
            
        }

        public CMDAgent(string user, string pass, CMDRequest reqSender)
        {
            this.user = user;
            this.pass = pass;
            OnCMDRequest += reqSender;
        }
    }
}
