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
    public partial class FrameTable : Form
    {
        private readonly PrimesEntities _db;
        public FrameTable()
        {
            InitializeComponent();
            _db = new PrimesEntities();
        }

        private void FrameTable_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            try
            {
                var frames = _db.FrameLists
                .Select(q => new {
                    Id = q.Id,
                    Item = q.Item,
                    Blueprint = q.Blueprint,
                    Neuroptics = q.Neuroptics,
                    Chassis = q.Chassis,
                    Systems = q.Systems
                }).ToList();

                gvFrameList.DataSource = frames;
                gvFrameList.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Add new entry
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFrame addFrame = new AddFrame(this);
            addFrame.MdiParent = MdiParent;
            addFrame.Show();
        }

        // Marks the current selected cell as found (using an *) after confirmation.
        private void btnFound_Click(object sender, EventArgs e)
        {
            try
            {
                int xLoc = gvFrameList.CurrentCellAddress.X;
                int yLoc = gvFrameList.CurrentCellAddress.Y;

                if ((xLoc != 0) && (xLoc != 1))
                {                 
                    string item = gvFrameList.Rows[yLoc].Cells[1].Value.ToString();
                    string part = gvFrameList.Columns[xLoc].Name;

                    DialogResult dr = MessageBox.Show($"Mark {item} {part} as found?", "Confirmation", MessageBoxButtons.YesNo);

                    if(dr == DialogResult.Yes)
                    {
                        var entry = _db.FrameLists.FirstOrDefault(q => q.Item == item);
                        switch (xLoc)
                        {
                            case 2:
                                entry.Blueprint = "*";
                                break;

                            case 3:
                                entry.Neuroptics = "*";
                                break;

                            case 4:
                                entry.Chassis = "*";
                                break;

                            case 5:
                                entry.Systems = "*";
                                break;
                        }
                        _db.SaveChanges();
                        PopulateGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Selection");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Deletes selected entry after confirmation
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Delete Entry?", "Confirmation", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    var id = (int)gvFrameList.SelectedRows[0].Cells["Id"].Value;
                    var entry = _db.FrameLists.FirstOrDefault(q => q.Id == id);

                    _db.FrameLists.Remove(entry);
                    _db.SaveChanges();
                    PopulateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
