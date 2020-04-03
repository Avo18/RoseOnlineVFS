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
    }
}
