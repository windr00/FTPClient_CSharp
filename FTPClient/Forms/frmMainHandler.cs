using System;
using System.Windows.Forms;

namespace FTPClient.Forms
{
    public partial class frmMain
    {

        private string pasvHost;
        private int pasvPort;

        private void OnError(Statics.CMD_TYPE type, string text)
        {
            MessageBox.Show(type.ToString() + "failed\n" + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lsFiles.Enabled = true;
        }

        

        private void OnLOGINDone(object result)
        {
            agent.Command(Statics.CMD_TYPE.SYST, OnCMDDone);

        }

        private void OnCWDDone(object result)
        {
            agent.Command(Statics.CMD_TYPE.PWD, OnCMDDone);
        }

        private void OnPWDDone(object result)
        {
            currentFolder = result as string;
            if (!currentFolder.EndsWith(stash))
            {
                currentFolder += stash;
            }
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
            try
            {
                Console.WriteLine(result as string);
                fileSet = new FileSet(stash);
                fileSet.ParseFromString(currentFolder, result as string);
                refreshFileListView(fileSet.GetAllFiles());
            }
            catch (InvalidOperationException e)
            {
                this.Invoke(onDone, Statics.CMD_TYPE.LIST, true, result);
            }
        }

        private void OnTYPEDone(object restult)
        {
            agent.Command(Statics.CMD_TYPE.PASV, OnCMDDone);
        }

        private void OnSYSTDone(object result)
        {
            if ((result as string).ToUpper().Contains("WIN"))
            {
                stash = "\\";
            }
            else
            {
                stash = "/";
            }
            agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, stash);
        }

    }
}
