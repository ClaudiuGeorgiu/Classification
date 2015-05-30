namespace Classification
{
    partial class ConfusionMatrixView
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
            this.actual_label = new System.Windows.Forms.Label();
            this.predicted_label = new System.Windows.Forms.Label();
            this.confusionMatrix_dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.confusionMatrix_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // actual_label
            // 
            this.actual_label.AutoSize = true;
            this.actual_label.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actual_label.Location = new System.Drawing.Point(263, 9);
            this.actual_label.Name = "actual_label";
            this.actual_label.Size = new System.Drawing.Size(112, 17);
            this.actual_label.TabIndex = 0;
            this.actual_label.Text = "Actual values";
            // 
            // predicted_label
            // 
            this.predicted_label.AutoSize = true;
            this.predicted_label.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predicted_label.Location = new System.Drawing.Point(12, 29);
            this.predicted_label.Name = "predicted_label";
            this.predicted_label.Size = new System.Drawing.Size(16, 272);
            this.predicted_label.TabIndex = 1;
            this.predicted_label.Text = "P\nr\ne\nd\ni\nc\nt\ne\nd\n \nv\na\nl\nu\ne\ns";
            // 
            // confusionMatrix_dataGridView
            // 
            this.confusionMatrix_dataGridView.AllowUserToAddRows = false;
            this.confusionMatrix_dataGridView.AllowUserToDeleteRows = false;
            this.confusionMatrix_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.confusionMatrix_dataGridView.Location = new System.Drawing.Point(34, 29);
            this.confusionMatrix_dataGridView.Name = "confusionMatrix_dataGridView";
            this.confusionMatrix_dataGridView.ReadOnly = true;
            this.confusionMatrix_dataGridView.RowTemplate.Height = 24;
            this.confusionMatrix_dataGridView.Size = new System.Drawing.Size(576, 272);
            this.confusionMatrix_dataGridView.TabIndex = 2;
            // 
            // ConfusionMatrixView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 313);
            this.Controls.Add(this.confusionMatrix_dataGridView);
            this.Controls.Add(this.predicted_label);
            this.Controls.Add(this.actual_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfusionMatrixView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Confusion Matrix View";
            ((System.ComponentModel.ISupportInitialize)(this.confusionMatrix_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label actual_label;
        private System.Windows.Forms.Label predicted_label;
        private System.Windows.Forms.DataGridView confusionMatrix_dataGridView;
    }
}