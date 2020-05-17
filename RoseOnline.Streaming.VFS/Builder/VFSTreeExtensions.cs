using RoseOnline.Streaming.VFS.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Builder
{
    public static class VFSTreeExtensions
    {

        public static VFSTree<T> AddFile<T>(this VFSTree<T> @this, string file)
        {
            @this.AddFile(file);
            return @this;
        }
    }
}
