﻿using System;
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
        static int php = 0;
        static int[] phpoff = { 0 };
        static int[] phpmaxoff = { 0 };
        static int position = 0;
        static int ping = 0;
        static int pingoff = 0;
        static int xoff = 0;
        static int yoff = 0;
        static int fish = 0;
        static int chat = 0;
        static int battlex = 0;
        static int battley = 0;
        static int[] fishoffset = { 0 };
        static int[] chatoffset = { 0 };
        static int[] battlexoff = { 0 };
        static int[] battleyoff = { 0 };
        #endregion
        //static int a = 0;
        //static int a = 0;
        //static int a = 0;
        #region Offsets OpenGL
        ////position
        //static int gl_position = 0x00116004;
        //static int gl_xoff = 0x1C;
        //static int gl_yoff = 0x20;
        ////hp
        //static int gl_hp = 0x00A76A60;
        //static int gl_hpoff = 0x4E8;
        //static int gl_hpmaxoff = 0x4F0;
        ////ping
        //static int gl_ping = 0x00067E48;
        //static int gl_pingoff = 0x0;
        ////chat
        //static int gl_chat = 0x00A77424;
        //static int[] gl_chatoffset = new int[] { 0x4, 0x0, 0x70, 0x0, 0x14, 0x210, 0x1C, 0x8, 0x18, 0xD8 };
        ////peixe
        //static int gl_fish = 0x00A77424;
        //static int[] gl_fishoffset = new int[] { 0x0, 0x4, 0x28, 0x0, 0x14, 0x138, 0x30, 0x0, 0x18, 0xD8 };
        ////batalha x y
        //static int gl_battlex = 0x0;
        //static int[] gl_battlexoff = new int[] { 0x0 };
        //static int gl_battley = 0x0;
        //static int[] gl_battleyoff = new int[] { 0x0 };
        #endregion

        #region Offsets DirectX
        //position
        //static int dx_position = 0x00122E28;
        static readonly int dx_position = 0x00060780;
        static readonly int dx_xoff = 0x23C;
        static readonly int dx_yoff = 0x240;
        //hp
        static readonly int dx_hp = 0x00A523F0;
        static readonly int dx_hpoff = 0x4E8;
        static readonly int dx_hpmaxoff = 0x4F0;
        static readonly int dx_php = 0x00A52DE4;
        static readonly int[] dx_phpoff = new int[] { 0x0, 0x0, 0x28, 0x0, 0x14, 0xD8, 0x14, 0x8, 0x14, 0x60 };
        static readonly int[] dx_phpmaxoff = new int[] { 0x0, 0x0, 0x28, 0x0, 0x14, 0x168, 0x14, 0x8, 0x14, 0x228 };
        //ping
        static readonly int dx_ping = 0x0;
        static readonly int dx_pingoff = 0x0;
        //chat
        static readonly int dx_chat = 0x00A536A0; 
        static readonly int[] dx_chatoffset = new int[] { 0xAC, 0xAC, 0xAC, 0x80, 0x4, 0xC, 0x80, 0x0, 0x0, 0xD8 };
        //peixe
        static readonly int dx_fish = 0x00A52DE4;
        static readonly int[] dx_fishoffset = new int[] { 0x44, 0x8, 0x28, 0xC, 0x14, 0x138, 0x30, 0x0, 0x18, 0xD8 };
        //batalha x y
        static readonly int dx_battlex = 0x00A4C9B4; 
        static readonly int[] dx_battlexoff = new int[] { 0x40, 0x4, 0x28, 0x3C, 0x1C, 0x1A8, 0x28, 0x78, 0x38, 0x1E4 };
        static readonly int dx_battley = 0x00A4C9B4;
        static readonly int[] dx_battleyoff = new int[] { 0x74, 0x4, 0x28, 0x0, 0x14, 0x70, 0xB8, 0x30, 0x18, 0x1F0 };
        #endregion

        public static Process[] processes = null;
        static string ProcessName = "";
        public static void startmem()
        {
            bool open = false;
            //string ProcessName = "otpgl";
            //if (Process.GetProcessesByName(ProcessName).Length > 0)
            //{
            //    m_Process = Process.GetProcessesByName(ProcessName)[0];
            //    m_pProcessHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, m_Process.Id); // Sets Our ProcessHandle
            //    Setting.BaseAddress = (IntPtr)GetModuleAdress("otpgl");
            //    processes = Process.GetProcessesByName("otpgl");
            //    hp = gl_hp;
            //    hpoff = gl_hpoff;
            //    hpmaxoff = gl_hpmaxoff;
            //    ping = gl_ping;
            //    position = gl_position;
            //    ping = gl_ping;
            //    pingoff = gl_pingoff;
            //    xoff = gl_xoff;
            //    yoff = gl_yoff;
            //    fishoffset = gl_fishoffset;
            //    chatoffset = gl_chatoffset;
            //    chat = gl_chat;
            //    fish = gl_fish;
            //    battlex = gl_battlex;
            //    battlexoff = gl_battlexoff;
            //    battley = gl_battley;
            //    battleyoff = gl_battleyoff;
            //    Setting.game = "opengl";
            //    open = true;
            //}

            ProcessName = "otpdx";
            if (Process.GetProcessesByName(ProcessName).Length > 0)
            {
                m_Process = Process.GetProcessesByName(ProcessName)[0];
                m_pProcessHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, m_Process.Id); // Sets Our ProcessHandle
                Setting.BaseAddress = (IntPtr)GetModuleAdress("otpdx");
                processes = Process.GetProcessesByName("otpdx");
                hp = dx_hp;
                hpoff = dx_hpoff;
                hpmaxoff = dx_hpmaxoff;
                php = dx_php;
                phpoff = dx_phpoff;
                phpmaxoff = dx_phpmaxoff;
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
                battlex = dx_battlex;
                battlexoff = dx_battlexoff;
                battley = dx_battley;
                battleyoff = dx_battleyoff;
                Setting.game = "directx";
                open = true;
            }
            if (!open)
            {
                MessageBox.Show("Cliente Beta em modo DirectX não encontrado", "Process not found!", MessageBoxButtons.OK);
                Environment.Exit(1);
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
            PokeHP();
        }
        public static void Position()
        {
            int finalAddress = ReadMemory<int>((int)Setting.BaseAddress + position);
            Setting.charx = ReadMemory<int>((int)finalAddress + xoff);
            Setting.chary = ReadMemory<int>((int)finalAddress + yoff);
        }

        public static void BattleXY()
        {
            IntPtr pointerx = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + battlex), battlexoff[0]);
            for (int i = 1; i < chatoffset.Length; i++)
            {
                pointerx = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointerx), battlexoff[i]);
            }
            Setting.bx = ReadMemory<int>((int)pointerx);

            IntPtr pointery = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + battley), battleyoff[0]);
            for (int i = 1; i < chatoffset.Length; i++)
            {
                pointery = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointery), battleyoff[i]);
            }
            Setting.by = ReadMemory<int>((int)pointery);
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

        public static void PokeHP()
        {
            IntPtr pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + php), phpoff[0]);
            for (int i = 1; i < phpoff.Length; i++)
            {
                pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer), phpoff[i]);
            }
            Setting.PokeHP = ReadMemory<double>((int)pointer);

            IntPtr pointer2 = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + php), phpmaxoff[0]);
            for (int i = 1; i < phpmaxoff.Length; i++)
            {
                pointer2 = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer2), phpmaxoff[i]);
            }
            Setting.PokeHPMax = ReadMemory<double>((int)pointer2);
            Setting.PokeHPPercent = Math.Round((Setting.PokeHP / Setting.PokeHPMax) * 100);
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
