using RoseOnline.Streaming.VFS.Adapter;

namespace RoseOnline.Streaming.VFS.Factory
{
    interface IVFSModeAdapterFacory
    {
        IVFSModeAdapter GetVFSModeAdapter();
    }

    class VFSModeAdapterFacory : IVFSModeAdapterFacory
    {
        public IVFSModeAdapter GetVFSModeAdapter()
        {
            return new VFSModeAdapter();
        }
    }
}
