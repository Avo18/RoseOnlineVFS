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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VFSRoseOnline.ExtentionMethods;

namespace VFSRoseOnline
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
            Init();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            treeViewLoadingProgressBar.Maximum = _vfsReadFacade.VFSModel.Sum(x => x.VFSNodes.Count);
            treeViewVFS.Nodes.AddRange(await LoadVFSFilesInTreeview());
        }

        
    }
}
