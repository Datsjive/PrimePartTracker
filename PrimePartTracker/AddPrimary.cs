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
    public partial class AddPrimary : Form
    {
        private readonly PrimesEntities _db;
        private PrimaryTable _primaryTable;

        public AddPrimary(PrimaryTable primaryTable)
        {
            InitializeComponent();
            _db = new PrimesEntities();
            _primaryTable = primaryTable;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                var newPrimary = new PrimaryList
                {
                    Item = tbItem.Text,
                    Blueprint = $"{cbBlueprint.SelectedItem.ToString()[0]} {tbBlueprint.Text}",
                    Barrel = $"{cbBarrel.SelectedItem.ToString()[0]} {tbBarrel.Text}",
                    Reciever = $"{cbReciever.SelectedItem.ToString()[0]} {tbReciever.Text}",
                    Stock = $"{cbStock.SelectedItem.ToString()[0]} {tbStock.Text}"
                };

                _db.PrimaryLists.Add(newPrimary);
                _db.SaveChanges();
                _primaryTable.PopulateGrid();
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
