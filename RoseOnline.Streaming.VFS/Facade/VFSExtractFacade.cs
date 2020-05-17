using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Factory;
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
            _vfsExtract = new VFSExtract(_vfs);
        }

        public async Task<bool> ExtractFileAsync(string fileName, CancellationToken token = default)
        {
            return await _vfsExtract.ExtractFileAsync(fileName, token).ConfigureAwait(false);
        }
    }
}
