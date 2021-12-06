using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace FeebasBot.Classes.Funcoes
{
    class updater
    {

        static string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            //Return the information we've gathered.
            return operatingSystem;
        }
        //http://atm6.duckdns.org:25565/feebas
        public static void update() { }
        public static void updatea()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile("http://atm6.duckdns.org:25565/feebas", "up.txt");
                    client.DownloadFile("http://atm6.duckdns.org:25565/Updater.exe", "Updater.exe");
                }
                catch { }
            }
            Setting.newversion = int.Parse(File.ReadAllText("up.txt"));
            try
            {
                File.Delete("up.txt");
            }
            catch (Exception)
            {
            }

            if (Setting.newversion > Setting.version)
            {
                if (int.Parse(getOSInfo()) > 7)
                {
                    //Setting.version = Setting.newversion;
                    //Setting.SaveSettings();
                    MessageBox.Show("Nova versão disponivel, tentando atualizador automatico\nse falhar, baixe a nova versão no link do discord");
                    Process.Start("Updater.exe");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Nova versão disponivel, como você usa Windows 7, baixe no grupo do Discord");
                }
            }
        }
    }
}
