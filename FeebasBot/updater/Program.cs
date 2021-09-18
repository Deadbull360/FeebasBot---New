using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace updater
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"update.zip";
            string extractPath = @".";
            Thread.Sleep(2000);
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath, true);
            File.Delete("update.zip");
        }
    }
}
