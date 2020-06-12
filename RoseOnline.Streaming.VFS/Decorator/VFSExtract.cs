using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RoseOnline.Streaming.VFS.Decorator
{
    public class VFSExtract : Stream
    {
        private readonly MemoryStream _buffer;
        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => _buffer.Length;

        public override long Position { get => _buffer.Position; set => throw NotSupported(); }

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
            await WriteAsync(readedBytes, 0, size, token).ConfigureAwait(false);
            return true;
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

        public override Task FlushAsync(CancellationToken cancellationToken) 
            => _buffer.FlushAsync(cancellationToken);

        public override int Read(byte[] buffer, int offset, int count)
            => throw NotSupported();

        public override long Seek(long offset, SeekOrigin origin)
            => throw NotSupported();

        public override void SetLength(long value)
            => throw NotSupported();

        public override void Write(byte[] buffer, int offset, int count) 
            => _buffer.Write(buffer, offset, count);

        public Task WriteAsync(byte[] buffer, int offset, uint count, CancellationToken cancellationToken)
            => WriteAsync(buffer, offset, checked((int)count), cancellationToken);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) 
            => _buffer.WriteAsync(buffer, offset, count, cancellationToken);
        

        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            _buffer.Dispose();
        }

        private Exception NotSupported() => throw new NotSupportedException("This is not supported.");
    }
}
