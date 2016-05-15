using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPClient
{
    class FileBean
    {
        public bool isDir { get; set; } = false;

        public uint size { get; set; } = 0;

        public DateTime modifyTime { get; set; } = DateTime.MinValue;

        public string fileName { get; set; } = string.Empty;

        public string fullPath { get; set; } = string.Empty;

        public Icon fileIcon { get; set; } = SystemIcons.Application;

        public List<FileBean> childFiles { get; set; } = null;
    }
}
