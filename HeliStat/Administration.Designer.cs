namespace HeliStat
{
    partial class frmAdministration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministration));
            this.menuStripAdmin = new System.Windows.Forms.MenuStrip();
            this.toolStripAdmin = new System.Windows.Forms.ToolStrip();
            this.statusStripAdmin = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(800, 24);
            this.menuStripAdmin.TabIndex = 0;
            this.menuStripAdmin.Text = "menuStrip1";
            // 
            // toolStripAdmin
            // 
            this.toolStripAdmin.Location = new System.Drawing.Point(0, 24);
            this.toolStripAdmin.Name = "toolStripAdmin";
            this.toolStripAdmin.Size = new System.Drawing.Size(800, 25);
            this.toolStripAdmin.TabIndex = 1;
            this.toolStripAdmin.Text = "toolStrip1";
            // 
            // statusStripAdmin
            // 
            this.statusStripAdmin.Location = new System.Drawing.Point(0, 428);
            this.statusStripAdmin.Name = "statusStripAdmin";
            this.statusStripAdmin.Size = new System.Drawing.Size(800, 22);
            this.statusStripAdmin.TabIndex = 2;
            this.statusStripAdmin.Text = "statusStrip1";
            // 
            // frmAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStripAdmin);
            this.Controls.Add(this.toolStripAdmin);
            this.Controls.Add(this.menuStripAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripAdmin;
            this.MaximizeBox = false;
            this.Name = "frmAdministration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeliStat - Administration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStrip toolStripAdmin;
        private System.Windows.Forms.StatusStrip statusStripAdmin;
    }
}