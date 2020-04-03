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
        List<ArraySegment<String>> GetAllNodes();
        ArraySegment<string> GetAllVFSFileNames();
    }

    public class VFSReadFacade : IVFSReadFacade
    {
        private readonly VFSFactory _vfsFactory;
        private readonly VFSModeAdapterFacory _vfsModeAdapterFacory;
        private readonly Decorator.VFS _vfs;
        private readonly VFSStream _vfsStream;

        public ArraySegment<string> VFSFileNames { get; set; }
        private List<VFSModel> vfsModel = new List<VFSModel>();
        public ArraySegment<VFSModel> VFSModel { get; set; }

        public VFSReadFacade()
        {
            _vfsModeAdapterFacory = new VFSModeAdapterFacory();
            _vfsFactory = new VFSFactory(_vfsModeAdapterFacory);
            _vfs = _vfsFactory.GetVFS();
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

        public List<ArraySegment<String>> GetAllNodes()
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
            _vfs.Dispose();
            _vfsStream.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
