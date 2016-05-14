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
        private string host;
        private int port;
        private string user;
        private string pass;
        private TCPNetwork client = new TCPNetwork();

        private Encoding encoding = Encoding.UTF8;

        private LoginAgent loginAgent;
        private CWDAgent cwdAgent;
        private PWDAgent pwdAgent;
        private PASVAgent pasvAgent;

        public delegate void Done(Statics.CMD_TYPE type, bool state, object result);

        private Done listener;

        public void OnDone(Statics.CMD_TYPE cmd, bool state, object result)
        {

            if (listener != null)
            {
                listener(cmd, state, result);
                
            }
        }

        public CMDAgent(string host, int port, string user, string pass)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            loginAgent = new LoginAgent(host, port, user, pass, ref client, OnDone);
            cwdAgent = new CWDAgent(ref client, OnDone);
            pwdAgent = new PWDAgent(ref client, OnDone);
            pasvAgent = new PASVAgent(ref client, OnDone);
        }

        public void Command(Statics.CMD_TYPE cmd, Done onDoneListener, params string[] arg)
        {
            listener = onDoneListener;
            Type t = typeof(CMDAgent);
            FieldInfo info = t.GetField(cmd.ToString().ToLower() + "Agent");
            (info.GetValue(this) as CommonAgent).Start(arg);
        }

        
    }
}
