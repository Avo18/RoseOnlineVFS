using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Model
{
    public class VFSModel
    {
        public string VFSRoot { get; set; }
        public ArraySegment<string> VFSNodes { get; set; }
    }
}
