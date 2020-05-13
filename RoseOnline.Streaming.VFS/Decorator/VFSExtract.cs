using System;
using System.IO;

namespace RoseOnline.Streaming.VFS.Decorator
{

    public interface IVFSExtract
    {
        bool ExtractFile(string fileName);
    }
    public class VFSExtract : VFSBase, IVFSExtract
    {
        private readonly VFS _VFS;
        internal IntPtr _VFSData;
        public VFSExtract(VFS vfs)
        {
            _VFS = InjectionChecks.NotNull(vfs);
        }

        public bool ExtractFile(string fileName)
        {
            IntPtr openFileName = VOpenFile(fileName);
            uint size = VFGetsize(openFileName);
            if (size <= 0) return false;
            var readedBytes = VFRead(size, openFileName);
            return WriteBytesToFile(readedBytes, fileName);
        }
        
        private bool WriteBytesToFile(byte[] buffer, string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buffer, 0, buffer.Length);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IntPtr VOpenFile(string fileName)
        {
            return NativeMethods.VOpenFile(fileName, _VFS.VFSData);
        }

        private uint VFGetsize(IntPtr file)
        {
            return NativeMethods.vfgetsize(file);
        }

        private byte[] VFRead(uint size, IntPtr file)
        {
            uint count = this.VFGetsize(file);
            var buffer = new byte[count];
            var successfullyReaded = NativeMethods.vfread(buffer, size, count, file) <= 0 ? false : true;
            if (successfullyReaded)
                return buffer;
            return new byte[0];
        }
    }
}
