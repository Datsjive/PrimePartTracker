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
    public partial class AddMelee : Form
    {
        private readonly PrimesEntities _db;
        private MeleeTable _meleeTable;
        public AddMelee(MeleeTable meleeTable)
        {
            InitializeComponent();
            _db = new PrimesEntities();
            _meleeTable = meleeTable;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                var newMelee = new MeleeList
                {
                    Item = tbItem.Text,
                    Blueprint = $"{cbBlueprint.SelectedItem.ToString()[0]} {tbBlueprint.Text}",
                    Blade = $"{cbBlade.SelectedItem.ToString()[0]} {tbBlade.Text}",
                    Handle = $"{cbHandle.SelectedItem.ToString()[0]} {tbHandle.Text}"
                };

                _db.MeleeLists.Add(newMelee);
                _db.SaveChanges();
                _meleeTable.PopulateGrid();
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
