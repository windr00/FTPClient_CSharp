using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class FileSet
    {
        private FileBean root;

        public void ParseFromString(string currentDir, string listData)
        {
            string[] paths = currentDir.Split('/');
            if (paths[1].Equals(string.Empty))
            {
                root.fullPath = "/";
                root.isDir = true;
                root.fileName = "/";
                
            }
        }

    }
}
