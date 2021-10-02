﻿using csharp_Sqlite;
//using MySqlX.XDevAPI.Relational;
using FeebasBot.Classes;
using FeebasBot.Classes.Bot;
using FeebasBot.Classes.Funcoes;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot.Forms
{
    public partial class CaveBot : Form
    {
        static int timerx, timery;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        public void SendKeysA(Keys vk_key)
        {
            PostMessage(otpHandle, WM_KEYDOWN, (IntPtr)vk_key, IntPtr.Zero);
            PostMessage(otpHandle, WM_KEYUP, (IntPtr)vk_key, IntPtr.Zero);
        }
        int z = 1;
        string colorrod = "0";
        readonly string[] names = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", };
        readonly int[] values = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
        int current = 0;
        bool stop = false;
        bool trueif = false;
        int iexec = 0;
        int idatual = 0;
        IntPtr otpHandle = Win32.FindWindow("otPokemon", null);
        public CaveBot()
        {
            InitializeComponent();
        }

        public void exec()
        {

            if (stop == true) { Thread.CurrentThread.Abort(); }
            int time = 200;
            view.Rows[iexec].Selected = true;
            string now = view.Rows[iexec].Cells[1].Value.ToString();
            if (Setting.PausarNoTarget == 1)
            {
                Verificacoes.Targetando();
                while (Setting.IsTargeting == 1)
                {
                    Thread.Sleep(0);
                    Verificacoes.Targetando();
                }
            }
            if (Setting.PausarNoTarget == 1)
            {
                Verificacoes.Targetando();
                while (Setting.IsTargeting == 1)
                {
                    Thread.Sleep(0);
                    Verificacoes.Targetando();
                }
            }
            switch (now)
            {
                default:
                    break;
                case "Waypoint":
                    //nw.reset();
                    int ix = Convert.ToInt32(view.Rows[iexec].Cells[2].Value);
                    int iy = Convert.ToInt32(view.Rows[iexec].Cells[3].Value);

                    while (Setting.charx != ix | Setting.chary != iy)
                    {
                        if (stop == true) { Thread.CurrentThread.Abort(); }
                        if (Setting.PausarNoTarget == 1)
                        {
                            Verificacoes.Targetando();
                            while (Setting.IsTargeting == 1)
                            {
                                Thread.Sleep(0);
                                Verificacoes.Targetando();
                            }
                        }
                        if (Setting.charx < ix)
                        {

                            //Win32.SetForegroundWindow(otpHandle);
                            //SendKeysA(Keys.Right);
                            //SendKeys.SendWait("{Right}");
                            nw.right();
                            Thread.Sleep(Setting.waytime);
                        }
                        if (Setting.charx > ix)
                        {

                            //Win32.SetForegroundWindow(otpHandle);
                            //SendKeysA(Keys.Right);
                            //SendKeys.SendWait("{Left}");
                            nw.left();
                            Thread.Sleep(Setting.waytime);
                        }
                        if (Setting.chary > iy)
                        {

                            // Win32.SetForegroundWindow(otpHandle);
                            //SendKeysA(Keys.Right);
                            //SendKeys.SendWait("{Up}");
                            nw.up();
                            Thread.Sleep(Setting.waytime);
                        }
                        if (Setting.chary < iy)
                        {

                            //Win32.SetForegroundWindow(otpHandle);
                            //SendKeysA(Keys.Right);
                            //SendKeys.SendWait("{Down}");
                            nw.down();
                            Thread.Sleep(Setting.waytime);
                        }
                        Mem.Memory();
                        if (Setting.charx != Convert.ToInt32(view.Rows[iexec].Cells[2].Value) && Setting.chary != Convert.ToInt32(view.Rows[iexec].Cells[3].Value))
                        {
                            iexec -= 1;
                            break;
                        }
                    }
                    break;
                case "Left":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    Win32.SetForegroundWindow(otpHandle);
                    //SendKeysA(Keys.Left);
                    SendKeys.SendWait("{Left}");
                    Thread.Sleep(time);
                    break;
                case "Right":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    Win32.SetForegroundWindow(otpHandle);
                    //SendKeysA(Keys.Right);
                    SendKeys.SendWait("{Right}");
                    Thread.Sleep(time);
                    break;
                case "Up":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    Win32.SetForegroundWindow(otpHandle);
                    //SendKeysA(Keys.Up);
                    SendKeys.SendWait("{Up}");
                    Thread.Sleep(time);
                    break;
                case "Down":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    Win32.SetForegroundWindow(otpHandle);
                    //SendKeysA(Keys.Down);
                    SendKeys.SendWait("{Down}");
                    Thread.Sleep(time);
                    break;
                case "Wait":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    //Win32.SetForegroundWindow(otpHandle);
                    Thread.Sleep(Convert.ToInt32(view.Rows[iexec].Cells[4].Value) * 1000);
                    break;
                case "LClick":
                    Thread.Sleep(200);
                    Mem.Memory();
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    //Win32.SetForegroundWindow(otpHandle);
                    if (view.Rows[iexec - 1].Cells[1].Value.ToString() == "Waypoint")
                    {
                        if (Setting.charx == Convert.ToInt32(view.Rows[iexec - 1].Cells[2].Value) && Setting.chary == Convert.ToInt32(view.Rows[iexec - 1].Cells[3].Value))
                        {
                            Win32.LeftClick(Convert.ToInt32(view.Rows[iexec].Cells[2].Value), Convert.ToInt32(view.Rows[iexec].Cells[3].Value));
                            Thread.Sleep(200);
                        }
                        else
                        {
                            iexec -= 2;
                            break;
                        }
                    }
                    else
                    {
                        Win32.LeftClick(Convert.ToInt32(view.Rows[iexec].Cells[2].Value), Convert.ToInt32(view.Rows[iexec].Cells[3].Value));
                        Thread.Sleep(200);
                    }
                    break;
                case "RClick":
                    Thread.Sleep(200);
                    Mem.Memory();
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    //Win32.SetForegroundWindow(otpHandle);
                    if (view.Rows[iexec - 1].Cells[1].Value.ToString() == "Waypoint")
                    {
                        if (Setting.charx == Convert.ToInt32(view.Rows[iexec - 1].Cells[2].Value) && Setting.chary == Convert.ToInt32(view.Rows[iexec - 1].Cells[3].Value))
                        {
                            Win32.RightClick(Convert.ToInt32(view.Rows[iexec].Cells[2].Value), Convert.ToInt32(view.Rows[iexec].Cells[3].Value));
                            Thread.Sleep(200);
                        }
                        else
                        {
                            iexec -= 2;
                            break;
                        }
                    }
                    else
                    {
                        Win32.RightClick(Convert.ToInt32(view.Rows[iexec].Cells[2].Value), Convert.ToInt32(view.Rows[iexec].Cells[3].Value));
                        Thread.Sleep(200);
                    }
                    break;
                case "Message":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    //Win32.SetForegroundWindow(otpHandle);
                    MessageBox.Show(Convert.ToString(view.Rows[iexec].Cells[4].Value));
                    Thread.Sleep(200);
                    break;
                case "Goto Label":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    string labeltogo = view.Rows[iexec].Cells[4].Value.ToString();
                    for (int a = 0; a < view.RowCount; a++)
                    {
                        if (view.Rows[a].Cells[1].Value.ToString() == "Label" && view.Rows[a].Cells[4].Value.ToString() == labeltogo)
                        {
                            iexec = a;
                            break;
                        }
                    }
                    break;
                case "If Color":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    //Win32.SetForegroundWindow(otpHandle);
                    int x = Convert.ToInt32(view.Rows[iexec].Cells[2].Value);
                    int y = Convert.ToInt32(view.Rows[iexec].Cells[3].Value);
                    //MessageBox.Show(GrabPixel(x, y));
                    if (GrabPixel(x, y) == view.Rows[iexec].Cells[4].Value.ToString())
                    {
                        trueif = true;
                        //MessageBox.Show(Convert.ToString(trueif));
                        //iexec++;
                    }
                    else
                    {
                        trueif = false;
                        for (int b = iexec; b < view.RowCount; b++)
                        {
                            if (view.Rows[b].Cells[1].Value.ToString() == "Else")
                            {
                                iexec = b;
                                break;
                            }
                            else if (view.Rows[b].Cells[1].Value.ToString() == "End")
                            {
                                iexec = b;
                                break;
                            }
                            if (b == view.RowCount)
                            {
                                MessageBox.Show("End não encontrado!\nParando CaveBot!");
                                iexec = view.RowCount;
                                break;
                            }
                        }
                    }
                    break;
                case "Else":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    for (int c = iexec; c < view.RowCount; c++)
                    {
                        if (view.Rows[c].Cells[1].Value.ToString() == "End")
                        {
                            //MessageBox.Show("f");
                            if (trueif == true)
                            { iexec = c; trueif = false; }
                            break;
                        }
                        if (c == view.RowCount)
                        {
                            MessageBox.Show("End não encontrado!\nParando CaveBot!");
                            iexec = view.RowCount;
                            break;
                        }
                    }
                    break;
                case "SAY":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    String s = Convert.ToString(view.Rows[iexec].Cells[4].Value);
                    SendKeys.SendWait("{Enter}");
                    var chars = s.ToCharArray();
                    for (int ctr = 0; ctr < chars.Length; ctr++)                        //Console.WriteLine("   {0}: {1}", ctr, chars[ctr]);
                    {
                        Win32.SetForegroundWindow(otpHandle);
                        if (Convert.ToString(chars[ctr]) == " ")
                        {
                            SendKeys.SendWait(" ");
                        }
                        else
                        {
                            SendKeys.SendWait("{" + chars[ctr] + "}");
                        }
                        //MessageBox.Show("{" + chars[ctr] + "}"); 
                    }
                    SendKeys.SendWait("{Enter}");
                    break;
                case "Pokemon":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    //Win32.SetForegroundWindow(otpHandle);
                    int diff = Setting.Poke2Y - Setting.Poke1Y;
                    int pokechange = Convert.ToInt32(view.Rows[iexec].Cells[4].Value);
                    if (pokechange == 1)
                    { Thread.Sleep(500); Win32.LeftClick(Setting.Poke1X, Setting.Poke1Y); }
                    if (pokechange == 2)
                    { Thread.Sleep(500); Win32.LeftClick(Setting.Poke2X, Setting.Poke2Y); }
                    if (pokechange == 3)
                    { Thread.Sleep(500); Win32.LeftClick(Setting.Poke3X, Setting.Poke3Y); }
                    if (pokechange == 4)
                    { Thread.Sleep(500); Win32.LeftClick(Setting.Poke4X, Setting.Poke4Y); }
                    if (pokechange == 5)
                    { Thread.Sleep(500); Win32.LeftClick(Setting.Poke5X, Setting.Poke5Y); }
                    if (pokechange == 6)
                    { Thread.Sleep(500); Win32.LeftClick(Setting.Poke6X, Setting.Poke6Y); }
                    Thread.Sleep(3000);
                    break;
                case "Teleport":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    string tp = "!teleport Saffron";
                    var charstp = tp.ToCharArray();
                    SendKeys.SendWait("{Enter}");
                    for (int ctr = 0; ctr < charstp.Length; ctr++)                        //Console.WriteLine("   {0}: {1}", ctr, chars[ctr]);
                    {
                        Win32.SetForegroundWindow(otpHandle);
                        if (Convert.ToString(charstp[ctr]) == " ")
                        {
                            SendKeys.SendWait(" ");
                        }
                        else
                        {
                            SendKeys.SendWait("{" + charstp[ctr] + "}");
                        }
                        //MessageBox.Show("{" + chars[ctr] + "}"); 
                    }
                    SendKeys.SendWait("{Enter}");
                    Thread.Sleep(1000);
                    break;
                case "Logout":
                    if (stop == true) { Thread.CurrentThread.Abort(); }
                    while (z == 1)
                    {
                        string colornow = GrabPixel(Setting.RodX, Setting.RodY);
                        Thread.Sleep(1000);
                        Win32.SetForegroundWindow(otpHandle);
                        SendKeys.SendWait("^{q}");
                        if (colornow != colorrod)
                        {
                            z = 0;
                            break;
                        }
                    }
                    break;
                case "Label":
                    Setting.LastLabel = view.Rows[iexec].Cells[4].Value.ToString();
                    break;
            }
            if (Setting.PausarNoTarget == 1)
            {
                Verificacoes.Targetando();
                while (Setting.IsTargeting == 1)
                {
                    Thread.Sleep(0);
                    Verificacoes.Targetando();
                }
            }
            if (iexec < view.RowCount)
            { iexec++; }
            if (iexec >= view.RowCount)
            { iexec = 0; stop = true; }
            if (stop == false)
            {
                exec();
            }

        }
        public string GrabPixel(int x, int y)
        {
            //string px = Convert.ToString(getpixel.GetPixel(getpixel.GetWindowDC(getpixel.GetDesktopWindow()), x, y));
            string px = Convert.ToString(getpixel.GetColorAt(otpHandle, x, y));

            return px;
        }

        private void CaveBot_Load(object sender, EventArgs e)
        {
            this.Name = Rdn.randomname();
            this.Text = this.Name;
            if (Setting.PausarNoTarget == 1) { cPauseTarget.Checked = true; }
            otpHandle = Win32.FindWindow("otPokemon", null);
            view.DataSource = DalHelper.GetClientes();
            if (view.RowCount > 0)
            {
                view.Rows[0].Selected = true;
                view.CurrentCell = view[1, 0];
            }
            for (int i = 0; i < view.RowCount; i++)
            {
                idatual = Convert.ToInt32(view.Rows[i].Cells[0].Value) + 1;
            }
            view.Columns["id"].Visible = false;
        }
        public void update()
        {
            view.DataSource = DalHelper.GetClientes();
            //alinhar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Test", 100, 200, "");
            idatual++;
            update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int current = 0;
            //int anterior = 0;
            if (view.CurrentRow != null)
            {
                current = view.Rows[view.CurrentRow.Index].Index;
                DalHelper.Delete(Convert.ToInt32(view.Rows[view.CurrentRow.Index].Cells[0].Value));
            }
            update();
            if (current > 0 && view.Rows[current - 1].Cells[0].Value != null)
            {
                view.Rows[current - 1].Selected = true;
                view.CurrentCell = view[1, current - 1];
            }
            else if (current > 0)
            {
                view.Rows[0].Selected = true;
                view.CurrentCell = view[1, 0];
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Left", 0, 0, "");
            Win32.SetForegroundWindow(otpHandle);
            SendKeys.SendWait("{Left}");
            //SendKeysA(Keys.Up);
            idatual++;
            update();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Down", 0, 0, "");
            Win32.SetForegroundWindow(otpHandle);
            SendKeys.SendWait("{Down}");
            idatual++;
            update();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Up", 0, 0, "");
            Win32.SetForegroundWindow(otpHandle);
            SendKeys.SendWait("{Up}");
            idatual++;
            update();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Right", 0, 0, "");
            Win32.SetForegroundWindow(otpHandle);
            SendKeys.SendWait("{Right}");
            idatual++;
            update();
        }
        public void button2_Click(object sender, EventArgs e)
        {
            autopoint.Checked = false;
            otpHandle = Win32.FindWindow("otPokemon", null);
            z = 1;
            colorrod = GrabPixel(Setting.RodX, Setting.RodY);
            stop = false;
            //iexec = 0;
            //for (iexec = 0; iexec < view.RowCount; iexec++)
            //{
            Thread thread = new Thread(exec);
            thread.Start();
            //}
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            exec();
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Wait", 0, 0, waittime.Text);
            idatual++;
            update();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Cross;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            DalHelper.Add(idatual, "LClick", MousePosition.X + 8, MousePosition.Y, "");
            idatual++;
            update();
        }
        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            DalHelper.Add(idatual, "RClick", MousePosition.X + 8, MousePosition.Y, "");
            idatual++;
            update();
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Label", 0, 0, txtLabel.Text);
            idatual++;
            update();
        }

        private void btnGotoLabel_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Goto Label", 0, 0, txtLabel.Text);
            idatual++;
            update();
        }

        private void btnColor_MouseUp(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X + 8;
            int y = MousePosition.Y;
            DalHelper.Add(idatual, "If Color", x, y, GrabPixel(x, y));
            idatual++;
            update();
        }

        private void btnElse_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Else", 0, 0, "");
            idatual++;
            update();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "End", 0, 0, "");
            idatual++;
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "SAY", 0, 0, txtLabel.Text);
            idatual++;
            update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stop = true;
        }
        public void alinhar()
        {
            DalHelper.UpdateID(Convert.ToInt32(view.Rows[0].Cells[0].Value), 0);
            update();
            int bkpstart = 99;
            int bkp = bkpstart;
            for (int i = 1; i < view.RowCount; i++)
            {
                MessageBox.Show("trocando id:" + Convert.ToString(Convert.ToInt32(view.Rows[i].Cells[0].Value)) + "\nPor:" + Convert.ToString(Convert.ToInt32(view.Rows[i - 1].Cells[0].Value) + 1));
                for (int a = i; a < view.RowCount; a++)
                {
                    if (Convert.ToInt32(view.Rows[a].Cells[0].Value) == Convert.ToInt32(view.Rows[i - 1].Cells[0].Value) + 1)
                    {
                        DalHelper.UpdateID(Convert.ToInt32(view.Rows[a].Cells[0].Value), bkp);
                        bkp++;
                    }
                }
                DalHelper.UpdateID(Convert.ToInt32(view.Rows[i].Cells[0].Value), Convert.ToInt32(view.Rows[i - 1].Cells[0].Value) + 1);
                update();
            }
            /*
            int a = 0;
            while (a < view.RowCount)
            {
                MessageBox.Show(a + ":" + view.RowCount);
                MessageBox.Show("inici");
                MessageBox.Show("pegar ids");
                int idnow = Convert.ToInt32(view.Rows[a].Cells[0].Value);
                int idnext = Convert.ToInt32(view.Rows[a + 1].Cells[0].Value);
                MessageBox.Show("IdAtual:" + idnow + "\nIdProximo:" + idnext); 
                if (idnow==idnext-1)
                {
                    MessageBox.Show("id correto");
                    if (a < view.RowCount)
                    {
                        MessageBox.Show("a++");
                        a++;
                    }                    
                }
                else
                {
                    MessageBox.Show("atualizando id atual (prox-1)");
                    DalHelper.UpdateID(idnow, idnext-1);
                }
                update();
            }
            /*
            while (ab < view.RowCount)
            {
                MessageBox.Show(Convert.ToString(ab));
                int valuei = Convert.ToInt32(view.Rows[ab].Cells[0].Value);
                int valuenext = Convert.ToInt32(view.Rows[ab+1].Cells[0].Value);
                string Comando = Convert.ToString(view.Rows[ab+1].Cells[1].Value);
                int X = Convert.ToInt32(view.Rows[ab+1].Cells[2].Value);
                int Y = Convert.ToInt32(view.Rows[ab+1].Cells[3].Value);
                string Option = Convert.ToString(view.Rows[ab+1].Cells[4].Value);
                if (valuenext == valuei + 1)
                {
                    
                    ab++;
                }
                else
                {
                    MessageBox.Show(Convert.ToString("i:" + valuei + "\nn:" + valuenext + "\ndevia ser:" + valuei + 1));
                    DalHelper.Delete(valuenext);
                    DalHelper.Add(valuei+1, Comando, X, Y, Option);
                    if (ab>0)
                    {
                        ab--;
                    }
                                     
                }
                update();
            }
            */
        }
        private void btnMvUp_Click(object sender, EventArgs e)
        {
            int current = view.CurrentRow.Index;
            if (current > 0)
            {
                //view.Rows[0].Selected = true;
                //view.CurrentCell = view[1, 0];
                //atual
                int id = Convert.ToInt32(view.Rows[current].Cells[0].Value);
                string Comando = Convert.ToString(view.Rows[current].Cells[1].Value);
                int X = Convert.ToInt32(view.Rows[current].Cells[2].Value);
                int Y = Convert.ToInt32(view.Rows[current].Cells[3].Value);
                string Option = Convert.ToString(view.Rows[current].Cells[4].Value);
                //anterior
                int idanterior = Convert.ToInt32(view.Rows[current - 1].Cells[0].Value);
                string Canterior = Convert.ToString(view.Rows[current - 1].Cells[1].Value);
                int Xanterior = Convert.ToInt32(view.Rows[current - 1].Cells[2].Value);
                int Yanterior = Convert.ToInt32(view.Rows[current - 1].Cells[3].Value);
                string Oanterior = Convert.ToString(view.Rows[current - 1].Cells[4].Value);
                //
                DalHelper.Update(idanterior, Comando, X, Y, Option);
                DalHelper.Update(id, Canterior, Xanterior, Yanterior, Oanterior);
                update();
                //view.Rows[idanterior].Selected = true;
                //view.CurrentCell = view[1, idanterior];            
            }
        }

        private void btnMvDown_Click(object sender, EventArgs e)
        {
            current = view.CurrentRow.Index;
            if (current < view.RowCount)
            {
                //view.Rows[0].Selected = true;
                //view.CurrentCell = view[1, 0];
                //atual
                int id = Convert.ToInt32(view.Rows[current].Cells[0].Value);
                string Comando = Convert.ToString(view.Rows[current].Cells[1].Value);
                int X = Convert.ToInt32(view.Rows[current].Cells[2].Value);
                int Y = Convert.ToInt32(view.Rows[current].Cells[3].Value);
                string Option = Convert.ToString(view.Rows[current].Cells[4].Value);
                //anterior
                int idproximo = Convert.ToInt32(view.Rows[current + 1].Cells[0].Value);
                string Cproximo = Convert.ToString(view.Rows[current + 1].Cells[1].Value);
                int Xproximo = Convert.ToInt32(view.Rows[current + 1].Cells[2].Value);
                int Yproximo = Convert.ToInt32(view.Rows[current + 1].Cells[3].Value);
                string Oproximo = Convert.ToString(view.Rows[current + 1].Cells[4].Value);
                //             
                DalHelper.Update(id, Cproximo, Xproximo, Yproximo, Oproximo);
                DalHelper.Update(idproximo, Comando, X, Y, Option);
                update();
                //view.Rows[idproximo].Selected = true;
                //view.CurrentCell = view[1, idproximo];
            }
        }
        private void CaveBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop = true;
        }

        private void btnTP_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Teleport", 0, 0, "Saffron");
            idatual++;
            update();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Logout", 0, 0, "");
            idatual++;
            update();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Pokemon", 0, 0, waittime.Text);
            idatual++;
            update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cPauseTarget_CheckedChanged(object sender, EventArgs e)
        {
            if (cPauseTarget.Checked == true) { Setting.PausarNoTarget = 1; } else { Setting.PausarNoTarget = 0; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "X: " + Setting.charx;
            label2.Text = "Y: " + Setting.chary;
        }

        private void wButton_Click(object sender, EventArgs e)
        {
            DalHelper.Add(idatual, "Waypoint", Setting.charx, Setting.chary, "");
            idatual++;
            update();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            autopoint.Checked = false;
            otpHandle = Win32.FindWindow("otPokemon", null);
            z = 1;
            colorrod = GrabPixel(Setting.RodX, Setting.RodY);
            stop = false;
            iexec = 0;
            //for (iexec = 0; iexec < view.RowCount; iexec++)
            //{
            Thread thread = new Thread(exec);
            thread.Start();
            //}

        }

        private void loadcave_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Setting.cavefile = loadcave.FileName.ToString();
        }

        private void load_Click(object sender, EventArgs e)
        {
            loadcave.ShowDialog();
            view.DataSource = DalHelper.GetClientes();
            //this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            createnew.ShowDialog();
            DalHelper.createfile(createnew.FileName.ToString() + ".sqlite");
            Setting.cavefile = createnew.FileName.ToString() + ".sqlite";
            view.DataSource = DalHelper.GetClientes();
        }

        private void autopoint_CheckedChanged(object sender, EventArgs e)
        {

            if (autopoint.Checked)
            {
                timerx = Setting.charx;
                timery = Setting.chary;
                waytimer.Start();
            }
            else waytimer.Stop();
        }

        private void waytimer_Tick(object sender, EventArgs e)
        {
            if (Setting.charx != timerx | Setting.chary != timery)
            {
                timerx = Setting.charx;
                timery = Setting.chary;
                DalHelper.Add(idatual, "Waypoint", Setting.charx, Setting.chary, "");
                idatual++;
                update();
            }
        }
    }
}
