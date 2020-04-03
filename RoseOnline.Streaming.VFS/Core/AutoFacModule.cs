using Autofac;
using RoseOnline.Streaming.VFS.Factory;
using System.IO;

namespace RoseOnline.Streaming.VFS.Core
{
    public class AutoFacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IVFSFactory>().As<VFSFactory>();

        }
    }
}
