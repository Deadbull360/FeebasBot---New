using FeebasBot.Classes;
using FeebasBot.Classes.Bot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeebasBot.Telas
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            X.Text = "Char X: " + Setting.charx;
            Y.Text = "Char Y: " + Setting.chary;
            PokeHP.Text = "PokeHP: " + Setting.PokeHP;
            CharHP.Text = "CharHP: " + Setting.CharHP;
            string f="";
            if (Setting.fish == 5632) f = "Oculto";
            if (Setting.fish == 1536) f = "Esperando";
            if (Setting.fish == 1600) f = "Pescou";
            string ff = "";
            if (Setting.Chat == 1152) ff = "Sem mensagem";
            if (Setting.Chat == 1216) ff = "Com mensagem";
            if (Setting.Chat == 1186) ff = "Focado";
            fish.Text = "Peixe: " + f;
            pescados.Text = "Pesca total: " + Setting.pescados.ToString();
            chat.Text = "Chat Padrão: " + ff;
        }

        private void Info_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                win32.ReleaseCapture();
                win32.SendMessage(Handle, win32.WM_NCLBUTTONDOWN, win32.HT_CAPTION, 0);
            }
        }
    }
}
