namespace OCRPattern {
    partial class MForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbFiles = new System.Windows.Forms.TextBox();
            this.cfgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.task = new OCRPattern.Task();
            this.tsc = new System.Windows.Forms.ToolStripContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbDoNotSplit = new System.Windows.Forms.CheckBox();
            this.bRefRecycDir = new System.Windows.Forms.Button();
            this.cbUseRecyc = new System.Windows.Forms.CheckBox();
            this.tbRecycDir = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bSelForm = new System.Windows.Forms.Button();
            this.tbSeledForm = new System.Windows.Forms.TextBox();
            this.cbOnlyThis = new System.Windows.Forms.CheckBox();
            this.cbRotate4 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbMoveInAfter = new System.Windows.Forms.CheckBox();
            this.cbMoveOutAfter = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbRunOutCmd = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOutParm = new System.Windows.Forms.TextBox();
            this.bAddOutParm = new System.Windows.Forms.Button();
            this.tbOutCmd = new System.Windows.Forms.TextBox();
            this.bRefOutCmd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbClear = new System.Windows.Forms.CheckBox();
            this.cbImportAlways = new System.Windows.Forms.CheckBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bRefDirOut = new System.Windows.Forms.Button();
            this.tbDirOut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bRefDirIn = new System.Windows.Forms.Button();
            this.tbDirIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tstop = new System.Windows.Forms.ToolStrip();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bDebugOutput = new System.Windows.Forms.ToolStripButton();
            this.fbdDirIn = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdDirOut = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdOutCmd = new System.Windows.Forms.OpenFileDialog();
            this.cmsOutCmd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mParmcsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mParmpic = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdAdd = new System.Windows.Forms.OpenFileDialog();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.fbdRecycDir = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.cfgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.task)).BeginInit();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tstop.SuspendLayout();
            this.cmsOutCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "入力ファイル一覧：";
            this.tt.SetToolTip(this.label1, "認識を掛けるファイルを1行1ファイルで入力します。 ");
            // 
            // tbFiles
            // 
            this.tbFiles.AllowDrop = true;
            this.tbFiles.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "Files", true));
            this.tbFiles.Location = new System.Drawing.Point(12, 24);
            this.tbFiles.Multiline = true;
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFiles.Size = new System.Drawing.Size(395, 140);
            this.tbFiles.TabIndex = 1;
            this.tbFiles.WordWrap = false;
            this.tbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFiles_DragDrop);
            this.tbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbFiles_DragEnter);
            // 
            // cfgBindingSource
            // 
            this.cfgBindingSource.DataMember = "Cfg";
            this.cfgBindingSource.DataSource = this.task;
            // 
            // task
            // 
            this.task.DataSetName = "Task";
            this.task.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.groupBox5);
            this.tsc.ContentPanel.Controls.Add(this.groupBox4);
            this.tsc.ContentPanel.Controls.Add(this.cbRotate4);
            this.tsc.ContentPanel.Controls.Add(this.groupBox3);
            this.tsc.ContentPanel.Controls.Add(this.groupBox2);
            this.tsc.ContentPanel.Controls.Add(this.groupBox1);
            this.tsc.ContentPanel.Controls.Add(this.bAdd);
            this.tsc.ContentPanel.Controls.Add(this.bRefDirOut);
            this.tsc.ContentPanel.Controls.Add(this.tbDirOut);
            this.tsc.ContentPanel.Controls.Add(this.label3);
            this.tsc.ContentPanel.Controls.Add(this.bRefDirIn);
            this.tsc.ContentPanel.Controls.Add(this.tbDirIn);
            this.tsc.ContentPanel.Controls.Add(this.label2);
            this.tsc.ContentPanel.Controls.Add(this.label1);
            this.tsc.ContentPanel.Controls.Add(this.tbFiles);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(434, 720);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(434, 745);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.tstop);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbDoNotSplit);
            this.groupBox5.Controls.Add(this.bRefRecycDir);
            this.groupBox5.Controls.Add(this.cbUseRecyc);
            this.groupBox5.Controls.Add(this.tbRecycDir);
            this.groupBox5.Location = new System.Drawing.Point(12, 452);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(407, 76);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // cbDoNotSplit
            // 
            this.cbDoNotSplit.AutoSize = true;
            this.cbDoNotSplit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "DoNotSplit", true));
            this.cbDoNotSplit.Location = new System.Drawing.Point(150, 47);
            this.cbDoNotSplit.Name = "cbDoNotSplit";
            this.cbDoNotSplit.Size = new System.Drawing.Size(164, 16);
            this.cbDoNotSplit.TabIndex = 3;
            this.cbDoNotSplit.Text = "ページを分割しない(NB仕様)";
            this.cbDoNotSplit.UseVisualStyleBackColor = true;
            // 
            // bRefRecycDir
            // 
            this.bRefRecycDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bRefRecycDir.Location = new System.Drawing.Point(320, 22);
            this.bRefRecycDir.Name = "bRefRecycDir";
            this.bRefRecycDir.Size = new System.Drawing.Size(75, 19);
            this.bRefRecycDir.TabIndex = 2;
            this.bRefRecycDir.Text = "参照...";
            this.bRefRecycDir.UseVisualStyleBackColor = true;
            this.bRefRecycDir.Click += new System.EventHandler(this.bRefRecycDir_Click);
            // 
            // cbUseRecyc
            // 
            this.cbUseRecyc.AutoSize = true;
            this.cbUseRecyc.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "UseRecyc", true));
            this.cbUseRecyc.Location = new System.Drawing.Point(6, 0);
            this.cbUseRecyc.Name = "cbUseRecyc";
            this.cbUseRecyc.Size = new System.Drawing.Size(263, 16);
            this.cbUseRecyc.TabIndex = 0;
            this.cbUseRecyc.Text = "認識に失敗したら、ページを次のフォルダに保存する";
            this.cbUseRecyc.UseVisualStyleBackColor = true;
            // 
            // tbRecycDir
            // 
            this.tbRecycDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "DirRecyc", true));
            this.tbRecycDir.Location = new System.Drawing.Point(8, 22);
            this.tbRecycDir.Name = "tbRecycDir";
            this.tbRecycDir.Size = new System.Drawing.Size(306, 19);
            this.tbRecycDir.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bSelForm);
            this.groupBox4.Controls.Add(this.tbSeledForm);
            this.groupBox4.Controls.Add(this.cbOnlyThis);
            this.groupBox4.Location = new System.Drawing.Point(12, 639);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 64);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // bSelForm
            // 
            this.bSelForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bSelForm.Location = new System.Drawing.Point(320, 22);
            this.bSelForm.Name = "bSelForm";
            this.bSelForm.Size = new System.Drawing.Size(75, 19);
            this.bSelForm.TabIndex = 4;
            this.bSelForm.Text = "選択...";
            this.bSelForm.UseVisualStyleBackColor = true;
            this.bSelForm.Click += new System.EventHandler(this.bSelForm_Click);
            // 
            // tbSeledForm
            // 
            this.tbSeledForm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "SeledForm", true));
            this.tbSeledForm.Location = new System.Drawing.Point(8, 22);
            this.tbSeledForm.Name = "tbSeledForm";
            this.tbSeledForm.Size = new System.Drawing.Size(306, 19);
            this.tbSeledForm.TabIndex = 1;
            // 
            // cbOnlyThis
            // 
            this.cbOnlyThis.AutoSize = true;
            this.cbOnlyThis.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "OnlyThis", true));
            this.cbOnlyThis.Location = new System.Drawing.Point(6, 0);
            this.cbOnlyThis.Name = "cbOnlyThis";
            this.cbOnlyThis.Size = new System.Drawing.Size(179, 16);
            this.cbOnlyThis.TabIndex = 0;
            this.cbOnlyThis.Text = "このフォームだけを使って読み取る";
            this.cbOnlyThis.UseVisualStyleBackColor = true;
            this.cbOnlyThis.CheckedChanged += new System.EventHandler(this.cbRotate4_CheckedChanged);
            // 
            // cbRotate4
            // 
            this.cbRotate4.AutoSize = true;
            this.cbRotate4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "Rotate4", true));
            this.cbRotate4.Location = new System.Drawing.Point(18, 617);
            this.cbRotate4.Name = "cbRotate4";
            this.cbRotate4.Size = new System.Drawing.Size(129, 16);
            this.cbRotate4.TabIndex = 13;
            this.cbRotate4.Text = "4方向で認識を試みる";
            this.cbRotate4.UseVisualStyleBackColor = true;
            this.cbRotate4.CheckedChanged += new System.EventHandler(this.cbRotate4_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.cbMoveInAfter);
            this.groupBox3.Controls.Add(this.cbMoveOutAfter);
            this.groupBox3.Location = new System.Drawing.Point(12, 534);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 77);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "認識が終了した後の動作";
            // 
            // cbMoveInAfter
            // 
            this.cbMoveInAfter.AutoSize = true;
            this.cbMoveInAfter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "MoveInAfter", true));
            this.cbMoveInAfter.Location = new System.Drawing.Point(6, 18);
            this.cbMoveInAfter.Name = "cbMoveInAfter";
            this.cbMoveInAfter.Size = new System.Drawing.Size(331, 16);
            this.cbMoveInAfter.TabIndex = 0;
            this.cbMoveInAfter.Text = "入力ファイルは %TEMP% に移動し、元の場所に残さないようにする";
            this.cbMoveInAfter.UseVisualStyleBackColor = true;
            // 
            // cbMoveOutAfter
            // 
            this.cbMoveOutAfter.AutoSize = true;
            this.cbMoveOutAfter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "MoveOutAfter", true));
            this.cbMoveOutAfter.Location = new System.Drawing.Point(6, 40);
            this.cbMoveOutAfter.Name = "cbMoveOutAfter";
            this.cbMoveOutAfter.Size = new System.Drawing.Size(331, 16);
            this.cbMoveOutAfter.TabIndex = 1;
            this.cbMoveOutAfter.Text = "出力ファイルは %TEMP% に移動し、元の場所に残さないようにする";
            this.cbMoveOutAfter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbRunOutCmd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbOutParm);
            this.groupBox2.Controls.Add(this.bAddOutParm);
            this.groupBox2.Controls.Add(this.tbOutCmd);
            this.groupBox2.Controls.Add(this.bRefOutCmd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // cbRunOutCmd
            // 
            this.cbRunOutCmd.AutoSize = true;
            this.cbRunOutCmd.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "RunOutCmd", true));
            this.cbRunOutCmd.Location = new System.Drawing.Point(6, 0);
            this.cbRunOutCmd.Name = "cbRunOutCmd";
            this.cbRunOutCmd.Size = new System.Drawing.Size(158, 16);
            this.cbRunOutCmd.TabIndex = 0;
            this.cbRunOutCmd.Text = "認識に成功したら、実行する";
            this.cbRunOutCmd.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "実行するプログラム：";
            // 
            // tbOutParm
            // 
            this.tbOutParm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "OutParm", true));
            this.tbOutParm.Location = new System.Drawing.Point(8, 71);
            this.tbOutParm.Name = "tbOutParm";
            this.tbOutParm.Size = new System.Drawing.Size(306, 19);
            this.tbOutParm.TabIndex = 5;
            // 
            // bAddOutParm
            // 
            this.bAddOutParm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bAddOutParm.Location = new System.Drawing.Point(320, 71);
            this.bAddOutParm.Name = "bAddOutParm";
            this.bAddOutParm.Size = new System.Drawing.Size(75, 19);
            this.bAddOutParm.TabIndex = 6;
            this.bAddOutParm.Text = "変数項";
            this.bAddOutParm.UseVisualStyleBackColor = true;
            this.bAddOutParm.Click += new System.EventHandler(this.bAddOutParm_Click);
            // 
            // tbOutCmd
            // 
            this.tbOutCmd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "OutCmd", true));
            this.tbOutCmd.Location = new System.Drawing.Point(8, 34);
            this.tbOutCmd.Name = "tbOutCmd";
            this.tbOutCmd.Size = new System.Drawing.Size(308, 19);
            this.tbOutCmd.TabIndex = 2;
            // 
            // bRefOutCmd
            // 
            this.bRefOutCmd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bRefOutCmd.Location = new System.Drawing.Point(320, 34);
            this.bRefOutCmd.Name = "bRefOutCmd";
            this.bRefOutCmd.Size = new System.Drawing.Size(75, 19);
            this.bRefOutCmd.TabIndex = 3;
            this.bRefOutCmd.Text = "選択...";
            this.bRefOutCmd.UseVisualStyleBackColor = true;
            this.bRefOutCmd.Click += new System.EventHandler(this.bRefOutCmd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "引数：";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.cbClear);
            this.groupBox1.Controls.Add(this.cbImportAlways);
            this.groupBox1.Location = new System.Drawing.Point(12, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "このタスクを開いた時の動作";
            // 
            // cbClear
            // 
            this.cbClear.AutoSize = true;
            this.cbClear.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "ClearAlways", true));
            this.cbClear.Location = new System.Drawing.Point(6, 18);
            this.cbClear.Name = "cbClear";
            this.cbClear.Size = new System.Drawing.Size(170, 16);
            this.cbClear.TabIndex = 0;
            this.cbClear.Text = "「入力ファイル一覧」をクリアする";
            this.tt.SetToolTip(this.cbClear, "タスクを開いた際に、入力ファイル一覧の入力欄を空っぽにします。 ");
            this.cbClear.UseVisualStyleBackColor = true;
            // 
            // cbImportAlways
            // 
            this.cbImportAlways.AutoSize = true;
            this.cbImportAlways.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cfgBindingSource, "ImportAlways", true));
            this.cbImportAlways.Location = new System.Drawing.Point(6, 40);
            this.cbImportAlways.Name = "cbImportAlways";
            this.cbImportAlways.Size = new System.Drawing.Size(356, 16);
            this.cbImportAlways.TabIndex = 1;
            this.cbImportAlways.Text = "「入力フォルダ」の中を読み取って、「入力ファイル一覧」に自動入力する";
            this.cbImportAlways.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bAdd.Location = new System.Drawing.Point(332, 170);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 19);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = "追加...";
            this.tt.SetToolTip(this.bAdd, "ファイルを追加します。 ");
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bRefDirOut
            // 
            this.bRefDirOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bRefDirOut.Location = new System.Drawing.Point(332, 321);
            this.bRefDirOut.Name = "bRefDirOut";
            this.bRefDirOut.Size = new System.Drawing.Size(75, 19);
            this.bRefDirOut.TabIndex = 9;
            this.bRefDirOut.Text = "参照...";
            this.bRefDirOut.UseVisualStyleBackColor = true;
            this.bRefDirOut.Click += new System.EventHandler(this.bRefDirOut_Click);
            // 
            // tbDirOut
            // 
            this.tbDirOut.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "DirOut", true));
            this.tbDirOut.Location = new System.Drawing.Point(12, 321);
            this.tbDirOut.Name = "tbDirOut";
            this.tbDirOut.Size = new System.Drawing.Size(314, 19);
            this.tbDirOut.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "出力フォルダ：";
            // 
            // bRefDirIn
            // 
            this.bRefDirIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bRefDirIn.Location = new System.Drawing.Point(332, 204);
            this.bRefDirIn.Name = "bRefDirIn";
            this.bRefDirIn.Size = new System.Drawing.Size(75, 19);
            this.bRefDirIn.TabIndex = 5;
            this.bRefDirIn.Text = "参照...";
            this.bRefDirIn.UseVisualStyleBackColor = true;
            this.bRefDirIn.Click += new System.EventHandler(this.bRefDirIn_Click);
            // 
            // tbDirIn
            // 
            this.tbDirIn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cfgBindingSource, "DirIn", true));
            this.tbDirIn.Location = new System.Drawing.Point(12, 204);
            this.tbDirIn.Name = "tbDirIn";
            this.tbDirIn.Size = new System.Drawing.Size(314, 19);
            this.tbDirIn.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "入力フォルダ：";
            // 
            // tstop
            // 
            this.tstop.Dock = System.Windows.Forms.DockStyle.None;
            this.tstop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSave,
            this.toolStripSeparator1,
            this.bRun,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.bDebugOutput});
            this.tstop.Location = new System.Drawing.Point(3, 0);
            this.tstop.Name = "tstop";
            this.tstop.Size = new System.Drawing.Size(307, 25);
            this.tstop.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(88, 22);
            this.bSave.Text = "設定を保存";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bRun
            // 
            this.bRun.Image = ((System.Drawing.Image)(resources.GetObject("bRun.Image")));
            this.bRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(89, 22);
            this.bRun.Text = "OCRを開始";
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bDebugOutput
            // 
            this.bDebugOutput.Image = ((System.Drawing.Image)(resources.GetObject("bDebugOutput.Image")));
            this.bDebugOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDebugOutput.Name = "bDebugOutput";
            this.bDebugOutput.Size = new System.Drawing.Size(100, 22);
            this.bDebugOutput.Text = "デバッグ出力";
            this.bDebugOutput.Click += new System.EventHandler(this.bDebugOutput_Click);
            // 
            // fbdDirIn
            // 
            this.fbdDirIn.Description = "入力フォルダ：";
            // 
            // fbdDirOut
            // 
            this.fbdDirOut.Description = "出力フォルダ：";
            // 
            // ofdOutCmd
            // 
            this.ofdOutCmd.Filter = "プログラム|*.exe;*.bat;*.cmd";
            this.ofdOutCmd.Multiselect = true;
            // 
            // cmsOutCmd
            // 
            this.cmsOutCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mParmcsv,
            this.mParmpic});
            this.cmsOutCmd.Name = "cmsOutCmd";
            this.cmsOutCmd.Size = new System.Drawing.Size(149, 48);
            // 
            // mParmcsv
            // 
            this.mParmcsv.Name = "mParmcsv";
            this.mParmcsv.Size = new System.Drawing.Size(148, 22);
            this.mParmcsv.Text = "出力したCSV";
            this.mParmcsv.Click += new System.EventHandler(this.mParmcsv_Click);
            // 
            // mParmpic
            // 
            this.mParmpic.Name = "mParmpic";
            this.mParmpic.Size = new System.Drawing.Size(148, 22);
            this.mParmpic.Text = "出力した画像";
            this.mParmpic.Click += new System.EventHandler(this.mParmpic_Click);
            // 
            // ofdAdd
            // 
            this.ofdAdd.Filter = global::OCRPattern.Properties.Settings.Default.GazoIn;
            this.ofdAdd.Multiselect = true;
            // 
            // fbdRecycDir
            // 
            this.fbdRecycDir.Description = "認識に失敗したら、ページを次のフォルダに保存する";
            // 
            // MForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 745);
            this.Controls.Add(this.tsc);
            this.Name = "MForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "タスク編集";
            this.Load += new System.EventHandler(this.MForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cfgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.task)).EndInit();
            this.tsc.ContentPanel.ResumeLayout(false);
            this.tsc.ContentPanel.PerformLayout();
            this.tsc.TopToolStripPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.PerformLayout();
            this.tsc.ResumeLayout(false);
            this.tsc.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tstop.ResumeLayout(false);
            this.tstop.PerformLayout();
            this.cmsOutCmd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFiles;
        private System.Windows.Forms.OpenFileDialog ofdAdd;
        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.ToolStrip tstop;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bRun;
        private System.Windows.Forms.CheckBox cbClear;
        private System.Windows.Forms.BindingSource cfgBindingSource;
        private Task task;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDirIn;
        private System.Windows.Forms.CheckBox cbImportAlways;
        private System.Windows.Forms.Button bRefDirIn;
        private System.Windows.Forms.FolderBrowserDialog fbdDirIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bRefDirOut;
        private System.Windows.Forms.TextBox tbDirOut;
        private System.Windows.Forms.FolderBrowserDialog fbdDirOut;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.CheckBox cbMoveInAfter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOutCmd;
        private System.Windows.Forms.Button bRefOutCmd;
        private System.Windows.Forms.OpenFileDialog ofdOutCmd;
        private System.Windows.Forms.Button bAddOutParm;
        private System.Windows.Forms.ContextMenuStrip cmsOutCmd;
        private System.Windows.Forms.ToolStripMenuItem mParmcsv;
        private System.Windows.Forms.ToolStripMenuItem mParmpic;
        private System.Windows.Forms.CheckBox cbMoveOutAfter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbOutParm;
        private System.Windows.Forms.CheckBox cbRunOutCmd;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbRotate4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbOnlyThis;
        private System.Windows.Forms.TextBox tbSeledForm;
        private System.Windows.Forms.Button bSelForm;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbUseRecyc;
        private System.Windows.Forms.TextBox tbRecycDir;
        private System.Windows.Forms.Button bRefRecycDir;
        private System.Windows.Forms.FolderBrowserDialog fbdRecycDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bDebugOutput;
        private System.Windows.Forms.CheckBox cbDoNotSplit;
    }
}

