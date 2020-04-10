using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCRPattern
{
    public partial class SQLServerLookupForm : Form
    {
        public SQLServerLookupForm(BindingSource blkBindingSource)
        {
            InitializeComponent();

            this.blkBindingSource.DataSource = blkBindingSource;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SqlConnection(sqlConnStrText.Text))
                {
                    db.Open();
                }
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();

                var command = new SqlCommand(sqlQueryText.Text, db);
                command.Parameters.AddWithValue("@input", sqlInputSampleText.Text);

                using (var reader = command.ExecuteReader())
                {
                    sqlOutputColumnsText.Text = string.Join("\r\n",
                        Enumerable.Range(0, reader.FieldCount)
                            .Select(i => reader.GetName(i))
                    );
                }
            }
        }

        private void buildBtn_Click(object sender, EventArgs e)
        {

        }

        private void SQLServerLookupForm_Load(object sender, EventArgs e)
        {

        }

        private void SQLServerLookupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            blkBindingSource.EndEdit();
        }

        private void buildQueryBtn_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();
                var tables = db.GetSchema("Tables");

                schemaMenu.Items.Clear();
                foreach (var row in tables.Select())
                {
                    var item = schemaMenu.Items.Add($"{row[1]}/{row[2]}");
                    item.Tag = row.ItemArray.Cast<string>().Take(3).ToArray();
                }
            }

            schemaMenu.Show((Control)sender, Point.Empty);
        }

        private void schemaMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var restriction = (string[])e.ClickedItem.Tag;

            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();
                var columns = db.GetSchema("Columns", restriction);

                List<string> names = new List<string>();
                foreach (var row in columns.Select())
                {
                    names.Add(row[3] + "");
                }

                sqlQueryText.Text = $"SELECT TOP 1\r\n {string.Join(",\r\n ", names.Select(name => $"[{name}]"))}\r\n\r\n FROM [{restriction[1]}].[{restriction[2]}]\r\n";
            }
        }
    }
}
