﻿using FeebasBot.Classes;
using FeebasBot.Classes.Bot;
using FeebasBot.Classes.Funcoes;
//using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot.Telas
{
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
        }

        private void basescreen_Load(object sender, EventArgs e)
        {
            this.Name = Rdn.randomname();
            this.Text = this.Name;
            if (Setting.waytime == 0) Setting.waytime = 130;
            waytime.Value = Setting.waytime;
            if (Setting.attacktime < 200) Setting.attacktime = 200;
            fullhitcheck.Checked = Properties.Settings.Default.fullhit;
            if (Setting.PodeUsarLooting == 0) cLoot.Enabled = false;
            numericUpDown1.Value = Setting.attacktime;
            if (Setting.Pescar == 1) { cPescar.Checked = true; cNoStop.Enabled = true; cRandom.Enabled = true; } else { cNoStop.Enabled = false; cRandom.Enabled = false; }
            if (Setting.randomfish == 1) { cRandom.Checked = true; }
            if (Setting.PescarSemParar == 1) cNoStop.Checked = true;
            if (Setting.Atacar == 1) { cAtacar.Checked = true; cSemTarget.Enabled = true; } else { cSemTarget.Enabled = false; }
            if (Setting.AtacarSemTarget == 1) cSemTarget.Checked = true;
            if (Setting.Lootear == 1) cLoot.Checked = true;
            if (Setting.TrocarDePokemon == 1) cTrocaDePoke.Checked = true;
            if (Setting.catchpoke == 1) cCatch.Checked = true;
            if (Setting.ChatStop == 1) cChatStop.Checked = true;
            if (Setting.PodeUsarCaveBot == 1) { cCaveChat.Enabled = true; cCavePlayer.Enabled = true; } else { cCaveChat.Enabled = false; cCavePlayer.Enabled = false; }
            if (Setting.CaveChat == 1) cCaveChat.Checked = true;
            if (Setting.CavePlayer == 1) cCavePlayer.Checked = true;
            if (Setting.FocusChat == 1) cFocusChat.Checked = true;
            if (Setting.FocusMove == 1) cFocusMove.Checked = true;
            if (Setting.m1 == 1) cm1.Checked = true;
            if (Setting.m2 == 1) cm2.Checked = true;
            if (Setting.m3 == 1) cm3.Checked = true;
            if (Setting.m4 == 1) cm4.Checked = true;
            if (Setting.m5 == 1) cm5.Checked = true;
            if (Setting.m6 == 1) cm6.Checked = true;
            if (Setting.m7 == 1) cm7.Checked = true;
            if (Setting.m8 == 1) cm8.Checked = true;
            if (Setting.m9 == 1) cm9.Checked = true;
            if (Setting.m10 == 1) cm10.Checked = true;
            if (Setting.p1 == 1) p1.Checked = true;
            if (Setting.p2 == 1) p2.Checked = true;
            if (Setting.p3 == 1) p3.Checked = true;
            if (Setting.p4 == 1) p4.Checked = true;
            if (Setting.p5 == 1) p5.Checked = true;
            if (Setting.p6 == 1) p6.Checked = true;
            if (Setting.p7 == 1) p7.Checked = true;
            if (Setting.p8 == 1) p8.Checked = true;
        }

        private void basescreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                win32.ReleaseCapture();
                win32.SendMessage(Handle, win32.WM_NCLBUTTONDOWN, win32.HT_CAPTION, 0);
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bMinimize_Click(object sender, EventArgs e)
        {

        }
        private void btnVara_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição da Vara?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.RodX = xn;
                Setting.RodY = yn;
                MessageBox.Show("Posição da Vara salva!");
            }
        }

        private void btnVara_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void btnAgua_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição da Agua?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.WaterX = xn;
                Setting.WaterY = yn;
                MessageBox.Show("Posição da Agua salva!");
            }
        }

        private void btnPeixe_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Peixe?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.FishX = xn;
                Setting.FishY = yn;
                MessageBox.Show("Posição do Peixe salva!");
            }
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja Configurar a posição da Batalha??", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Ataque.ConfigurarAtaque(xn, yn);

            }

        }
        #region ManualConfig
        private void cManualConfig1_CheckedChanged(object sender, EventArgs e)
        {
            cManualConfig2.Checked = false;
            ManualConfig.Start();
        }

        private void cManualConfig2_CheckedChanged(object sender, EventArgs e)
        {
            cManualConfig1.Checked = false;
            ManualConfig.Start();
        }

        private void ManualConfig_Tick(object sender, EventArgs e)
        {
            win32.MoveMouse(Setting.BattleX, Setting.BattleY);
            win32.MoveMouse(Setting.BattleX + 1, Setting.BattleY);
            if (cManualConfig1.Checked)
            {
                //pixelmiddle
                uint pixel = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX, Setting.TargetY));
                Color colormiddle = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
                ManualMiddle.BackColor = colormiddle;
                //pixelleft
                uint pixelleft = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX - 1, Setting.TargetY));
                Color colorleft = Color.FromArgb((int)(pixelleft & 0x000000FF), (int)(pixelleft & 0x0000FF00) >> 8, (int)(pixelleft & 0x00FF0000) >> 16);
                ManualLeft.BackColor = colorleft;
                //pixelright
                uint pixelright = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX + 1, Setting.TargetY));
                Color colorright = Color.FromArgb((int)(pixelright & 0x000000FF), (int)(pixelright & 0x0000FF00) >> 8, (int)(pixelright & 0x00FF0000) >> 16);
                ManualRight.BackColor = colorright;
                //pixelup
                uint pixelup = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX, Setting.TargetY - 1));
                Color colorup = Color.FromArgb((int)(pixelup & 0x000000FF), (int)(pixelup & 0x0000FF00) >> 8, (int)(pixelup & 0x00FF0000) >> 16);
                ManualUp.BackColor = colorup;
                //pixeldown
                uint pixeldown = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX, Setting.TargetY + 1));
                Color colordown = Color.FromArgb((int)(pixeldown & 0x000000FF), (int)(pixeldown & 0x0000FF00) >> 8, (int)(pixeldown & 0x00FF0000) >> 16);
                ManualDown.BackColor = colordown;
            }
            if (cManualConfig2.Checked)
            {
                //pixelmiddle
                uint pixel = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX2, Setting.TargetY2));
                Color colormiddle = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
                ManualMiddle.BackColor = colormiddle;
                //pixelleft
                uint pixelleft = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX2 - 1, Setting.TargetY2));
                Color colorleft = Color.FromArgb((int)(pixelleft & 0x000000FF), (int)(pixelleft & 0x0000FF00) >> 8, (int)(pixelleft & 0x00FF0000) >> 16);
                ManualLeft.BackColor = colorleft;
                //pixelright
                uint pixelright = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX2 + 1, Setting.TargetY2));
                Color colorright = Color.FromArgb((int)(pixelright & 0x000000FF), (int)(pixelright & 0x0000FF00) >> 8, (int)(pixelright & 0x00FF0000) >> 16);
                ManualRight.BackColor = colorright;
                //pixelup
                uint pixelup = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX2, Setting.TargetY2 - 1));
                Color colorup = Color.FromArgb((int)(pixelup & 0x000000FF), (int)(pixelup & 0x0000FF00) >> 8, (int)(pixelup & 0x00FF0000) >> 16);
                ManualUp.BackColor = colorup;
                //pixeldown
                uint pixeldown = Convert.ToUInt32(getpixel.GrabPixel(Setting.TargetX2, Setting.TargetY2 + 1));
                Color colordown = Color.FromArgb((int)(pixeldown & 0x000000FF), (int)(pixeldown & 0x0000FF00) >> 8, (int)(pixeldown & 0x00FF0000) >> 16);
                ManualDown.BackColor = colordown;
            }
            if (!cManualConfig1.Checked && !cManualConfig2.Checked)
            {
                ManualMiddle.BackColor = Color.Black;
                ManualRight.BackColor = Color.Black;
                ManualLeft.BackColor = Color.Black;
                ManualUp.BackColor = Color.Black;
                ManualDown.BackColor = Color.Black;
                ManualConfig.Stop();
            }

        }

        private void ManualLeft_Click(object sender, EventArgs e)
        {
            if (cManualConfig1.Checked)//configurando px1 
            {
                Setting.TargetX--;
            }
            if (cManualConfig2.Checked)//configurando px1 
            {
                Setting.TargetX2--;
            }
        }

        private void ManualRight_Click(object sender, EventArgs e)
        {
            if (cManualConfig1.Checked)//configurando px1 
            {
                Setting.TargetX++;
            }
            if (cManualConfig2.Checked)//configurando px1 
            {
                Setting.TargetX2++;
            }
        }

        private void ManualDown_Click(object sender, EventArgs e)
        {
            if (cManualConfig1.Checked)//configurando px1 
            {
                Setting.TargetY++;
            }
            if (cManualConfig2.Checked)//configurando px1 
            {
                Setting.TargetY2++;
            }
        }

        private void ManualUp_Click(object sender, EventArgs e)
        {
            if (cManualConfig1.Checked)//configurando px1 
            {
                Setting.TargetY--;
            }
            if (cManualConfig2.Checked)//configurando px1 
            {
                Setting.TargetY2--;
            }
        }
        #endregion
        #region Moves
        private void cm1_CheckedChanged(object sender, EventArgs e)
        {
            if (cm1.Checked == true)
            {
                Setting.m1 = 1;
            }
            else
            {
                Setting.m1 = 0;
            }
        }

        private void cm2_CheckedChanged(object sender, EventArgs e)
        {
            if (cm2.Checked == true)
            {
                Setting.m2 = 1;
            }
            else
            {
                Setting.m2 = 0;
            }
        }

        private void cm3_CheckedChanged(object sender, EventArgs e)
        {
            if (cm3.Checked == true)
            {
                Setting.m3 = 1;
            }
            else
            {
                Setting.m3 = 0;
            }
        }

        private void cm4_CheckedChanged(object sender, EventArgs e)
        {
            if (cm4.Checked == true)
            {
                Setting.m4 = 1;
            }
            else
            {
                Setting.m4 = 0;
            }
        }

        private void cm5_CheckedChanged(object sender, EventArgs e)
        {
            if (cm5.Checked == true)
            {
                Setting.m5 = 1;
            }
            else
            {
                Setting.m5 = 0;
            }
        }

        private void cm6_CheckedChanged(object sender, EventArgs e)
        {
            if (cm6.Checked == true)
            {
                Setting.m6 = 1;
            }
            else
            {
                Setting.m6 = 0;
            }
        }

        private void cm7_CheckedChanged(object sender, EventArgs e)
        {
            if (cm7.Checked == true)
            {
                Setting.m7 = 1;
            }
            else
            {
                Setting.m7 = 0;
            }
        }

        private void cm8_CheckedChanged(object sender, EventArgs e)
        {
            if (cm8.Checked == true)
            {
                Setting.m8 = 1;
            }
            else
            {
                Setting.m8 = 0;
            }
        }

        private void cm9_CheckedChanged(object sender, EventArgs e)
        {
            if (cm9.Checked == true)
            {
                Setting.m9 = 1;
            }
            else
            {
                Setting.m9 = 0;
            }
        }

        private void cm10_CheckedChanged(object sender, EventArgs e)
        {
            if (cm10.Checked == true)
            {
                Setting.m10 = 1;
            }
            else
            {
                Setting.m10 = 0;
            }
        }

        #endregion

        private void cPescar_CheckedChanged(object sender, EventArgs e)
        {
            if (cPescar.Checked == true) { Setting.Pescar = 1; cNoStop.Enabled = true; cRandom.Enabled = true; }
            else { Setting.Pescar = 0; cNoStop.Enabled = false; cRandom.Enabled = false; }
        }

        private void cAtacar_CheckedChanged(object sender, EventArgs e)
        {
            if (cAtacar.Checked == true) { Setting.Atacar = 1; cSemTarget.Enabled = true; }
            else { Setting.Atacar = 0; cSemTarget.Enabled = false; cSemTarget.Checked = false; }
        }

        private void tabFunction_Click(object sender, EventArgs e)
        {

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
        //private void bLogin_Click(object sender, EventArgs e)
        //{
        //    int server = 0;
        //    int puc = 0, pul = 0, put = 0, pc = 0;
        //    Setting.login = txtLogin.Text;
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
        //        MessageBox.Show("Todas as funções liberadas!");
        //        Setting.login = "Free Premium";
        //        this.Close();
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
        //        else { Setting.login = null; MessageBox.Show("Login Incorreto!"); }
        //        con.Close();
        //        //MessageBox.Show(Convert.ToString(mac) + "\n" + Convert.ToString(firstMacAddress));
        //        if (mac == firstMacAddress)
        //        {
        //            Setting.LoggedIn = true;
        //            Setting.PodeUsarCaveBot = puc;
        //            Setting.PodeUsarLooting = pul;
        //            Setting.PodeUsarTrocaDePokemon = put;
        //            Setting.PodeCapturar = pc;
        //            MessageBox.Show("Logado com sucesso!");
        //        }
        //        else if (mac == "0")
        //        {
        //            con.Open();
        //            cmd.CommandText = "UPDATE users SET MAC='" + firstMacAddress + "' WHERE User='" + Setting.login + "'";
        //            cmd.ExecuteNonQuery();
        //            Setting.LoggedIn = true;
        //            MessageBox.Show("Logado com sucesso!");
        //        }
        //        else if (mac != firstMacAddress && mac != "0" && mac != "")
        //        {
        //            MessageBox.Show("Computador diferente do cadastrado no sistema\nComunicar o Desenvolvedor!", "Informação", MessageBoxButtons.OK);
        //        }
        //        con.Close();
        //        this.Close();
        //    }
        //}
        #endregion

        private void tabLogin_Click(object sender, EventArgs e)
        {

        }

        private void tabAtk_Click(object sender, EventArgs e)
        {

        }

        private void cNoStop_CheckedChanged(object sender, EventArgs e)
        {
            if (cNoStop.Checked == true) { Setting.PescarSemParar = 1; if (Setting.PodeCapturar == 1) { cCatch.Enabled = false; } }
            else { Setting.PescarSemParar = 0; if (Setting.PodeCapturar == 1) { cCatch.Enabled = true; } }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string pixel = getpixel.GrabPixel(Setting.TargetX, Setting.TargetY);
            if (pixel == "16777215") { cManualConfig1.ForeColor = Color.Green; } else { cManualConfig1.ForeColor = Color.Black; }
            string pixel2 = getpixel.GrabPixel(Setting.TargetX, Setting.TargetY);
            if (pixel2 == "16777215") { cManualConfig2.ForeColor = Color.Green; timer1.Stop(); } else { cManualConfig2.ForeColor = Color.Black; }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Setting.attacktime = Convert.ToInt32(numericUpDown1.Value);
        }

        private void Battlemanual_CheckedChanged(object sender, EventArgs e)
        {
            if (Battlemanual.Checked)
            { panel4.Visible = true; }
            else { panel4.Visible = false; }
        }

        private void cLoot_CheckedChanged(object sender, EventArgs e)
        {
            if (cLoot.Checked == true) { Setting.Lootear = 1; }
            else { Setting.Lootear = 0; }
        }

        private void cShowLoot_CheckedChanged(object sender, EventArgs e)
        {
            Thread thread = new Thread(DrawLooting);
            thread.Start();
        }
        public void DrawLooting()
        {
            int position = (Setting.SQMY - Setting.PlayerY);
            while (cShowLoot.Checked == true)
            {
                IntPtr desktopPtr = win32.GetDC(IntPtr.Zero);
                Graphics g = Graphics.FromHdc(desktopPtr);
                SolidBrush b = new SolidBrush(Color.Red);
                SolidBrush rec = new SolidBrush(Color.Purple);
                g.FillRectangle(b, Setting.PlayerX - 16, Setting.PlayerY - 16, 32, 32);
                // /\ <
                if (Setting.p1 == 1) { g.FillRectangle(rec, Setting.SQMX - position - 16, Setting.SQMY - position * 2 - 16, 32, 32); }
                if (Setting.p2 == 1) { g.FillRectangle(rec, Setting.SQMX - 16, Setting.SQMY - position * 2 - 16, 32, 32); }
                if (Setting.p3 == 1) { g.FillRectangle(rec, Setting.SQMX + position - 16, Setting.SQMY - position * 2 - 16, 32, 32); }
                if (Setting.p4 == 1) { g.FillRectangle(rec, Setting.SQMX - position - 16, Setting.SQMY - position - 16, 32, 32); }
                if (Setting.p5 == 1) { g.FillRectangle(rec, Setting.SQMX + position - 16, Setting.SQMY - position - 16, 32, 32); }
                if (Setting.p6 == 1) { g.FillRectangle(rec, Setting.SQMX - position - 16, Setting.SQMY - 16, 32, 32); }
                if (Setting.p7 == 1) { g.FillRectangle(rec, Setting.SQMX - 16, Setting.SQMY - 16, 32, 32); }
                if (Setting.p8 == 1) { g.FillRectangle(rec, Setting.SQMX + position - 16, Setting.SQMY - 16, 32, 32); }
                g.Dispose();
                win32.ReleaseDC(IntPtr.Zero, desktopPtr);
            }
        }

        private void DrawPositions_Tick(object sender, EventArgs e)
        {

        }

        private void bPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Player?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.PlayerX = xn;
                Setting.PlayerY = yn;
                MessageBox.Show("Posição do Player salva!");
            }
        }

        private void bSquare_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Quadrado?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.SQMX = xn;
                Setting.SQMY = yn;
                MessageBox.Show("Posição do Quadrado salva!");
            }
        }

        private void Configuracao_FormClosing(object sender, FormClosingEventArgs e)
        {
            cShowLoot.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Looting.AbrirCorpos();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (p1.Checked == true) { Setting.p1 = 1; } else { Setting.p1 = 0; }
            if (p2.Checked == true) { Setting.p2 = 1; } else { Setting.p2 = 0; }
            if (p3.Checked == true) { Setting.p3 = 1; } else { Setting.p3 = 0; }
            if (p4.Checked == true) { Setting.p4 = 1; } else { Setting.p4 = 0; }
            if (p5.Checked == true) { Setting.p5 = 1; } else { Setting.p5 = 0; }
            if (p6.Checked == true) { Setting.p6 = 1; } else { Setting.p6 = 0; }
            if (p7.Checked == true) { Setting.p7 = 1; } else { Setting.p7 = 0; }
            if (p8.Checked == true) { Setting.p8 = 1; } else { Setting.p8 = 0; }
            Setting.SaveSettings();
        }

        private void bCloseLoot_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição de Fechar Loot?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.CloseX = xn;
                Setting.CloseY = yn;
                MessageBox.Show("Posição de Fechar Loot salva!");
            }
        }

        private void bSlot_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Slot?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.SlotX = xn;
                Setting.SlotY = yn;
                MessageBox.Show("Posição do Slot salva!");
            }
        }

        private void bOrder_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Order?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.OrderX = xn;
                Setting.OrderY = yn;
                MessageBox.Show("Posição do Order salva!");
            }
        }

        private void cSemTarget_CheckedChanged(object sender, EventArgs e)
        {
            if (cSemTarget.Checked == true) { Setting.AtacarSemTarget = 1; } else { Setting.AtacarSemTarget = 0; }
        }

        private void cRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (cRandom.Checked == true) { Setting.randomfish = 1; } else { Setting.randomfish = 0; }
        }

        private void cTrocaDePoke_CheckedChanged(object sender, EventArgs e)
        {
            if (cTrocaDePoke.Checked == true) { Setting.TrocarDePokemon = 1; } else { Setting.TrocarDePokemon = 0; }
        }

        private void bPoke1_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Pokemon?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.Poke1X = xn;
                Setting.Poke1Y = yn;
                MessageBox.Show("Posição do Pokemon salva!");
            }
            //Setting.pokespace = (Setting.Poke6Y - Setting.Poke1Y) / 6;
            //pokexyupdate();
        }

        private void bPoke2_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Pokemon?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.Poke2X = xn;
                Setting.Poke2Y = yn;
                MessageBox.Show("Posição do Pokemon salva!");
            }
        }

        private void bPoke3_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Pokemon?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.Poke3X = xn;
                Setting.Poke3Y = yn;
                MessageBox.Show("Posição do Pokemon salva!");
            }
        }

        private void bPoke4_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Pokemon?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.Poke4X = xn;
                Setting.Poke4Y = yn;
                MessageBox.Show("Posição do Pokemon salva!");
            }
        }

        private void bPoke5_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Pokemon?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.Poke5X = xn;
                Setting.Poke5Y = yn;
                MessageBox.Show("Posição do Pokemon salva!");
            }
        }

        private void bPoke6_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Pokemon?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.Poke6X = xn;
                Setting.Poke6Y = yn;
                MessageBox.Show("Posição do Pokemon salva!");
            }
        }
        public static void pokexyupdate()
        {
            Setting.Poke2X += Setting.Poke1X;
            Setting.Poke2X += Setting.Poke1X;
            Setting.Poke3X += Setting.Poke1X;
            Setting.Poke4X += Setting.Poke1X;
            Setting.Poke5X += Setting.Poke1X;

            Setting.Poke2Y += Setting.pokespace;
            Setting.Poke3Y += Setting.pokespace + Setting.pokespace;
            Setting.Poke4Y += Setting.pokespace + Setting.pokespace + Setting.pokespace;
            Setting.Poke5Y += Setting.pokespace + Setting.pokespace + Setting.pokespace;
        }

        private void bPortrait_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Portrait?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.PortraitX = xn;
                Setting.PortraitY = yn;
                Setting.portraitdead = getpixel.GrabPixel(xn, yn);
                MessageBox.Show("Posição do Portrait salva!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(TrocaDePoke.VerificarMorto);
            thread.Start();
        }

        private void bSquare2_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição do Quadrado?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.SQMBX = xn;
                Setting.SQMBY = yn;
                MessageBox.Show("Posição do Quadrado salva!");
            }
        }

        private void bTestBall_Click(object sender, EventArgs e)
        {
            Catch.JogarBall();
        }

        private void bSlotBall_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja salvar a posição da Pokebola?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.pokeballX = xn;
                Setting.pokeballY = yn;
                MessageBox.Show("Posição da Pokebola salva!");
            }
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            int xn = MousePosition.X;
            int yn = MousePosition.Y;
            DialogResult dialogResult = MessageBox.Show("Deseja configurar o alarme de chat?", "Info", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Setting.ChatY = yn;
                Chat.ChatCoords(xn, yn);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Setting.ChatY = 0;
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            Setting.login = null;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/dD54Rn9");
        }

        private void cCatch_CheckedChanged(object sender, EventArgs e)
        {
            if (cCatch.Checked == true) { Setting.catchpoke = 1; } else { Setting.catchpoke = 0; }
        }

        private void cChatStop_CheckedChanged(object sender, EventArgs e)
        {
            if (cChatStop.Checked == true) { Setting.ChatStop = 1; } else { Setting.ChatStop = 0; }
        }

        private void cCavePlayer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cCaveChat_CheckedChanged(object sender, EventArgs e)
        {
            if (cCaveChat.Checked == true) { Setting.CaveChat = 1; } else { Setting.CaveChat = 0; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cFocusChat.Checked == true) { Setting.FocusChat = 1; } else { Setting.FocusChat = 0; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cFocusMove.Checked == true) { Setting.FocusMove = 1; } else { Setting.FocusMove = 0; }
        }

        private void waytime_ValueChanged(object sender, EventArgs e)
        {
            Setting.waytime = int.Parse(waytime.Value.ToString());
        }

        private void fullhitcheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.fullhit = fullhitcheck.Checked;
        }

        private void autoconfig_Click(object sender, EventArgs e)
        {
            Ataque.autoconfig();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked) timer2.Start();
            else timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Ataque.fuckthisgunk();
        }
    }
}
