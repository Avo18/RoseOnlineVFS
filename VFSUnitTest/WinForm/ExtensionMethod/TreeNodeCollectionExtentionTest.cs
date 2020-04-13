using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            treeNode.AddChildNode("3DDATA\\ELDEON\\TEST1.DDS");
            treeNode.AddChildNode("3DDATA\\ELDEON\\TEST2.DDS");

            Assert.IsTrue(treeNode.FirstNode.Nodes.Count == 2);

        }
    }
}
