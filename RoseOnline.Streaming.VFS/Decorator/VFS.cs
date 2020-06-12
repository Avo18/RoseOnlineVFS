using System;

namespace RoseOnline.Streaming.VFS.Decorator
{
    public interface IVFS
    {
        string IndexFile { get; set; }
        string VFSMode { get; set; }
    }


    public class VFS : VFSBase, IVFS
    {
        private bool _dispose;
        public string IndexFile { get; set; }
        public string VFSMode { get; set; }
        internal IntPtr VFSData { get; set; }

        public VFS(string indexFile, string vfsMode)
        {
            IndexFile = Validations.NotNullOrEmpty(indexFile);
            VFSMode = vfsMode;
            Init();
        }

        private void Init()
        {
            OpenVFS();
        }

        private void OpenVFS()
        {
            VFSData = NativeMethods.OpenVFS(this.IndexFile, VFSMode);
        }

        private void CloseVFS()
        {
            NativeMethods.CloseVFS(VFSData);
        }

        public sealed override void Dispose()
        {
            if (_dispose) return;
            CloseVFS();
            _dispose = true;
        }
    }

    public enum VFSMode
    {
        Read = 0x01
    }
}
