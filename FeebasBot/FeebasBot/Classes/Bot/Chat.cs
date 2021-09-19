using FeebasBot.Classes.Funcoes;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Chat
    {
        static System.IntPtr otpHandle = win32.FindWindow("otPokemon", null);
        public static void ChatCoords(int x, int y)
        {
            #region left
            string color = getpixel.GrabPixel(x, y);
            int xn = x;
            int yn = y;
            int maxdiff = 100;
            int maxxn = xn - maxdiff;
            while (true)
            {
                xn--;
                if (xn == maxxn) { MessageBox.Show("erro"); break; }
                color = getpixel.GrabPixel(xn, yn);
                if (xn == xn - maxdiff) { MessageBox.Show("Cor não encontrada!"); break; }
                if (color == "5003617") break;
                if (color == "5922662") break;
            }
            Setting.ChatEsquerdaX = xn;
            #endregion

            #region right
            xn = x;
            yn = y;
            maxdiff = 100;
            maxxn = xn + maxdiff;
            while (true)
            {
                xn++;
                if (xn == maxxn) { MessageBox.Show("erro"); break; }
                color = getpixel.GrabPixel(xn, yn);
                if (xn == xn + maxdiff) { MessageBox.Show("Cor não encontrada!"); break; }
                if (color == "5003617") break;
                if (color == "5922662") break;
            }
            Setting.ChatDireitaX = xn;
            #endregion
        }
        public static void CheckChat()
        {
            if (Setting.Chat == 1216)
            {
                if (Setting.ChatStop == 1 || Setting.CaveChat == 1)
                {
                    Setting.PlayerOnScreen = true;
                    Setting.Kill = true;
                }
                if (Setting.FocusChat == 1) win32.SetForegroundWindow(otpHandle);
            }
        }
        public static void CheckChat(bool audio)
        {
            if (Setting.Chat == 1216 && audio == true) FormsV.playSound("chat.wav");
        }
    }
}
