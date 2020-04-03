using RoseOnline.Streaming.VFS.Decorator;
using RoseOnline.Streaming.VFS.Facade;
using RoseOnline.Streaming.VFS.Factory;
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
            treeViewVFS.Nodes.AddRange(_vfsReadFacade.VFSFileNames);
            var b = _vfsReadFacade.VFSModel;
        }
    }
}
