using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Factory;
using System;
using System.Collections.Generic;
using System.Text;

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

        public bool ExtractFile(string fileName)
        {
            return _vfsExtract.ExtractFile(fileName);
        }
    }
}
