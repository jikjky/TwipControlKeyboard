using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCK.Class.INI
{
    public class URLIni : ClassToINI
    {
        public string TwipURL { get; set; } = "";
        public int DelayTime { get; set; } = 0;
        public string ToonationURL { get; set; } = "";
        public URLIni(FileInfo fileInfo) : base(fileInfo)
        {
            
        }
    }
}
