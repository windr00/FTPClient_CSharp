using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class AsyncEvent
    {
        private void SetAsyncEvent(TCPNetwork ins)
        {
            ins.AsyncEvent.Set();
        }

        public virtual void OnConnect(IAsyncResult ar)
        {
            try
            {
                var instance = (ar.AsyncState as AsyncState).instance;
                instance.client.EndConnect(ar);
                SetAsyncEvent(instance);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void OnSend(IAsyncResult ar)
        {
            SetAsyncEvent((ar.AsyncState as AsyncState).instance);            
        }

        public virtual void OnRecv(IAsyncResult ar)
        {
            SetAsyncEvent(ar);            
        }

    }
}
