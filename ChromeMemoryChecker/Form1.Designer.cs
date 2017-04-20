namespace ChromeMemoryChecker
{
    partial class Form1
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
            this.lstvMain = new System.Windows.Forms.ListView();
            this.clmIcons = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMemory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListProcessIcons = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProcessCount = new System.Windows.Forms.Label();
            this.lblChromeUsage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvMain
            // 
            this.lstvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIcons,
            this.clmDescription,
            this.clmName,
            this.clmMemory});
            this.tableLayoutPanel1.SetColumnSpan(this.lstvMain, 2);
            this.lstvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvMain.Location = new System.Drawing.Point(3, 83);
            this.lstvMain.Name = "lstvMain";
            this.lstvMain.Size = new System.Drawing.Size(389, 175);
            this.lstvMain.SmallImageList = this.imgListProcessIcons;
            this.lstvMain.TabIndex = 0;
            this.lstvMain.UseCompatibleStateImageBehavior = false;
            this.lstvMain.View = System.Windows.Forms.View.Details;
            // 
            // clmIcons
            // 
            this.clmIcons.Text = "";
            this.clmIcons.Width = 30;
            // 
            // clmDescription
            // 
            this.clmDescription.Text = "Process Description";
            this.clmDescription.Width = 107;
            // 
            // clmName
            // 
            this.clmName.Text = "Process Name";
            this.clmName.Width = 95;
            // 
            // clmMemory
            // 
            this.clmMemory.Text = "Memory Usage";
            this.clmMemory.Width = 98;
            // 
            // imgListProcessIcons
            // 
            this.imgListProcessIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListProcessIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListProcessIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lstvMain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.picIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 261);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // picIcon
            // 
            this.picIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIcon.Location = new System.Drawing.Point(3, 3);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(34, 54);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Found the following processes with \"chrome\":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblProcessCount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblChromeUsage, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(43, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(349, 54);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number of Processes:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Memory Used:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcessCount
            // 
            this.lblProcessCount.AutoSize = true;
            this.lblProcessCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessCount.Location = new System.Drawing.Point(128, 0);
            this.lblProcessCount.Name = "lblProcessCount";
            this.lblProcessCount.Size = new System.Drawing.Size(218, 27);
            this.lblProcessCount.TabIndex = 2;
            this.lblProcessCount.Text = "label4";
            this.lblProcessCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChromeUsage
            // 
            this.lblChromeUsage.AutoSize = true;
            this.lblChromeUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChromeUsage.Location = new System.Drawing.Point(128, 27);
            this.lblChromeUsage.Name = "lblChromeUsage";
            this.lblChromeUsage.Size = new System.Drawing.Size(218, 27);
            this.lblChromeUsage.TabIndex = 3;
            this.lblChromeUsage.Text = "label5";
            this.lblChromeUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvMain;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmMemory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ColumnHeader clmDescription;
        private System.Windows.Forms.ColumnHeader clmIcons;
        private System.Windows.Forms.ImageList imgListProcessIcons;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProcessCount;
        private System.Windows.Forms.Label lblChromeUsage;
    }
}

