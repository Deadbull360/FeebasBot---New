using FeebasBot.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FeebasBot.Telas
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            
        }
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (progressBar1.Value == 100)
                button1.Enabled = true;
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            
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
        }

        private void button1_Click(object sender, EventArgs e)
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
