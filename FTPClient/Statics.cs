using System;
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
        public static readonly string TYPE_CMD = "TYPE I\n";
        public static readonly string QUIT_CMD = "QUIT \n";
        public static readonly string PWD_CMD = "PWD \n";
        public static readonly string CDUP_CMD = "CDUP \n";
        public static readonly string FEAT_CMD = "FEAT \n";
        public static readonly string PORT_CMD = "PORT \n";
        public static readonly string PASV_CMD = "PASV \n";
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
            LIST,
            CWD,
            PWD,
            PASV,
            TYPE,
            CDUP,
            FEAT,
            PORT,
            AUTH,
            RETR,
            STOR,
            MKD,
            RMD,
            DELE,
            ABOR,
            RNFR,
            RNTO,
            SIZE,
            SYST
        }

        public static readonly string CONNECT_SUCC = "220";

        public static readonly string USER_SUCC = "331";

        public static readonly string PASS_SUCC = "230";

        public static readonly string LOGIN_FAILED = "530";

        public static readonly string CWD_SUCC = "250";

        public static readonly string CWD_FAILED = "550";

        public static readonly string PWD_SUCC = "257";

        public static readonly string PASV_SUCC = "227";

        public static readonly string PASV_FAILED = "500";

        public static readonly string TYPE_SUCC = "200";

        public static readonly string TYPE_FALIED = "501";

        public static readonly string LIST_START = "150";

        public static readonly string LIST_SUCC = "226";

        public static readonly string LIST_FAILED = "500";

        public static readonly string SYST_SUCC = "215";

    }
}

