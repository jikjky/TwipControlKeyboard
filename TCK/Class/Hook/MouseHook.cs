using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;

namespace TCK.Class.Hook
{

    /// <summary>
    /// Captures global mouse events
    /// </summary>
    public class MouseHook : GlobalHook
    {
        public class NotInputKey
        {
            public Keys key;
            public TimeSpan timeOut;
            public TimeSpan time;
        }
        public List<NotInputKey> notInputKeys = new List<NotInputKey>();

        public void AddNotInputKey(Keys key, int time)
        {
            Keys tempKey = key;

            foreach (var item in notInputKeys)
            {
                if (tempKey == item.key)
                {
                    item.timeOut += TimeSpan.FromMilliseconds(time);
                    return;
                }
            }

            NotInputKey inputKey = new NotInputKey();
            inputKey.key = tempKey;
            inputKey.timeOut += TimeSpan.FromMilliseconds(time);
            notInputKeys.Add(inputKey);
            new Thread(() =>
            {
                DateTime objCurrentTime = new DateTime();
                objCurrentTime = DateTime.Now;

                while (true)
                {
                    inputKey.time = DateTime.Now - objCurrentTime;
                    if (inputKey.time > inputKey.timeOut)
                    {
                        break;
                    }
                    Thread.Sleep(10);
                }
                notInputKeys.Remove(inputKey);
            })
            { IsBackground = true }.Start();

        }

        #region MouseEventType Enum

        private enum MouseEventType
        {
            None,
            MouseDown,
            MouseUp,
            DoubleClick,
            MouseWheel,
            MouseMove
        }

        #endregion

        #region Events

        public event MouseEventHandler MouseDown;
        public event MouseEventHandler MouseUp;
        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseWheel;

        public event EventHandler Click;
        public event EventHandler DoubleClick;

        #endregion

        #region Constructor

        public MouseHook()
        {

            _hookType = WH_MOUSE_LL;

        }

        #endregion

        #region Methods

        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            
            if (nCode > -1 && (MouseDown != null || MouseUp != null || MouseMove != null))
            {

                MouseLLHookStruct mouseHookStruct =
                    (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

                MouseButtons button = GetButton(wParam);
                MouseEventType eventType = GetEventType(wParam);

                if (eventType == MouseEventType.MouseMove)
                {
                    return CallNextHookEx(_handleToHook, nCode, wParam, lParam);
                }

                MouseEventArgs e = new MouseEventArgs(
                    button,
                    (eventType == MouseEventType.DoubleClick ? 2 : 1),
                    mouseHookStruct.pt.x,
                    mouseHookStruct.pt.y,
                    (eventType == MouseEventType.MouseWheel ? (short)((mouseHookStruct.mouseData >> 16) & 0xffff) : 0));

                // Prevent multiple Right Click events (this probably happens for popup menus)
                if (button == MouseButtons.Right && mouseHookStruct.flags != 0)
                {
                    eventType = MouseEventType.None;
                }

                foreach (var item in notInputKeys)
                {
                    if (item.key == Keys.LButton && button == MouseButtons.Left)
                    {
                        return 1;
                    }
                    else if (item.key == Keys.RButton && button == MouseButtons.Right)
                    {
                        return 1;
                    }
                    else if (item.key == Keys.MButton && button == MouseButtons.Middle)
                    {
                        return 1;
                    }
                    else if (item.key == Keys.XButton1 && button == MouseButtons.XButton1)
                    {
                        return 1;
                    }
                    else if (item.key == Keys.XButton2 && button == MouseButtons.XButton2)
                    {
                        return 1;
                    }
                }

                switch (eventType)
                {
                    case MouseEventType.MouseDown:
                        if (MouseDown != null)
                        {
                            MouseDown(this, e);
                        }
                        break;
                    case MouseEventType.MouseUp:
                        if (Click != null)
                        {
                            Click(this, new EventArgs());
                        }
                        if (MouseUp != null)
                        {
                            MouseUp(this, e);
                        }
                        break;
                    case MouseEventType.DoubleClick:
                        if (DoubleClick != null)
                        {
                            DoubleClick(this, new EventArgs());
                        }
                        break;
                    case MouseEventType.MouseWheel:
                        if (MouseWheel != null)
                        {
                            MouseWheel(this, e);
                        }
                        break;
                    case MouseEventType.MouseMove:
                        if (MouseMove != null)
                        {
                            MouseMove(this, e);
                        }
                        break;
                    default:
                        break;
                }
                
            }

            return CallNextHookEx(_handleToHook, nCode, wParam, lParam);

        }

        private MouseButtons GetButton(Int32 wParam)
        {

            switch (wParam)
            {

                case WM_LBUTTONDOWN:
                case WM_LBUTTONUP:
                case WM_LBUTTONDBLCLK:
                    return MouseButtons.Left;
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                case WM_RBUTTONDBLCLK:
                    return MouseButtons.Right;
                case WM_MBUTTONDOWN:
                case WM_MBUTTONUP:
                case WM_MBUTTONDBLCLK:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;

            }

        }

        private MouseEventType GetEventType(Int32 wParam)
        {

            switch (wParam)
            {

                case WM_LBUTTONDOWN:
                case WM_RBUTTONDOWN:
                case WM_MBUTTONDOWN:
                    return MouseEventType.MouseDown;
                case WM_LBUTTONUP:
                case WM_RBUTTONUP:
                case WM_MBUTTONUP:
                    return MouseEventType.MouseUp;
                case WM_LBUTTONDBLCLK:
                case WM_RBUTTONDBLCLK:
                case WM_MBUTTONDBLCLK:
                    return MouseEventType.DoubleClick;
                case WM_MOUSEWHEEL:
                    return MouseEventType.MouseWheel;
                case WM_MOUSEMOVE:
                    return MouseEventType.MouseMove;
                default:
                    return MouseEventType.None;

            }
        }

        #endregion
        
    }

}
