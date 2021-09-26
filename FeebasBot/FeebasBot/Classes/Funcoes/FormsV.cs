//using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace FeebasBot.Classes.Funcoes
{
    class FormsV
    {
        public static bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static void playSound(string path, bool state)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = path;
            if (File.Exists(path))
            {
                if (state)
                {
                    player.Load();
                    player.Play();
                }
                else player.Stop();
            }
        }

        public static void playResource(System.IO.Stream file)
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(file);
            snd.Play();
        }
        //#region Login
        //String firstMacAddress = NetworkInterface
        //    .GetAllNetworkInterfaces()
        //    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
        //    .Select(nic => nic.GetPhysicalAddress().ToString())
        //    .FirstOrDefault();
        //MySqlConnection con;
        //MySqlCommand cmd;
        //MySqlDataReader dr;
        //public void login()
        //{
        //    string mac = "";
        //    int a = 0;
        //    if (Setting.login != "")
        //    {
        //        //updatebot();
        //        while (a == 0)
        //        {
        //            string my = "Server=sql10.freemysqlhosting.net;Database=sql10336993;user=sql10336993;Pwd=8JsRa57ub3;SslMode=none";
        //            con = new MySqlConnection(my);
        //            cmd = new MySqlCommand();
        //            con.Open();
        //            cmd.Connection = con;
        //            cmd.CommandText = "SELECT * FROM users where User='" + Setting.login + "'";
        //            dr = cmd.ExecuteReader();
        //            if (dr.Read() == false)
        //            { }
        //            else
        //            {
        //                mac = Convert.ToString(dr.GetValue(2));
        //                Setting.PodeUsarCaveBot = Convert.ToInt32(dr.GetValue(1));
        //                Setting.PodeUsarLooting = Convert.ToInt32(dr.GetValue(3));
        //                Setting.PodeUsarTrocaDePokemon = Convert.ToInt32(dr.GetValue(7));
        //                Setting.PodeCapturar = Convert.ToInt32(dr.GetValue(6));
        //            }
        //            con.Close();
        //            //MessageBox.Show(Convert.ToString(mac) + "\n" + Convert.ToString(firstMacAddress));
        //            if (mac == firstMacAddress)
        //            {
        //                Setting.LoggedIn = true;
        //                //MessageBox.Show("Logado com sucesso!");
        //            }
        //            else if (mac == "0")
        //            {
        //                con.Open();
        //                cmd.CommandText = "UPDATE users SET MAC='" + firstMacAddress + "' WHERE User='" + Setting.login + "'";
        //                cmd.ExecuteNonQuery();
        //                Setting.LoggedIn = true;
        //                MessageBox.Show("Logado com sucesso!");
        //            }
        //            else if (mac != firstMacAddress && mac != "0" && mac != "")
        //            {
        //                MessageBox.Show("Computador diferente do cadastrado no sistema\nComunicar o Desenvolvedor!", "Informação", MessageBoxButtons.OK);
        //            }
        //            con.Close();
        //            a = 1;
        //        }
        //    }
        //}
        //#endregion
    }
}
