namespace OCRPattern {
    partial class TemplateForm {
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
            System.Windows.Forms.Label testKeywordLabel;
            System.Windows.Forms.Label laWL;
            System.Windows.Forms.Label laBL;
            System.Windows.Forms.Label xLabel;
            System.Windows.Forms.Label cRTypeLabel;
            System.Windows.Forms.Label fieldNameLabel;
            System.Windows.Forms.Label postProcessLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            this.cmsCharList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mCLDigit = new System.Windows.Forms.ToolStripMenuItem();
            this.mCLLetterU = new System.Windows.Forms.ToolStripMenuItem();
            this.mCLLetterL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsc = new System.Windows.Forms.ToolStripContainer();
            this.vsc = new System.Windows.Forms.SplitContainer();
            this.slpPv = new OCRPattern.ScrollLessPanel();
            this.picPane = new OCRPattern.PicPane();
            this.cmsPicPane = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mSelArea = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpStat = new System.Windows.Forms.TableLayoutPanel();
            this.llRevertPic = new System.Windows.Forms.LinkLabel();
            this.lRes = new System.Windows.Forms.Label();
            this.bSQLServer = new System.Windows.Forms.Button();
            this.bAddPP = new System.Windows.Forms.Button();
            this.postProcessTextBox = new System.Windows.Forms.TextBox();
            this.blkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dcr = new OCRPattern.DCR();
            this.cbSkipWs = new System.Windows.Forms.CheckBox();
            this.cbNeedVerify = new System.Windows.Forms.CheckBox();
            this.bVerifyKw = new System.Windows.Forms.Button();
            this.lnum = new System.Windows.Forms.Label();
            this.bReportAll = new System.Windows.Forms.Button();
            this.numNewRes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.bWL = new System.Windows.Forms.Button();
            this.bBL = new System.Windows.Forms.Button();
            this.cbSelArea = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPWay = new System.Windows.Forms.ComboBox();
            this.cbNR = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testKeywordTextBox = new System.Windows.Forms.TextBox();
            this.cbPSM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bTestSeled = new System.Windows.Forms.Button();
            this.whitelistTextBox = new System.Windows.Forms.TextBox();
            this.blacklistTextBox = new System.Windows.Forms.TextBox();
            this.ifTestCheckBox = new System.Windows.Forms.CheckBox();
            this.ifImportCheckBox = new System.Windows.Forms.CheckBox();
            this.bTestAll = new System.Windows.Forms.Button();
            this.gvRes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.blkBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.fieldNameTextBox = new System.Windows.Forms.TextBox();
            this.tstop = new System.Windows.Forms.ToolStrip();
            this.bSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bBGPic = new System.Windows.Forms.ToolStripDropDownButton();
            this.bA4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bSpecifyPic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bAnother = new System.Windows.Forms.ToolStripButton();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.ofdPic = new System.Windows.Forms.OpenFileDialog();
            this.ofdAnother = new System.Windows.Forms.OpenFileDialog();
            this.cmsPP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mPPErase = new System.Windows.Forms.ToolStripMenuItem();
            this.mPPRepl = new System.Windows.Forms.ToolStripMenuItem();
            this.mPPSwap = new System.Windows.Forms.ToolStripMenuItem();
            testKeywordLabel = new System.Windows.Forms.Label();
            laWL = new System.Windows.Forms.Label();
            laBL = new System.Windows.Forms.Label();
            xLabel = new System.Windows.Forms.Label();
            cRTypeLabel = new System.Windows.Forms.Label();
            fieldNameLabel = new System.Windows.Forms.Label();
            postProcessLabel = new System.Windows.Forms.Label();
            this.cmsCharList.SuspendLayout();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vsc)).BeginInit();
            this.vsc.Panel1.SuspendLayout();
            this.vsc.Panel2.SuspendLayout();
            this.vsc.SuspendLayout();
            this.slpPv.SuspendLayout();
            this.cmsPicPane.SuspendLayout();
            this.tlpStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blkBindingNavigator)).BeginInit();
            this.blkBindingNavigator.SuspendLayout();
            this.tstop.SuspendLayout();
            this.cmsPP.SuspendLayout();
            this.SuspendLayout();
            // 
            // testKeywordLabel
            // 
            testKeywordLabel.AutoSize = true;
            testKeywordLabel.Location = new System.Drawing.Point(33, 249);
            testKeywordLabel.Name = "testKeywordLabel";
            testKeywordLabel.Size = new System.Drawing.Size(93, 12);
            testKeywordLabel.TabIndex = 19;
            testKeywordLabel.Text = "必要なキーワード：";
            // 
            // laWL
            // 
            laWL.AutoSize = true;
            laWL.Location = new System.Drawing.Point(5, 323);
            laWL.Name = "laWL";
            laWL.Size = new System.Drawing.Size(71, 12);
            laWL.TabIndex = 25;
            laWL.Text = "ホワイトリスト：";
            // 
            // laBL
            // 
            laBL.AutoSize = true;
            laBL.Location = new System.Drawing.Point(5, 286);
            laBL.Name = "laBL";
            laBL.Size = new System.Drawing.Size(67, 12);
            laBL.TabIndex = 22;
            laBL.Text = "ブラックリスト：";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Location = new System.Drawing.Point(3, 25);
            xLabel.Name = "xLabel";
            xLabel.Size = new System.Drawing.Size(35, 12);
            xLabel.TabIndex = 3;
            xLabel.Text = "座標：";
            // 
            // cRTypeLabel
            // 
            cRTypeLabel.AutoSize = true;
            cRTypeLabel.Location = new System.Drawing.Point(3, 124);
            cRTypeLabel.Name = "cRTypeLabel";
            cRTypeLabel.Size = new System.Drawing.Size(61, 12);
            cRTypeLabel.TabIndex = 9;
            cRTypeLabel.Text = "認識タイプ：";
            // 
            // fieldNameLabel
            // 
            fieldNameLabel.AutoSize = true;
            fieldNameLabel.Location = new System.Drawing.Point(33, 190);
            fieldNameLabel.Name = "fieldNameLabel";
            fieldNameLabel.Size = new System.Drawing.Size(67, 12);
            fieldNameLabel.TabIndex = 14;
            fieldNameLabel.Text = "フィールド名：";
            // 
            // postProcessLabel
            // 
            postProcessLabel.AutoSize = true;
            postProcessLabel.Location = new System.Drawing.Point(238, 286);
            postProcessLabel.Name = "postProcessLabel";
            postProcessLabel.Size = new System.Drawing.Size(59, 12);
            postProcessLabel.TabIndex = 33;
            postProcessLabel.Text = "文字変換：";
            // 
            // cmsCharList
            // 
            this.cmsCharList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCLDigit,
            this.mCLLetterU,
            this.mCLLetterL});
            this.cmsCharList.Name = "cmsCharList";
            this.cmsCharList.Size = new System.Drawing.Size(126, 70);
            // 
            // mCLDigit
            // 
            this.mCLDigit.Name = "mCLDigit";
            this.mCLDigit.Size = new System.Drawing.Size(125, 22);
            this.mCLDigit.Text = "半角 数字";
            this.mCLDigit.Click += new System.EventHandler(this.mCLDigit_Click);
            // 
            // mCLLetterU
            // 
            this.mCLLetterU.Name = "mCLLetterU";
            this.mCLLetterU.Size = new System.Drawing.Size(125, 22);
            this.mCLLetterU.Text = "半角 A-Z";
            this.mCLLetterU.Click += new System.EventHandler(this.mCLDigit_Click);
            // 
            // mCLLetterL
            // 
            this.mCLLetterL.Name = "mCLLetterL";
            this.mCLLetterL.Size = new System.Drawing.Size(125, 22);
            this.mCLLetterL.Text = "半角 a-z";
            this.mCLLetterL.Click += new System.EventHandler(this.mCLDigit_Click);
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.vsc);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(770, 631);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(770, 656);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.tstop);
            // 
            // vsc
            // 
            this.vsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.vsc.Location = new System.Drawing.Point(0, 0);
            this.vsc.Name = "vsc";
            // 
            // vsc.Panel1
            // 
            this.vsc.Panel1.Controls.Add(this.slpPv);
            this.vsc.Panel1.Controls.Add(this.tlpStat);
            // 
            // vsc.Panel2
            // 
            this.vsc.Panel2.AutoScroll = true;
            this.vsc.Panel2.Controls.Add(this.bSQLServer);
            this.vsc.Panel2.Controls.Add(this.bAddPP);
            this.vsc.Panel2.Controls.Add(postProcessLabel);
            this.vsc.Panel2.Controls.Add(this.postProcessTextBox);
            this.vsc.Panel2.Controls.Add(this.cbSkipWs);
            this.vsc.Panel2.Controls.Add(this.cbNeedVerify);
            this.vsc.Panel2.Controls.Add(this.bVerifyKw);
            this.vsc.Panel2.Controls.Add(this.lnum);
            this.vsc.Panel2.Controls.Add(this.bReportAll);
            this.vsc.Panel2.Controls.Add(this.numNewRes);
            this.vsc.Panel2.Controls.Add(this.label4);
            this.vsc.Panel2.Controls.Add(this.bWL);
            this.vsc.Panel2.Controls.Add(this.bBL);
            this.vsc.Panel2.Controls.Add(this.cbSelArea);
            this.vsc.Panel2.Controls.Add(this.label3);
            this.vsc.Panel2.Controls.Add(this.cbPWay);
            this.vsc.Panel2.Controls.Add(this.cbNR);
            this.vsc.Panel2.Controls.Add(this.label2);
            this.vsc.Panel2.Controls.Add(testKeywordLabel);
            this.vsc.Panel2.Controls.Add(this.testKeywordTextBox);
            this.vsc.Panel2.Controls.Add(this.cbPSM);
            this.vsc.Panel2.Controls.Add(this.label1);
            this.vsc.Panel2.Controls.Add(this.bTestSeled);
            this.vsc.Panel2.Controls.Add(laWL);
            this.vsc.Panel2.Controls.Add(this.whitelistTextBox);
            this.vsc.Panel2.Controls.Add(laBL);
            this.vsc.Panel2.Controls.Add(this.blacklistTextBox);
            this.vsc.Panel2.Controls.Add(this.ifTestCheckBox);
            this.vsc.Panel2.Controls.Add(this.ifImportCheckBox);
            this.vsc.Panel2.Controls.Add(this.bTestAll);
            this.vsc.Panel2.Controls.Add(this.gvRes);
            this.vsc.Panel2.Controls.Add(this.cbType);
            this.vsc.Panel2.Controls.Add(this.blkBindingNavigator);
            this.vsc.Panel2.Controls.Add(xLabel);
            this.vsc.Panel2.Controls.Add(cRTypeLabel);
            this.vsc.Panel2.Controls.Add(fieldNameLabel);
            this.vsc.Panel2.Controls.Add(this.fieldNameTextBox);
            this.vsc.Size = new System.Drawing.Size(770, 631);
            this.vsc.SplitterDistance = 304;
            this.vsc.SplitterWidth = 6;
            this.vsc.TabIndex = 0;
            // 
            // slpPv
            // 
            this.slpPv.AccessibleName = "テンプレート プレビュー表示";
            this.slpPv.AutoScroll = true;
            this.slpPv.BackColor = System.Drawing.SystemColors.ControlDark;
            this.slpPv.Controls.Add(this.picPane);
            this.slpPv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slpPv.Location = new System.Drawing.Point(0, 0);
            this.slpPv.Name = "slpPv";
            this.slpPv.Size = new System.Drawing.Size(304, 616);
            this.slpPv.TabIndex = 1;
            // 
            // picPane
            // 
            this.picPane.AutoScroll = true;
            this.picPane.AutoSize = true;
            this.picPane.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.picPane.BackColor = System.Drawing.Color.White;
            this.picPane.CanSelRect = false;
            this.picPane.ContextMenuStrip = this.cmsPicPane;
            this.picPane.ForeColor = System.Drawing.Color.Black;
            this.picPane.Image = null;
            this.picPane.Location = new System.Drawing.Point(3, 3);
            this.picPane.MinimumSize = new System.Drawing.Size(32, 32);
            this.picPane.Name = "picPane";
            this.picPane.PelsPerMeter = new System.Drawing.SizeF(0F, 0F);
            this.picPane.SelRect = ((System.Drawing.RectangleF)(resources.GetObject("picPane.SelRect")));
            this.picPane.Size = new System.Drawing.Size(32, 32);
            this.picPane.TabIndex = 0;
            this.picPane.UseBright = false;
            this.picPane.Zoom = 1F;
            this.picPane.ImageChanged += new System.EventHandler(this.picPane_ImageChanged);
            this.picPane.SelRectChanged += new System.EventHandler<OCRPattern.SelRectChangedEventArgs>(this.picPane_SelRectChanged);
            // 
            // cmsPicPane
            // 
            this.cmsPicPane.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSelArea});
            this.cmsPicPane.Name = "cmsPicPane";
            this.cmsPicPane.Size = new System.Drawing.Size(250, 26);
            this.cmsPicPane.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPicPane_Opening);
            // 
            // mSelArea
            // 
            this.mSelArea.Name = "mSelArea";
            this.mSelArea.Size = new System.Drawing.Size(249, 22);
            this.mSelArea.Text = "領域を左ボタンでドラッグし、選択する";
            this.mSelArea.Click += new System.EventHandler(this.mSelArea_Click);
            // 
            // tlpStat
            // 
            this.tlpStat.AutoSize = true;
            this.tlpStat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpStat.ColumnCount = 2;
            this.tlpStat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStat.Controls.Add(this.llRevertPic, 0, 0);
            this.tlpStat.Controls.Add(this.lRes, 1, 0);
            this.tlpStat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpStat.Location = new System.Drawing.Point(0, 616);
            this.tlpStat.Name = "tlpStat";
            this.tlpStat.RowCount = 1;
            this.tlpStat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStat.Size = new System.Drawing.Size(304, 15);
            this.tlpStat.TabIndex = 3;
            // 
            // llRevertPic
            // 
            this.llRevertPic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.llRevertPic.AutoSize = true;
            this.llRevertPic.Location = new System.Drawing.Point(3, 0);
            this.llRevertPic.Name = "llRevertPic";
            this.llRevertPic.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.llRevertPic.Size = new System.Drawing.Size(82, 15);
            this.llRevertPic.TabIndex = 3;
            this.llRevertPic.TabStop = true;
            this.llRevertPic.Text = "元の画像に戻す";
            this.tt.SetToolTip(this.llRevertPic, "評価用に、別の画像を指定した場合、当初の背景画像に戻します。 ");
            this.llRevertPic.Visible = false;
            this.llRevertPic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRevertPic_LinkClicked);
            // 
            // lRes
            // 
            this.lRes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lRes.AutoSize = true;
            this.lRes.Location = new System.Drawing.Point(290, 0);
            this.lRes.Name = "lRes";
            this.lRes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lRes.Size = new System.Drawing.Size(11, 15);
            this.lRes.TabIndex = 4;
            this.lRes.Text = "...";
            // 
            // bSQLServer
            // 
            this.bSQLServer.Location = new System.Drawing.Point(356, 171);
            this.bSQLServer.Name = "bSQLServer";
            this.bSQLServer.Size = new System.Drawing.Size(75, 53);
            this.bSQLServer.TabIndex = 105;
            this.bSQLServer.Text = "SQL Server Lookup";
            this.tt.SetToolTip(this.bSQLServer, "認識後に SQL Server より追加情報を取得します");
            this.bSQLServer.UseVisualStyleBackColor = true;
            this.bSQLServer.Click += new System.EventHandler(this.bSQLServer_Click);
            // 
            // bAddPP
            // 
            this.bAddPP.Location = new System.Drawing.Point(356, 275);
            this.bAddPP.Name = "bAddPP";
            this.bAddPP.Size = new System.Drawing.Size(75, 23);
            this.bAddPP.TabIndex = 104;
            this.bAddPP.Text = "追加∇";
            this.bAddPP.UseVisualStyleBackColor = true;
            this.bAddPP.Click += new System.EventHandler(this.bAddPP_Click);
            // 
            // postProcessTextBox
            // 
            this.postProcessTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "PostProcess", true));
            this.postProcessTextBox.Location = new System.Drawing.Point(240, 301);
            this.postProcessTextBox.Multiline = true;
            this.postProcessTextBox.Name = "postProcessTextBox";
            this.postProcessTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.postProcessTextBox.Size = new System.Drawing.Size(191, 78);
            this.postProcessTextBox.TabIndex = 29;
            this.tt.SetToolTip(this.postProcessTextBox, "認識を実行した後に、結果を操作できるようにします。この設定は、枠ごとに異なります。\r\n\r\n例えば、零 0 と オー O が逆に認識される等。");
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
            // cbSkipWs
            // 
            this.cbSkipWs.AutoSize = true;
            this.cbSkipWs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.blkBindingSource, "SkipWs", true));
            this.cbSkipWs.Location = new System.Drawing.Point(196, 230);
            this.cbSkipWs.Name = "cbSkipWs";
            this.cbSkipWs.Size = new System.Drawing.Size(112, 16);
            this.cbSkipWs.TabIndex = 18;
            this.cbSkipWs.Text = "空白を詰めて判定";
            this.cbSkipWs.UseVisualStyleBackColor = true;
            // 
            // cbNeedVerify
            // 
            this.cbNeedVerify.AutoSize = true;
            this.cbNeedVerify.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.blkBindingSource, "NeedVerify", true));
            this.cbNeedVerify.Location = new System.Drawing.Point(5, 363);
            this.cbNeedVerify.Name = "cbNeedVerify";
            this.cbNeedVerify.Size = new System.Drawing.Size(209, 16);
            this.cbNeedVerify.TabIndex = 28;
            this.cbNeedVerify.Text = "認識結果を都度、確認したい項目です";
            this.cbNeedVerify.UseVisualStyleBackColor = true;
            // 
            // bVerifyKw
            // 
            this.bVerifyKw.Location = new System.Drawing.Point(188, 264);
            this.bVerifyKw.Name = "bVerifyKw";
            this.bVerifyKw.Size = new System.Drawing.Size(50, 19);
            this.bVerifyKw.TabIndex = 21;
            this.bVerifyKw.Text = "検証";
            this.bVerifyKw.UseVisualStyleBackColor = true;
            this.bVerifyKw.Click += new System.EventHandler(this.bVerifyKw_Click);
            // 
            // lnum
            // 
            this.lnum.AutoSize = true;
            this.lnum.Font = new System.Drawing.Font("ＭＳ ゴシック", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnum.Location = new System.Drawing.Point(327, 140);
            this.lnum.Name = "lnum";
            this.lnum.Size = new System.Drawing.Size(42, 19);
            this.lnum.TabIndex = 16;
            this.lnum.Text = "(1)";
            this.lnum.Visible = false;
            // 
            // bReportAll
            // 
            this.bReportAll.Location = new System.Drawing.Point(208, 570);
            this.bReportAll.Name = "bReportAll";
            this.bReportAll.Size = new System.Drawing.Size(75, 46);
            this.bReportAll.TabIndex = 103;
            this.bReportAll.Text = "レポート化";
            this.tt.SetToolTip(this.bReportAll, "認識テストの結果をHTMLと画像を組み合わせてレポートを作成します。");
            this.bReportAll.UseVisualStyleBackColor = true;
            this.bReportAll.Click += new System.EventHandler(this.bReportAll_Click);
            // 
            // numNewRes
            // 
            this.numNewRes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.blkBindingSource, "ResampleDPI", true));
            this.numNewRes.Location = new System.Drawing.Point(3, 102);
            this.numNewRes.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNewRes.Name = "numNewRes";
            this.numNewRes.Size = new System.Drawing.Size(59, 19);
            this.numNewRes.TabIndex = 6;
            this.numNewRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tt.SetToolTip(this.numNewRes, "ノイズ除去の前に、画像の解像度を統一する場合に使用します。\r\n\r\nスキャンによって異なるdpiを使用しますと、ノイズ除去の結果も大きく異なりますので、統一すると良" +
        "いでしょう。\r\n\r\n大体、200～300dpiが適当な範囲でしょうか。 ");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "DPIを変更する(無調整は0)：";
            // 
            // bWL
            // 
            this.bWL.Location = new System.Drawing.Point(158, 338);
            this.bWL.Name = "bWL";
            this.bWL.Size = new System.Drawing.Size(27, 19);
            this.bWL.TabIndex = 27;
            this.bWL.Text = "+";
            this.tt.SetToolTip(this.bWL, "クリックして、候補から一括で追加できます。");
            this.bWL.UseVisualStyleBackColor = true;
            this.bWL.Click += new System.EventHandler(this.bBL_Click);
            // 
            // bBL
            // 
            this.bBL.Location = new System.Drawing.Point(158, 301);
            this.bBL.Name = "bBL";
            this.bBL.Size = new System.Drawing.Size(27, 19);
            this.bBL.TabIndex = 24;
            this.bBL.Text = "+";
            this.tt.SetToolTip(this.bBL, "クリックして、候補から一括で追加できます。");
            this.bBL.UseVisualStyleBackColor = true;
            this.bBL.Click += new System.EventHandler(this.bBL_Click);
            // 
            // cbSelArea
            // 
            this.cbSelArea.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSelArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSelArea.Location = new System.Drawing.Point(3, 40);
            this.cbSelArea.Name = "cbSelArea";
            this.cbSelArea.Size = new System.Drawing.Size(77, 44);
            this.cbSelArea.TabIndex = 4;
            this.cbSelArea.Text = "領域をマウスで選択する";
            this.tt.SetToolTip(this.cbSelArea, "左側の画面から、認識したい領域を指定できます。\r\n\r\nボタンをクリックし、左側の用紙プレビューから、認識したい領域をマウスでドラッグアンドドロップしてください。");
            this.cbSelArea.UseVisualStyleBackColor = true;
            this.cbSelArea.CheckedChanged += new System.EventHandler(this.cbSelArea_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "ページの種類：";
            // 
            // cbPWay
            // 
            this.cbPWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPWay.FormattingEnabled = true;
            this.cbPWay.Location = new System.Drawing.Point(110, 40);
            this.cbPWay.Name = "cbPWay";
            this.cbPWay.Size = new System.Drawing.Size(146, 20);
            this.cbPWay.TabIndex = 2;
            this.tt.SetToolTip(this.cbPWay, resources.GetString("cbPWay.ToolTip"));
            // 
            // cbNR
            // 
            this.cbNR.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.blkBindingSource, "NoiseReduction", true));
            this.cbNR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNR.FormattingEnabled = true;
            this.cbNR.Location = new System.Drawing.Point(158, 102);
            this.cbNR.Name = "cbNR";
            this.cbNR.Size = new System.Drawing.Size(150, 20);
            this.cbNR.TabIndex = 8;
            this.tt.SetToolTip(this.cbNR, resources.GetString("cbNR.ToolTip"));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ノイズ除去：";
            // 
            // testKeywordTextBox
            // 
            this.testKeywordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "TestKeyword", true));
            this.testKeywordTextBox.Location = new System.Drawing.Point(35, 264);
            this.testKeywordTextBox.Name = "testKeywordTextBox";
            this.testKeywordTextBox.Size = new System.Drawing.Size(147, 19);
            this.testKeywordTextBox.TabIndex = 20;
            this.tt.SetToolTip(this.testKeywordTextBox, "キーワードを指定します。必要なキーワード中の、空白文字は全て削除して検証いたします。 ");
            // 
            // cbPSM
            // 
            this.cbPSM.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.blkBindingSource, "PSM", true));
            this.cbPSM.DropDownHeight = 222;
            this.cbPSM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPSM.DropDownWidth = 222;
            this.cbPSM.FormattingEnabled = true;
            this.cbPSM.IntegralHeight = false;
            this.cbPSM.Location = new System.Drawing.Point(158, 139);
            this.cbPSM.Name = "cbPSM";
            this.cbPSM.Size = new System.Drawing.Size(150, 20);
            this.cbPSM.TabIndex = 12;
            this.tt.SetToolTip(this.cbPSM, resources.GetString("cbPSM.ToolTip"));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "ページ分割(PSM)";
            // 
            // bTestSeled
            // 
            this.bTestSeled.Location = new System.Drawing.Point(93, 570);
            this.bTestSeled.Name = "bTestSeled";
            this.bTestSeled.Size = new System.Drawing.Size(75, 46);
            this.bTestSeled.TabIndex = 102;
            this.bTestSeled.Text = "認識テスト\r\n(選択分)";
            this.tt.SetToolTip(this.bTestSeled, "表で選択している認識枠について、認識を実行します。認識結果は、表に出力されます。 ");
            this.bTestSeled.UseVisualStyleBackColor = true;
            this.bTestSeled.Click += new System.EventHandler(this.bTestAll_Click);
            // 
            // whitelistTextBox
            // 
            this.whitelistTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "Whitelist", true));
            this.whitelistTextBox.Location = new System.Drawing.Point(5, 338);
            this.whitelistTextBox.Name = "whitelistTextBox";
            this.whitelistTextBox.Size = new System.Drawing.Size(147, 19);
            this.whitelistTextBox.TabIndex = 26;
            this.tt.SetToolTip(this.whitelistTextBox, "認識候補として使いたい文字を、一文字ずつ入力していきます。指定しなかった文字は、認識しません。 ");
            // 
            // blacklistTextBox
            // 
            this.blacklistTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "Blacklist", true));
            this.blacklistTextBox.Location = new System.Drawing.Point(5, 301);
            this.blacklistTextBox.Name = "blacklistTextBox";
            this.blacklistTextBox.Size = new System.Drawing.Size(147, 19);
            this.blacklistTextBox.TabIndex = 23;
            this.tt.SetToolTip(this.blacklistTextBox, "認識候補から外したい文字を、一文字ずつ入力していきます。 ");
            // 
            // ifTestCheckBox
            // 
            this.ifTestCheckBox.AutoSize = true;
            this.ifTestCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.blkBindingSource, "IfTest", true));
            this.ifTestCheckBox.Location = new System.Drawing.Point(5, 230);
            this.ifTestCheckBox.Name = "ifTestCheckBox";
            this.ifTestCheckBox.Size = new System.Drawing.Size(180, 16);
            this.ifTestCheckBox.TabIndex = 17;
            this.ifTestCheckBox.Text = "フォーム判定に使用する項目です";
            this.tt.SetToolTip(this.ifTestCheckBox, "このテンプレートを使用するかどうか、判定するために使います。必要なキーワード：に、キーワードを入力します。\r\n\r\n例：\r\n認識結果「注 文 書」を、キーワード「注" +
        "文書」で認識 → 合格");
            // 
            // ifImportCheckBox
            // 
            this.ifImportCheckBox.AutoSize = true;
            this.ifImportCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.blkBindingSource, "IfImport", true));
            this.ifImportCheckBox.Location = new System.Drawing.Point(5, 171);
            this.ifImportCheckBox.Name = "ifImportCheckBox";
            this.ifImportCheckBox.Size = new System.Drawing.Size(142, 16);
            this.ifImportCheckBox.TabIndex = 13;
            this.ifImportCheckBox.Text = "CSVに取り込む項目です";
            this.tt.SetToolTip(this.ifImportCheckBox, "チェックを入れると、CSVファイルに、フィールド名・認識結果を文字列で記入します。 ");
            // 
            // bTestAll
            // 
            this.bTestAll.Location = new System.Drawing.Point(3, 570);
            this.bTestAll.Name = "bTestAll";
            this.bTestAll.Size = new System.Drawing.Size(75, 46);
            this.bTestAll.TabIndex = 101;
            this.bTestAll.Text = "認識テスト\r\n(すべて)";
            this.tt.SetToolTip(this.bTestAll, "すべての認識枠について、認識を実行します。認識結果は、表に出力されます。");
            this.bTestAll.UseVisualStyleBackColor = true;
            this.bTestAll.Click += new System.EventHandler(this.bTestAll_Click);
            // 
            // gvRes
            // 
            this.gvRes.AccessibleName = "認識結果";
            this.gvRes.AllowUserToAddRows = false;
            this.gvRes.AllowUserToDeleteRows = false;
            this.gvRes.AllowUserToOrderColumns = true;
            this.gvRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRes.AutoGenerateColumns = false;
            this.gvRes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.cRes,
            this.cPic});
            this.gvRes.DataSource = this.blkBindingSource;
            this.gvRes.Location = new System.Drawing.Point(5, 385);
            this.gvRes.Name = "gvRes";
            this.gvRes.RowTemplate.Height = 21;
            this.gvRes.Size = new System.Drawing.Size(426, 179);
            this.gvRes.TabIndex = 99;
            this.gvRes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvRes_CellContentClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FieldName";
            this.dataGridViewTextBoxColumn7.HeaderText = "フィールド名";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // cRes
            // 
            this.cRes.HeaderText = "結果";
            this.cRes.Name = "cRes";
            this.cRes.Width = 150;
            // 
            // cPic
            // 
            this.cPic.HeaderText = "画像";
            this.cPic.Name = "cPic";
            this.cPic.Visible = false;
            this.cPic.Width = 80;
            // 
            // cbType
            // 
            this.cbType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.blkBindingSource, "CRType", true));
            this.cbType.DropDownHeight = 222;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.IntegralHeight = false;
            this.cbType.Location = new System.Drawing.Point(3, 139);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(149, 20);
            this.cbType.TabIndex = 10;
            this.tt.SetToolTip(this.cbType, resources.GetString("cbType.ToolTip"));
            // 
            // blkBindingNavigator
            // 
            this.blkBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.blkBindingNavigator.BindingSource = this.blkBindingSource;
            this.blkBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.blkBindingNavigator.DeleteItem = null;
            this.blkBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.blkBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.blkBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.blkBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.blkBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.blkBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.blkBindingNavigator.Name = "blkBindingNavigator";
            this.blkBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.blkBindingNavigator.Size = new System.Drawing.Size(460, 25);
            this.blkBindingNavigator.TabIndex = 0;
            this.blkBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新規追加";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目の総数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "最初に移動";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "前に戻る";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 19);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "現在の場所";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "次に移動";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "最後に移動";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "削除";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // fieldNameTextBox
            // 
            this.fieldNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.blkBindingSource, "FieldName", true));
            this.fieldNameTextBox.Location = new System.Drawing.Point(35, 205);
            this.fieldNameTextBox.Name = "fieldNameTextBox";
            this.fieldNameTextBox.Size = new System.Drawing.Size(147, 19);
            this.fieldNameTextBox.TabIndex = 15;
            this.tt.SetToolTip(this.fieldNameTextBox, "引継ぎマスタで指定する名称になります。");
            // 
            // tstop
            // 
            this.tstop.AccessibleName = "テンプレート ツールバー";
            this.tstop.Dock = System.Windows.Forms.DockStyle.None;
            this.tstop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSave,
            this.toolStripSeparator1,
            this.bBGPic,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.tscbZoom,
            this.toolStripSeparator3,
            this.bAbout,
            this.toolStripSeparator4,
            this.bAnother});
            this.tstop.Location = new System.Drawing.Point(3, 0);
            this.tstop.Name = "tstop";
            this.tstop.Size = new System.Drawing.Size(634, 25);
            this.tstop.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(78, 22);
            this.bSave.Text = "保存します";
            this.bSave.ToolTipText = "編集しているテンプレートを保存します。";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bBGPic
            // 
            this.bBGPic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bA4,
            this.toolStripSeparator5,
            this.bSpecifyPic});
            this.bBGPic.Image = ((System.Drawing.Image)(resources.GetObject("bBGPic.Image")));
            this.bBGPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bBGPic.Name = "bBGPic";
            this.bBGPic.Size = new System.Drawing.Size(84, 22);
            this.bBGPic.Text = "背景画像";
            this.bBGPic.ToolTipText = "背景画像を指定します。この画像がテンプレート編集の下地となります。 また、テンプレート内部に保存されます。";
            // 
            // bA4
            // 
            this.bA4.Name = "bA4";
            this.bA4.Size = new System.Drawing.Size(150, 22);
            this.bA4.Text = "白紙(A4縦)";
            this.bA4.Click += new System.EventHandler(this.bA4_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(147, 6);
            // 
            // bSpecifyPic
            // 
            this.bSpecifyPic.Name = "bSpecifyPic";
            this.bSpecifyPic.Size = new System.Drawing.Size(150, 22);
            this.bSpecifyPic.Text = "ファイルを指定...";
            this.bSpecifyPic.Click += new System.EventHandler(this.bSpecifyPic_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "倍率：";
            this.toolStripLabel1.ToolTipText = "背景画像を画面に表示する際の、倍率を指定します。";
            // 
            // tscbZoom
            // 
            this.tscbZoom.DropDownHeight = 222;
            this.tscbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbZoom.DropDownWidth = 97;
            this.tscbZoom.IntegralHeight = false;
            this.tscbZoom.Items.AddRange(new object[] {
            "3.125%",
            "6.25%",
            "12.5%",
            "25%",
            "50%",
            "75%",
            "100%"});
            this.tscbZoom.Name = "tscbZoom";
            this.tscbZoom.Size = new System.Drawing.Size(75, 25);
            this.tscbZoom.SelectedIndexChanged += new System.EventHandler(this.tscbZoom_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bAbout
            // 
            this.bAbout.Image = ((System.Drawing.Image)(resources.GetObject("bAbout.Image")));
            this.bAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(121, 22);
            this.bAbout.Text = "利用技術について...";
            this.bAbout.ToolTipText = "利用技術について、特に謝辞のある物を表示します。 ";
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bAnother
            // 
            this.bAnother.Image = ((System.Drawing.Image)(resources.GetObject("bAnother.Image")));
            this.bAnother.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAnother.Name = "bAnother";
            this.bAnother.Size = new System.Drawing.Size(195, 22);
            this.bAnother.Text = "評価用に、別の画像を指定します...";
            this.bAnother.ToolTipText = "認識に使用したい画像をファイルから指定します。1ページのみ選択できます。この画像は、テンプレート内容に保存されません。 ";
            this.bAnother.Click += new System.EventHandler(this.bAnother_Click);
            // 
            // ofdPic
            // 
            this.ofdPic.Filter = global::OCRPattern.Properties.Settings.Default.PicIn;
            // 
            // ofdAnother
            // 
            this.ofdAnother.Filter = global::OCRPattern.Properties.Settings.Default.GazoIn;
            // 
            // cmsPP
            // 
            this.cmsPP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPPErase,
            this.mPPRepl,
            this.mPPSwap});
            this.cmsPP.Name = "cmsPP";
            this.cmsPP.Size = new System.Drawing.Size(200, 70);
            // 
            // mPPErase
            // 
            this.mPPErase.Name = "mPPErase";
            this.mPPErase.Size = new System.Drawing.Size(199, 22);
            this.mPPErase.Text = "指定した文字を削除したい";
            this.mPPErase.Click += new System.EventHandler(this.mPPErase_Click);
            // 
            // mPPRepl
            // 
            this.mPPRepl.Name = "mPPRepl";
            this.mPPRepl.Size = new System.Drawing.Size(199, 22);
            this.mPPRepl.Text = "文字を置き換えしたい";
            this.mPPRepl.Click += new System.EventHandler(this.mPPRepl_Click);
            // 
            // mPPSwap
            // 
            this.mPPSwap.Name = "mPPSwap";
            this.mPPSwap.Size = new System.Drawing.Size(199, 22);
            this.mPPSwap.Text = "文字を入れ替えたい";
            this.mPPSwap.Click += new System.EventHandler(this.mPPSwap_Click);
            // 
            // EForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 656);
            this.Controls.Add(this.tsc);
            this.Name = "EForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "テンプレート編集";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EForm_FormClosing);
            this.Load += new System.EventHandler(this.EForm_Load);
            this.cmsCharList.ResumeLayout(false);
            this.tsc.ContentPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.PerformLayout();
            this.tsc.ResumeLayout(false);
            this.tsc.PerformLayout();
            this.vsc.Panel1.ResumeLayout(false);
            this.vsc.Panel1.PerformLayout();
            this.vsc.Panel2.ResumeLayout(false);
            this.vsc.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vsc)).EndInit();
            this.vsc.ResumeLayout(false);
            this.slpPv.ResumeLayout(false);
            this.slpPv.PerformLayout();
            this.cmsPicPane.ResumeLayout(false);
            this.tlpStat.ResumeLayout(false);
            this.tlpStat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNewRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blkBindingNavigator)).EndInit();
            this.blkBindingNavigator.ResumeLayout(false);
            this.blkBindingNavigator.PerformLayout();
            this.tstop.ResumeLayout(false);
            this.tstop.PerformLayout();
            this.cmsPP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.ToolStrip tstop;
        private System.Windows.Forms.ToolStripButton bSave;
        private System.Windows.Forms.OpenFileDialog ofdPic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer vsc;
        private System.Windows.Forms.BindingNavigator blkBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.BindingSource blkBindingSource;
        private DCR dcr;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox fieldNameTextBox;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox tscbZoom;
        private PicPane picPane;
        private System.Windows.Forms.DataGridView gvRes;
        private System.Windows.Forms.Button bTestAll;
        private System.Windows.Forms.CheckBox ifTestCheckBox;
        private System.Windows.Forms.CheckBox ifImportCheckBox;
        private System.Windows.Forms.TextBox blacklistTextBox;
        private System.Windows.Forms.TextBox whitelistTextBox;
        private System.Windows.Forms.Button bTestSeled;
        private System.Windows.Forms.ComboBox cbPSM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox testKeywordTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNR;
        private System.Windows.Forms.ComboBox cbPWay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bAbout;
        private ScrollLessPanel slpPv;
        private System.Windows.Forms.CheckBox cbSelArea;
        private System.Windows.Forms.ContextMenuStrip cmsPicPane;
        private System.Windows.Forms.ToolStripMenuItem mSelArea;
        private System.Windows.Forms.ContextMenuStrip cmsCharList;
        private System.Windows.Forms.ToolStripMenuItem mCLDigit;
        private System.Windows.Forms.ToolStripMenuItem mCLLetterU;
        private System.Windows.Forms.ToolStripMenuItem mCLLetterL;
        private System.Windows.Forms.Button bBL;
        private System.Windows.Forms.Button bWL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bAnother;
        private System.Windows.Forms.OpenFileDialog ofdAnother;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numNewRes;
        private System.Windows.Forms.TableLayoutPanel tlpStat;
        private System.Windows.Forms.LinkLabel llRevertPic;
        private System.Windows.Forms.Label lRes;
        private System.Windows.Forms.Button bReportAll;
        private System.Windows.Forms.Label lnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRes;
        private System.Windows.Forms.DataGridViewImageColumn cPic;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Button bVerifyKw;
        private System.Windows.Forms.CheckBox cbNeedVerify;
        private System.Windows.Forms.ToolStripDropDownButton bBGPic;
        private System.Windows.Forms.ToolStripMenuItem bA4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem bSpecifyPic;
        private System.Windows.Forms.CheckBox cbSkipWs;
        private System.Windows.Forms.TextBox postProcessTextBox;
        private System.Windows.Forms.Button bAddPP;
        private System.Windows.Forms.ContextMenuStrip cmsPP;
        private System.Windows.Forms.ToolStripMenuItem mPPErase;
        private System.Windows.Forms.ToolStripMenuItem mPPRepl;
        private System.Windows.Forms.ToolStripMenuItem mPPSwap;
        private System.Windows.Forms.Button bSQLServer;
    }
}