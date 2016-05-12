using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClient
{
    class AsyncState
    {

        public ManualResetEvent re { get; private set; }

        public void SetAsyncEvent(ref ManualResetEvent r)
        {
            re = r;
        }

        public TcpClient client { get; set; }

        private byte[] _buffer;

        public byte[] buffer
        {
            get
            {
                if (_buffer == null)
                {
                    _buffer = new byte[Statics.NET_READ_BUFFER_LENGTH];
                }
                return _buffer;
            }
            set { _buffer = buffer; }
        }

    }
}
