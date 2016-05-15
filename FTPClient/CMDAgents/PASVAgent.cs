using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient.CMDAgents
{
    class PASVAgent : CommonAgent, IAsyncEvent
    {
        public PASVAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {
        }

        public override void Start(string[] args)
        {
            client.SetEventHandler(this).Send(Encoding.UTF8.GetBytes(Statics.PASV_CMD));
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
            var str = Encoding.UTF8.GetString(buffer);
            try
            {
                if (str.StartsWith(Statics.PASV_SUCC))
                {
                    var res = str.Substring(str.IndexOf("(") + 1, str.IndexOf(")") - str.IndexOf("(") - 1);
                    string[] parts = res.Split(',');
                    var host = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];
                    int port = 0;
                    if (parts.Length == 5)
                    {
                        port = int.Parse(parts[4]);
                    }
                    else if (parts.Length == 6)
                    {
                        port = int.Parse(parts[4])*256 + int.Parse(parts[5]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    onDone(Statics.CMD_TYPE.PASV, true, new object[] {host, port});
                }
                else
                {
                    onDone(Statics.CMD_TYPE.PASV, false, str);
                }
            }
            catch (Exception e)
            {
                onDone(Statics.CMD_TYPE.PWD, false, "Unknown Server Status");
            }
        }
    }
}
