using RoseOnline.Streaming.VFS.Facade;
using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VFSRoseOnline
{
    public partial class Form1
    {
        private VFSExtractFacade _vfsExtractFacade;
        private void InitializeExtractVFS()
        {
            _vfsExtractFacade = new VFSExtractFacade(_vfsFactory, _vfsModeAdapterFacory, _vfs);
        }
        public async Task<bool> ExtractFileAsync(string filename, IntPtr vfsFile, CancellationToken token = default)
        {
            return await _vfsExtractFacade.ExtractFileAsync(filename, vfsFile, token).ConfigureAwait(false);
        }
    }
}
