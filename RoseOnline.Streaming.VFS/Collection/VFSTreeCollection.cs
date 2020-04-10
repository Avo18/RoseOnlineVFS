using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RoseOnline.Streaming.VFS.Collection
{
    public class VFSTree<T> : IEnumerable<VFSTree<T>>
    {
        public VFSTree<T> Parent { get; set; }
        public T Data { get; set; }
        public List<VFSTree<T>> Childeren { get; set; }

        public List<T> Files { get; set; }

        public VFSTree<T> Index { get; set; }
        public bool IsRoot
        {
            get { return Parent == null; }
        }

        public VFSTree(T data)
        {
            Data = data;
            Childeren = new List<VFSTree<T>>();
            Files = new List<T>();
        }

        public VFSTree<T> AddChild(T child)
        {
            VFSTree<T> node = new VFSTree<T>(child) { Parent = this };
            Childeren.Add(node);
            Index = node;
            return Index;
        }

        public void AddFile(T file)
        {
            Files.Add(file);
        }

        public VFSTree<T> FindNode(T find)
        {
            for (var i = Index; i != null; i = i.Index)
            {
                //var found = i.Childeren.Find(x => x.Data.Equals(find));
                var found = i.Data.Equals(find);
                //if (found != null)
                if (found)
                    return i;
                if (i.IsRoot)
                    break;
            }
            return null;
        }


        public IEnumerator<VFSTree<T>> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
            foreach (var child in Childeren)
                foreach (var value in child)
                    yield return value;

        }
    }
}
