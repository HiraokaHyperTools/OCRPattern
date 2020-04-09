namespace OCRPattern
{
    partial class AboutForm
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
            this.info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // info
            // 
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info.Location = new System.Drawing.Point(0, 0);
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(563, 395);
            this.info.TabIndex = 0;
            this.info.Text = "";
            this.info.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.info_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 395);
            this.Controls.Add(this.info);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCRPattern 利用技術につきまして";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox info;
    }
}