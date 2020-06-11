using RoseOnline.Streaming.VFS.Adapter;
using RoseOnline.Streaming.VFS.Decorator;
using System;
using System.Diagnostics.Contracts;

namespace RoseOnline.Streaming.VFS.Factory
{
    public interface IVFSFactory
    {
        Decorator.VFS GetVFS();
        VFSStream GetVFSStream(Decorator.VFS vfs);
        VFSExtract GetVFSExtract(Decorator.VFS vfs);
    }

    public class VFSFactory : IVFSFactory
    {
        private readonly IVFSModeAdapter _VFSModeAdapter;
        public VFSFactory(IVFSModeAdapterFacory vfsModeAdapterFacory)
        {
            _VFSModeAdapter = Validations.NotNull(vfsModeAdapterFacory.GetVFSModeAdapter());
        }

        public Decorator.VFS GetVFS()
        {
            using (var result = new Decorator.VFS(Constants.DATA_IDX, _VFSModeAdapter.GetStringVFSMode(VFSMode.Read)))
            {
                return result;
            }
        }

        public VFSStream GetVFSStream(Decorator.VFS vfs)
        {
            Validations.NotNull(vfs);
            using (var result = new VFSStream(vfs))
            {
                return result;
            }
        }

        public VFSExtract GetVFSExtract(Decorator.VFS vfs)
        {
            Validations.NotNull(vfs);
            using (var result = new VFSExtract(vfs))
            {
                return result;
            }
        }

    }
}
