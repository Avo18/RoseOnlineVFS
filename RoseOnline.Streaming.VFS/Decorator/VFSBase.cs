using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RoseOnline.Streaming.VFS.Decorator
{
    public abstract class VFSBase : IDisposable
    {
        protected IntPtr[] ReserveMemory(int numberOfFiles)
        {
            IntPtr[] reserve = new IntPtr[numberOfFiles];
            for (int i = 0; i < numberOfFiles; i++)
                reserve[i] = Marshal.StringToHGlobalAnsi(new string(new char[256]));
            return reserve;
        }

        protected ArraySegment<string> ConvertIntPtrToString(int numberOfFiles, IntPtr[] reserveMemory)
        {
            string[] rootFiles = new string[numberOfFiles];
            for (int i = 0; i < numberOfFiles; i++)
                rootFiles[i] = Marshal.PtrToStringAnsi(reserveMemory[i]);
            return new ArraySegment<string>(rootFiles);
        }

        protected ArraySegment<VFSNode> ConvertIntPtrToList(int numberOfFiles, IntPtr[] reserveMemory)
        {
            var list = new List<VFSNode>(numberOfFiles);
            for (int i = 0; i < numberOfFiles; i++)
                list.Add(new VFSNode() { VFSPath = Marshal.PtrToStringAnsi(reserveMemory[i]), AddressPtr = reserveMemory[i] });
            return new ArraySegment<VFSNode>(list.ToArray());
        }

        protected void FreeHGlobal(IntPtr[] memory)
        {
            foreach(var value in memory)
            {
                Marshal.FreeHGlobal(value);
            }
        }

        public abstract void Dispose();
    }
}
