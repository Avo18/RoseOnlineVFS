using RoseOnline.Streaming.VFS.Adapter;

namespace RoseOnline.Streaming.VFS.Factory
{
    public interface IVFSModeAdapterFacory
    {
        IVFSModeAdapter GetVFSModeAdapter();
    }

    public class VFSModeAdapterFacory : IVFSModeAdapterFacory
    {
        public IVFSModeAdapter GetVFSModeAdapter()
        {
            return new VFSModeAdapter();
        }
    }
}
