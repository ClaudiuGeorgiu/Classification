namespace Classification
{
    partial class TreeView
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
            this.tree_pictureBox = new System.Windows.Forms.PictureBox();
            this.tree_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tree_pictureBox)).BeginInit();
            this.tree_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree_pictureBox
            // 
            this.tree_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.tree_pictureBox.Name = "tree_pictureBox";
            this.tree_pictureBox.Size = new System.Drawing.Size(1262, 673);
            this.tree_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tree_pictureBox.TabIndex = 0;
            this.tree_pictureBox.TabStop = false;
            this.tree_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.tree_pictureBox_Paint);
            this.tree_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_pictureBox_MouseDown);
            this.tree_pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tree_pictureBox_MouseMove);
            // 
            // tree_panel
            // 
            this.tree_panel.AutoScroll = true;
            this.tree_panel.BackColor = System.Drawing.Color.White;
            this.tree_panel.Controls.Add(this.tree_pictureBox);
            this.tree_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_panel.Location = new System.Drawing.Point(0, 0);
            this.tree_panel.Name = "tree_panel";
            this.tree_panel.Size = new System.Drawing.Size(1262, 673);
            this.tree_panel.TabIndex = 16;
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.tree_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TreeView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Tree View";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.TreeView_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.tree_pictureBox)).EndInit();
            this.tree_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tree_pictureBox;
        private System.Windows.Forms.Panel tree_panel;

    }
}