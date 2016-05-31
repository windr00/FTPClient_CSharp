using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FTPClient.Forms;

namespace FTPClient.CMDAgents
{
    class RETRAgent : CommonAgent, IAsyncEvent
    {
        public RETRAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {
        }

        private ManualResetEvent locker = new ManualResetEvent(false);

        private TCPNetwork dataSocket;

        public delegate void OnRecvData(int length);

        private OnRecvData recv;

        public override void Start(object[] args)
        {
            var remoteFile = args[0] as string;
            var localPath = args[1] as string;
            var ip = args[2] as string;
            var port = int.Parse(args[3] as string) ;
            recv = args[4] as OnRecvData;
            dataSocket.SetEventHandler(new DataHandler(ref dataSocket, ref locker,  ref recv, ref onDone,localPath)).SetAddress(ip, port);
            client.SetEventHandler(this).Send(Encoding.UTF8.GetBytes(Statics.RETR_CMD + remoteFile + "\n"));
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
            var res = Encoding.UTF8.GetString(buffer);
            if (res.StartsWith(Statics.RETR_STRART_I_RETURN))
            {
                client.Recv();
            }
            else if (res.StartsWith(Statics.RETR_SUCC_RETURN))
            {
                locker.WaitOne();
                onDone(Statics.CMD_TYPE.RETR, true, res);
            }
            else
            {
                onDone(Statics.CMD_TYPE.RETR, false, res);
            }
        }

        class DataHandler : CommonAgent, IAsyncEvent
        {
            private string path;
            private ManualResetEvent locker;
            private OnRecvData onRecv;

            public DataHandler(ref TCPNetwork client, ref ManualResetEvent l,ref OnRecvData onDone, ref Done onWorkDone,string path) : base(ref client, onWorkDone)
            {
                this.locker = l;
                this.path = path;
                this.onRecv = onDone;
            }

            public override void Start(object[] args)
            {
                throw new NotImplementedException();
            }

            public void OnConnect(bool ConnectState)
            {
                if (ConnectState)
                {
                    try
                    {
                        var str = path.Split('\\');
                        var p = str[0];
                        for (int i = 1; i < str.Length - 1; i++)
                        {
                            p += "\\" + str[i];
                            if (!Directory.Exists(p))
                            {
                                Directory.CreateDirectory(p);
                            }
                        }
                        File.Create(str[str.Length - 1]);
                    }
                    catch (Exception e)
                    {
                        onDone(Statics.CMD_TYPE.RETR, false, "Local directory creation failed.");
                    }
                    client.Recv();
                }
            }

            public void OnSend()
            {
                throw new NotImplementedException();
            }

            public void OnRecv(byte[] buffer)
            {
                using (var stream = File.Open(path, FileMode.Append))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                if (!client.RecvFinished())
                {
                    client.Recv();
                }
                else
                {
                    locker.Set();
                }
                onRecv(buffer.Length);
            }
        }
    }
}
