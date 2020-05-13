using RoseOnline.Streaming.VFS.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VFSRoseOnline.ExtentionMethods;

namespace VFSRoseOnline
{
    public partial class Form1
    {
        private VFSReadFacade _vfsReadFacade;

        private void InitializeVFSReadFacade()
        {
            _vfsReadFacade = new VFSReadFacade(_vfsFactory, _vfsModeAdapterFacory, _vfs);
        }

        private void LoadVFS()
        {
            using (_vfsReadFacade)
            {
                _vfsReadFacade.GetAllVFSFileNames();
                _vfsReadFacade.GetAllNodes();
            }
        }
        private Task<TreeNode[]> LoadVFSFilesInTreeview()
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
                        rootNode.AddChildNode(path);
                        //merge.Merge(path);
                        treeViewLoadingProgressBar.Value += 1;
                    }

                    treeNodes.Add(rootNode);             
                    //listMerges.Add(merge);
                }
                CheckProgressbarSuccessfullyLoaded();
                return treeNodes.ToArray();
            });
        }

        private void CheckProgressbarSuccessfullyLoaded()
        {
            if (treeViewLoadingProgressBar.Value == treeViewLoadingProgressBar.Maximum)
            {
                treeViewLoadedStatusLabel.Text = "VFS files successfully loaded";
                treeViewLoadingProgressBar.Visible = false;
            }
        }
    }
}
