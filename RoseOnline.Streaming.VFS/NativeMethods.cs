using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RoseOnline.Streaming.VFS
{
    public class NativeMethods
    {
        [DllImport("TriggerVFS.dll", EntryPoint = "_OpenVFS@8", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OpenVFS(string fileName, string mode);

        [DllImport("TriggerVFS.dll", EntryPoint = "_CloseVFS@4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseVFS(IntPtr vfs);

        [DllImport("TriggerVFS.dll", EntryPoint = "_VGetVfsCount@4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGetVfsCount(IntPtr vfs);

        [DllImport("TriggerVFS.dll", EntryPoint = "_VGetVfsNames@16", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGetVfsNames(IntPtr vfs, IntPtr[] files, int number, short maxPath);

        [DllImport("TriggerVFS.dll", EntryPoint = "_VGetFileCount@8", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGetFileCount(IntPtr vfs, string vfsName);

        [DllImport("TriggerVFS.dll", EntryPoint = "_VGetFileNames@20", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VGetFileNames(IntPtr vfs, string vfsName, IntPtr[] fileNames, int number, int max);

        [DllImport("TriggerVFS.dll", EntryPoint = "_VOpenFile@8", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr VOpenFile(string fileName, IntPtr vfsFile);

        [DllImport("TriggerVFS.dll", EntryPoint = "_VCloseFile@4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VCloseFile(IntPtr vfsFile);

        [DllImport("TriggerVFS.dll", EntryPoint = "_vfread@16", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint vfread(byte[] buffer, uint size, uint count, IntPtr vfsFile);

        [DllImport("TriggerVFS.dll", EntryPoint = "_vfgetsize@4", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint vfgetsize(IntPtr vfsFile);
    }
}
