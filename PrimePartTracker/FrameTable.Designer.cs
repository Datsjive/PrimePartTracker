namespace PrimePartTracker
{
    partial class FrameTable
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
            this.gvFrameList = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFound = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFrameList)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFrameList
            // 
            this.gvFrameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFrameList.Location = new System.Drawing.Point(12, 12);
            this.gvFrameList.Name = "gvFrameList";
            this.gvFrameList.Size = new System.Drawing.Size(546, 426);
            this.gvFrameList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(588, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 61);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Entry";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFound
            // 
            this.btnFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFound.Location = new System.Drawing.Point(588, 195);
            this.btnFound.Name = "btnFound";
            this.btnFound.Size = new System.Drawing.Size(148, 61);
            this.btnFound.TabIndex = 2;
            this.btnFound.Text = "Mark as Found";
            this.btnFound.UseVisualStyleBackColor = true;
            this.btnFound.Click += new System.EventHandler(this.btnFound_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(588, 327);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(148, 61);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove Entry";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FrameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnFound);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvFrameList);
            this.Name = "FrameTable";
            this.Text = "FrameTable";
            this.Load += new System.EventHandler(this.FrameTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFrameList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFrameList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFound;
        private System.Windows.Forms.Button btnRemove;
    }
}