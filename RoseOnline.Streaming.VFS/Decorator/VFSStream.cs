using RoseOnline.Streaming.VFS.Model;
using System;
using System.Threading.Tasks;

namespace RoseOnline.Streaming.VFS.Decorator
{
    public interface IVFSStream
    {
        int VGetVfsCount();
        ArraySegment<string> VGetVfsNames();
        int VGetFileCount(string vfsName);
        ArraySegment<VFSNode> VGetFileNames(string vfsName);
        Task<int> VGetVFSCountAsync();
        Task<ArraySegment<string>> VGetVfsNamesAsync();
        Task<int> VGetFileCountAsync(string vfsName);
        Task<ArraySegment<VFSNode>> VGetFileNamesAsync(string vfsName);
    }

    public class VFSStream : VFSBase, IVFSStream
    {
        internal readonly VFS _VFS;
        private bool _dispose;
        public VFSStream(VFS vfs)
        {
            _VFS = Validations.NotNull(vfs);
        }

        public int VGetVfsCount()
        {
            return NativeMethods.VGetVfsCount(_VFS.VFSData) - 1;
        }
        public async Task<int> VGetVFSCountAsync()
        {
            await Task.Yield();
            return VGetVfsCount();
        }

        public ArraySegment<string> VGetVfsNames()
        {
            int numberOfFiles = VGetVfsCount();
            IntPtr[] reserveMemory = ReserveMemory(numberOfFiles);
            NativeMethods.VGetVfsNames(_VFS.VFSData, reserveMemory, numberOfFiles, Constants.MAX_PATH_LENGTH);
            var vfsNames = ConvertIntPtrToString(numberOfFiles, reserveMemory);
            FreeHGlobal(reserveMemory);
            return vfsNames;
        }
        public async Task<ArraySegment<string>> VGetVfsNamesAsync()
        {
            await Task.Yield();
            return VGetVfsNames();
        }

        public int VGetFileCount(string vfsName)
        {
            return NativeMethods.VGetFileCount(_VFS.VFSData, vfsName);
        }
        public async Task<int> VGetFileCountAsync(string vfsName)
        {
            await Task.Yield();
            return VGetFileCount(vfsName);
        }

        public ArraySegment<VFSNode> VGetFileNames(string vfsName)
        {
            int fileCount = VGetFileCount(vfsName);
            IntPtr[] reserveMemory = ReserveMemory(fileCount);
            NativeMethods.VGetFileNames(_VFS.VFSData, vfsName, reserveMemory, fileCount, Constants.MAX_VFS_FILES);
            //var fileNames = ConvertIntPtrToString(fileCount, reserveMemory);
            var fileNames = ConvertIntPtrToList(fileCount, reserveMemory);
            FreeHGlobal(reserveMemory);
            return fileNames;
        }
        public async Task<ArraySegment<VFSNode>> VGetFileNamesAsync(string vfsName)
        {
            await Task.Yield();
            return VGetFileNames(vfsName);
        }

        public sealed override void Dispose()
        {
            if (_dispose) return;
            _VFS.Dispose();
            _dispose = true;
        }
    }
}
