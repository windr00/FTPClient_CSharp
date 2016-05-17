using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class FileSet
    {
        private readonly string stash;

        private FileBean root;

        public FileSet(string stash)
        {
            this.stash = stash;
        }

        public void ParseFromString(string currentDir, string listData)
        {
            string[] paths = currentDir.Split(stash.ToCharArray());
            if (paths[1].Equals(string.Empty))
            {
                root.fullPath = stash;
                root.isDir = true;
                root.fileName = stash;
            }
            string withoutR = listData.Replace('\r', '\n');
            string[] lines = listData.Split('\n');
            List<string> lineList = new List<string>(lines);
            lineList.RemoveAll(new Predicate<string>(s => s.Equals(string.Empty)));
            if (lineList[0].StartsWith("total"))
            {
                lineList.RemoveAt(0);
            }
            lines = lineList.ToArray();
        }
        

    }
}
