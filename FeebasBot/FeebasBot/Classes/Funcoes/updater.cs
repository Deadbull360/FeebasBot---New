using FeebasBot.Telas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeebasBot.Classes.Funcoes
{
    class updater
    {
        //http://atm6.duckdns.org:25565/feebas
        public static void update()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://atm6.duckdns.org:25565/feebas", "up.txt");
            }
            
            Setting.newversion = int.Parse(File.ReadAllText("up.txt"));
            
            File.Delete("up.txt");
            if (Setting.newversion > Setting.version)
            {
                Setting.version = Setting.newversion;
                Setting.SaveSettings();
                MessageBox.Show(Setting.newversion.ToString());
                MessageBox.Show(Setting.version.ToString());
                Process.Start("Updater.exe");
                Application.Exit();
            }
        }
    }
}
