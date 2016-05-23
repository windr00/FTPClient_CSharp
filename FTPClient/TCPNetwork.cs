using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClient
{
    class TCPNetwork
    {

        private TcpClient client;

        public bool Connected
        {
            get { return client.Connected; }
        }

        private string host;
        private int port;
        private IAsyncEvent handler;

        private ManualResetEvent re = new ManualResetEvent(false);

        private AsyncCallback back = delegate(IAsyncResult ar) {  };
        public ManualResetEvent AsyncEvent
        {
            get { return re; }
        }

        public TCPNetwork()
        {
            client = new TcpClient();
        }

        public TCPNetwork SetAddress(string host, int port)
        {
            this.host = host;
            this.port = port;
            return this;
        }

        public TCPNetwork SetEventHandler(IAsyncEvent handler)
        {
            this.handler = handler;
            return this;
        }

        public TCPNetwork Connect()
        {
            try
            {
                var state = new AsyncState();
                state.client = client;
                state.SetAsyncEvent(ref this.re);
                
                client.BeginConnect(host, port,delegate(IAsyncResult ar)
                {
                    try
                    {
                        var s = ar.AsyncState as AsyncState;
                        s.re.Set();
                        state.client.EndConnect(ar);
                        handler.OnConnect(client.Connected);
                    }
                    catch (Exception e)
                    {
                        handler.OnConnect(false);
                        
                    }
                }, state);
                return this;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TCPNetwork Recv()
        {
            try
            {
                var state = new AsyncState();
                state.client = client ;
                state.SetAsyncEvent(ref this.re);
                client.GetStream().BeginRead(state.buffer, 0, Statics.NET_READ_BUFFER_LENGTH, delegate(IAsyncResult ar)
                {
                    try
                    {
                        var s = ar.AsyncState as AsyncState;
                        s.re.Set();
                        var length = s.client.GetStream().EndRead(ar);
                        byte[] buff = new byte[length];
                        Array.Copy(s.buffer,buff, length);
                        handler.OnRecv(buff);
                        Console.WriteLine(Encoding.UTF8.GetString(buff));
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }, state);
            }
            catch (Exception e)
            {
                throw e;
            }
            return this;
        }

        public TCPNetwork Send(byte[] data)
        {
            try
            {
                var state = new AsyncState();
                state.client = client;
                state.SetAsyncEvent(ref this.re);
                client.GetStream().BeginWrite(data, 0, data.Length, delegate(IAsyncResult ar)
                {
                    try
                    {
                        var s = ar.AsyncState as AsyncState;
                        s.re.Set();
                        s.client.GetStream().EndWrite(ar);
                        handler.OnSend();
                        Console.WriteLine(Encoding.UTF8.GetString(data));

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }, state);
            }
            catch (Exception e)
            {
                throw e;
            }
            return this;
        }

        public TCPNetwork Sync()
        {
            re.WaitOne();
            re.Reset();
            return this;
        }

        public TCPNetwork Close()
        {
            try
            {
                client.GetStream().Close();
                client.Close();
                client = new TcpClient();
                return this;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool RecvFinished()
        {
            return (client.Available == 0);
        }

    }
}
