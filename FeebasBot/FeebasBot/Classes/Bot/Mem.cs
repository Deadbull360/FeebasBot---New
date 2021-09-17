using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Mem
    {
        public static Process[] processes = Process.GetProcessesByName("otpgl");
        public static void startmem()
        {
            if (processes.Length > 0)
            {
                Setting.BaseAddress = IntPtr.Zero;
                Process MYProc = processes[0];
                foreach (ProcessModule module in MYProc.Modules)
                {
                    if (module.ModuleName.Contains("otpgl"))
                    {
                        Setting.BaseAddress = module.BaseAddress;
                        //MessageBox.Show(BaseAddres.ToString());
                    }
                }
            }

        }
            
        
        public static void Memory()
        {
            if (Setting.BaseAddress != IntPtr.Zero)
            {
                    VAMemory memory = new VAMemory("otpgl");
                    int finalAddress = memory.ReadInt32((IntPtr)Setting.BaseAddress + 0x00116004);
                    Setting.charx = memory.ReadInt32((IntPtr)finalAddress + 0x1C);
                    Setting.chary = memory.ReadInt32((IntPtr)finalAddress + 0x20);
                    Thread.Sleep(200);
            }
        }
        

        public static void Fish()
        {
            
                VAMemory memory = new VAMemory("otpgl");
                var offsetArr = new int[] { 0x80, 0x2C, 0x0, 0x80, 0x8, 0x0, 0xD8 };
                IntPtr pointer = IntPtr.Add((IntPtr)memory.ReadInt32(Setting.BaseAddress + 0x00A77CE4), offsetArr[0]);
                for (int i = 1; i < offsetArr.Length; i++)
                {
                    pointer = IntPtr.Add((IntPtr)memory.ReadInt32(pointer), offsetArr[i]);
                }
                Setting.fish = memory.ReadInt32(pointer);
                            
        }
    }
}
