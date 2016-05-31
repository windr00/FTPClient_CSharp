using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FTPClient.Forms
{
    public partial class frmMain : Form
    {
        private string host;
        private int port;
        private string user;
        private string pass;
        private CMDAgent agent;

        private Stack<string> folderStack = new Stack<string>();

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
            lsFiles.Enabled = true;
        }
        

        private void lsFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsFiles.SelectedItems.Count == 0)
            {
                return;
            }
            var filename = currentFolder + lsFiles.SelectedItems[0].Text;
            var file = fileSet.GetFile(filename);
            if (file.isDir)
            {
                lsFiles.Enabled = false;
                agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, file.fileName);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lsFiles.Enabled)
            {
                lsFiles.Enabled = false;
                folderStack.Push(currentFolder);
                agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, "..");
            }
            else
            {
                MessageBox.Show("Please wait for current operation to be done", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (lsFiles.Enabled)
            {
                if (folderStack.Count != 0)
                {
                    lsFiles.Enabled = false;
                    var path = folderStack.Pop();
                    agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, path);
                }
            }
            else
            {
                MessageBox.Show("Please wait for current operation to be done", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (lsFiles.Enabled)
            {
                lsFiles.Enabled = false;
                agent.Command(Statics.CMD_TYPE.CWD, OnCMDDone, currentFolder);
            }
            else
            {
                MessageBox.Show("Please wait for current operation to be done", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lsFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Console.WriteLine(e.Item as ListViewItem);
        }

        private void lsFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void lsFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }

        private void lsFiles_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void lsFiles_DragLeave(object sender, EventArgs e)
        {

        }

        private void lsFiles_MouseClick(object sender, MouseEventArgs e)
        {
            filePathList.Clear();
            
            foreach (var i in lsFiles.SelectedItems)
            {
                var item = i as ListViewItem;
                filePathList.Add(item.Name);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (filePathList.Count == 0)
                {
                    menuEmptyOp.Show();
                    menuEmptyOp.Location = e.Location;
                }
                else
                {
                    menuFileOp.Location = e.Location;
                    menuFileOp.Show();
                }
            }
        }

        private void menuFileOp_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "Save to")
            {
                List<FileBean> fileBeans = new List<FileBean>();
                foreach (var item in filePathList)
                {
                    fileBeans.Add(fileSet.GetFile(item));
                }
            }
        }
    }
}
