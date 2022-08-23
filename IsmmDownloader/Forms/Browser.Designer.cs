
namespace IsmmDownloader.Forms
{
    partial class Browser
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.fetchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilterOK = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.filterBox.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBrowser,
            this.menuControlPanel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBrowser
            // 
            this.menuBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReload,
            this.menuHome,
            this.menuDebug});
            this.menuBrowser.Name = "menuBrowser";
            this.menuBrowser.Size = new System.Drawing.Size(61, 22);
            this.menuBrowser.Text = "&Browser";
            // 
            // menuReload
            // 
            this.menuReload.Name = "menuReload";
            this.menuReload.Size = new System.Drawing.Size(180, 22);
            this.menuReload.Text = "&Reload";
            this.menuReload.Click += new System.EventHandler(this.menuReload_Click);
            // 
            // menuHome
            // 
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(180, 22);
            this.menuHome.Text = "&Home";
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // menuDebug
            // 
            this.menuDebug.Name = "menuDebug";
            this.menuDebug.Size = new System.Drawing.Size(180, 22);
            this.menuDebug.Text = "&Debug";
            this.menuDebug.Click += new System.EventHandler(this.menuDebug_Click);
            // 
            // menuControlPanel
            // 
            this.menuControlPanel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fetchToolStripMenuItem,
            this.downloadToolStripMenuItem});
            this.menuControlPanel.Name = "menuControlPanel";
            this.menuControlPanel.Size = new System.Drawing.Size(54, 22);
            this.menuControlPanel.Text = "&Report";
            // 
            // fetchToolStripMenuItem
            // 
            this.fetchToolStripMenuItem.Name = "fetchToolStripMenuItem";
            this.fetchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fetchToolStripMenuItem.Text = "&Filter";
            this.fetchToolStripMenuItem.Click += new System.EventHandler(this.fetchToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsExcelToolStripMenuItem});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadToolStripMenuItem.Text = "&Download";
            // 
            // saveAsExcelToolStripMenuItem
            // 
            this.saveAsExcelToolStripMenuItem.Name = "saveAsExcelToolStripMenuItem";
            this.saveAsExcelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsExcelToolStripMenuItem.Text = "Save as &Excel";
            this.saveAsExcelToolStripMenuItem.Click += new System.EventHandler(this.saveAsExcelToolStripMenuItem_Click);
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.label2);
            this.filterBox.Controls.Add(this.label1);
            this.filterBox.Controls.Add(this.btnFilterOK);
            this.filterBox.Controls.Add(this.dateTo);
            this.filterBox.Controls.Add(this.dateFrom);
            this.filterBox.Location = new System.Drawing.Point(40, 50);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(390, 167);
            this.filterBox.TabIndex = 3;
            this.filterBox.TabStop = false;
            this.filterBox.Text = "Filter";
            this.filterBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From:";
            // 
            // btnFilterOK
            // 
            this.btnFilterOK.Location = new System.Drawing.Point(226, 112);
            this.btnFilterOK.Name = "btnFilterOK";
            this.btnFilterOK.Size = new System.Drawing.Size(75, 23);
            this.btnFilterOK.TabIndex = 3;
            this.btnFilterOK.Text = "OK";
            this.btnFilterOK.UseVisualStyleBackColor = true;
            this.btnFilterOK.Click += new System.EventHandler(this.btnFilterOK_Click);
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(101, 73);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 20);
            this.dateTo.TabIndex = 2;
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(101, 29);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 20);
            this.dateFrom.TabIndex = 1;
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.labelProgress);
            this.panelProgress.Controls.Add(this.progressBar1);
            this.panelProgress.Location = new System.Drawing.Point(214, 223);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(444, 71);
            this.panelProgress.TabIndex = 7;
            this.panelProgress.Visible = false;
            // 
            // labelProgress
            // 
            this.labelProgress.BackColor = System.Drawing.Color.Transparent;
            this.labelProgress.Location = new System.Drawing.Point(3, 36);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(438, 30);
            this.labelProgress.TabIndex = 1;
            this.labelProgress.Text = "0/0";
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(438, 30);
            this.progressBar1.TabIndex = 0;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 516);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Browser";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.Resize += new System.EventHandler(this.Browser_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.filterBox.ResumeLayout(false);
            this.filterBox.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuBrowser;
        private System.Windows.Forms.ToolStripMenuItem menuReload;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.ToolStripMenuItem menuControlPanel;
        private System.Windows.Forms.ToolStripMenuItem menuDebug;
        private System.Windows.Forms.ToolStripMenuItem fetchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsExcelToolStripMenuItem;
        private System.Windows.Forms.GroupBox filterBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilterOK;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

