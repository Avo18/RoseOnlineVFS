using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoseOnline.Streaming.VFS.Collection;

namespace VFSUnitTest
{
    [TestClass]
    public class VFSTreeTests
    {
        [TestMethod]
        public void VFSTreeFind_FoundChild()
        {
            var root = new VFSTree<string>("root");
            root.AddChild("child000");
            root.AddChild("child001");
            root.AddChild("child002");

            var childNode = root.FindNode("child001");
            childNode.AddChild("child011");
            childNode.AddChild("child021");

            Assert.AreEqual("child001", childNode.Data);
        }

        [TestMethod]
        public void VFSTreeFind_NoChildFound()
        {
            var root = new VFSTree<string>("root");
            root.AddChild("child000");
            root.AddChild("child001");
            root.AddChild("child002");

            var childNode = root.FindNode("123");

            Assert.IsNull(childNode);
        }

        [TestMethod]
        public void VFSTreeFind_DeeperChildFound()
        {
            var root = new VFSTree<string>("root");
            root.AddChild("child000");
            root.AddChild("child001");
            root.AddChild("child002");

            var childNode1 = root.FindNode("child001");
            childNode1.AddChild("child011");
            childNode1.AddChild("child021");
            var childNode21 = root.FindNode("child001").FindNode("child021");
            childNode21.AddChild("child121");
            childNode21.AddChild("child221");

            Assert.AreEqual("child021", childNode21.Data);
        }
    }
}
