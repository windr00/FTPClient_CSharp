using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTPClient.Forms;

namespace FTPClient
{
    public partial class frmMain : Form
    {
        private string host;
        private int port;
        private string user;
        private string pass;
        private CMDAgent agent;


        private delegate void CMDDone(Statics.CMD_TYPE type, bool state, string result);

        private CMDDone onDone;

        public frmMain(string host, int port, string user, string pass)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            InitializeComponent();
            this.Text = user + "@" + host + ":" + port;
            this.onDone = OnCMDDone;
        }

        private void OnCMDDone(Statics.CMD_TYPE type, bool state, object result)
        {
            
                Type t = this.GetType();
                var method = "On" + type.ToString() + "Done";
               
                MethodInfo info = t.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance, null, new []{typeof(object)}, null);
                if (state)
                {
                    info.Invoke(this, new object[] {result});
                }
                else
                {
                    OnError(type, result as string);
                }
        }

        public void OnfrmLoginClose(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            this.Enabled = true;
            frmMain_Load(null, null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!(user != string.Empty && pass != string.Empty))
            {
                frmLogin login = new frmLogin(user, pass, OnfrmLoginClose);
                this.Enabled = false;
                login.Show();
            }
            else
            {
                agent = new CMDAgent();
                agent.Command(Statics.CMD_TYPE.LOGIN, OnCMDDone, host, port.ToString(), user, pass);
            }
        }

        private void refreshDirTree(string parent, List<FileBean> files)
        {
            if (parent.Equals(stash))
            {
                treeRemoteDir.Nodes.Clear();
                treeRemoteDir.Nodes.Add(new TreeNode(stash));
            }
            if (files == null)
            {
                return;
            }
            var cuts = parent.Split(stash.Equals("\\") ? '\\' : '/');
            TreeNode node = treeRemoteDir.Nodes[0];
            for (int i = 1; i < cuts.Length; i++)
            {
                for (int j = 0; j < node.Nodes.Count; j++)
                {
                    if (cuts[i].Equals(node.Nodes[j].Name))
                    {
                        node = node.Nodes[j];
                        break;
                    }
                }
            }
            foreach (var i in files)
            {
                if (i.isDir)
                {
                    node.Nodes.Add(new TreeNode(i.fileName));
                    if (!parent.EndsWith(stash))
                    {
                        parent += stash;
                    }
                    refreshDirTree(i.fullPath, i.childFiles);
                }
            }
        }

        private void refreshFileListView(List<FileBean> files)
        {
            lsFiles.View = View.LargeIcon;
            ImageList images = new ImageList();
            images.ImageSize = new Size(files[0].fileLargeIcon.Width * 2, files[0].fileLargeIcon.Height * 2);
            foreach (var f in files)
            {
                images.Images.Add(f.fileLargeIcon);
            }
            lsFiles.Items.Clear();
            lsFiles.LargeImageList = images;
            
            lsFiles.BeginUpdate();

            for (int i = 0; i < files.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = files[i].fileName;
                lsFiles.Items.Add(lvi);
            }

            lsFiles.EndUpdate();
        }

        private void treeRemoteDir_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            var path = e.Node.FullPath.Substring(1);
            path = path.Replace("\\", stash);
            currentFolder = path;
            agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, currentFolder);
        }
    }
}
