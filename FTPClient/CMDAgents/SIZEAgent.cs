using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class SIZEAgent : CommonAgent, IAsyncEvent
    {
        public SIZEAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {
        }

        public override void Start(object[] args)
        {
            client.SetEventHandler(this).Send(Encoding.UTF8.GetBytes(Statics.SIZE_CMD + args[0] + "\n"));
            
        }

        public void OnConnect(bool ConnectState)
        {
            throw new NotImplementedException();
        }

        public void OnSend()
        {
            client.Recv();

        }

        public void OnRecv(byte[] buffer)
        {
            string res = Encoding.UTF8.GetString(buffer);
            if (res.StartsWith(Statics.SIZE_SUCC))
            {
                onDone(Statics.CMD_TYPE.SIZE, true, res.Split(' ')[1]);
            }
            else
            {
                onDone(Statics.CMD_TYPE.SIZE, false, res);
            }
        }

    }
    
}
