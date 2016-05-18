using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
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
            foreach (var i in lines)
            {
                FileBean file = new FileBean();
                var cuts = i.Split(' ');
                file.isDir = cuts[0].StartsWith("d");
                bool fileNameStart = false;
                bool sizeStart = false;
                for (int j = 0; j < cuts.Length; j++)
                {
                    //if (!sizeStart && Regex.IsMatch(cuts[j], "^\\d[A-Za-z0-9]*[A-Za-z0-9]$"))
                    //{
                    //    var num = cuts[j].Substring(0, cuts[j].Length - 1);
                    //    int size = 0;              
                    //    sizeStart = true;
                    //}
                    if (cuts[j].Contains(":"))
                    {
                        fileNameStart = true;
                        continue;
                    }
                    if (fileNameStart)
                    {
                        file.fileName += cuts[j];
                        if (j != cuts.Length - 1)
                        {
                            file.fileName += " ";
                        }
                    }
                }
                if (!currentDir.EndsWith(stash))
                {
                    currentDir += stash;
                }
                file.fullPath = currentDir + stash + file.fileName;
            }
        }
        

    }
}
