namespace OCRPattern {
    partial class OCRWIPForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.lfn = new System.Windows.Forms.Label();
            this.lPage = new System.Windows.Forms.Label();
            this.lTempl = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.panelWIP = new System.Windows.Forms.Panel();
            this.tlpWIP = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ldir = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lRot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelWIP.SuspendLayout();
            this.tlpWIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日本語・英語OCRにつきましては、こちらのオープンソースを利用して実現しています。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "バーコード認識につきましては、こちらのオープンソース技術を利用しています。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(331, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "ノイズ除去(画像処理)につきましては、こちらの技術を利用しています。";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(415, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(215, 12);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://code.google.com/p/tesseract-ocr/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(378, 107);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(157, 12);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://zxingnet.codeplex.com/";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(349, 219);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(237, 12);
            this.linkLabel3.TabIndex = 5;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "http://www.imagemagick.org/script/index.php";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lfn
            // 
            this.lfn.AutoSize = true;
            this.lfn.Location = new System.Drawing.Point(96, 29);
            this.lfn.Name = "lfn";
            this.lfn.Padding = new System.Windows.Forms.Padding(2);
            this.lfn.Size = new System.Drawing.Size(15, 16);
            this.lfn.TabIndex = 1;
            this.lfn.Text = "...";
            // 
            // lPage
            // 
            this.lPage.AutoSize = true;
            this.lPage.Location = new System.Drawing.Point(96, 56);
            this.lPage.Name = "lPage";
            this.lPage.Padding = new System.Windows.Forms.Padding(2);
            this.lPage.Size = new System.Drawing.Size(15, 16);
            this.lPage.TabIndex = 2;
            this.lPage.Text = "1";
            // 
            // lTempl
            // 
            this.lTempl.AutoSize = true;
            this.lTempl.Location = new System.Drawing.Point(96, 110);
            this.lTempl.Name = "lTempl";
            this.lTempl.Padding = new System.Windows.Forms.Padding(2);
            this.lTempl.Size = new System.Drawing.Size(15, 16);
            this.lTempl.TabIndex = 3;
            this.lTempl.Text = "...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 146);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(445, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "PDF読取につきましては、こちらの技術を改造し、利用しています。";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Image = global::OCRPattern.Properties.Resources.poppler_top;
            this.pictureBox4.Location = new System.Drawing.Point(12, 477);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(663, 86);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = global::OCRPattern.Properties.Resources._200px_Imagemagick_logo;
            this.pictureBox3.Location = new System.Drawing.Point(12, 234);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(204, 210);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::OCRPattern.Properties.Resources.zxingss;
            this.pictureBox2.Location = new System.Drawing.Point(12, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(558, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::OCRPattern.Properties.Resources.tessocr;
            this.pictureBox1.Location = new System.Drawing.Point(12, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(327, 462);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(162, 12);
            this.linkLabel4.TabIndex = 9;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "http://poppler.freedesktop.org/";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panelWIP
            // 
            this.panelWIP.Controls.Add(this.tlpWIP);
            this.panelWIP.Controls.Add(this.progressBar1);
            this.panelWIP.Location = new System.Drawing.Point(222, 279);
            this.panelWIP.Name = "panelWIP";
            this.panelWIP.Size = new System.Drawing.Size(453, 165);
            this.panelWIP.TabIndex = 10;
            this.panelWIP.Visible = false;
            // 
            // tlpWIP
            // 
            this.tlpWIP.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tlpWIP.ColumnCount = 2;
            this.tlpWIP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpWIP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWIP.Controls.Add(this.lRot, 1, 3);
            this.tlpWIP.Controls.Add(this.label6, 0, 0);
            this.tlpWIP.Controls.Add(this.label7, 0, 1);
            this.tlpWIP.Controls.Add(this.ldir, 1, 0);
            this.tlpWIP.Controls.Add(this.lPage, 1, 2);
            this.tlpWIP.Controls.Add(this.lfn, 1, 1);
            this.tlpWIP.Controls.Add(this.lTempl, 1, 4);
            this.tlpWIP.Controls.Add(this.label8, 0, 2);
            this.tlpWIP.Controls.Add(this.label4, 0, 4);
            this.tlpWIP.Controls.Add(this.label9, 0, 3);
            this.tlpWIP.Location = new System.Drawing.Point(5, 3);
            this.tlpWIP.Name = "tlpWIP";
            this.tlpWIP.RowCount = 5;
            this.tlpWIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpWIP.Size = new System.Drawing.Size(445, 137);
            this.tlpWIP.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(2);
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "ファイルの場所：";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 29);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2);
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "ファイル名：";
            // 
            // ldir
            // 
            this.ldir.AutoSize = true;
            this.ldir.Location = new System.Drawing.Point(96, 2);
            this.ldir.Name = "ldir";
            this.ldir.Padding = new System.Windows.Forms.Padding(2);
            this.ldir.Size = new System.Drawing.Size(15, 16);
            this.ldir.TabIndex = 4;
            this.ldir.Text = "...";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 56);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2);
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "ページ数目：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 110);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2);
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "状況：";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 83);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(2);
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "回転：";
            // 
            // llRot
            // 
            this.lRot.AutoSize = true;
            this.lRot.Location = new System.Drawing.Point(96, 83);
            this.lRot.Name = "llRot";
            this.lRot.Padding = new System.Windows.Forms.Padding(2);
            this.lRot.Size = new System.Drawing.Size(15, 16);
            this.lRot.TabIndex = 8;
            this.lRot.Text = "...";
            // 
            // OCRWIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(690, 577);
            this.Controls.Add(this.panelWIP);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OCRWIPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "認識しています...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelWIP.ResumeLayout(false);
            this.tlpWIP.ResumeLayout(false);
            this.tlpWIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        internal System.Windows.Forms.Label lfn;
        internal System.Windows.Forms.Label lPage;
        internal System.Windows.Forms.Label lTempl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.LinkLabel linkLabel4;
        internal System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label ldir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Panel panelWIP;
        private System.Windows.Forms.TableLayoutPanel tlpWIP;
        internal System.Windows.Forms.Label lRot;
        private System.Windows.Forms.Label label9;
    }
}