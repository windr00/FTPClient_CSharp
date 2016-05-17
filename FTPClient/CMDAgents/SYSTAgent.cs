using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class SYSTAgent : CommonAgent, IAsyncEvent
    {
        public SYSTAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {
        }

        public override void Start(string[] args) => client.SetEventHandler(this).Send(Encoding.UTF8.GetBytes(Statics.SYST_CMD));
        

        public void OnConnect(bool ConnectState)
        {
            throw new NotImplementedException();
        }

        public void OnSend() => client.Recv();

        public void OnRecv(byte[] buffer)
        {
            var str = Encoding.UTF8.GetString(buffer);
            if (str.StartsWith(Statics.SYST_SUCC))
            {
                onDone(Statics.CMD_TYPE.SYST, true, str);
            }
            else
            {
                onDone(Statics.CMD_TYPE.SYST, false, "Cannot require server OS type");
            }
        }
    }
}
