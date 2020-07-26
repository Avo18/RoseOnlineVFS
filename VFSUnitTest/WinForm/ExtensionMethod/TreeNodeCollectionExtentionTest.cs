using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoseOnline.Streaming.VFS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VFSRoseOnline.ExtentionMethods;

namespace VFSUnitTest.WinForm.ExtensionMethod
{
    [TestClass]
    public class TreeNodeCollectionExtentionTest
    {

        [TestMethod]
        public void AddChildNodesToTree()
        {
            TreeNode treeNode = new TreeNode("Root");
            VFSNode node1 = new VFSNode();
            node1.VFSPath = "3DDATA\\ELDEON\\TEST1.DDS";
            VFSNode node2 = new VFSNode();
            node2.VFSPath = "3DDATA\\ELDEON\\TEST2.DDS";
            treeNode.AddChildNode(node1);
            treeNode.AddChildNode(node2);

            Assert.IsTrue(treeNode.FirstNode.Nodes.Count == 2);

        }
    }
}
