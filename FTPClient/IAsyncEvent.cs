using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class AsyncEvent
    {
        private void SetAsyncEvent(IAsyncResult ar)
        {
            var re = (ar as AsyncState).AsyncEvent;
            re.Set();
        }

        public virtual void OnConnect(IAsyncResult ar)
        {
            SetAsyncEvent(ar);
        }

        public virtual void OnSend(IAsyncResult ar)
        {
            SetAsyncEvent(ar);            
        }

        public virtual void OnRecv(IAsyncResult ar)
        {
            SetAsyncEvent(ar);            
        }

    }
}
