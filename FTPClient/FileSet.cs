using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;



namespace FTPClient
{

    public class FileSet
    {
        public struct HICON__
        {

            /// int   
            public int unused;
        }

        public partial class NativeMethods
        {

            /// Return Type: UINT->unsigned int   
            ///lpszFile: LPCWSTR->WCHAR*   
            ///nIconIndex: int   
            ///phiconLarge: HICON*   
            ///phiconSmall: HICON*   
            ///nIcons: UINT->unsigned int   
            [System.Runtime.InteropServices.DllImportAttribute("shell32.dll", EntryPoint = "ExtractIconExW", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint ExtractIconExW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lpszFile, int nIconIndex, ref System.IntPtr phiconLarge, ref System.IntPtr phiconSmall, uint nIcons);

        }

        private readonly string stash;

        private List<FileBean> files;

        public FileSet(string stash)
        {
            this.stash = stash;
            files = new List<FileBean>();
        }

        public List<FileBean> GetAllFiles()
        {
            return files;
        }

        public FileBean GetFile(string path)
        {
            
            foreach (var f in files)
            {
                if (f.fullPath.Equals(path))
                {
                    return f;
                }   
            }
           return null;
        }

        void GetExtsIconAndDescription(string ext, out Icon largeIcon, out Icon smallIcon, out string description)
        {
            GetDefaultIcon(out largeIcon, out smallIcon);   //得到缺省图标  
            description = "";                               //缺省类型描述  
            RegistryKey extsubkey = Registry.ClassesRoot.OpenSubKey(ext);   //从注册表中读取扩展名相应的子键  
            if (extsubkey == null) return;

            string extdefaultvalue = extsubkey.GetValue(null) as string;     //取出扩展名对应的文件类型名称  
            if (extdefaultvalue == null) return;

            if (extdefaultvalue.Equals("exefile", StringComparison.OrdinalIgnoreCase))  //扩展名类型是可执行文件  
            {
                RegistryKey exefilesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键  
                if (exefilesubkey != null)
                {
                    string exefiledescription = exefilesubkey.GetValue(null) as string;   //得到exefile描述字符串  
                    if (exefiledescription != null) description = exefiledescription;
                }
                System.IntPtr exefilePhiconLarge = new IntPtr();
                System.IntPtr exefilePhiconSmall = new IntPtr();
                NativeMethods.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 2, ref exefilePhiconLarge, ref exefilePhiconSmall, 1);
                if (exefilePhiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(exefilePhiconLarge);
                if (exefilePhiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(exefilePhiconSmall);
                return;
            }

            RegistryKey typesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键  
            if (typesubkey == null) return;

            string typedescription = typesubkey.GetValue(null) as string;   //得到类型描述字符串  
            if (typedescription != null) description = typedescription;

            RegistryKey defaulticonsubkey = typesubkey.OpenSubKey("DefaultIcon");  //取默认图标子键  
            if (defaulticonsubkey == null) return;

            //得到图标来源字符串  
            string defaulticon = defaulticonsubkey.GetValue(null) as string; //取出默认图标来源字符串  
            if (defaulticon == null) return;
            string[] iconstringArray = defaulticon.Split(',');
            int nIconIndex = 0; //声明并初始化图标索引  
            if (iconstringArray.Length > 1)
                if (!int.TryParse(iconstringArray[1], out nIconIndex))
                    nIconIndex = 0;     //int.TryParse转换失败，返回0  

            //得到图标  
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            NativeMethods.ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }

        /// <summary>  
        /// 获取缺省图标  
        /// </summary>  
        /// <param name="largeIcon"></param>  
        /// <param name="smallIcon"></param>  
        private static void GetDefaultIcon(out Icon largeIcon, out Icon smallIcon)
        {
            largeIcon = smallIcon = null;
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            NativeMethods.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }




        public void ParseFromString(string currentDir, string listData)
        {
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
                file.fullPath = currentDir + file.fileName;
                if (!file.isDir)
                {
                    var c = file.fileName.Split('.');
                    Icon large;
                    Icon small;
                    string des;
                    GetExtsIconAndDescription("." + c[c.Length - 1], out large, out small, out des);
                    file.fileLargeIcon = large;
                    file.fileSmallIcon = small;
                    file.fileDescription = des;
                }

                files.Add(file);
            }
        }
        

    }
}
