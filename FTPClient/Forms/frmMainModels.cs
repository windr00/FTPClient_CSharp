using System.Collections.Generic;

namespace FTPClient.Forms
{
    public partial class frmMain
    {
        private string currentFolder = string.Empty;

        private string stash = string.Empty;

        private List<string> filePathList = new List<string>();

        private FileSet fileSet;
    }
}
