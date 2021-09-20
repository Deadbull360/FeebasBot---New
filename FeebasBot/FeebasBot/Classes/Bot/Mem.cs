using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Mem
    {
        #region statics
        public static Process m_Process;
        public static IntPtr m_pProcessHandle;
        public static int m_iNumberOfBytesRead = 0;
        public static int m_iNumberOfBytesWritten = 0;
        //
        static int hp = 0;
        static int hpoff = 0;
        static int hpmaxoff = 0;
        static int position = 0;
        static int ping = 0;
        static int pingoff = 0;
        static int xoff = 0;
        static int yoff = 0;
        static int fish = 0;
        static int chat = 0;
        static int[] fishoffset = { 0 };
        static int[] chatoffset = { 0 };
        #endregion
        //static int a = 0;
        //static int a = 0;
        //static int a = 0;
        #region Offsets OpenGL
        //position
        static int gl_position = 0x00116004;
        static int gl_xoff = 0x1C;
        static int gl_yoff = 0x20;
        //hp
        static int gl_hp = 0x00A76A60;
        static int gl_hpoff = 0x4E8;
        static int gl_hpmaxoff = 0x4F0;
        //ping
        static int gl_ping = 0x00067E48;
        static int gl_pingoff = 0x0;        
        //chat
        static int gl_chat = 0x00A77424;
        static int[] gl_chatoffset = new int[] { 0x4, 0x0, 0x70, 0x0, 0x14, 0x210, 0x1C, 0x8, 0x18, 0xD8 };
        //peixe
        static int gl_fish = 0x00A77424;
        static int[] gl_fishoffset = new int[] { 0x0, 0x4, 0x28, 0x0, 0x14, 0x138, 0x30, 0x0, 0x18, 0xD8 };
        #endregion

        #region Offsets DirectX
        //position
        static int dx_position = 0x00122E28;
        static int dx_xoff = 0x0;
        static int dx_yoff = 0x4;
        //hp
        static int dx_hp = 0x00A4BFF0;
        static int dx_hpoff = 0x4E8;
        static int dx_hpmaxoff = 0x4F0;
        //ping
        static int dx_ping = 0x0;
        static int dx_pingoff = 0x0;
        //chat
        static int dx_chat = 0x00A4C9B4;
        static int[] dx_chatoffset = new int[] { 0x44, 0x4, 0x28, 0x14, 0x4C, 0xC0, 0x18, 0x8, 0x18, 0xD8 };
        //peixe
        static int dx_fish = 0x00A4C9B4;
        static int[] dx_fishoffset = new int[] { 0x0, 0x4, 0x28, 0x0, 0x14, 0x138, 0x30, 0x0, 0x18, 0xD8 };
        #endregion

        public static Process[] processes = Process.GetProcessesByName("otpgl");
        public static void startmem()
        {
            string ProcessName = "otpgl";
            if (Process.GetProcessesByName(ProcessName).Length > 0)
            {
                m_Process = Process.GetProcessesByName(ProcessName)[0];
                m_pProcessHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, m_Process.Id); // Sets Our ProcessHandle
                Setting.BaseAddress = (IntPtr)GetModuleAdress("otpgl");
                hp = gl_hp;
                hpoff = gl_hpoff;
                hpmaxoff = gl_hpmaxoff;
                ping = gl_ping;
                position = gl_position;
                ping = gl_ping;
                pingoff = gl_pingoff;
                xoff = gl_xoff;
                yoff = gl_yoff;
                fishoffset = gl_fishoffset;
                chatoffset = gl_chatoffset;
                chat = gl_chat;
                fish = gl_fish;
            }
            else
            {
                ProcessName = "otpdx";
                if (Process.GetProcessesByName(ProcessName).Length > 0)
                {
                    m_Process = Process.GetProcessesByName(ProcessName)[0];
                    m_pProcessHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, m_Process.Id); // Sets Our ProcessHandle
                    Setting.BaseAddress = (IntPtr)GetModuleAdress("otpdx");
                    hp = dx_hp;
                    hpoff = dx_hpoff;
                    hpmaxoff = dx_hpmaxoff;
                    ping = dx_ping;
                    position = dx_position;
                    ping = dx_ping;
                    pingoff = dx_pingoff;
                    xoff = dx_xoff;
                    yoff = dx_yoff;
                    fishoffset = dx_fishoffset;
                    chatoffset = dx_chatoffset;
                    chat = dx_chat;
                    fish = dx_fish;
                    //MessageBox.Show(xoff.ToString());
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado", "Process not found!", MessageBoxButtons.OK);
                    Environment.Exit(1);
                }
            }

            
            

        }

        #region memory
        public static int GetModuleAdress(string ModuleName)
        {
            try
            {
                foreach (ProcessModule ProcMod in m_Process.Modules)
                {
                    if (!ModuleName.Contains(".exe"))
                        ModuleName = ModuleName.Insert(ModuleName.Length, ".exe");

                    if (ModuleName == ProcMod.ModuleName)
                    {
                        return (int)ProcMod.BaseAddress;
                    }
                }
            }
            catch { }
            return -1;
        }

        public static T ReadMemory<T>(int Adress) where T : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(T)); // Get ByteSize Of DataType
            byte[] buffer = new byte[ByteSize]; // Create A Buffer With Size Of ByteSize
            ReadProcessMemory((int)m_pProcessHandle, Adress, buffer, buffer.Length, ref m_iNumberOfBytesRead); // Read Value From Memory

            return ByteArrayToStructure<T>(buffer); // Transform the ByteArray to The Desired DataType
        }

        private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

        #region Constants

        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;

        #endregion
        #endregion
        public static void Memory()
        {
            //0x00A76A60 - player
            //X - C
            //Y - 10
            //Z - 14
            Position();
            Ping();
            HP();
        }
        public static void Position()
        {
            int finalAddress = ReadMemory<int>((int)Setting.BaseAddress + position);
            Setting.charx = ReadMemory<int>((int)finalAddress + xoff);
            Setting.chary = ReadMemory<int>((int)finalAddress + yoff);
        }

        public static void Ping()
        {
            int pingfinal = ReadMemory<int>((int)Setting.BaseAddress + ping); //
            Setting.Ping = ReadMemory<int>((int)pingfinal + pingoff);
        }

        public static void HP()
        {
            int hpfinal = ReadMemory<int>((int)Setting.BaseAddress + hp); //
            //Setting.direction = ReadMemory<int>((int)hpfinal + 0x38);
            Setting.CharHP = ReadMemory<double>((int)hpfinal + hpoff);
            Setting.CharHPMax = ReadMemory<double>((int)hpfinal + hpmaxoff);
        }

        public static void Battle()
        {
            System.Text.Encoding enc = System.Text.Encoding.ASCII;
            
            var offsetArr = new int[] { 0x24, 0x14, 0xF68, 0x2C, 0xC, 0xC, 0x14, 0x480, 0x18, 0x274 };
            
            IntPtr pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + 0x00A77B50), offsetArr[0]);
            for (int i = 1; i < offsetArr.Length; i++)
            {
                pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer), offsetArr[i]);
            }
            byte a = ReadMemory<byte>((int)pointer);
            //MessageBox.Show(a.ToString());
            //Read it as a byte array
            //byte[] myByteArray = 

            //string myString = enc.GetString(myByteArray);
        }

        public static void Fish()
        {
            IntPtr pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + fish), fishoffset[0]);
            for (int i = 1; i < fishoffset.Length; i++)
            {
                pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer), fishoffset[i]);
            }
            Setting.fish = ReadMemory<int>((int)pointer);
        }

        public static void Chat()
        {
            IntPtr pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + chat), chatoffset[0]);
            for (int i = 1; i < chatoffset.Length; i++)
            {
                pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer), chatoffset[i]);
            }
            Setting.Chat = ReadMemory<int>((int)pointer);
            Thread.Sleep(200);
        }
    }
}
