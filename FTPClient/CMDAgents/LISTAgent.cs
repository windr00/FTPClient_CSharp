using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    class LISTAgent : CommonAgent, IAsyncEvent
    {
        private string host;
        private int port;

        private byte[] recvBytes;

        public LISTAgent(ref TCPNetwork client, Done onDone) : base(ref client, onDone)
        {}

        public override void Start(string[] args)
        {
            client.Send(Encoding.UTF8.GetBytes(Statics.LIST_CMD));
            host = args[0];
            port = int.Parse(args[1]);
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
                onDone(Statics.CMD_TYPE.LIST, true, Encoding.UTF8.GetString(recvBytes));
            }
            else
            {
                onDone(Statics.CMD_TYPE.LIST, false, str);
            }
        }
        

        class dataChannelHandler : IAsyncEvent
        {
            private byte[] data;
            private TCPNetwork client;
            public dataChannelHandler(ref TCPNetwork client, ref byte[] bytes)
            {
                data = bytes;
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
            }
        }

        private void DataChannel()
        {
            TCPNetwork dataClient = new TCPNetwork();
            dataClient.SetEventHandler(new dataChannelHandler(ref dataClient, ref recvBytes))
                .SetAddress(host, port)
                .Connect();
        }
    }
}
