namespace OCRPattern {
    partial class ConfirmForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bsRes = new System.Windows.Forms.BindingSource(this.components);
            this.dsRes = new OCRPattern.DSRes();
            this.label3 = new System.Windows.Forms.Label();
            this.gvr = new System.Windows.Forms.DataGridView();
            this.cNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.slp = new OCRPattern.ScrollLessPanel();
            this.picPane = new OCRPattern.PicPane();
            this.sc2 = new System.Windows.Forms.SplitContainer();
            this.tbRes = new System.Windows.Forms.RichTextBox();
            this.flpbtn = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bsRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            this.slp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc2)).BeginInit();
            this.sc2.Panel1.SuspendLayout();
            this.sc2.Panel2.SuspendLayout();
            this.sc2.SuspendLayout();
            this.flpbtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "画像：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "認識結果：";
            // 
            // bsRes
            // 
            this.bsRes.DataMember = "TRes";
            this.bsRes.DataSource = this.dsRes;
            this.bsRes.CurrentChanged += new System.EventHandler(this.bsRes_CurrentChanged);
            // 
            // dsRes
            // 
            this.dsRes.DataSetName = "DSRes";
            this.dsRes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "一覧：";
            // 
            // gvr
            // 
            this.gvr.AllowUserToAddRows = false;
            this.gvr.AllowUserToDeleteRows = false;
            this.gvr.AutoGenerateColumns = false;
            this.gvr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNam,
            this.cDat});
            this.gvr.DataSource = this.bsRes;
            this.gvr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvr.Location = new System.Drawing.Point(0, 12);
            this.gvr.Name = "gvr";
            this.gvr.RowTemplate.Height = 21;
            this.gvr.Size = new System.Drawing.Size(466, 142);
            this.gvr.TabIndex = 5;
            // 
            // cNam
            // 
            this.cNam.DataPropertyName = "Nam";
            this.cNam.HeaderText = "フィールド名";
            this.cNam.Name = "cNam";
            this.cNam.ReadOnly = true;
            this.cNam.Width = 150;
            // 
            // cDat
            // 
            this.cDat.DataPropertyName = "Dat";
            this.cDat.HeaderText = "値";
            this.cDat.Name = "cDat";
            this.cDat.Width = 200;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(3, 3);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(350, 23);
            this.bOk.TabIndex = 6;
            this.bOk.Text = "OK、確定する。";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bCancel.Location = new System.Drawing.Point(359, 3);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(150, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "スキップ、この用紙を排除。";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // sc1
            // 
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sc1.Location = new System.Drawing.Point(0, 0);
            this.sc1.Name = "sc1";
            this.sc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.slp);
            this.sc1.Panel1.Controls.Add(this.label1);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.sc2);
            this.sc1.Size = new System.Drawing.Size(769, 474);
            this.sc1.SplitterDistance = 316;
            this.sc1.TabIndex = 8;
            // 
            // slp
            // 
            this.slp.AutoScroll = true;
            this.slp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.slp.Controls.Add(this.picPane);
            this.slp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slp.Location = new System.Drawing.Point(0, 12);
            this.slp.Name = "slp";
            this.slp.Size = new System.Drawing.Size(769, 304);
            this.slp.TabIndex = 1;
            this.slp.Paint += new System.Windows.Forms.PaintEventHandler(this.slp_Paint);
            // 
            // picPane
            // 
            this.picPane.AutoSize = true;
            this.picPane.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.picPane.CanSelRect = false;
            this.picPane.Image = null;
            this.picPane.Location = new System.Drawing.Point(0, 0);
            this.picPane.MinimumSize = new System.Drawing.Size(32, 32);
            this.picPane.Name = "picPane";
            this.picPane.PelsPerMeter = new System.Drawing.SizeF(0F, 0F);
            this.picPane.SelRect = ((System.Drawing.RectangleF)(resources.GetObject("picPane.SelRect")));
            this.picPane.Size = new System.Drawing.Size(32, 32);
            this.picPane.TabIndex = 0;
            this.picPane.UseBright = false;
            this.picPane.Zoom = 1F;
            // 
            // sc2
            // 
            this.sc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc2.Location = new System.Drawing.Point(0, 0);
            this.sc2.Name = "sc2";
            // 
            // sc2.Panel1
            // 
            this.sc2.Panel1.Controls.Add(this.tbRes);
            this.sc2.Panel1.Controls.Add(this.label2);
            // 
            // sc2.Panel2
            // 
            this.sc2.Panel2.Controls.Add(this.gvr);
            this.sc2.Panel2.Controls.Add(this.label3);
            this.sc2.Size = new System.Drawing.Size(769, 154);
            this.sc2.SplitterDistance = 299;
            this.sc2.TabIndex = 0;
            // 
            // tbRes
            // 
            this.tbRes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRes, "Dat", true));
            this.tbRes.DetectUrls = false;
            this.tbRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRes.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbRes.Location = new System.Drawing.Point(0, 12);
            this.tbRes.Name = "tbRes";
            this.tbRes.Size = new System.Drawing.Size(299, 142);
            this.tbRes.TabIndex = 3;
            this.tbRes.Text = "";
            // 
            // flpbtn
            // 
            this.flpbtn.AutoSize = true;
            this.flpbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpbtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpbtn.Controls.Add(this.bOk);
            this.flpbtn.Controls.Add(this.bCancel);
            this.flpbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpbtn.Location = new System.Drawing.Point(0, 474);
            this.flpbtn.Name = "flpbtn";
            this.flpbtn.Size = new System.Drawing.Size(769, 33);
            this.flpbtn.TabIndex = 9;
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 507);
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.flpbtn);
            this.Name = "ConfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "認識結果の確認画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfirmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).EndInit();
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel1.PerformLayout();
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            this.slp.ResumeLayout(false);
            this.slp.PerformLayout();
            this.sc2.Panel1.ResumeLayout(false);
            this.sc2.Panel1.PerformLayout();
            this.sc2.Panel2.ResumeLayout(false);
            this.sc2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc2)).EndInit();
            this.sc2.ResumeLayout(false);
            this.flpbtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ScrollLessPanel slp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvr;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.BindingSource bsRes;
        private DSRes dsRes;
        private PicPane picPane;
        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.SplitContainer sc2;
        private System.Windows.Forms.FlowLayoutPanel flpbtn;
        private System.Windows.Forms.RichTextBox tbRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDat;
    }
}