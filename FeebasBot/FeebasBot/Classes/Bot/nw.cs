using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class nw
    {
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYUP = 0x0101;

        public static void clear()
        {
            foreach (Process proc in Mem.processes)
            {
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.D, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.W, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.S, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.A, 0);
            }
        }
        public static void right()
        {
            foreach (Process proc in Mem.processes)
            {
                PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)Keys.D, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.D, 0);
            }
        }

        public static void left()
        {
            foreach (Process proc in Mem.processes)
            {
                PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)Keys.A, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.A, 0);
            }
        }

        public static void down()
        {
            foreach (Process proc in Mem.processes)
            {
                PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)Keys.S, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.S, 0);
            }
        }

        public static void up()
        {
            foreach (Process proc in Mem.processes)
            {
                PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)Keys.W, 0);
                PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)Keys.W, 0);
            }
        }
    }
}

