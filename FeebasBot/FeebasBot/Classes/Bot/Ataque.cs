﻿using FeebasBot.Classes.Funcoes;
using FeebasBot.Properties;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Ataque
    {
        
        public static bool ConfigurarAtaque(int x, int y)
        {
            bool hp = false;
            int maxy = y + 100;
            bool stop = false;
            bool found = false;
            string color = getpixel.GrabPixel(x, y);
            Cursor.Position = new System.Drawing.Point(x, y);
            while (color != "0")
            {
                if (y >= maxy)
                {
                    stop = true;
                    break;
                }
                else
                {
                    y++;
                }
                color = getpixel.GrabPixel(x, y);
                if (color == "0")
                {
                    found = true;
                    break;
                }
            }
            while (color == "0")
            {
                if (stop)
                {
                    found = true;
                    break;
                }
                x--;
                color = getpixel.GrabPixel(x, y);
                if (color != "0")
                {
                    break;
                }
            }
            x++;
            if (stop == false)
            {
                Setting.BattleX = x;
                Setting.BattleY = y;
                Setting.TargetX = x;
                Setting.TargetY = y;
                Setting.TargetX2 = x;
                Setting.TargetY2 = y;
                MessageBox.Show("Barra de HP Salva!");
                hp = true;
            }
            else
            {
                MessageBox.Show("Barra de HP não encontrada!");
            }
            // "16777215"
            #region Target
            if (hp)
            {
                hp = false;
                DialogResult dialogResult = MessageBox.Show("Deseja tentar a configuração automatica da Batalha?\nCOLOQUE A OPACIDADE EM 100% PARA FUNCIONAR!!!", "Info", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Position = new System.Drawing.Point(x, y);
                    #region target1
                    x = Setting.TargetX;
                    y = Setting.TargetY;
                    int maxx = x - 100;
                    stop = false;
                    found = false;
                    win32.MoveMouse(Setting.BattleX, Setting.BattleY);
                    color = getpixel.GrabPixel(x, y);
                    while (color != "16777215")
                    {
                        if (x <= maxx)
                        {
                            stop = true;
                            MessageBox.Show("Pixel não encontrado, tente novamente, ou faça manualmente!");
                            break;
                        }
                        else
                        {
                            x--;
                        }
                        color = getpixel.GrabPixel(x, y);
                        if (color == "16777215")
                        {
                            found = true;
                            Setting.TargetX = x;
                            hp = true;
                            break;
                        }
                    }
                    #endregion
                    #region Target2
                    x = Setting.TargetX;
                    y = Setting.TargetY2;
                    maxy = y - 20;
                    stop = false;
                    found = false;
                    win32.MoveMouse(Setting.BattleX, Setting.BattleY);
                    color = getpixel.GrabPixel(x, y);
                    if (hp)
                    {
                        while (color != "2298123")
                        {
                            if (y <= maxy)
                            {
                                stop = true;
                                MessageBox.Show("Pixel não encontrado, tente novamente, ou faça manualmente!");
                                break;
                            }
                            else
                            {
                                y--;
                            }
                            color = getpixel.GrabPixel(x, y);
                            if (color == "2298123")
                            {
                                found = true;
                                Setting.TargetY2 = y + 1;
                                Setting.TargetX2 = x;
                                MessageBox.Show("Batalha Configurada!");
                                break;
                            }
                        }
                    }
                    #endregion
                }
            }
            #endregion
            return found;
        }
        public static void Atacar()
        {
            while (true)
            {
                if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                bool targeting = Verificacoes.Targetando();
                bool vivo = Verificacoes.PokeVivo();
                if (targeting == false && vivo == true)
                {
                    if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                    win32.LeftClick(Setting.BattleX, Setting.BattleY);
                    if (Setting.tries < Setting.triestotal)
                    {
                        if (Setting.Pescar == 1 )
                        {
                            Setting.tries++;
                        }                        
                    }
                    else { Setting.PlayerOnScreen = true; }
                    
                }
                Thread.Sleep(300);
                if (targeting == true)
                {
                    Setting.tries = 0;
                    Moves();
                }
                if (Verificacoes.PokeVivo() == false) break;
            }
        }
        static void Moves()
        {
            while (true)
            {
                if (Setting.PlayerOnScreen == true || Setting.Kill) { Thread.CurrentThread.Abort(); }
                Verificacoes.Targetar();
                if (Verificacoes.PokeVivo() == false) { break; }
                if (Setting.m1 == 1)
                {
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F1, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F1, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m2 == 1) { 
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F2, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F2, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m3 == 1) {
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F3, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F3, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m4 == 1) {
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F4, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F4, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m5 == 1) {
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F5, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F5, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m6 == 1) { 
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F6, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F6, 0);
                    } 
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m7 == 1) { 
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F7, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F7, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m8 == 1) { 
                    foreach (Process proc in Mem.processes) { 
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F8, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F8, 0);
                    } 
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m9 == 1) {
                    foreach (Process proc in Mem.processes) { 
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F9, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F9, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
                Verificacoes.Targetar();
                if (Setting.m10 == 1) { 
                    foreach (Process proc in Mem.processes) {
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYDOWN, (int)Keys.F10, 0);
                        nw.PostMessage(proc.MainWindowHandle, nw.WM_KEYUP, (int)Keys.F10, 0);
                    }
                }
                if (Verificacoes.PokeVivo() == false) { break; }
                Thread.Sleep(Setting.attacktime);
            }
        }
        public static void MovesSemTarget()
        {
            if (Setting.m1 == 1) { win32.SendKeys(Keys.F1); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m2 == 1) { win32.SendKeys(Keys.F2); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m3 == 1) { win32.SendKeys(Keys.F3); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m4 == 1) { win32.SendKeys(Keys.F4); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m5 == 1) { win32.SendKeys(Keys.F5); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m6 == 1) { win32.SendKeys(Keys.F6); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m7 == 1) { win32.SendKeys(Keys.F7); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m8 == 1) { win32.SendKeys(Keys.F8); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m9 == 1) { win32.SendKeys(Keys.F9); }
            Thread.Sleep(Setting.attacktime);
            if (Setting.m10 == 1) { win32.SendKeys(Keys.F10); }
        }
    }
}
