using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCK.Class
{
    public class Config
    {
        public enum EMoveDirection
        {
            Left,
            Right,
            Top,
            Bottom
        }
        public enum EState
        {
            Click,
            NoneClick,
            MouseMove,
            AbsMouseMove,
        }
        public Keys key;
        public EState state;
        public string roulette;
        public int amount;
        public int time;
        public bool bCtrl;
        public bool bAlt;
        public bool bShift;
        public int delay;

        public int x;
        public int y;

        public EMoveDirection moveDirection;
        public int speed;
    }
}
