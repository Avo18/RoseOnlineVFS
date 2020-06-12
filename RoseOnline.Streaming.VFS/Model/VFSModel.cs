using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Model
{
    public class VFSModel
    {
        public string VFSRoot { get; set; }
        public ArraySegment<VFSNode> VFSNodes { get; set; }
    }

    public class VFSNode
    {
        public string VFSPath { get; set; }
        public IntPtr AddressPtr { get; set; }
    }
}
