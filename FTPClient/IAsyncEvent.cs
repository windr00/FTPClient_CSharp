using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    interface IAsyncEvent
    {

        void OnConnect(IAsyncResult ar);

        void OnSend(IAsyncResult ar);

        void OnRecv(IAsyncResult ar);

    }
}
