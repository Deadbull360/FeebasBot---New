using FeebasBot.Classes.Funcoes;
using FeebasBot.Properties;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Pesca
    {

        static public void minus(int x, int y)
        {
            foreach (Process proc in Mem.processes)
            {
                SendMessage(proc.MainWindowHandle, Win32.WM_MOUSEMOVE, (IntPtr)1, (IntPtr)Win32.MakeLParam(x, y)); // clica na água
                nw.PostMessage(proc.MainWindowHandle, Win32.WM_LBUTTONDOWN, 1, 0);
                int xa = x;
                while (xa != x - 10)
                {
                    SendMessage(proc.MainWindowHandle, Win32.WM_MOUSEMOVE, (IntPtr)1, (IntPtr)Win32.MakeLParam(xa, y)); // clica na água
                    xa -= 1;
                }
                Thread.Sleep(400);
                nw.PostMessage(proc.MainWindowHandle, Win32.WM_LBUTTONUP, 0, 0);
            }
        }

        static readonly System.IntPtr otpHandle = Win32.FindWindow("otPokemon", null);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public static bool Pescar()
        {
            bool pescou = false;
            //Mem.Memory();
            Mem.Fish();
            Chat.CheckChat();
            if (Setting.charx == Setting.LastX && Setting.chary == Setting.LastY)
            {
                IntPtr handle = Win32.FindWindow("otPokemon", null);
                int dir = 8;
                #region random
                Random rnd = new Random();
                if (Setting.randomfish == 1) { dir = rnd.Next(0, 8); }
                else { dir = 8; }

                int wx = Setting.WaterX, wy = Setting.WaterY;
                switch (dir)
                {
                    case 0:
                        wx += 64; //direita
                        break;
                    case 1:
                        wx -= 64; //esquerda
                        break;
                    case 2:
                        wy += 64; // baixo
                        break;
                    case 3:
                        wy -= 64; //cima
                        break;
                    case 4:
                        wx += 64; //direita
                        wy += 64; // baixo
                        break;
                    case 5:
                        wx -= 64; //esquerda
                        wy += 64; // baixo
                        break;
                    case 6:
                        wx += 64; //direita
                        wy -= 64; //cima
                        break;
                    case 7:
                        wx -= 64; //esquerda
                        wy -= 64; //cima
                        break;
                    case 8:
                        break;
                }
                #endregion
                int time = 0;
                Chat.CheckChat(true);
                Thread.Sleep(500);
                if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                //resetar seleção
                Win32.LeftClick(0, 0);
                //ativar vara
                foreach (Process proc in Mem.processes)
                {
                    nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.Scroll, 0);
                    nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.Scroll, 0);
                }
                Thread.Sleep(200);
                //clica na agua
                foreach (Process proc in Mem.processes)
                {
                    SendMessage(proc.MainWindowHandle, Win32.WM_MOUSEMOVE, (IntPtr)1, (IntPtr)Win32.MakeLParam(wx, wy)); // clica na água
                    nw.PostMessage(proc.MainWindowHandle, Win32.WM_LBUTTONDOWN, 1, 0);
                    nw.PostMessage(proc.MainWindowHandle, Win32.WM_LBUTTONUP, 0, 0);
                }
                Thread.Sleep(200);
                //salva a posição do char
                //Mem.Memory();
                Setting.LastX = Setting.charx;
                Setting.LastY = Setting.chary;
                Thread.Sleep(200);
                //reseta seleção
                Win32.LeftClick(0, 0);
                //detecta estado do peixe
                Mem.Fish();
                while (Setting.fish != 1600) //enquanto nao estiver verde
                {
                    Chat.CheckChat();
                    Mem.Fish(); //lê o peixe continuamente
                    if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                    Thread.Sleep(500);
                    //tempo de pesca
                    if (time < 20)
                    {
                        time++;
                    }
                    //se o tempo limite passar quebrar o loop
                    else break;
                }
                //Mem.Memory();
                //se a posicão do char for a mesma
                if (Setting.charx == Setting.LastX && Setting.chary == Setting.LastY)
                {
                    //se não tiver passado do tempo, puxar a vara
                    if (time < 20)
                    {
                        //total de pescas
                        Setting.pescados += 1;
                        FormsV.playResource(Resources.agua1);
                        //ativar vara e clicar na agua
                        foreach (Process proc in Mem.processes)
                        {
                            nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.Scroll, 0);
                            nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.Scroll, 0);
                            SendMessage(proc.MainWindowHandle, Win32.WM_MOUSEMOVE, (IntPtr)1, (IntPtr)Win32.MakeLParam(wx, wy)); // clica na água
                            nw.PostMessage(proc.MainWindowHandle, Win32.WM_LBUTTONDOWN, 1, 0);
                            nw.PostMessage(proc.MainWindowHandle, Win32.WM_LBUTTONUP, 0, 0);
                        }
                    }
                }
                //se tiver sido puxado
                else
                {
                    Setting.PlayerOnScreen = true;
                    if (Setting.FocusMove == 1) Win32.SetForegroundWindow(otpHandle);
                }
                //se n precisar targetar
                if (Setting.AtacarSemTarget == 1)
                { Ataque.MovesSemTarget(); }
                pescou = true;
            }
            else Setting.PlayerOnScreen = true;
            Chat.CheckChat(true);
            return pescou;
        }
    }
}
