namespace OCRPattern
{
    partial class EditUserWordsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inner = new System.Windows.Forms.Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.editor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inner.SuspendLayout();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // inner
            // 
            this.inner.Controls.Add(this.table);
            this.inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inner.Location = new System.Drawing.Point(0, 0);
            this.inner.Name = "inner";
            this.inner.Padding = new System.Windows.Forms.Padding(3);
            this.inner.Size = new System.Drawing.Size(544, 388);
            this.inner.TabIndex = 0;
            // 
            // table
            // 
            this.table.ColumnCount = 3;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.Controls.Add(this.save, 1, 3);
            this.table.Controls.Add(this.cancel, 2, 3);
            this.table.Controls.Add(this.editor, 0, 2);
            this.table.Controls.Add(this.label1, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(3, 3);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(538, 382);
            this.table.TabIndex = 0;
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save.Location = new System.Drawing.Point(400, 343);
            this.save.Name = "save";
            this.save.Padding = new System.Windows.Forms.Padding(7);
            this.save.Size = new System.Drawing.Size(53, 36);
            this.save.TabIndex = 2;
            this.save.Text = "保存";
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(459, 343);
            this.cancel.Name = "cancel";
            this.cancel.Padding = new System.Windows.Forms.Padding(7);
            this.cancel.Size = new System.Drawing.Size(76, 36);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "キャンセル";
            // 
            // editor
            // 
            this.editor.AcceptsReturn = true;
            this.table.SetColumnSpan(this.editor, 3);
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(3, 15);
            this.editor.Multiline = true;
            this.editor.Name = "editor";
            this.editor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.editor.Size = new System.Drawing.Size(532, 322);
            this.editor.TabIndex = 1;
            this.editor.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.table.SetColumnSpan(this.label1, 3);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "優先して認識したい単語を一行ずつ記述します。";
            // 
            // EditUserWordsForm
            // 
            this.AcceptButton = this.save;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(544, 388);
            this.Controls.Add(this.inner);
            this.Name = "EditUserWordsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "単語帳を編集";
            this.inner.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inner;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox editor;
    }
}