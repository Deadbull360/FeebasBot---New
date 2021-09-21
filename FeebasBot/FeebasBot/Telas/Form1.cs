using FeebasBot.Classes;
using FeebasBot.Classes.Bot;
using FeebasBot.Classes.Funcoes;
using FeebasBot.Forms;
using FeebasBot.Telas;
//using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot
{
    public partial class Form1 : Form
    {
        #region Form
        #region Form Functions
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.SaveSettings();
            Setting.Kill = true;
            Run.Stop();
            IntPtr otpHandle = win32.FindWindow("otPokemon", null);
            //win32.SetWindowText(otpHandle, "otPokemon");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mem.Battle();
            if (Setting.cavefile == null) Setting.cavefile = "cavebot.sqlite";
            if(Setting.version == 0) Setting.version = 3;
            updater.update();
            Mem.startmem();
            Mem.Fish();
            Mem.Memory();
            //label1.Text = Setting.result.ToString();
            IntPtr otpHandle = win32.FindWindow("otPokemon", null);
            Setting.click = false;
            Setting.clicklock = false;
            //if (Setting.login != "") Login();
            Setting.GameName = win32.GetActiveWindowTitle();
            textBox1.Text = Setting.GameName;
            //IntPtr bothandle = win32.FindWindow("otPokemon", null + "Bot");
            //if (bothandle != IntPtr.Zero) { MessageBox.Show("Renomeie o Client Anteior antes de abrir mais um bot!"); Application.Exit(); }
            this.Text = "svchost";
            IntPtr otphandle = win32.FindWindow("otPokemon", null);
            //if (otphandle == IntPtr.Zero) { MessageBox.Show("otPokemon não está aberto!"); Application.Exit(); }
            ghk = new KeyHandler(Keys.Insert, this);
            ghk.Register();
            Setting.LoggedIn = true;
            Setting.PodeUsarCaveBot = 1;
            Setting.PodeUsarLooting = 1;
            Setting.PodeUsarTrocaDePokemon = 1;
            Setting.PodeCapturar = 1;
            Setting.login = "Free Premium";
        }
        private KeyHandler ghk;
        private void HandleHotkey()
        {
            Setting.UseHk = true;
            Looting.AbrirCorpos();
            Setting.UseHk = false;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                win32.ReleaseCapture();
                win32.SendMessage(Handle, win32.WM_NCLBUTTONDOWN, win32.HT_CAPTION, 0);
            }
        }
        #endregion
        #region Buttons
        private void bClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        private void bConfig_Click(object sender, EventArgs e)
        {
            Configuracao configuracao = new Configuracao();
            if (FormsV.CheckOpened("Configuracao"))
            {
                configuracao.Close();
            }
            else
            {
                configuracao.Show();
            }
        }
        private void bCave_Click(object sender, EventArgs e)
        {
            CaveBot cavebot = new CaveBot();
            if (FormsV.CheckOpened("CaveBot"))
            {
                cavebot.Close();
            }
            else
            {
                if (Setting.PodeUsarCaveBot == 1)
                {
                    cavebot.Show();
                }
                else { MessageBox.Show("Função Bloqueada!"); }
            }
        }
        #region Login
        //String firstMacAddress = NetworkInterface
        //    .GetAllNetworkInterfaces()
        //    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
        //    .Select(nic => nic.GetPhysicalAddress().ToString())
        //    .FirstOrDefault();
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataReader dr;
        //private void Login()
        //{
        //    int server = 0;
        //    int puc=0,pul=0,put=0,pc=0;
        //    string mac = "";
        //    string my = "Server=sql10.freemysqlhosting.net;Database=;user=;Pwd=;SslMode=none";
        //    con = new MySqlConnection(my);
        //    cmd = new MySqlCommand();
        //    try
        //    {
        //        con.Open();
        //        server = 1;
        //    }
        //    catch (Exception)
        //    {
        //        Setting.LoggedIn = true;
        //        Setting.PodeUsarCaveBot = 1;
        //        Setting.PodeUsarLooting = 1;
        //        Setting.PodeUsarTrocaDePokemon = 1;
        //        Setting.PodeCapturar = 1;
        //    }
        //    if (server == 1)
        //    {
        //        cmd.Connection = con;
        //        cmd.CommandText = "SELECT * FROM users where User='" + Setting.login + "'";
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            mac = Convert.ToString(dr.GetValue(2));
        //            puc = Convert.ToInt32(dr.GetValue(1));
        //            pul = Convert.ToInt32(dr.GetValue(3));
        //            put = Convert.ToInt32(dr.GetValue(7));
        //            pc = Convert.ToInt32(dr.GetValue(6));
        //        }
        //        con.Close();
        //        //MessageBox.Show(Convert.ToString(mac) + "\n" + Convert.ToString(firstMacAddress));
        //        if (mac == firstMacAddress)
        //        {
        //            Setting.LoggedIn = true;
        //            Setting.PodeUsarCaveBot = puc;
        //            Setting.PodeUsarLooting = pul;
        //            Setting.PodeUsarTrocaDePokemon = put;
        //            Setting.PodeCapturar = pc;
        //            //MessageBox.Show("Logado com sucesso!");
        //        }
        //        else if (mac == "0")
        //        {
        //            con.Open();
        //            cmd.CommandText = "UPDATE users SET MAC='" + firstMacAddress + "' WHERE User='" + Setting.login + "'";
        //            cmd.ExecuteNonQuery();
        //            Setting.LoggedIn = true;
        //            //MessageBox.Show("Logado com sucesso!");
        //        }
        //        else if (mac != firstMacAddress && mac != "0" && mac != "")
        //        {
        //            MessageBox.Show("Computador diferente do cadastrado no sistema\nComunicar o Desenvolvedor!", "Informação", MessageBoxButtons.OK);
        //        }
        //        con.Close();
        //    }
        //}
        #endregion
        #endregion
        #endregion
        #region Variaveis
        bool Pescando = false;
        bool Pescou = false;

        #endregion
        private void bStart_Click(object sender, EventArgs e)
        {
            Mem.Memory();
            Chat.CheckChat();
            if (Setting.Chat == 1186) MessageBox.Show("Você está com o chat Padrão focado, troque para o chat do servidor \n para que a detecção funcione corretamente");
            Setting.LastX = Setting.charx;
            Setting.LastY = Setting.chary;
            if (Setting.TrocarDePokemon == 1) { Troca.Start(); }
            Setting.verificandopoke = false;
            Setting.Kill = false;
            Pescando = false;
            Pescou = false;
            bStart.ForeColor = Color.Green;
            Setting.PlayerOnScreen = false;
            Setting.Running = true;
            Run.Start();
        }
        void pescar()
        {
            if (Setting.Lootear == 1) Looting.AbrirCorpos();
            Pesca.Pescar();
            Pescando = false;
        }
        private void bStop_Click(object sender, EventArgs e)
        {
            Setting.Kill = true;
            Run.Stop();
            Troca.Stop();
            bStart.ForeColor = Color.Red;
        }
        void start()
        {

            if (Setting.PescarSemParar == 1) { Setting.triestotal = 30; }
            else { Setting.triestotal = 7; }
            if (Setting.PlayerOnScreen == false)
            {
                if (Setting.Atacar == 1 && Setting.AtacarSemTarget == 0)
                {
                    Ataque.Atacar();
                }
                if (Setting.Pescar == 1 && Setting.PescarSemParar == 0)
                {
                    if (Setting.Lootear == 1) Looting.AbrirCorpos();
                    if (Setting.catchpoke == 1) Catch.JogarBall();
                    Pesca.Pescar();
                }
                Setting.tries = 0;
                if (Setting.Atacar == 1)
                {
                    if (Setting.AtacarSemTarget == 0)
                    { Ataque.Atacar(); }
                }
                Setting.Running = true;
            }
            Chat.CheckChat();
        }



        private void Run_Tick(object sender, EventArgs e)
        {
            if (Setting.Pescar == 1 && Setting.PescarSemParar == 1)
            {
                Thread thread2 = new Thread(pescar);
                if (Pescando == false) thread2.Start();
                Pescando = true;
            }
            Thread thread = new Thread(start);
            if (Setting.Running)
            {
                Setting.Running = false;
                thread.Start();
            }
            if (Setting.PlayerOnScreen == true)
            {
                Setting.Kill = true;
                Run.Stop();
                Troca.Stop();
                bStart.ForeColor = Color.Red;
                //FormsV.playSound("alarm.wav");
                if (Setting.CaveChat == 1 || Setting.CavePlayer == 1)
                {
                    if (Setting.LoggedIn = true && Setting.PodeUsarCaveBot == 1)
                    {
                        CaveBot caveBot = new CaveBot();
                        caveBot.Show();
                        caveBot.button2_Click(sender, e);
                        caveBot.Hide();
                    }
                }
            }
            //Thread.Sleep(200);
        }

        private void Open_Tick(object sender, EventArgs e)
        {
            Thread chatmem = new Thread(Mem.Chat);
            if (!chatmem.IsAlive) chatmem.Start();
            this.Text = "svchost";
            //label1.Text = "Feebasbot";
            //if (Setting.GameName != "otPokemon") { label1.Text = Setting.GameName; }
            string a = "Clique duas vezes para abrir a janela do bot!\nChar: " + Setting.GameName;
            if (a.Length < 64)
            {
                nIcon.Text = "Clique duas vezes para abrir a janela do bot!\nChar: " + Setting.GameName;
            }
        }
        int f = 0;
        private void Troca_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(TrocaDePoke.VerificarMorto);
            if (Setting.verificandopoke == false) { thread.Start(); Setting.verificandopoke = true; if (f == 0) Thread.Sleep(3000); f = 1; }
            if (Setting.PlayerOnScreen == true)
            {
                Setting.Kill = true;
                Troca.Stop();
                Run.Stop();
                bStart.ForeColor = Color.Red;
                //FormsV.playSound("alarm.wav");
                if (Setting.CaveChat == 1 || Setting.CavePlayer == 1)
                {
                    if (Setting.LoggedIn = true && Setting.PodeUsarCaveBot == 1)
                    {
                        CaveBot caveBot = new CaveBot();
                        caveBot.Show();
                        caveBot.button2_Click(sender, e);
                        caveBot.Hide();
                    }
                }
            }
        }

        private void stop_Tick(object sender, EventArgs e)
        {
            if (MousePosition.X == 0 && MousePosition.Y == 0)
            {
                Setting.Kill = true;
                Troca.Stop();
                Run.Stop();
                bStart.ForeColor = Color.Red;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void binfo_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            if (FormsV.CheckOpened("Info"))
            {
                info.Dispose();
            }
            else
            {
                info.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                IntPtr otpHandle = win32.FindWindow("otPokemon", null);
                Setting.GameName = textBox1.Text;
                win32.SetWindowText(otpHandle, Setting.GameName);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Enabled == true) textBox1.Enabled = false;
            else textBox1.Enabled = true;
        }

        private void memory_Tick(object sender, EventArgs e)
        {
            Thread mem = new Thread(Mem.Memory);
            //if (!mem.IsAlive) mem.Start();
            mem.Start();
        }
    }
}
