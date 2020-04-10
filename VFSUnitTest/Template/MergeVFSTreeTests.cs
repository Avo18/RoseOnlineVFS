using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoseOnline.Streaming.VFS.Template;
using RoseOnline.Streaming.VFS.Collection;
using RoseOnline.Streaming.VFS.Adapter;

namespace VFSUnitTest.Template
{
    /// <summary>
    /// Summary description for MergeVFSTreeTests
    /// </summary>
    [TestClass]
    public class MergeVFSTreeTests
    {
        private MergeVFSTree Sut;

        [TestInitialize]
        public void Init()
        {
            Sut = new MergeVFSTree(new VFSTree<string>("Root"));
        }
        [TestMethod]
        public void SamePathMerge()
        {
            var path1 = "3DDATA\\MAPS\\ELDEON\\EZ01\\31_29.TIL";
            var path2 = "3DDATA\\MAPS\\ELDEON\\EZ01\\31_30.TIL";

            Sut.Merge(path1);
            Sut.Merge(path2);
            var result = Sut.VFSTree;

            Assert.IsTrue(result.Index.Index.Index.Files.Count == 2);
        }

        [TestMethod]
        public void NotTheSamePathMerge()
        {
            var path1 = "3DMAPS\\MAPS\\ELDEON\\EZ01\\31_29.TIL";
            var path2 = "3DDATA\\MAPS\\ELDEON\\EZ02\\31_30.TIL";


           // var result = Sut.Merge(path1VFSTree, path2);

        }
    }
}
