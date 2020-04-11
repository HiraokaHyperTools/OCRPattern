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

        private void runBtn_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();

                var command = new SqlCommand(sqlQueryText.Text, db);
                command.Parameters.AddWithValue("@input", sqlInputSampleText.Text);

                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    reader.Close();
                    db.Close();

                    var form = new Form()
                    {
                        Text = "SQL Server 問合せ結果",
                        WindowState = FormWindowState.Maximized,
                    };
                    var grid = new DataGridView()
                    {
                        Parent = form,
                        Dock = DockStyle.Fill,
                        DataSource = dataTable,
                        AllowUserToAddRows = false,
                        AllowUserToDeleteRows = false,
                    };
                    form.Show();
                }
            }
        }

        private void ConfirmApply(TextBox textBox, string newText)
        {
            if (MessageBox.Show(this, newText, null, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                textBox.Text = newText;
            }
        }

        private void SQLServerLookupForm_Load(object sender, EventArgs e)
        {

        }

        private void SQLServerLookupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            blkBindingSource.EndEdit();
        }

        private void connStrBtn_Click(object sender, EventArgs e)
        {
            connStrMenu.Show((Control)sender, Point.Empty);
        }

        private void runConnTestMenu_Click(object sender, EventArgs e)
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

        private void sqlQueryMenuBtn_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();
                var tables = db.GetSchema("Tables");

                sqlQueryMenu.Items.Clear();
                foreach (var row in tables.Select())
                {
                    var item = sqlQueryMenu.Items.Add($"{row[1]}/{row[2]}", null, onClick);
                    item.Tag = row.ItemArray.Cast<string>().Take(3).ToArray();
                }
            }

            sqlQueryMenu.Show((Control)sender, Point.Empty);
        }

        private void onClick(object sender, EventArgs e)
        {
            var restriction = (string[])((ToolStripMenuItem)sender).Tag;

            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();
                var columns = db.GetSchema("Columns", restriction);

                List<string> names = new List<string>();
                foreach (var row in columns.Select())
                {
                    names.Add(row[3] + "");
                }

                db.Close();

                ConfirmApply(sqlQueryText, $"SELECT TOP 1\r\n {string.Join(",\r\n ", names.Select(name => $"[{name}]"))}\r\n\r\n FROM [{restriction[1]}].[{restriction[2]}]\r\n");
            }
        }

        private void sqlOutputColumnMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "SQL Server へ問合せを実行し、列名一覧を取得します。", null, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
            {
                return;
            }

            using (var db = new SqlConnection(sqlConnStrText.Text))
            {
                db.Open();

                var command = new SqlCommand(sqlQueryText.Text, db);
                command.Parameters.AddWithValue("@input", sqlInputSampleText.Text);

                using (var reader = command.ExecuteReader())
                {
                    var text = string.Join("\r\n",
                        Enumerable.Range(0, reader.FieldCount)
                            .Select(i => reader.GetName(i))
                    );

                    reader.Close();
                    db.Close();

                    ConfirmApply(sqlOutputColumnsText, text);
                }
            }
        }
    }
}
