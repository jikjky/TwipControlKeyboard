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
        public int TwipDelayTime { get; set; } = 8000;
        public string ToonationURL { get; set; } = "";
        public int ToonationDelayTime { get; set; } = 0;
        public URLIni(FileInfo fileInfo) : base(fileInfo)
        {
   
        }
    }
}
