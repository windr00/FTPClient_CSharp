using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class frmMain
    {

        private string pasvHost;
        private int pasvPort;

        private void OnError(Statics.CMD_TYPE type, string text)
        {
            MessageBox.Show(type.ToString() + "failed\n" + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

        private void OnLOGINDone(object result)
        {
            agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, "/");

        }

        private void OnCWDDone(object result)
        {
            agent.Command(Statics.CMD_TYPE.PWD, OnCMDDone);
        }

        private void OnPWDDone(object result)
        {
            currentFolder = result as string;
            try
            {
                txtCurDir.Text = currentFolder;
                agent.Command(Statics.CMD_TYPE.TYPE, OnCMDDone);
            }
            catch (InvalidOperationException e)
            {
                this.Invoke(onDone, Statics.CMD_TYPE.PWD, true, result);
            }
        }

        private void OnPASVDone(object result)
        {
            var arr = result as object[];
            pasvHost = arr[0] as string;
            pasvPort = (int)arr[1];
            agent.Command(Statics.CMD_TYPE.LIST, OnCMDDone,
                new[] { pasvHost, pasvPort.ToString() });
        }

        private void OnLISTDone(object result)
        {
            Console.WriteLine(result as string);
        }

        private void OnTYPEDone(object restult)
        {
            agent.Command(Statics.CMD_TYPE.PASV, OnCMDDone);
        }

    }
}
