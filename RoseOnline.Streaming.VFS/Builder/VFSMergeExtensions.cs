using RoseOnline.Streaming.VFS.Template;

namespace RoseOnline.Streaming.VFS.Builder
{
    public static class VFSMergeExtensions
    {
        public static IMerge<T> MergePath<T>(this IMerge<T> @this, T path) where T : class, new()
        {
            @this.Merge(path);
            return @this;
        }
    }
}
