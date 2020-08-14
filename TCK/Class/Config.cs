using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twip.Class
{
    public class Config
    {
        public enum EState
        {
            Click,
            NoneClick,
        }
        public Keys key;
        public EState state;
        public int amount;
        public int time;
        public bool bCtrl;
        public bool bAlt;
        public bool bShift;
    }
}
