using RoseOnline.Streaming.VFS.Facade;
using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VFSRoseOnline.ExtentionMethods;

namespace VFSRoseOnline
{
    public partial class Form1
    {
#pragma warning disable IDE0069  //IDE0069 false-positive
        private VFSReadFacade _vfsReadFacade;
#pragma warning restore IDE0069
        private List<ArraySegment<VFSNode>> VFSNodes { get; set; }

        private void InitializeVFSReadFacade()
        {
            _vfsReadFacade = new VFSReadFacade(_vfsFactory, _vfsModeAdapterFacory, _vfs);
        }

        private void LoadVFS()
        {
            using (_vfsReadFacade)
            {
                _vfsReadFacade.GetAllVFSFileNames();
                VFSNodes = _vfsReadFacade.GetAllNodes();
            }
        }
        private Task<TreeNode[]> LoadVFSFilesInTreeview(CancellationToken token = default)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            return Task.Run(() =>
            {
                //List<MergeVFSTree> listMerges = new List<MergeVFSTree>();
                foreach (var model in _vfsReadFacade.VFSModel)
                {
                    treeViewLoadedStatusLabel.Text = string.Intern("Loading: ") + model.VFSRoot;
                    //MergeVFSTree merge = new MergeVFSTree(new RoseOnline.Streaming.VFS.Collection.VFSTree<string>(model.VFSRoot));
                    var rootNode = new TreeNode(model.VFSRoot);
                    foreach (var path in model.VFSNodes)
                    {
                        rootNode.AddChildNode(path.VFSPath);
                        //merge.Merge(path);
                        Invoke(new EventHandle(() => treeViewLoadingProgressBar.Value += 1)); 
                    }

                    treeNodes.Add(rootNode);             
                    //listMerges.Add(merge);
                }
                CheckProgressbarSuccessfullyLoaded();
                return treeNodes.ToArray();
            }, token);
        }

        private void CheckProgressbarSuccessfullyLoaded()
        {
            if (treeViewLoadingProgressBar.Value == treeViewLoadingProgressBar.Maximum)
            {
                Invoke(new EventHandle(() => treeViewLoadedStatusLabel.Text = "VFS files successfully loaded"));
                Invoke(new EventHandle(() => treeViewLoadingProgressBar.Visible = false));
            }
        }
    }
}
