using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class LISTAgent : CommonAgent, IAsyncEvent
    {
        private string host;
        private int port;

        private byte[] recvBytes;

        private TCPNetwork dataClient;
        private dataChannelHandler handler;

        public LISTAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {
            dataClient = new TCPNetwork();
            handler = new dataChannelHandler(ref dataClient);
        }

        public override void Start(string[] args)
        {
            host = args[0];
            port = int.Parse(args[1]);
            client.SetEventHandler(this).Send(Encoding.UTF8.GetBytes(Statics.LIST_CMD));
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
            if (str.StartsWith(Statics.LIST_START))
            {
                DataChannel();
                client.Recv();
            }
            else if (str.StartsWith(Statics.LIST_SUCC))
            {
                handler.locker.WaitOne();
                handler.GetData(out recvBytes);
                onDone(Statics.CMD_TYPE.LIST, true, Encoding.UTF8.GetString(recvBytes));
            }
            else
            {
                onDone(Statics.CMD_TYPE.LIST, false, str);
            }
        }
        

        class dataChannelHandler : IAsyncEvent
        {

            public ManualResetEvent locker = new ManualResetEvent(false);
            private byte[] data;
            private TCPNetwork client;
            public dataChannelHandler(ref TCPNetwork client)
            {
                this.client = client;
            }

            public void OnConnect(bool ConnectState)
            {
                client.Recv();
            }

            public void OnSend()
            {
                throw new NotImplementedException();
            }

            public void OnRecv(byte[] buffer)
            {
                data = buffer;
                client.Close();
                
                locker.Set();
            }

            public void GetData(out byte[] bytes)
            {
                bytes = data;
            }
        }

        private void DataChannel()
        {
            
            dataClient.SetEventHandler(handler)
                .SetAddress(host, port)
                .Connect();
        }
    }
}
