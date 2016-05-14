using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class LISTAgent : CommonAgent, IAsyncEvent
    {
        public LISTAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {}

        public override void Start(string[] args)
        {
            throw new NotImplementedException();
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
