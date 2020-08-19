using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TKC.Class.Hook
{
    class MouseMove
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        /// <summary>
        /// Clicks the mouse.
        /// </summary>
        public static void Click()
        {
            mouse_event(0x02, 0, 0, 0, 0);
            mouse_event(0x04, 0, 0, 0, 0);
        }

        /// <summary>
        /// Executes the mouse moves.
        /// </summary>
        /// <param name="step"></param>
        /// <param name="async"></param>
        public static void ExecuteMove(Point step, bool async = false)
        {
            if (!async)
            {
                mouse_event(0x1, step.X, step.Y, 0, 0);
            }
            else
            {
                // Move X.
                new Thread(() =>
                {
                    mouse_event(0x1, step.X, 0, 0, 0);
                }).Start();

                // Move Y.
                new Thread(() =>
                {
                    mouse_event(0x1, 0, step.Y, 0, 0);
                }).Start();
            }
        }

        /// <summary>
        /// Moves the mouse.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void ExecuteMove(int x, int y)
        {
            ExecuteMove(new Point(x, y));
        }
    }
}
