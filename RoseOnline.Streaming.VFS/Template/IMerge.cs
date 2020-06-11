using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Template
{
    public interface IMerge<in T>
    {
        void Merge(T data);
    }
}
