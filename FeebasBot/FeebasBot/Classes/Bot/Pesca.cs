using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Pesca
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public static bool Pescar()
        {
            bool pescou = false;
            Mem.Memory();
            Mem.Fish();
            Chat.CheckChat();
            if (Setting.charx == Setting.LastX && Setting.chary == Setting.LastY)
            {
                IntPtr handle = win32.FindWindow("otPokemon", null);
                int dir = 8;
                #region random
                Random rnd = new Random();
                if (Setting.randomfish == 1)
                {
                    dir = rnd.Next(0, 8);
                }
                else
                {
                    dir = 8;
                }

                int wx = Setting.WaterX, wy = Setting.WaterY;
                switch (dir)
                {
                    case 0:
                        wx = wx + 64; //direita
                        break;
                    case 1:
                        wx = wx - 64; //esquerda
                        break;
                    case 2:
                        wy = wy + 64; // baixo
                        break;
                    case 3:
                        wy = wy - 64; //cima
                        break;
                    case 4:
                        wx = wx + 64; //direita
                        wy = wy + 64; // baixo
                        break;
                    case 5:
                        wx = wx - 64; //esquerda
                        wy = wy + 64; // baixo
                        break;
                    case 6:
                        wx = wx + 64; //direita
                        wy = wy - 64; //cima
                        break;
                    case 7:
                        wx = wx - 64; //esquerda
                        wy = wy - 64; //cima
                        break;
                    case 8:
                        break;
                }
                #endregion
                int time = 0;
                Chat.CheckChat();
                Thread.Sleep(500);

                if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                Setting.clicklock = true;
                win32.LeftClickLocked(0, 0);
                //IntPtr now = win32.GetForegroundWindow();
                //MessageBox.Show(now.ToString());
                //win32.SetForegroundWindow(handle);
                //win32.LeftClickOld(win32.FindWindow("otPokemon", null), Setting.RodX, Setting.RodY);//clicar na vara            
                foreach (Process proc in Mem.processes)
                {
                    nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.Scroll, 0);
                    nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.Scroll, 0);
                }
                //win32.LeftClick(Setting.RodX, Setting.RodY);
                Thread.Sleep(200);
                //win32.LeftClickOld(win32.FindWindow("otPokemon", null), wx, wy);//clicar na agua
                //win32.LeftClick(wx, wy);//clicar na agua

                foreach (Process proc in Mem.processes)
                {
                    SendMessage(proc.MainWindowHandle, win32.WM_MOUSEMOVE, (IntPtr)1, (IntPtr)win32.MakeLParam(wx, wy)); // clica na água
                    nw.PostMessage(proc.MainWindowHandle, win32.WM_LBUTTONDOWN, 1, 0);
                    nw.PostMessage(proc.MainWindowHandle, win32.WM_LBUTTONUP, 0, 0);
                }
                Thread.Sleep(200);

                Mem.Memory();
                Setting.LastX = Setting.charx;
                Setting.LastY = Setting.chary;
                //win32.LeftClick(wx, wy);
                //win32.SetForegroundWindow(now);
                Thread.Sleep(200);
                win32.LeftClickLocked(0, 0);
                Setting.clicklock = false;
                //string startcolor = Verificacoes.FishColor();
                //string colornow = Verificacoes.FishColor();
                //while (colornow == startcolor)
                //{
                //    if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                //    Thread.Sleep(500);
                //    if (time < 20)
                //    {
                //        //colornow = Convert.ToString(getpixel.GetPixel(getpixel.GetWindowDC(getpixel.GetDesktopWindow()), Setting.FishX, Setting.FishY));
                //        colornow = Verificacoes.FishColor();
                //        time++;
                //    }
                //    else
                //    {
                //        colornow = "0";
                //    }
                //}
                Mem.Fish();
                while (Setting.fish != 1600)
                {
                    Mem.Fish();
                    if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                    Thread.Sleep(500);
                    if (time < 20)
                    {
                        time++;
                    }
                    else break;
                }
                if (time < 20)
                {
                    Setting.pescados += 1;
                    Mem.Memory();
                    if (Setting.charx == Setting.LastX && Setting.chary == Setting.LastY)
                    {
                        //win32.LeftClick(Setting.FishX, Setting.FishY); 
                        foreach (Process proc in Mem.processes)
                        {
                            nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.Scroll, 0);
                            nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.Scroll, 0);
                            SendMessage(proc.MainWindowHandle, win32.WM_MOUSEMOVE, (IntPtr)1, (IntPtr)win32.MakeLParam(wx, wy)); // clica na água
                            nw.PostMessage(proc.MainWindowHandle, win32.WM_LBUTTONDOWN, 1, 0);
                            nw.PostMessage(proc.MainWindowHandle, win32.WM_LBUTTONUP, 0, 0);
                        }
                    }
                    win32.MoveMouse(0, 0);
                }
                if (Setting.AtacarSemTarget == 1)
                { Ataque.MovesSemTarget(); }
                pescou = true;
            }
            else Setting.PlayerOnScreen = true;
            return pescou;
        }
    }
}
