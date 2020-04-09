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
            this.lfn = new System.Windows.Forms.Label();
            this.lPage = new System.Windows.Forms.Label();
            this.lTempl = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelWIP = new System.Windows.Forms.Panel();
            this.tlpWIP = new System.Windows.Forms.TableLayoutPanel();
            this.lRot = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ldir = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelWIP.SuspendLayout();
            this.tlpWIP.SuspendLayout();
            this.SuspendLayout();
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
            // panelWIP
            // 
            this.panelWIP.Controls.Add(this.tlpWIP);
            this.panelWIP.Controls.Add(this.progressBar1);
            this.panelWIP.Location = new System.Drawing.Point(12, 12);
            this.panelWIP.Name = "panelWIP";
            this.panelWIP.Size = new System.Drawing.Size(453, 165);
            this.panelWIP.TabIndex = 10;
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
            // lRot
            // 
            this.lRot.AutoSize = true;
            this.lRot.Location = new System.Drawing.Point(96, 83);
            this.lRot.Name = "lRot";
            this.lRot.Padding = new System.Windows.Forms.Padding(2);
            this.lRot.Size = new System.Drawing.Size(15, 16);
            this.lRot.TabIndex = 8;
            this.lRot.Text = "...";
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
            // OCRWIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(485, 200);
            this.Controls.Add(this.panelWIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OCRWIPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "認識しています...";
            this.panelWIP.ResumeLayout(false);
            this.tlpWIP.ResumeLayout(false);
            this.tlpWIP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lfn;
        internal System.Windows.Forms.Label lPage;
        internal System.Windows.Forms.Label lTempl;
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