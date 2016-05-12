using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class ServerProfile
    {
        public string host { get; set; }

        public int port { get; set; }

        public string user { get; set; }

        public string pass { get; set; }

        public ServerProfile(string h, int pn, string u, string p)
        {
            host = h;
            port = pn;
            user = u;
            pass = p;
        }

        public override string ToString()
        {
            return host + ":" + port.ToString();
        }
    }
}
