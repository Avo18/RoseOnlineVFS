﻿using System;

namespace RoseOnline.Streaming.VFS.Decorator
{
    interface IVFSStream
    {
        int VGetVfsCount();
        ArraySegment<string> VGetVfsNames();
        int VGetFileCount(string vfsName);
        ArraySegment<string> VGetFileNames(string vfsName);
    }

    class VFSStream : VFSBase, IVFSStream
    {
        internal readonly VFS _VFS;
        public VFSStream(VFS vfs)
        {
            _VFS = InjectionChecks.NotNull(vfs);
        }

        public int VGetVfsCount()
        {
            return NativeMethods.VGetVfsCount(_VFS.VFSData) - 1;
        }

        public ArraySegment<string> VGetVfsNames()
        {
            int numberOfFiles = VGetVfsCount();
            IntPtr[] reserveMemory = ReserveMemory(numberOfFiles);
            NativeMethods.VGetVfsNames(_VFS.VFSData, reserveMemory, numberOfFiles, Constants.MAX_PATH_LENGTH);
            return ConvertIntPtrToString(numberOfFiles, reserveMemory);
        }

        public int VGetFileCount(string vfsName)
        {
            return NativeMethods.VGetFileCount(_VFS.VFSData, vfsName);
        }

        public ArraySegment<string> VGetFileNames(string vfsName)
        {
            int fileCount = VGetFileCount(vfsName);
            IntPtr[] reserveMemory = ReserveMemory(fileCount);
            NativeMethods.VGetFileNames(_VFS.VFSData, vfsName, reserveMemory, fileCount, 5);
            return ConvertIntPtrToString(fileCount, reserveMemory);
        }
        
    }
}