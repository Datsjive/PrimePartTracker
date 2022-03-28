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
    public partial class PrimaryTable : Form
    {
        private readonly PrimesEntities _db;
        public PrimaryTable()
        {
            InitializeComponent();
            _db = new PrimesEntities();
        }

        private void PrimaryTable_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            try
            {
                var primaries = _db.PrimaryLists
                .Select(q => new {
                    Id = q.Id,
                    Item = q.Item,
                    Blueprint = q.Blueprint,
                    Barrel = q.Barrel,
                    Reciever = q.Reciever,
                    Stock = q.Stock
                }).ToList();

                gvPrimaryList.DataSource = primaries;
                gvPrimaryList.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Add new entry
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPrimary addPrimary = new AddPrimary(this);
            addPrimary.MdiParent = MdiParent;
            addPrimary.Show();
        }

        // Marks the current selected cell as found (using an *) after confirmation.
        private void btnFound_Click(object sender, EventArgs e)
        {
            try
            {
                int xLoc = gvPrimaryList.CurrentCellAddress.X;
                int yLoc = gvPrimaryList.CurrentCellAddress.Y;

                if ((xLoc != 0) && (xLoc != 1))
                {
                    string item = gvPrimaryList.Rows[yLoc].Cells[1].Value.ToString();
                    string part = gvPrimaryList.Columns[xLoc].Name;

                    DialogResult dr = MessageBox.Show($"Mark {item} {part} as found?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        var entry = _db.PrimaryLists.FirstOrDefault(q => q.Item == item);
                        switch (xLoc)
                        {
                            case 2:
                                entry.Blueprint = "*";
                                break;

                            case 3:
                                entry.Barrel = "*";
                                break;

                            case 4:
                                entry.Reciever = "*";
                                break;

                            case 5:
                                entry.Stock = "*";
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
                    var id = (int)gvPrimaryList.SelectedRows[0].Cells["Id"].Value;
                    var entry = _db.PrimaryLists.FirstOrDefault(q => q.Id == id);

                    _db.PrimaryLists.Remove(entry);
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
