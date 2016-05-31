using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class CWDAgent : CommonAgent, IAsyncEvent
    {


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
            var str = Encoding.UTF8.GetString(buffer);
            if (str.StartsWith(Statics.CWD_SUCC))
            {
                onDone(Statics.CMD_TYPE.CWD, true, str);
            }
            else
            {
                onDone(Statics.CMD_TYPE.CWD, false, str);
            }
        }

        public override void Start(object[] args)
        {
            var to = args[0];
            string str = string.Empty;
            if (args[0].Equals(".."))
            {
                str = Statics.CDUP_CMD;
            }
            else
            {
                str = Statics.CWD_CMD + to + "\n";
            }
            client.SetEventHandler(this).Send(Encoding.UTF8.GetBytes(str));

        }

        public CWDAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {
        }
    }
}
