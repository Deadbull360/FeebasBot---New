using System.Threading;

namespace FeebasBot.Classes.Bot
{
    class Catch
    {
        static readonly int position = (Setting.SQMBY - Setting.PlayerY);
        public static void JogarBall()
        {
            if (Setting.PodeCapturar == 1 && Setting.catchpoke == 1 && Setting.LoggedIn == true)
            {
                Setting.clicklock = true;
                Win32.LeftClickLocked(0, 0);
                Win32.RightClickLocked(Setting.pokeballX, Setting.pokeballY);
                Thread.Sleep(200);
                Win32.LeftClickLocked(Setting.SQMBX, Setting.SQMBY);
                Thread.Sleep(1000);
                Win32.RightClickLocked(Setting.pokeballX, Setting.pokeballY);
                Thread.Sleep(200);
                Win32.LeftClickLocked(Setting.SQMBX - position, Setting.SQMBY);
                Thread.Sleep(1000);
                Win32.RightClickLocked(Setting.pokeballX, Setting.pokeballY);
                Thread.Sleep(200);
                Win32.LeftClickLocked(Setting.SQMBX + position, Setting.SQMBY);
                if (Setting.Lootear == 0)
                {
                    Thread.Sleep(300);
                    Win32.LeftClickLocked(Setting.OrderX, Setting.OrderY);
                    Thread.Sleep(200);
                    Win32.LeftClickLocked(Setting.SQMBX, Setting.SQMBY);
                    Thread.Sleep(300);
                }
                //if (Setting.PescarSemParar == 0) Posicionar();
                Setting.clicklock = false;
            }
        }
    }
}
