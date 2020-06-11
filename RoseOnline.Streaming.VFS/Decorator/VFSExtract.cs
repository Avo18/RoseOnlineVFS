using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RoseOnline.Streaming.VFS.Decorator
{

    public interface IVFSExtract
    {
        Task<bool> ExtractFileAsync(string fileName, IntPtr vfsFile, CancellationToken token = default);
    }
    public class VFSExtract : Stream, IVFSExtract
    {
        private readonly MemoryStream _buffer;
        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => _buffer.Length;

        public override long Position { get => _buffer.Position; set => throw new NotSupportedException("This stream not supporting seek"); }

        public VFSExtract()
        {
            _buffer = new MemoryStream();
        }

        public VFSExtract(MemoryStream buffer)
        {
            _buffer = Validations.NotNull(buffer);
        }

        ~VFSExtract()
        {
            Dispose(false);
        }

        public async Task<bool> ExtractFileAsync(string fileName, IntPtr vfsFile, CancellationToken token = default)
        {
            IntPtr openFileName = VOpenFile(fileName, vfsFile);
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

        private IntPtr VOpenFile(string fileName, IntPtr vfsFile)
        {
            return NativeMethods.VOpenFile(fileName, vfsFile);
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

        public override void Flush() => _buffer.Flush();

        public override Task FlushAsync(CancellationToken cancellationToken) => _buffer.FlushAsync(cancellationToken);

        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException("This is not supported");

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException("Seek is not supported");

        public override void SetLength(long value) => throw new NotSupportedException("SetLength is not supported");

        public override void Write(byte[] buffer, int offset, int count) => _buffer.Write(buffer, offset, count);


        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            _buffer.Dispose();
        }
    }
}
