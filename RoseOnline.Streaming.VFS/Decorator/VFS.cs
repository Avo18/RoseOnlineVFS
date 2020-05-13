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
        public string IndexFile { get; set; }
        public string VFSMode { get; set; }
        internal IntPtr VFSData { get; set; }

        public VFS(string indexFile, string vfsMode)
        {
            IndexFile = InjectionChecks.NotNullOrEmpty(indexFile);
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

        public override void Dispose()
        {
            CloseVFS();
            base.Dispose();
        }
    }

    public enum VFSMode
    {
        Read = 0x01
    }
}
