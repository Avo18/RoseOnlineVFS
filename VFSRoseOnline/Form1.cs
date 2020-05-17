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
        private readonly VFSModeAdapterFacory _vfsModeAdapterFacory;
        private readonly VFSFactory _vfsFactory;
#pragma warning disable IDE0069  //IDE0069 false-positive
        private readonly VFS _vfs;
        private readonly MenuItem exportMenuItem;
        private readonly ContextMenu contextMenu;
#pragma warning restore IDE0069 
        public Form1()
        { 
            InitializeComponent();
            _vfsModeAdapterFacory = new VFSModeAdapterFacory();
            _vfsFactory = new VFSFactory(_vfsModeAdapterFacory);
            _vfs = _vfsFactory.GetVFS();

            InitializeVFSReadFacade();
            InitializeExtractVFS();
            LoadVFS();

            using (exportMenuItem = new MenuItem("Export"))
            {
                using (contextMenu = new ContextMenu())
                {
                    contextMenu.MenuItems.Add(exportMenuItem);
                }
                exportMenuItem.Click += new EventHandler(ExportMenuItem_Click);
            }
        }

        void ExportMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = treeViewVFS.SelectedNode.Text;
            ExtractFile(fileName);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            treeViewLoadingProgressBar.Maximum = _vfsReadFacade.VFSModel.Sum(x => x.VFSNodes.Count);
            using var cancellationTokenSource = new CancellationTokenSource();
            treeViewVFS.Nodes.AddRange(await LoadVFSFilesInTreeview(cancellationTokenSource.Token));
        }

        private void TreeViewVFS_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!(sender is TreeView treeView)) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right && treeView.SelectedNode != null && treeView.SelectedNode.Text.Contains('.'))
            {
                contextMenu.Show(treeViewVFS, e.Location);
            }
        }
    }
}
