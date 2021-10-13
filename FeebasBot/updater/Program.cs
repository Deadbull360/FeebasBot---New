using System;
using System.IO;
using System.Net;
using System.Threading;

namespace updater
{
    class Program
    {


        static void Main()
        {
            int down = 0;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("http://atm6.duckdns.org:25565/feebas.zip"),
                    // Param2 = Path to save
                    "update.zip"
                );
            }

            void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                down = e.ProgressPercentage;
            }
            while (down != 100)
            {
                Console.Clear();
                Console.Write("Downloading: " + down + "%");
                Thread.Sleep(200);
            }
            Console.Clear();
            Console.WriteLine("Downloading: 100%");
            Console.WriteLine("Extraindo");
            string zipPath = @"update.zip";
            string extractPath = @".";
            Thread.Sleep(2000);
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath, true);
            Thread.Sleep(2000);
            File.Delete("update.zip");
        }
    }
}
