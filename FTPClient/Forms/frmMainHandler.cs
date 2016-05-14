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
        private void OnLOGINDone(bool state, object result)
        {
            if (state)
            {
                agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, "/");
            }
            else
            {
                MessageBox.Show("Login failed\n" + result as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pass = string.Empty;
                frmMain_Load(null, null);
            }
        }

        private void OnCWDDone(bool state, object result)
        {
            if (state)
            {
                agent.Command(Statics.CMD_TYPE.PWD, OnCMDDone);

            }
            else
            {
                MessageBox.Show("CWD FAILED\n" + result as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPWDDone(bool state, object result)
        {
            if (state)
            {
                currentFolder = result as string;
                txtCurDir.Text = currentFolder;
                agent.Command(Statics.CMD_TYPE.PASV, OnCMDDone);
            }
            else
            {
                MessageBox.Show("PWD FAILED\n" + result as string, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPASVDone(bool state, object result)
        {
            if (state)
            {
                
            }
        }

    }
}
