using System;
using System.Diagnostics;

namespace FeebasBot.Classes.Funcoes
{
    class Rdn
    {
        public static int Radn()
        {
            int dir = 0;
            Random rnd = new Random();
            dir = rnd.Next(0, 2);
            return dir;
        }
        static public string randomname()
        {
            int i = 0;
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
                i += 1;
            int a = 0;
            Random rnd = new Random();
            a = rnd.Next(0, i);
            return (processCollection[a].ProcessName.ToString());
        }
    }
}