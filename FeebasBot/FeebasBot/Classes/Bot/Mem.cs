using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FeebasBot.Classes.Bot
{
    class Mem
    {

        public static Process m_Process;
        public static IntPtr m_pProcessHandle;
        public static int m_iNumberOfBytesRead = 0;
        public static int m_iNumberOfBytesWritten = 0;

        public static Process[] processes = Process.GetProcessesByName("otpgl");
        public static void startmem()
        {
            string ProcessName = "otpgl";
            if (Process.GetProcessesByName(ProcessName).Length > 0)
                m_Process = Process.GetProcessesByName(ProcessName)[0];
            else
            {
                MessageBox.Show("Apenas Cliente BETA OPENGL", "Process not found!", MessageBoxButtons.OK);
                Environment.Exit(1);
            }
            m_pProcessHandle = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, m_Process.Id); // Sets Our ProcessHandle
            Setting.BaseAddress = (IntPtr)GetModuleAdress("otpgl");
        }

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

        public static void Memory()
        {
            if (Setting.BaseAddress != IntPtr.Zero)
            {
                //VAMemory memory = new VAMemory("otpgl");
                //int finalAddress = memory.ReadInt32((IntPtr)Setting.BaseAddress + 0x00116004);
                int finalAddress = ReadMemory<int>((int)Setting.BaseAddress + 0x00116004);
                //Setting.charx = memory.ReadInt32((IntPtr)finalAddress + 0x1C);
                //Setting.chary = memory.ReadInt32((IntPtr)finalAddress + 0x20);
                Setting.charx = ReadMemory<int>((int)finalAddress + 0x1C);
                Setting.chary = ReadMemory<int>((int)finalAddress + 0x20);
                Thread.Sleep(50);
            }
        }


        public static void Fish()
        {
            //VAMemory memory = new VAMemory("otpgl");
            var offsetArr = new int[] { 0x0, 0x4, 0x28, 0x0, 0x14, 0x138, 0x30, 0x0, 0x18, 0xD8 };
            //IntPtr pointer = IntPtr.Add((IntPtr)memory.ReadInt32(Setting.BaseAddress + 0x00A77CE4), offsetArr[0]);
            IntPtr pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + 0x00A77424), offsetArr[0]);
            for (int i = 1; i < offsetArr.Length; i++)
            {
                //pointer = IntPtr.Add((IntPtr)memory.ReadInt32(pointer), offsetArr[i]);
                pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer), offsetArr[i]);
            }
            //Setting.fish = memory.ReadInt32(pointer);
            Setting.fish = ReadMemory<int>((int)pointer);
        }

        public static void Chat()
        {
            //VAMemory memory = new VAMemory("otpgl");
            var offsetArr = new int[] { 0x4, 0x0, 0x70, 0x0, 0x14, 0x210, 0x1C, 0x8, 0x18, 0xD8 };
            //IntPtr pointer = IntPtr.Add((IntPtr)memory.ReadInt32(Setting.BaseAddress + 0x00A77CE4), offsetArr[0]);
            IntPtr pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)Setting.BaseAddress + 0x00A77424), offsetArr[0]);
            for (int i = 1; i < offsetArr.Length; i++)
            {
                //pointer = IntPtr.Add((IntPtr)memory.ReadInt32(pointer), offsetArr[i]);
                pointer = IntPtr.Add((IntPtr)ReadMemory<int>((int)pointer), offsetArr[i]);
            }
            //Setting.fish = memory.ReadInt32(pointer);
            Setting.Chat = ReadMemory<int>((int)pointer);
            Thread.Sleep(200);
        }
    }
}
