using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Factory;
using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RoseOnline.Streaming.VFS.Facade
{
    public interface IVFSReadFacade : IDisposable
    {
        List<ArraySegment<VFSNode>> GetAllNodes();
        ArraySegment<string> GetAllVFSFileNames();
    }

    public class VFSReadFacade : VFSFacadeBase, IVFSReadFacade
    {
        private readonly VFSStream _vfsStream;
        public ArraySegment<string> VFSFileNames { get; set; }
        private readonly List<VFSModel> vfsModel = new List<VFSModel>();
        public ArraySegment<VFSModel> VFSModel { get; set; }
        private bool _dispose;

        public VFSReadFacade(VFSFactory vfsFactory, VFSModeAdapterFacory vfsModeAdapterFacory, Decorator.VFS vfs) 
            : base(vfsFactory, vfsModeAdapterFacory, vfs)
        {
            _vfsStream = _vfsFactory.GetVFSStream(_vfs);
            VFSFileNames = new ArraySegment<string>();
            VFSModel = new ArraySegment<VFSModel>();
        }

        public ArraySegment<string> GetAllVFSFileNames()
        {
            VFSFileNames = _vfsStream.VGetVfsNames();
            foreach (var vfsFileName in VFSFileNames)
            {
                vfsModel.Add(new Model.VFSModel()
                {
                    VFSRoot = vfsFileName
                });
            }
            return VFSFileNames;
        }

        public List<ArraySegment<VFSNode>> GetAllNodes()
        {
            foreach (var vfsName in VFSFileNames)
            {
                var findModel = vfsModel.Find(x => x.VFSRoot.Equals(vfsName));
                if (findModel == null || string.IsNullOrEmpty(findModel.VFSRoot))
                    continue;
                findModel.VFSNodes = _vfsStream.VGetFileNames(vfsName);
            }
            VFSModel = new ArraySegment<VFSModel>(vfsModel.ToArray());
            return vfsModel.Select(x => x.VFSNodes).ToList();
        }

        public void Dispose()
        {
            if (_dispose) return;
            _vfs.Dispose();
            _vfsStream.Dispose();
            _dispose = true;
        }
    }
}
