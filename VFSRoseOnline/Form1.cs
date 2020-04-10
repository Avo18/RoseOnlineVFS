using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Facade;
using RoseOnline.Streaming.VFS.Factory;
using RoseOnline.Streaming.VFS.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VFSRoseOnline.ExtentionMethods;

namespace VFSRoseOnline
{
    public partial class Form1 : Form
    {
        private readonly VFSReadFacade _vfsReadFacade;
        public Form1()
        { 
            InitializeComponent();
            using (_vfsReadFacade = new VFSReadFacade())
            {
                _vfsReadFacade.GetAllVFSFileNames();
                _vfsReadFacade.GetAllNodes();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeViewVFS.Nodes.AddRange(_vfsReadFacade.VFSModel);

            List<MergeVFSTree> listMerges = new List<MergeVFSTree>();
            foreach(var model in _vfsReadFacade.VFSModel)
            {
                MergeVFSTree merge = new MergeVFSTree(new RoseOnline.Streaming.VFS.Collection.VFSTree<string>(model.VFSRoot));
                foreach (var path in model.VFSNodes)
                {
                    merge.Merge(path);
                }
                listMerges.Add(merge);
            }
        }

    }
}
