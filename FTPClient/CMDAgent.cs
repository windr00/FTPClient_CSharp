﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    class CMDAgent : IAsyncEvent
    {
        private string host;
        private int port;
        private string user;
        private string pass;
        private TCPNetwork client;

        public Encoding encoding = Encoding.UTF8;

        public void OnConnect(IAsyncResult ar)
        {
            try
            {
                var state = ar.AsyncState as AsyncState;
                state.client.EndConnect(ar);
                client.Recv();
            }
            catch (Exception e)
            {
                MessageBox.Show("服务器连接异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw e;
            }
        }

        public void OnRecv(IAsyncResult ar)
        {
            try
            {
                var state = ar.AsyncState as AsyncState;
                var length = state.client.GetStream().EndRead(ar);
                byte[] buff = new byte[length];
                Array.Copy(state.buffer, buff, length);
                string recv = encoding.GetString(buff);
                
                OnResponse(recv);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void OnSend(IAsyncResult ar)
        {

        }

        private void OnRequest(string req)
        {
            
        }

        private void OnResponse(string rsp)
        {
            Console.WriteLine(rsp);
            
        }

        public CMDAgent(string host, int port, string user, string pass)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            client = new TCPNetwork();
        }

        public void Login()
        {
            if (!client.Connected)
            {
                client.SetAddress(host, port).SetEventHandler(this).Connect();
            }
        }
    }
}