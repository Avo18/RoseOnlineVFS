using RoseOnline.Streaming.VFS.Collection;
using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFSRoseOnline.ExtentionMethods
{
    public static class TreeNodeCollectionExtention
    {
        public static TreeNode[] AddRange(this TreeNodeCollection treeNodeCollection, ArraySegment<string> values)
        {
            var treeNodes = new List<TreeNode>();
            foreach(var value in values)
            {
                treeNodes.Add(new TreeNode(value));
            }
            treeNodeCollection.AddRange(treeNodes.ToArray());
            return treeNodes.ToArray();
        }

        public static void AddRange(this TreeNodeCollection treeNodeCollection, ArraySegment<VFSModel> values)
        {
            foreach(var value in values)
            {
                AddRootNode(treeNodeCollection, value.VFSRoot);
                AddChildNode(treeNodeCollection, value);
            }
        }

        public static void AddRange(this TreeNodeCollection treeNodeCollection, VFSTree<string> vfsTree)
        {

        }

        private static void AddRootNode(TreeNodeCollection treeNodeCollection, string value)
        {
            treeNodeCollection.Add(new TreeNode(value));
        }

        private static void AddChildNode(TreeNodeCollection treeNodeCollection, VFSModel model)
        {
            //var getChildNodesOfRoot = treeNodeCollection[model.VFSRoot].Nodes;

        }
    }
}
