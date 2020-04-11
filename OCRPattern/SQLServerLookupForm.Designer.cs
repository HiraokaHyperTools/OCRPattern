namespace OCRPattern
{
    partial class SQLServerLookupForm
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.blkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dcr = new OCRPattern.DCR();
            this.label1 = new System.Windows.Forms.Label();
            this.sqlConnStrText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlQueryText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sqlInputSampleText = new System.Windows.Forms.TextBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.sqlOutputColumnsText = new System.Windows.Forms.TextBox();
            this.connStrMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runConnTestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.connStrBtn = new System.Windows.Forms.Button();
            this.sqlQueryMenuBtn = new System.Windows.Forms.Button();
            this.sqlQueryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sqlOutputColumnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.blkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcr)).BeginInit();
            this.connStrMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.blkBindingSource, "UseSQLServerLookup", true));
            this.checkBox1.Location = new System.Drawing.Point(12, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(187, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "SQL Server Lookup を使用します";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // blkBindingSource
            // 
            this.blkBindingSource.DataMember = "Blk";
            this.blkBindingSource.DataSource = this.dcr;
            // 
            // dcr
            // 
            this.dcr.DataSetName = "DCR";
            this.dcr.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ConnectionString";
            // 
            // sqlConnStrText
            // 
            this.sqlConnStrText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "SQLConnStr", true));
            this.sqlConnStrText.Location = new System.Drawing.Point(12, 65);
            this.sqlConnStrText.Name = "sqlConnStrText";
            this.sqlConnStrText.Size = new System.Drawing.Size(317, 19);
            this.sqlConnStrText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "SQL 問合せ文";
            // 
            // sqlQueryText
            // 
            this.sqlQueryText.AcceptsReturn = true;
            this.sqlQueryText.AcceptsTab = true;
            this.sqlQueryText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "SQLQuery", true));
            this.sqlQueryText.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sqlQueryText.Location = new System.Drawing.Point(12, 168);
            this.sqlQueryText.Multiline = true;
            this.sqlQueryText.Name = "sqlQueryText";
            this.sqlQueryText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlQueryText.Size = new System.Drawing.Size(317, 133);
            this.sqlQueryText.TabIndex = 5;
            this.sqlQueryText.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "@input パラメータに与えるサンプル文字列";
            // 
            // sqlInputSampleText
            // 
            this.sqlInputSampleText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "SQLInputSample", true));
            this.sqlInputSampleText.Location = new System.Drawing.Point(12, 111);
            this.sqlInputSampleText.Name = "sqlInputSampleText";
            this.sqlInputSampleText.Size = new System.Drawing.Size(317, 19);
            this.sqlInputSampleText.TabIndex = 10;
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(12, 447);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 46);
            this.runBtn.TabIndex = 11;
            this.runBtn.Text = "テスト問合せ";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "出力のうち、採用する列";
            // 
            // sqlOutputColumnsText
            // 
            this.sqlOutputColumnsText.AcceptsReturn = true;
            this.sqlOutputColumnsText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "SQLOutputColumns", true));
            this.sqlOutputColumnsText.Location = new System.Drawing.Point(12, 330);
            this.sqlOutputColumnsText.Multiline = true;
            this.sqlOutputColumnsText.Name = "sqlOutputColumnsText";
            this.sqlOutputColumnsText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlOutputColumnsText.Size = new System.Drawing.Size(317, 94);
            this.sqlOutputColumnsText.TabIndex = 8;
            this.sqlOutputColumnsText.WordWrap = false;
            // 
            // connStrMenu
            // 
            this.connStrMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runConnTestMenu});
            this.connStrMenu.Name = "connStrMenu";
            this.connStrMenu.Size = new System.Drawing.Size(167, 26);
            // 
            // runConnTestMenu
            // 
            this.runConnTestMenu.Name = "runConnTestMenu";
            this.runConnTestMenu.Size = new System.Drawing.Size(166, 22);
            this.runConnTestMenu.Text = "接続テストを実行...";
            this.runConnTestMenu.Click += new System.EventHandler(this.runConnTestMenu_Click);
            // 
            // connStrBtn
            // 
            this.connStrBtn.Location = new System.Drawing.Point(335, 65);
            this.connStrBtn.Name = "connStrBtn";
            this.connStrBtn.Size = new System.Drawing.Size(75, 19);
            this.connStrBtn.TabIndex = 3;
            this.connStrBtn.Text = "...";
            this.connStrBtn.UseVisualStyleBackColor = true;
            this.connStrBtn.Click += new System.EventHandler(this.connStrBtn_Click);
            // 
            // sqlQueryMenuBtn
            // 
            this.sqlQueryMenuBtn.Location = new System.Drawing.Point(335, 168);
            this.sqlQueryMenuBtn.Name = "sqlQueryMenuBtn";
            this.sqlQueryMenuBtn.Size = new System.Drawing.Size(75, 19);
            this.sqlQueryMenuBtn.TabIndex = 6;
            this.sqlQueryMenuBtn.Text = "...";
            this.sqlQueryMenuBtn.UseVisualStyleBackColor = true;
            this.sqlQueryMenuBtn.Click += new System.EventHandler(this.sqlQueryMenuBtn_Click);
            // 
            // sqlQueryMenu
            // 
            this.sqlQueryMenu.Name = "sqlQueryMenu";
            this.sqlQueryMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // sqlOutputColumnMenu
            // 
            this.sqlOutputColumnMenu.Location = new System.Drawing.Point(335, 330);
            this.sqlOutputColumnMenu.Name = "sqlOutputColumnMenu";
            this.sqlOutputColumnMenu.Size = new System.Drawing.Size(75, 19);
            this.sqlOutputColumnMenu.TabIndex = 18;
            this.sqlOutputColumnMenu.Text = "...";
            this.sqlOutputColumnMenu.UseVisualStyleBackColor = true;
            this.sqlOutputColumnMenu.Click += new System.EventHandler(this.sqlOutputColumnMenu_Click);
            // 
            // SQLServerLookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 524);
            this.Controls.Add(this.sqlOutputColumnMenu);
            this.Controls.Add(this.sqlQueryMenuBtn);
            this.Controls.Add(this.connStrBtn);
            this.Controls.Add(this.sqlOutputColumnsText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.sqlInputSampleText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sqlQueryText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sqlConnStrText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Name = "SQLServerLookupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQLServerLookupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SQLServerLookupForm_FormClosing);
            this.Load += new System.EventHandler(this.SQLServerLookupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcr)).EndInit();
            this.connStrMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource blkBindingSource;
        private DCR dcr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sqlConnStrText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sqlQueryText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sqlInputSampleText;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sqlOutputColumnsText;
        private System.Windows.Forms.ContextMenuStrip connStrMenu;
        private System.Windows.Forms.ToolStripMenuItem runConnTestMenu;
        private System.Windows.Forms.Button connStrBtn;
        private System.Windows.Forms.Button sqlQueryMenuBtn;
        private System.Windows.Forms.ContextMenuStrip sqlQueryMenu;
        private System.Windows.Forms.Button sqlOutputColumnMenu;
    }
}