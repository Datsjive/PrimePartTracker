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
    public partial class MeleeTable : Form
    {
        private readonly PrimesEntities _db;
        public MeleeTable()
        {
            InitializeComponent();
            _db = new PrimesEntities();
        }

        private void MeleeTable_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            try
            {
                var melees = _db.MeleeLists
                .Select(q => new {
                    Id = q.Id,
                    Item = q.Item,
                    Blueprint = q.Blueprint,
                    Blade = q.Blade,
                    Handle = q.Handle
                }).ToList();

                gvMeleeList.DataSource = melees;
                gvMeleeList.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Add new entry
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMelee addMelee = new AddMelee(this);
            addMelee.MdiParent = MdiParent;
            addMelee.Show();
        }

        // Marks the current selected cell as found (using an *) after confirmation.
        private void btnFound_Click(object sender, EventArgs e)
        {
            try
            {
                int xLoc = gvMeleeList.CurrentCellAddress.X;
                int yLoc = gvMeleeList.CurrentCellAddress.Y;

                if ((xLoc != 0) && (xLoc != 1))
                {
                    string item = gvMeleeList.Rows[yLoc].Cells[1].Value.ToString();
                    string part = gvMeleeList.Columns[xLoc].Name;

                    DialogResult dr = MessageBox.Show($"Mark {item} {part} as found?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        var entry = _db.MeleeLists.FirstOrDefault(q => q.Item == item);
                        switch (xLoc)
                        {
                            case 2:
                                entry.Blueprint = "*";
                                break;

                            case 3:
                                entry.Blade = "*";
                                break;

                            case 4:
                                entry.Handle = "*";
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
                    var id = (int)gvMeleeList.SelectedRows[0].Cells["Id"].Value;
                    var entry = _db.MeleeLists.FirstOrDefault(q => q.Id == id);

                    _db.MeleeLists.Remove(entry);
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
