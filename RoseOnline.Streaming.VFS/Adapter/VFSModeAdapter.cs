using RoseOnline.Streaming.VFS.Decorator;
using System.IO;

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
