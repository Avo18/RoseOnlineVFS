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
        public static TreeNode AddRootNode(this TreeNodeCollection treeNodeCollection, string value)
        {
            var rootNode = new TreeNode(value);
            treeNodeCollection.Add(new TreeNode(value));
            return treeNodeCollection.Cast<TreeNode>().Where(x => x.Text == value).FirstOrDefault();
        }


        public static void AddChildNode(this TreeNode treeNode, string path)
        {
            string[] folders = path.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            int index = 1;
            for (TreeNode nested = treeNode; index < folders.Length; index++)
            {
                var getValuePath = folders[index];

                var foundNode = nested.Nodes.Cast<TreeNode>().Where(x => x.Text == getValuePath);
                if (foundNode.Count() == 0)
                {
                    nested.Nodes.Add(getValuePath);
                }
                nested = foundNode.FirstOrDefault();
            }
        }
    }
}
