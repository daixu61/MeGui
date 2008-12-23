namespace MeGUI.core.gui
{
    partial class ProfileExporter
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
            this.PresetExporterToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusCheck = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.Text = "Select the presets to export";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 323);
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.Text = "Export...";
            this.button2.Click += new System.EventHandler(this.export_Click);
            // 
            // profileList
            // 
            this.profileList.ContextMenuStrip = this.statusCheck;
            // 
            // PresetExporterToolTip
            // 
            this.PresetExporterToolTip.AutoPopDelay = 5000;
            this.PresetExporterToolTip.InitialDelay = 1000;
            this.PresetExporterToolTip.ReshowDelay = 100;
            // 
            // statusCheck
            // 
            this.statusCheck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllToolStripMenuItem,
            this.checkNoneToolStripMenuItem});
            this.statusCheck.Name = "statusCheck";
            this.statusCheck.Size = new System.Drawing.Size(140, 48);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.checkAllToolStripMenuItem.Text = "Check All";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // checkNoneToolStripMenuItem
            // 
            this.checkNoneToolStripMenuItem.Name = "checkNoneToolStripMenuItem";
            this.checkNoneToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.checkNoneToolStripMenuItem.Text = "Check None";
            this.checkNoneToolStripMenuItem.Click += new System.EventHandler(this.checkNoneToolStripMenuItem_Click);
            // 
            // ProfileExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(383, 358);
            this.Name = "ProfileExporter";
            this.Text = "Presets Exporter";
            this.Shown += new System.EventHandler(this.ProfileExporter_Shown);
            this.Controls.SetChildIndex(this.profileList, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.statusCheck.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip PresetExporterToolTip;
        private System.Windows.Forms.ContextMenuStrip statusCheck;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkNoneToolStripMenuItem;
    }
}
