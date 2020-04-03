using RoseOnline.Streaming.VFS.Decorator;

namespace RoseOnline.Streaming.VFS.Adapter
{
    public interface IVFSModeAdapter
    {
        string GetStringVFSMode(VFSMode vfsMode);
    }

    public class VFSModeAdapter : IVFSModeAdapter
    {
        public string GetStringVFSMode(VFSMode vfsMode)
        {
            switch(vfsMode)
            {
                case VFSMode.Read:
                    return "r";
            }
            return null;
        }
    }
}
