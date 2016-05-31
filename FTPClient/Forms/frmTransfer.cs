using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FTPClient;

namespace FTPClient.Forms
{
    public partial class frmTransfer : Form
    {

        public delegate void OnDone();

        private CMDAgent cmdAgent;
        private List<FileBean> files = new List<FileBean>();
        private List<FileBean> dirs = new List<FileBean>();
        private OnDone listerner;
        private FileSet tempFileSet;
        private string curPath;
        private int curFile = 0;

        private int sizeSum = 0;


        private delegate void CountSum();

        private CountSum sumCounter;
        public frmTransfer(ref CMDAgent cmdAgent, ref FileSet fileSet, string stash, List<FileBean> files, OnDone onDone)
        {
            this.cmdAgent = cmdAgent;
            this.listerner = onDone;
            tempFileSet = new FileSet(stash);
            InitializeComponent();
            sumCounter = CountSizeSum;
            SeperateFileAndDir(files);
            GetAllFiles(Statics.CMD_TYPE.TYPE, true, null);

        }

        private void SeperateFileAndDir(List<FileBean> fs)
        {
            foreach (var file in fs)
            {
                if (!file.isDir)
                {
                    files.Add(file);
                }
                else
                {
                    dirs.Add(file);
                }
            }
        }
        


        private void GetAllFiles(Statics.CMD_TYPE type, bool state, object result)
        {
            try
            {
                if (state == false)
                {
                    throw new Exception();
                }

                if (type == Statics.CMD_TYPE.TYPE)
                {
                    cmdAgent.Command(Statics.CMD_TYPE.CWD, GetAllFiles, dirs[0].fullPath);
                }
                else if (type == Statics.CMD_TYPE.CWD)
                {
                    cmdAgent.Command(Statics.CMD_TYPE.LIST, GetAllFiles, null);
                }
                else if (type == Statics.CMD_TYPE.LIST)
                {

                    dirs.RemoveAt(0);
                    tempFileSet.ParseFromString(curPath, result as string);
                    SeperateFileAndDir(tempFileSet.GetAllFiles());
                    if (dirs.Count != 0)
                    {
                        cmdAgent.Command(Statics.CMD_TYPE.CWD, GetAllFiles, dirs[0].fullPath);
                    }
                    else
                    {
                        GetAllFilesSize(Statics.CMD_TYPE.TYPE, true, null);
                    }
                    
                }

            }
            catch (Exception e)
            {

            }

        }

        private void GetAllFilesSize(Statics.CMD_TYPE type, bool state, object result)
        {
            try
            {
                if (state == false)
                {
                    throw new Exception();
                }

                if (type == Statics.CMD_TYPE.TYPE)
                {
                    cmdAgent.Command(Statics.CMD_TYPE.SIZE, GetAllFilesSize, files[curFile].fullPath);
                }
                else if (type == Statics.CMD_TYPE.SIZE)
                {
                    files[curFile].size = (uint) result;
                    
                    curFile++;
                    if (curFile == files.Count)
                    {
                        CountSizeSum();
                    }
                    else
                    {
                        cmdAgent.Command(Statics.CMD_TYPE.SIZE, GetAllFilesSize, files[curFile].fullPath);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }


        private void CountSizeSum()
        {
            sizeSum = 0;
            foreach (var file in files)
            {
                sizeSum += (int)file.size;
            }
            try
            {
                progressAll.Maximum = sizeSum;
            }
            catch (InvalidOperationException e)
            {
                progressAll.Invoke(sumCounter);
            }
        }

        private void RETRAllFiles(Statics.CMD_TYPE type, bool state, object resul)
        {
            try
            {
                if (state == false)
                {
                    throw new Exception();
                     
                }
                if (type == Statics.CMD_TYPE.TYPE)
                {
                    cmdAgent.Command(Statics.CMD_TYPE.PASV, RETRAllFiles, files[0].fullPath);
                }

            }
            catch (Exception e)
            {
                
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
