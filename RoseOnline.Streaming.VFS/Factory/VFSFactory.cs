using RoseOnline.Streaming.VFS.Adapter;
using RoseOnline.Streaming.VFS.Decorator;
using System;
using System.Diagnostics.Contracts;

namespace RoseOnline.Streaming.VFS.Factory
{
    interface IVFSFactory
    {
        Decorator.VFS GetVFS();
        VFSStream GetVFSStream(Decorator.VFS vfs);
        VFSExtract GetVFSExtract(Decorator.VFS vfs);
    }

    class VFSFactory : IVFSFactory
    {
        private readonly IVFSModeAdapter _VFSModeAdapter;
        public VFSFactory(IVFSModeAdapterFacory vfsModeAdapterFacory)
        {
            _VFSModeAdapter = InjectionChecks.NotNull(vfsModeAdapterFacory.GetVFSModeAdapter());
        }

        public Decorator.VFS GetVFS()
        {
            return new Decorator.VFS(Constants.DATA_IDX, _VFSModeAdapter.GetStringVFSMode(VFSMode.Read));
        }

        public VFSStream GetVFSStream(Decorator.VFS vfs)
        {
            return new VFSStream(vfs);
        }

        public VFSExtract GetVFSExtract(Decorator.VFS vfs)
        {
            return new VFSExtract(vfs);
        }

    }
}
