namespace OCRPattern
{
    partial class EditUserPatternsForm
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
            this.components = new System.ComponentModel.Container();
            this.inner = new System.Windows.Forms.Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.editor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showMenu = new System.Windows.Forms.Button();
            this.patterns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.usedLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.郵便番号item = new System.Windows.Forms.ToolStripMenuItem();
            this.電話番号item = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.oneLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.アルファベット一文字item = new System.Windows.Forms.ToolStripMenuItem();
            this.数字一文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アルファベットまたは数字一文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.区切り文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大文字一文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小文字一文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.複数形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inner.SuspendLayout();
            this.table.SuspendLayout();
            this.patterns.SuspendLayout();
            this.SuspendLayout();
            // 
            // inner
            // 
            this.inner.Controls.Add(this.table);
            this.inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inner.Location = new System.Drawing.Point(0, 0);
            this.inner.Name = "inner";
            this.inner.Padding = new System.Windows.Forms.Padding(3);
            this.inner.Size = new System.Drawing.Size(581, 340);
            this.inner.TabIndex = 1;
            // 
            // table
            // 
            this.table.ColumnCount = 3;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.Controls.Add(this.save, 1, 3);
            this.table.Controls.Add(this.cancel, 2, 3);
            this.table.Controls.Add(this.editor, 0, 2);
            this.table.Controls.Add(this.label1, 0, 0);
            this.table.Controls.Add(this.showMenu, 0, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(3, 3);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(575, 334);
            this.table.TabIndex = 0;
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save.Location = new System.Drawing.Point(437, 295);
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
            this.cancel.Location = new System.Drawing.Point(496, 295);
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
            this.editor.Location = new System.Drawing.Point(3, 43);
            this.editor.Multiline = true;
            this.editor.Name = "editor";
            this.editor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.editor.Size = new System.Drawing.Size(569, 246);
            this.editor.TabIndex = 1;
            this.editor.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.table.SetColumnSpan(this.label1, 3);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "優先して認識したいパターンを一行ずつ記述します。";
            // 
            // showMenu
            // 
            this.showMenu.AutoSize = true;
            this.showMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table.SetColumnSpan(this.showMenu, 3);
            this.showMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.showMenu.Location = new System.Drawing.Point(415, 15);
            this.showMenu.Name = "showMenu";
            this.showMenu.Size = new System.Drawing.Size(157, 22);
            this.showMenu.TabIndex = 4;
            this.showMenu.Text = "クリックして、パターンを選択 ∇";
            this.showMenu.UseVisualStyleBackColor = true;
            this.showMenu.Click += new System.EventHandler(this.showMenu_Click);
            // 
            // patterns
            // 
            this.patterns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usedLabel,
            this.郵便番号item,
            this.電話番号item,
            this.toolStripSeparator2,
            this.oneLabel,
            this.アルファベット一文字item,
            this.数字一文字ToolStripMenuItem,
            this.アルファベットまたは数字一文字ToolStripMenuItem,
            this.区切り文字ToolStripMenuItem,
            this.大文字一文字ToolStripMenuItem,
            this.小文字一文字ToolStripMenuItem,
            this.複数形ToolStripMenuItem,
            this.toolStripSeparator1,
            this.helpItem});
            this.patterns.Name = "patterns";
            this.patterns.Size = new System.Drawing.Size(224, 280);
            // 
            // usedLabel
            // 
            this.usedLabel.Enabled = false;
            this.usedLabel.Name = "usedLabel";
            this.usedLabel.Size = new System.Drawing.Size(223, 22);
            this.usedLabel.Text = "よく使うもの：";
            // 
            // 郵便番号item
            // 
            this.郵便番号item.Name = "郵便番号item";
            this.郵便番号item.Size = new System.Drawing.Size(223, 22);
            this.郵便番号item.Text = "郵便番号";
            this.郵便番号item.Click += new System.EventHandler(this.郵便番号item_Click);
            // 
            // 電話番号item
            // 
            this.電話番号item.Name = "電話番号item";
            this.電話番号item.Size = new System.Drawing.Size(223, 22);
            this.電話番号item.Text = "電話番号";
            this.電話番号item.Click += new System.EventHandler(this.電話番号item_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // oneLabel
            // 
            this.oneLabel.Enabled = false;
            this.oneLabel.Name = "oneLabel";
            this.oneLabel.Size = new System.Drawing.Size(223, 22);
            this.oneLabel.Text = "パターン識別子：";
            // 
            // アルファベット一文字item
            // 
            this.アルファベット一文字item.Name = "アルファベット一文字item";
            this.アルファベット一文字item.Size = new System.Drawing.Size(223, 22);
            this.アルファベット一文字item.Text = "アルファベット一文字";
            this.アルファベット一文字item.Click += new System.EventHandler(this.アルファベット一文字item_Click);
            // 
            // 数字一文字ToolStripMenuItem
            // 
            this.数字一文字ToolStripMenuItem.Name = "数字一文字ToolStripMenuItem";
            this.数字一文字ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.数字一文字ToolStripMenuItem.Text = "数字一文字";
            this.数字一文字ToolStripMenuItem.Click += new System.EventHandler(this.数字一文字ToolStripMenuItem_Click);
            // 
            // アルファベットまたは数字一文字ToolStripMenuItem
            // 
            this.アルファベットまたは数字一文字ToolStripMenuItem.Name = "アルファベットまたは数字一文字ToolStripMenuItem";
            this.アルファベットまたは数字一文字ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.アルファベットまたは数字一文字ToolStripMenuItem.Text = "アルファベットまたは数字一文字";
            this.アルファベットまたは数字一文字ToolStripMenuItem.Click += new System.EventHandler(this.アルファベットまたは数字一文字ToolStripMenuItem_Click);
            // 
            // 区切り文字ToolStripMenuItem
            // 
            this.区切り文字ToolStripMenuItem.Name = "区切り文字ToolStripMenuItem";
            this.区切り文字ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.区切り文字ToolStripMenuItem.Text = "区切り文字";
            this.区切り文字ToolStripMenuItem.Click += new System.EventHandler(this.区切り文字ToolStripMenuItem_Click);
            // 
            // 大文字一文字ToolStripMenuItem
            // 
            this.大文字一文字ToolStripMenuItem.Name = "大文字一文字ToolStripMenuItem";
            this.大文字一文字ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.大文字一文字ToolStripMenuItem.Text = "大文字一文字";
            this.大文字一文字ToolStripMenuItem.Click += new System.EventHandler(this.大文字一文字ToolStripMenuItem_Click);
            // 
            // 小文字一文字ToolStripMenuItem
            // 
            this.小文字一文字ToolStripMenuItem.Name = "小文字一文字ToolStripMenuItem";
            this.小文字一文字ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.小文字一文字ToolStripMenuItem.Text = "小文字一文字";
            this.小文字一文字ToolStripMenuItem.Click += new System.EventHandler(this.小文字一文字ToolStripMenuItem_Click);
            // 
            // 複数形ToolStripMenuItem
            // 
            this.複数形ToolStripMenuItem.Name = "複数形ToolStripMenuItem";
            this.複数形ToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.複数形ToolStripMenuItem.Text = "複数形";
            this.複数形ToolStripMenuItem.Click += new System.EventHandler(this.複数形ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // helpItem
            // 
            this.helpItem.Name = "helpItem";
            this.helpItem.Size = new System.Drawing.Size(223, 22);
            this.helpItem.Text = "ヘルプ表示 (英語サイトへ移動)";
            this.helpItem.Click += new System.EventHandler(this.helpItem_Click);
            // 
            // EditUserPatternsForm
            // 
            this.AcceptButton = this.save;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(581, 340);
            this.Controls.Add(this.inner);
            this.Name = "EditUserPatternsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ユーザーパターン帳を編集";
            this.inner.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.patterns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inner;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        internal System.Windows.Forms.TextBox editor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showMenu;
        private System.Windows.Forms.ContextMenuStrip patterns;
        private System.Windows.Forms.ToolStripMenuItem 郵便番号item;
        private System.Windows.Forms.ToolStripMenuItem 電話番号item;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpItem;
        private System.Windows.Forms.ToolStripMenuItem usedLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem アルファベット一文字item;
        private System.Windows.Forms.ToolStripMenuItem oneLabel;
        private System.Windows.Forms.ToolStripMenuItem 数字一文字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アルファベットまたは数字一文字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 区切り文字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 複数形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大文字一文字ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小文字一文字ToolStripMenuItem;
    }
}