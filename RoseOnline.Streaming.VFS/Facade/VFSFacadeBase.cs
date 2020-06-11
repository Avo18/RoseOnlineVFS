using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Facade
{
    public abstract class VFSFacadeBase
    {
        private protected VFSFactory _vfsFactory;
        private protected VFSModeAdapterFacory _vfsModeAdapterFacory;
        private protected Decorator.VFS _vfs;
        public VFSFacadeBase(VFSFactory vfsFactory, VFSModeAdapterFacory vfsModeAdapterFacory, Decorator.VFS vfs)
        {
            _vfsFactory = Validations.NotNull(vfsFactory);
            _vfsModeAdapterFacory = Validations.NotNull(vfsModeAdapterFacory);
            _vfs = Validations.NotNull(vfs);

            //_vfsModeAdapterFacory = new VFSModeAdapterFacory();
            //_vfsFactory = new VFSFactory(_vfsModeAdapterFacory);
            //_vfs = _vfsFactory.GetVFS();

        }
    }
}
