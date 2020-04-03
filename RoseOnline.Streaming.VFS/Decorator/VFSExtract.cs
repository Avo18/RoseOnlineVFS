using System;

namespace RoseOnline.Streaming.VFS.Decorator
{

    interface IVFSExtract
    {
        void VOpenFile(string fileName);
        uint VFGetsize();
        bool VFRead(uint size);
    }
    class VFSExtract : VFSBase, IVFSExtract
    {
        private readonly VFS _VFS;
        internal IntPtr _VFSData;
        private byte[] _Buffer;
        public VFSExtract(VFS vfs)
        {
            _VFS = InjectionChecks.NotNull(vfs);
        }

        public void VOpenFile(string fileName)
        {
            _VFSData = NativeMethods.VOpenFile(fileName, _VFS.VFSData);
        }

        public uint VFGetsize()
        {
            return NativeMethods.vfgetsize(_VFSData);
        }

        public bool VFRead(uint size)
        {
            uint count = this.VFGetsize();
            _Buffer = new byte[count];
            return NativeMethods.vfread(_Buffer, size, count, _VFSData) <= 0 ? false : true;
        }
    }
}
