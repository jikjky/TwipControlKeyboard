using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twip.Class.INI
{
    public class URLIni : ClassToINI
    {
        public string URL { get; set; } = "";
        public URLIni(FileInfo fileInfo) : base(fileInfo)
        {
            
        }
    }
}
