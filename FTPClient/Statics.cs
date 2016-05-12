using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class Statics
    {

        public const int NET_READ_BUFFER_LENGTH = 65535;

        public const string USER_CMD = "USER ";
        public const string PASS_CMD = "PASS ";
        public const string OPTS_CMD = "OPTS SET UTF8 ON\n";
        public const string SYST_CMD = "SYST \n";
        public const string CWD_CMD = "CWD ";
        public const string NOOP_CMD = "NOOP \n";
        public const string TYPE_CMD = "TYPE ";
        public const string QUIT_CMD = "QUIT \n";
        public const string PWD_CMD = "PWD \n";
        public const string CDUP_CMD = "CDUP \n";
        public const string FEAT_CMD = "FEAT \n";
        public const string PORT_CMD = "PORT ";
        public const string PASV_CWD = "PWD ";
        public const string AUTH_CMD = "AUTH ";
        public const string RETR_CMD = "RETR ";
        public const string STOR_CMD = "STOR ";
        public const string MKD_CMD = "MKD ";
        public const string RMD_CMD = "RMD ";
        public const string DELE_CMD = "DELE ";
        public const string ABOR_CMD = "ABOR \n";
        public const string LIST_CMD = "LIST \n";
        public const string RNFR_CMD = "RNFR ";
        public const string RNTO_CMD = "RNTO ";
        public const string SIZE_CMD = "SIZE ";


        public const string COMMAND_NOT_UNDERSTOOD_RETURN = "500";
        public const string INIT_RETURN = "220";
        public const string FEAT_RETURN = "211-";
        public const string OPTS_UTF8_ON_RETURN = "200 OPTS UTF8 IS SET TO ON.\n";
        public const string OPTS_UTF8_OFF_RETURN = "200 OPTS UTF8 IS SET TO OFF.\n";
        public const string USER_RETURN = "331 NEED PASSWORD.\n";
        public const string PASS_LOGEDIN_RETURN = "230 WELCOME !\n";
        public const string PASS_FAILED_RETURN = "530 LOGIN OR PASSWORD INCORRECT\n";
        public const string QUIT_RETURN = "221 GOOD BYE!\n";
        public const string TYPE_RETURN = "200 TYPE SET TO ";
        public const string TYPE_FAILED_RETURN = "501 WRONG TYPE\n";
        public const string NOOP_RETURN = "200 NOOP OK.\n";
        public const string CWD_SUCC_RETURN = "250 CWD SUCCESSFUL.\n";
        public const string CWD_FAILED_RETURN = "550 CWD FAILED\n";
        public const string PWD_RETURN = "257 CURRENT DIRECTORY IS ";
        public const string PORT_FAILED_RETURN = "500 PORT PARAM ERROR.\n";
        public const string PORT_SUCC_RETURN = "200 PORT SUCCESSFUL\n";
        public const string PASV_SUCC_RETURN = "227 ENTERING PASSIVE MODE (";
        public const string PASV_FAILED_RETURN = "500 ERROR ENTERING PASSIVE MODE \n";
        public const string RETR_STRART_A_RETURN = "150 OPENING ASCII MODE DATA CONNECTION.\n";
        public const string RETR_STRART_I_RETURN = "150 OPENING BINARY MODE DATA CONNECTION.\n";
        public const string RETR_SUCC_RETURN = "226 TRANSFER COMPLETE\n";
        public const string RETR_FAILED_RETURN = "550 FILE NOT FOUND OR ACCESS DENIED.\n";
        public const string STOR_SUCC_RETURN = "226 TRANSFER COMPLETE\n";
        public const string STOR_FAILED_RETURN = "550 FILE ALREADY EXISTS OR ACCESS DENIED.\n";
        public const string STOR_STRART_A_RETURN = "150 OPENING ASCII MODE DATA CONNECTION.\n";
        public const string STOR_STRART_I_RETURN = "150 OPENING BINARY MODE DATA CONNECTION.\n";
        public const string LIST_START_RETURN = "150 OPENING ASCII MODE DATA CONNECTION.\n";
        public const string LIST_FAILED_RETURN = "500 LIST ERROR\n";
        public const string LIST_SUCC_RETURN = "226 LIST TRANSFER COMPLETE\n";
        public const string CDUP_SUCC_RETURN = "250 CDUP SUCCESSFUL\n";
        public const string CDUP_FAILED_RETURN = "500 CDUP FAILED\n";
        public const string ABOR_SUCC_RETURN = "200 TRANSFER ABORT!\n";
        public const string ABOR_FAILED_RETURN = "500 NO TRANSFER GOING\n";
        public const string MKD_SUCC_RETURN = "250 MKD SUCCESSFUL\n";
        public const string MKD_FAILED_RETURN = "550 MKD FALIED\n";
        public const string MKD_EXIST_WARN_RETURN = "500 MKD FALIED ALREADY EXISTS\n";
        public const string DELE_SUCC_RETURN = "250 DELETE SUCCESSFUL\n";
        public const string DELE_FALIED_RETURN = "550 DELETE FALIED\n";
        public const string DELE_ISDIR_WARN_RETURN = "550 DELETE FALIED FILE IS A DIRECTORY\n";
        public const string RMD_SUCC_RETURN = "250 RM DIRECTORY SUCCESSFUL\n";
        public const string RMD_FALIED_RETURN = "250 RM DIRECTORY FALIED\n";
        public const string RMD_ISFILE_WARN_RETURN = "550 RM DIRECTORY FALIED FILE IS NOT A DICRECTORY\n";
        public const string RNFR_SUCC_RETURN = "350 RNFR SUCCESSFUL\n";
        public const string RNFR_FALIED_RETURN = "550 RNFR FAILED\n";
        public const string RNTO_SUCC_RETURN = "250 RNTO SUCCESSFUL\n";
        public const string RNTO_FAILED_RETURN = "550 RNTO FAILED\n";
        public const string SIZE_SUCC_RETURN = "213 ";
        public const string SIZE_FAILED_RETURN = "500 GET SIZE FAILED\n";
        public const string CMD_NOT_ALLOWED_RETURN = "450 CMD NOT ALLOWED, YOU MAY NEED TO LOGIN FIRST\n";
        public static string SYSTEM_STASH;
        public static string SYST_RETURN = "215 ";
    }
}
