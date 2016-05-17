using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTPClient.CMDAgents;

namespace FTPClient
{
    class CMDAgent
    {
        private TCPNetwork client = new TCPNetwork();

        private Encoding encoding = Encoding.UTF8;
        public delegate void Done(Statics.CMD_TYPE type, bool state, object result);

        private Dictionary<Statics.CMD_TYPE, CommonAgent> agents = new Dictionary<Statics.CMD_TYPE, CommonAgent>();

        private Done listener;

        public void OnDone(Statics.CMD_TYPE cmd, bool state, object result) => listener?.Invoke(cmd, state, result);
        public CMDAgent()
        {
            agents.Add(Statics.CMD_TYPE.LOGIN, new LoginAgent(ref client, OnDone));
            agents.Add(Statics.CMD_TYPE.CWD, new CWDAgent(ref client, OnDone));
            agents.Add(Statics.CMD_TYPE.PWD, new PWDAgent(ref client, OnDone));
            agents.Add(Statics.CMD_TYPE.PASV, new PASVAgent(ref client, OnDone));
            agents.Add(Statics.CMD_TYPE.LIST, new LISTAgent(ref client, OnDone));
            agents.Add(Statics.CMD_TYPE.TYPE, new TYPEAgent(ref client, OnDone));
            agents.Add(Statics.CMD_TYPE.SYST, new SYSTAgent(ref client, OnDone));
        }

        public void Command(Statics.CMD_TYPE cmd, Done onDoneListener, params string[] arg)
        {
            listener = onDoneListener;
            agents[cmd].Start(arg);
        }

        
    }
}
