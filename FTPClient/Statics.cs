﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class Statics
    {

        public static readonly int NET_READ_BUFFER_LENGTH = 65535;


        public static readonly string INIT_CMD = "INIT";
        public static readonly string USER_CMD = "USER ";
        public static readonly string PASS_CMD = "PASS ";
        public static readonly string OPTS_CMD = "OPTS SET UTF8 ON\n";
        public static readonly string SYST_CMD = "SYST \n";
        public static readonly string CWD_CMD = "CWD ";
        public static readonly string NOOP_CMD = "NOOP \n";
        public static readonly string TYPE_CMD = "TYPE ";
        public static readonly string QUIT_CMD = "QUIT \n";
        public static readonly string PWD_CMD = "PWD \n";
        public static readonly string CDUP_CMD = "CDUP \n";
        public static readonly string FEAT_CMD = "FEAT \n";
        public static readonly string PORT_CMD = "PORT ";
        public static readonly string PASV_CWD = "PWD ";
        public static readonly string AUTH_CMD = "AUTH ";
        public static readonly string RETR_CMD = "RETR ";
        public static readonly string STOR_CMD = "STOR ";
        public static readonly string MKD_CMD = "MKD ";
        public static readonly string RMD_CMD = "RMD ";
        public static readonly string DELE_CMD = "DELE ";
        public static readonly string ABOR_CMD = "ABOR \n";
        public static readonly string LIST_CMD = "LIST \n";
        public static readonly string RNFR_CMD = "RNFR ";
        public static readonly string RNTO_CMD = "RNTO ";
        public static readonly string SIZE_CMD = "SIZE ";

        public enum CMD_TYPE
        {
            LOGIN,
            LSIT
        }

        public static readonly string CONNECT_SUCC = "220";

        public static readonly string USER_SUCC = "332";

        public static readonly string PASS_SUCC = "230";

        public static readonly string LOGIN_FAILED = "530";
    }
}

