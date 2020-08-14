using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;

namespace Twip.Class.Keyboard
{

    /// <summary>
    /// Captures global keyboard events
    /// </summary>
    public class KeyboardHook : GlobalHook
    {
        public class NotInputKey
        {
            public Keys key;
            public TimeSpan timeOut;
            public TimeSpan time;
        }
        public List<NotInputKey> notInputKeys = new List<NotInputKey>();

        public void AddNotInputKey(char key, int time)
        {
            Keys tempKey = (Keys)Enum.Parse(typeof(Keys), char.ToString(key).ToUpper());

            foreach (var item in notInputKeys)
            {
                if (tempKey == item.key)
                {
                    item.timeOut += TimeSpan.FromMilliseconds(time);
                    return ;
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

        #region Events

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event KeyPressEventHandler KeyPress;

        #endregion

        #region Constructor

        public KeyboardHook()
        {
            _hookType = WH_KEYBOARD_LL;
        }

        #endregion

        #region Methods

        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {

            bool handled = false;

            if (nCode > -1 && (KeyDown != null || KeyUp != null || KeyPress != null))
            {

                KeyboardHookStruct keyboardHookStruct =
                    (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                // Is Control being held down?
                bool control = ((GetKeyState(VK_LCONTROL) & 0x80) != 0) ||
                               ((GetKeyState(VK_RCONTROL) & 0x80) != 0);

                // Is Shift being held down?
                bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
                             ((GetKeyState(VK_RSHIFT) & 0x80) != 0);

                // Is Alt being held down?
                bool alt = ((GetKeyState(VK_LALT) & 0x80) != 0) ||
                           ((GetKeyState(VK_RALT) & 0x80) != 0);

                // Is CapsLock on?
                bool capslock = (GetKeyState(VK_CAPITAL) != 0);

                // Create event using keycode and control/shift/alt values found above
                KeyEventArgs e = new KeyEventArgs(
                    (Keys)(
                        keyboardHookStruct.vkCode |
                        (control ? (int)Keys.Control : 0) |
                        (shift ? (int)Keys.Shift : 0) |
                        (alt ? (int)Keys.Alt : 0)
                        ));

                // Handle KeyDown and KeyUp events
                bool isNotInputKey = false;
                switch (wParam)
                {

                    case WM_KEYDOWN:
                    case WM_SYSKEYDOWN:
                        if (KeyDown != null)
                        {
                            foreach (var item in notInputKeys)
                            {
                                if (e.KeyCode == item.key)
                                {
                                    handled = true;
                                    isNotInputKey = true;
                                    break;
                                }
                            }
                            if (isNotInputKey == false)
                            {
                                KeyDown(this, e);
                                handled = handled || e.Handled;
                            }
                        }
                        break;
                    case WM_KEYUP:
                    case WM_SYSKEYUP:
                        if (KeyUp != null)
                        {
                            KeyUp(this, e);
                            handled = handled || e.Handled;
                        }
                        break;

                }

                // Handle KeyPress event
                if (wParam == WM_KEYDOWN &&
                   !handled &&
                   !e.SuppressKeyPress &&
                    KeyPress != null)
                {

                    byte[] keyState = new byte[256];
                    byte[] inBuffer = new byte[2];
                    GetKeyboardState(keyState);

                    if (ToAscii(keyboardHookStruct.vkCode,
                              keyboardHookStruct.scanCode,
                              keyState,
                              inBuffer,
                              keyboardHookStruct.flags) == 1)
                    {

                        char key = (char)inBuffer[0];
                        if ((capslock ^ shift) && Char.IsLetter(key))
                            key = Char.ToUpper(key);
                        KeyPressEventArgs e2 = new KeyPressEventArgs(key);
                        KeyPress(this, e2);
                        handled = handled || e.Handled;

                    }

                }

            }

            if (handled)
            {
                return 1;
            }
            else
            {
                return CallNextHookEx(_handleToHook, nCode, wParam, lParam);
            }

        }

        #endregion

    }

}
