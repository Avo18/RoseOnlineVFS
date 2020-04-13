using RoseOnline.Streaming.VFS.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Template
{
    public class MergeVFSTree : IMerge<string>
    {
        public VFSTree<string> VFSTree { get; set; }
        public MergeVFSTree(VFSTree<string> root)
        {
            VFSTree = root;
        }

        public void Merge(string data)
        {
            MergePathToVFSTree(data);
        }

        private void MergePathToVFSTree(string data)
        {
            var folders = data.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            if (folders.Length == 0) return;

            int index = 1;
            for (VFSTree<string> nested = VFSTree; index < folders.Length; index++)
            {
                var getValuePath = folders[index];
                if (AddFile(getValuePath, nested)) return;

                var foundNode = nested.FindNode(getValuePath);
                if (foundNode == null)
                {
                    foundNode = nested.AddChild(getValuePath);
                }
                nested = foundNode;
            }
        }

        private bool AddFile(string file, VFSTree<string> node)
        {
            var foundFile = CheckIfFile(file);
            if (foundFile)
            {
                node.AddFile(file);
                return true;
            }
            return false;
        }
        private bool CheckIfFile(string file)
        {
            var isFile = file.Contains(".");
            if (!isFile) return false;
            return true;
        }
    }
}
