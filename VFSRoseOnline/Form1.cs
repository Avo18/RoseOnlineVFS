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
        private readonly MenuItem exportMenuItem = new MenuItem("Export");
        private readonly ContextMenu contextMenu = new ContextMenu();
        public Form1()
        { 
            InitializeComponent();
            Init();
            contextMenu.MenuItems.Add(exportMenuItem);
            exportMenuItem.Click += new EventHandler(exportMenuItem_Click);
        }

        void exportMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            treeViewLoadingProgressBar.Maximum = _vfsReadFacade.VFSModel.Sum(x => x.VFSNodes.Count);
            treeViewVFS.Nodes.AddRange(await LoadVFSFilesInTreeview());
        }

        private void treeViewVFS_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            if (treeView == null) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right && treeView.SelectedNode != null && treeView.SelectedNode.Text.Contains('.'))
            {
                contextMenu.Show(treeViewVFS, e.Location);
            }
        }
    }
}
