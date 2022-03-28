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
    public partial class AddFrame : Form
    {
        private readonly PrimesEntities _db;
        private FrameTable _frameTable;
        public AddFrame(FrameTable frameTable)
        {
            InitializeComponent();
            _db = new PrimesEntities();
            _frameTable = frameTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newFrame = new FrameList
                {
                    Item = tbItem.Text,
                    Blueprint = $"{cbBlueprint.SelectedItem.ToString()[0]} {tbBlueprint.Text}",
                    Neuroptics = $"{cbNeuro.SelectedItem.ToString()[0]} {tbNeuro.Text}",
                    Chassis = $"{cbChassis.SelectedItem.ToString()[0]} {tbChassis.Text}",
                    Systems = $"{cbSystems.SelectedItem.ToString()[0]} {tbSystems.Text}"
                };

                _db.FrameLists.Add(newFrame);
                _db.SaveChanges();
                _frameTable.PopulateGrid();
                Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
