using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RoseOnline.Streaming.VFS.Decorator
{

    public interface IVFSExtract
    {
        Task<bool> ExtractFileAsync(string fileName, CancellationToken token = default);
    }
    public class VFSExtract : VFSBase, IVFSExtract
    {
        private readonly VFS _VFS;
        private bool _dispose;
        public VFSExtract(VFS vfs)
        {
            _VFS = InjectionChecks.NotNull(vfs);
        }

        public async Task<bool> ExtractFileAsync(string fileName, CancellationToken token = default)
        {
            IntPtr openFileName = VOpenFile(fileName);
            uint size = VFGetsize(openFileName);
            if (size <= 0) return false;
            var readedBytes = VFRead(size, openFileName);
            return await WriteBytesToFileAsync(readedBytes, fileName, token).ConfigureAwait(false);
        }
        
        private async Task<bool> WriteBytesToFileAsync(byte[] buffer, string fileName, CancellationToken token = default)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    await fs.WriteAsync(buffer, 0, buffer.Length, token).ConfigureAwait(false);
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

        public sealed override void Dispose()
        {
            if (_dispose) return;
            _VFS.Dispose();
            _dispose = true;
        }
    }
}
