namespace PrimePartTracker
{
    partial class MainWindow
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
            this.miFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrimary = new System.Windows.Forms.ToolStripMenuItem();
            this.miMelee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFrames,
            this.miPrimary,
            this.miMelee});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFrames
            // 
            this.miFrames.Name = "miFrames";
            this.miFrames.Size = new System.Drawing.Size(57, 20);
            this.miFrames.Text = "Frames";
            this.miFrames.Click += new System.EventHandler(this.miFrames_Click);
            // 
            // miPrimary
            // 
            this.miPrimary.Name = "miPrimary";
            this.miPrimary.Size = new System.Drawing.Size(60, 20);
            this.miPrimary.Text = "Primary";
            this.miPrimary.Click += new System.EventHandler(this.miPrimary_Click);
            // 
            // miMelee
            // 
            this.miMelee.Name = "miMelee";
            this.miMelee.Size = new System.Drawing.Size(51, 20);
            this.miMelee.Text = "Melee";
            this.miMelee.Click += new System.EventHandler(this.miMelee_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 583);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Prime Part Tracker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFrames;
        private System.Windows.Forms.ToolStripMenuItem miPrimary;
        private System.Windows.Forms.ToolStripMenuItem miMelee;
    }
}

