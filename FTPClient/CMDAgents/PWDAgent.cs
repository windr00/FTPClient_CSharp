using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class PWDAgent : CommonAgent, IAsyncEvent
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
            try
            {
                var str = Encoding.UTF8.GetString(buffer);
                if (str.StartsWith(Statics.PWD_SUCC))
                {
                    var where = str.Substring(str.IndexOf("\"") + 1, str.LastIndexOf("\"") - str.IndexOf("\"") - 1);
                    onDone(Statics.CMD_TYPE.PWD, true, where);
                }
                else
                {
                    onDone(Statics.CMD_TYPE.PWD, false, str);
                }
            }
            catch (Exception e)
            {
                onDone(Statics.CMD_TYPE.PWD, false, "Unknown Server Status");
            }
        }

        public override void Start(string[] args)
        {
            var str = Encoding.UTF8.GetBytes(Statics.PWD_CMD);
            client.SetEventHandler(this).Send(str);
        }

        public PWDAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {}
    }
}
