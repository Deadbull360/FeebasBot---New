﻿using System.Threading;

namespace FeebasBot.Classes.Bot
{
    class TrocaDePoke
    {
        public static void VerificarMorto()
        {
            if (Setting.PodeUsarTrocaDePokemon == 1 && Setting.LoggedIn == true)
            {
                string px = getpixel.GrabPixel(Setting.PortraitX, Setting.PortraitY);
                if (px == Setting.portraitdead) TrocarDePokemon();
                //MessageBox.Show(Setting.portraitdead + ":" + px + "\n" + Setting.poke);
                Setting.verificandopoke = false;
            }
        }
        public static void TrocarDePokemon()
        {
            while (true)
            {
                //MessageBox.Show(Setting.poke.ToString());
                if (Setting.poke == 0) Setting.poke++;
                if (Setting.poke > 6) Setting.poke = 1;
                if (Setting.Kill == true) { Thread.CurrentThread.Abort(); }
                Setting.clicklock = true;
                if (Setting.poke == 1)
                { Thread.Sleep(700); Win32.LeftClickLocked(Setting.Poke1X, Setting.Poke1Y); Thread.Sleep(1000); Setting.poke++; break; }
                if (Setting.poke == 2)
                { Thread.Sleep(700); Win32.LeftClickLocked(Setting.Poke2X, Setting.Poke2Y); Thread.Sleep(1000); Setting.poke++; break; }
                if (Setting.poke == 3)
                { Thread.Sleep(700); Win32.LeftClickLocked(Setting.Poke3X, Setting.Poke3Y); Thread.Sleep(1000); Setting.poke++; break; }
                if (Setting.poke == 4)
                { Thread.Sleep(700); Win32.LeftClickLocked(Setting.Poke4X, Setting.Poke4Y); Thread.Sleep(1000); Setting.poke++; break; }
                if (Setting.poke == 5)
                { Thread.Sleep(700); Win32.LeftClickLocked(Setting.Poke5X, Setting.Poke5Y); Thread.Sleep(1000); Setting.poke++; break; }
                if (Setting.poke == 6)
                { Thread.Sleep(700); Win32.LeftClickLocked(Setting.Poke6X, Setting.Poke6Y); Thread.Sleep(1000); Setting.poke++; break; }
            }
            Setting.clicklock = false;
        }
    }
}
