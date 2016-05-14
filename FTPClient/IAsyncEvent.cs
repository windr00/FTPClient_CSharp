using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    interface IAsyncEvent
    {

        void OnConnect(bool ConnectState);

        void OnSend();

        void OnRecv(byte[] buffer);

    }
}
