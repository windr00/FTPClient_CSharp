using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient.CMDAgents
{
    abstract class CommonAgent
    {
        protected TCPNetwork client;


        public delegate void Done(Statics.CMD_TYPE type, bool state, object result);

        protected Done onDone;

        public CommonAgent(ref TCPNetwork client, Done onDone)
        {
            this.client = client;
            this.onDone = onDone;
        }
        public abstract void Start(string[] args);
    }
}
