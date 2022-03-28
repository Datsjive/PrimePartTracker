using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimePartTracker
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void miFrames_Click(object sender, EventArgs e)
        {
            if (!Utils.TabIsOpen("FrameTable"))
            {
                FrameTable frameTable = new FrameTable();
                frameTable.MdiParent = this;
                frameTable.Show();
            }
        }

        private void miPrimary_Click(object sender, EventArgs e)
        {
            if (!Utils.TabIsOpen("PrimaryTable"))
            {
                PrimaryTable primaryTable = new PrimaryTable();
                primaryTable.MdiParent = this;
                primaryTable.Show();
            }
        }

        private void miMelee_Click(object sender, EventArgs e)
        {
            if (!Utils.TabIsOpen("MeleeTable"))
            {
                MeleeTable meleeTable = new MeleeTable();
                meleeTable.MdiParent = this;
                meleeTable.Show();
            }
        }
    }
}
