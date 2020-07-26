using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Factory;
using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoseOnline.Streaming.VFS.Facade
{
    public class VFSExtractFacade : VFSFacadeBase
    {
        private readonly VFSExtract _vfsExtract;
        public VFSExtractFacade(VFSFactory vfsFactory, VFSModeAdapterFacory vfsModeAdapterFacory, Decorator.VFS vfs) 
            : base(vfsFactory, vfsModeAdapterFacory, vfs)
        {
            _vfsExtract = new VFSExtract();
        }

        public async Task<bool> ExtractFileAsync(string fileName, IntPtr vfsFile, CancellationToken token = default) 
            => await _vfsExtract.ExtractFileAsync(fileName, vfsFile, token).ConfigureAwait(false);
    }
}
