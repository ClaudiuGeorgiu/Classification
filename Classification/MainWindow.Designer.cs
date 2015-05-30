namespace Classification
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
            this.dataset_dataGridView = new System.Windows.Forms.DataGridView();
            this.attributeToPredict_comboBox = new System.Windows.Forms.ComboBox();
            this.attributeToPredict_label = new System.Windows.Forms.Label();
            this.trainClassifier_button = new System.Windows.Forms.Button();
            this.testClassifier_button = new System.Windows.Forms.Button();
            this.classifierToUse_label = new System.Windows.Forms.Label();
            this.classifierToUse_comboBox = new System.Windows.Forms.ComboBox();
            this.training_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trainingFile_button = new System.Windows.Forms.Button();
            this.testingFile_button = new System.Windows.Forms.Button();
            this.testing_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.classificationLog_richTextBox = new System.Windows.Forms.RichTextBox();
            this.reset_button = new System.Windows.Forms.Button();
            this.trainingTime_label = new System.Windows.Forms.Label();
            this.testingTime_label = new System.Windows.Forms.Label();
            this.classifierError_label = new System.Windows.Forms.Label();
            this.predictionError_label = new System.Windows.Forms.Label();
            this.predictionErrorValue_label = new System.Windows.Forms.Label();
            this.classifierErrorValue_label = new System.Windows.Forms.Label();
            this.testingTimeValue_label = new System.Windows.Forms.Label();
            this.trainingTimeValue_label = new System.Windows.Forms.Label();
            this.training_groupBox = new System.Windows.Forms.GroupBox();
            this.parameters_groupBox = new System.Windows.Forms.GroupBox();
            this.svmParameters_panel = new System.Windows.Forms.Panel();
            this.svmAlgorithm_comboBox = new System.Windows.Forms.ComboBox();
            this.svmKernel_comboBox = new System.Windows.Forms.ComboBox();
            this.svmAlgorithm_label = new System.Windows.Forms.Label();
            this.svmKernel_label = new System.Windows.Forms.Label();
            this.bayesianParameters_panel = new System.Windows.Forms.Panel();
            this.bayesian_label = new System.Windows.Forms.Label();
            this.treeParameters_panel = new System.Windows.Forms.Panel();
            this.decisionTree_checkBox = new System.Windows.Forms.CheckBox();
            this.treeHeight_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.treeJoin_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.treeHeight_label = new System.Windows.Forms.Label();
            this.treeJoin_label = new System.Windows.Forms.Label();
            this.performance_groupBox = new System.Windows.Forms.GroupBox();
            this.testing_groupBox = new System.Windows.Forms.GroupBox();
            this.confusionMatrix_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataset_dataGridView)).BeginInit();
            this.training_groupBox.SuspendLayout();
            this.parameters_groupBox.SuspendLayout();
            this.svmParameters_panel.SuspendLayout();
            this.bayesianParameters_panel.SuspendLayout();
            this.treeParameters_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeHeight_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeJoin_numericUpDown)).BeginInit();
            this.performance_groupBox.SuspendLayout();
            this.testing_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataset_dataGridView
            // 
            this.dataset_dataGridView.AllowUserToAddRows = false;
            this.dataset_dataGridView.AllowUserToDeleteRows = false;
            this.dataset_dataGridView.AllowUserToResizeColumns = false;
            this.dataset_dataGridView.AllowUserToResizeRows = false;
            this.dataset_dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataset_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataset_dataGridView.Enabled = false;
            this.dataset_dataGridView.Location = new System.Drawing.Point(6, 21);
            this.dataset_dataGridView.Name = "dataset_dataGridView";
            this.dataset_dataGridView.ReadOnly = true;
            this.dataset_dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataset_dataGridView.RowTemplate.Height = 24;
            this.dataset_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataset_dataGridView.Size = new System.Drawing.Size(782, 249);
            this.dataset_dataGridView.TabIndex = 0;
            // 
            // attributeToPredict_comboBox
            // 
            this.attributeToPredict_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attributeToPredict_comboBox.Enabled = false;
            this.attributeToPredict_comboBox.FormattingEnabled = true;
            this.attributeToPredict_comboBox.Location = new System.Drawing.Point(794, 106);
            this.attributeToPredict_comboBox.Name = "attributeToPredict_comboBox";
            this.attributeToPredict_comboBox.Size = new System.Drawing.Size(200, 24);
            this.attributeToPredict_comboBox.TabIndex = 1;
            this.attributeToPredict_comboBox.SelectedIndexChanged += new System.EventHandler(this.attributeToPredict_comboBox_SelectedIndexChanged);
            // 
            // attributeToPredict_label
            // 
            this.attributeToPredict_label.Location = new System.Drawing.Point(794, 83);
            this.attributeToPredict_label.Name = "attributeToPredict_label";
            this.attributeToPredict_label.Size = new System.Drawing.Size(200, 20);
            this.attributeToPredict_label.TabIndex = 2;
            this.attributeToPredict_label.Text = "Attribute to predict:";
            // 
            // trainClassifier_button
            // 
            this.trainClassifier_button.Enabled = false;
            this.trainClassifier_button.Location = new System.Drawing.Point(794, 225);
            this.trainClassifier_button.Name = "trainClassifier_button";
            this.trainClassifier_button.Size = new System.Drawing.Size(200, 45);
            this.trainClassifier_button.TabIndex = 3;
            this.trainClassifier_button.Text = "Train Classifier";
            this.trainClassifier_button.UseVisualStyleBackColor = true;
            this.trainClassifier_button.Click += new System.EventHandler(this.trainClassifier_button_Click);
            // 
            // testClassifier_button
            // 
            this.testClassifier_button.Enabled = false;
            this.testClassifier_button.Location = new System.Drawing.Point(794, 98);
            this.testClassifier_button.Name = "testClassifier_button";
            this.testClassifier_button.Size = new System.Drawing.Size(200, 45);
            this.testClassifier_button.TabIndex = 5;
            this.testClassifier_button.Text = "Test Classifier";
            this.testClassifier_button.UseVisualStyleBackColor = true;
            this.testClassifier_button.Click += new System.EventHandler(this.testClassifier_button_Click);
            // 
            // classifierToUse_label
            // 
            this.classifierToUse_label.Location = new System.Drawing.Point(794, 149);
            this.classifierToUse_label.Name = "classifierToUse_label";
            this.classifierToUse_label.Size = new System.Drawing.Size(200, 20);
            this.classifierToUse_label.TabIndex = 6;
            this.classifierToUse_label.Text = "Classifier to use:";
            // 
            // classifierToUse_comboBox
            // 
            this.classifierToUse_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classifierToUse_comboBox.Enabled = false;
            this.classifierToUse_comboBox.FormattingEnabled = true;
            this.classifierToUse_comboBox.Location = new System.Drawing.Point(794, 172);
            this.classifierToUse_comboBox.Name = "classifierToUse_comboBox";
            this.classifierToUse_comboBox.Size = new System.Drawing.Size(200, 24);
            this.classifierToUse_comboBox.TabIndex = 7;
            this.classifierToUse_comboBox.SelectedIndexChanged += new System.EventHandler(this.classifierToUse_comboBox_SelectedIndexChanged);
            // 
            // training_openFileDialog
            // 
            this.training_openFileDialog.Filter = "Text files (*.txt)|*.txt";
            string initialPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "..\\..\\..\\");
            this.training_openFileDialog.InitialDirectory = System.IO.Path.GetFullPath(initialPath);
            // 
            // trainingFile_button
            // 
            this.trainingFile_button.Location = new System.Drawing.Point(794, 21);
            this.trainingFile_button.Name = "trainingFile_button";
            this.trainingFile_button.Size = new System.Drawing.Size(200, 45);
            this.trainingFile_button.TabIndex = 8;
            this.trainingFile_button.Text = "Open Training File";
            this.trainingFile_button.UseVisualStyleBackColor = true;
            this.trainingFile_button.Click += new System.EventHandler(this.trainingFile_button_Click);
            // 
            // testingFile_button
            // 
            this.testingFile_button.Location = new System.Drawing.Point(794, 21);
            this.testingFile_button.Name = "testingFile_button";
            this.testingFile_button.Size = new System.Drawing.Size(200, 45);
            this.testingFile_button.TabIndex = 9;
            this.testingFile_button.Text = "Open Testing File";
            this.testingFile_button.UseVisualStyleBackColor = true;
            this.testingFile_button.Click += new System.EventHandler(this.testingFile_button_Click);
            // 
            // testing_openFileDialog
            // 
            this.testing_openFileDialog.Filter = "Text files (*.txt)|*.txt";
            this.testing_openFileDialog.InitialDirectory = System.IO.Path.GetFullPath(initialPath);
            // 
            // classificationLog_richTextBox
            // 
            this.classificationLog_richTextBox.DetectUrls = false;
            this.classificationLog_richTextBox.Enabled = false;
            this.classificationLog_richTextBox.Location = new System.Drawing.Point(6, 21);
            this.classificationLog_richTextBox.Name = "classificationLog_richTextBox";
            this.classificationLog_richTextBox.ReadOnly = true;
            this.classificationLog_richTextBox.Size = new System.Drawing.Size(782, 260);
            this.classificationLog_richTextBox.TabIndex = 10;
            this.classificationLog_richTextBox.Text = "";
            // 
            // reset_button
            // 
            this.reset_button.Enabled = false;
            this.reset_button.Location = new System.Drawing.Point(1018, 521);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(232, 60);
            this.reset_button.TabIndex = 13;
            this.reset_button.Text = "RESET";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // trainingTime_label
            // 
            this.trainingTime_label.AutoSize = true;
            this.trainingTime_label.Location = new System.Drawing.Point(9, 29);
            this.trainingTime_label.Name = "trainingTime_label";
            this.trainingTime_label.Size = new System.Drawing.Size(94, 17);
            this.trainingTime_label.TabIndex = 14;
            this.trainingTime_label.Text = "Training time:";
            // 
            // testingTime_label
            // 
            this.testingTime_label.AutoSize = true;
            this.testingTime_label.Location = new System.Drawing.Point(9, 91);
            this.testingTime_label.Name = "testingTime_label";
            this.testingTime_label.Size = new System.Drawing.Size(89, 17);
            this.testingTime_label.TabIndex = 15;
            this.testingTime_label.Text = "Testing time:";
            // 
            // classifierError_label
            // 
            this.classifierError_label.AutoSize = true;
            this.classifierError_label.Location = new System.Drawing.Point(9, 60);
            this.classifierError_label.Name = "classifierError_label";
            this.classifierError_label.Size = new System.Drawing.Size(104, 17);
            this.classifierError_label.TabIndex = 16;
            this.classifierError_label.Text = "Classifier error:";
            // 
            // predictionError_label
            // 
            this.predictionError_label.AutoSize = true;
            this.predictionError_label.Location = new System.Drawing.Point(9, 122);
            this.predictionError_label.Name = "predictionError_label";
            this.predictionError_label.Size = new System.Drawing.Size(110, 17);
            this.predictionError_label.TabIndex = 17;
            this.predictionError_label.Text = "Prediction error:";
            // 
            // predictionErrorValue_label
            // 
            this.predictionErrorValue_label.AutoSize = true;
            this.predictionErrorValue_label.Location = new System.Drawing.Point(125, 122);
            this.predictionErrorValue_label.Name = "predictionErrorValue_label";
            this.predictionErrorValue_label.Size = new System.Drawing.Size(13, 17);
            this.predictionErrorValue_label.TabIndex = 21;
            this.predictionErrorValue_label.Text = "-";
            // 
            // classifierErrorValue_label
            // 
            this.classifierErrorValue_label.AutoSize = true;
            this.classifierErrorValue_label.Location = new System.Drawing.Point(125, 60);
            this.classifierErrorValue_label.Name = "classifierErrorValue_label";
            this.classifierErrorValue_label.Size = new System.Drawing.Size(13, 17);
            this.classifierErrorValue_label.TabIndex = 20;
            this.classifierErrorValue_label.Text = "-";
            // 
            // testingTimeValue_label
            // 
            this.testingTimeValue_label.AutoSize = true;
            this.testingTimeValue_label.Location = new System.Drawing.Point(125, 91);
            this.testingTimeValue_label.Name = "testingTimeValue_label";
            this.testingTimeValue_label.Size = new System.Drawing.Size(13, 17);
            this.testingTimeValue_label.TabIndex = 19;
            this.testingTimeValue_label.Text = "-";
            // 
            // trainingTimeValue_label
            // 
            this.trainingTimeValue_label.AutoSize = true;
            this.trainingTimeValue_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.trainingTimeValue_label.Location = new System.Drawing.Point(125, 29);
            this.trainingTimeValue_label.Name = "trainingTimeValue_label";
            this.trainingTimeValue_label.Size = new System.Drawing.Size(13, 17);
            this.trainingTimeValue_label.TabIndex = 18;
            this.trainingTimeValue_label.Text = "-";
            // 
            // training_groupBox
            // 
            this.training_groupBox.Controls.Add(this.attributeToPredict_comboBox);
            this.training_groupBox.Controls.Add(this.trainingFile_button);
            this.training_groupBox.Controls.Add(this.classifierToUse_label);
            this.training_groupBox.Controls.Add(this.trainClassifier_button);
            this.training_groupBox.Controls.Add(this.dataset_dataGridView);
            this.training_groupBox.Controls.Add(this.attributeToPredict_label);
            this.training_groupBox.Controls.Add(this.classifierToUse_comboBox);
            this.training_groupBox.Location = new System.Drawing.Point(12, 12);
            this.training_groupBox.Name = "training_groupBox";
            this.training_groupBox.Size = new System.Drawing.Size(1000, 276);
            this.training_groupBox.TabIndex = 22;
            this.training_groupBox.TabStop = false;
            this.training_groupBox.Text = "Classifier Training";
            // 
            // parameters_groupBox
            // 
            this.parameters_groupBox.Controls.Add(this.svmParameters_panel);
            this.parameters_groupBox.Controls.Add(this.bayesianParameters_panel);
            this.parameters_groupBox.Controls.Add(this.treeParameters_panel);
            this.parameters_groupBox.Enabled = false;
            this.parameters_groupBox.Location = new System.Drawing.Point(1018, 12);
            this.parameters_groupBox.Name = "parameters_groupBox";
            this.parameters_groupBox.Size = new System.Drawing.Size(232, 276);
            this.parameters_groupBox.TabIndex = 23;
            this.parameters_groupBox.TabStop = false;
            this.parameters_groupBox.Text = "Training Parameters";
            // 
            // svmParameters_panel
            // 
            this.svmParameters_panel.Controls.Add(this.svmAlgorithm_comboBox);
            this.svmParameters_panel.Controls.Add(this.svmKernel_comboBox);
            this.svmParameters_panel.Controls.Add(this.svmAlgorithm_label);
            this.svmParameters_panel.Controls.Add(this.svmKernel_label);
            this.svmParameters_panel.Location = new System.Drawing.Point(6, 28);
            this.svmParameters_panel.Name = "svmParameters_panel";
            this.svmParameters_panel.Size = new System.Drawing.Size(220, 242);
            this.svmParameters_panel.TabIndex = 2;
            this.svmParameters_panel.Visible = false;
            // 
            // svmAlgorithm_comboBox
            // 
            this.svmAlgorithm_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.svmAlgorithm_comboBox.FormattingEnabled = true;
            this.svmAlgorithm_comboBox.Location = new System.Drawing.Point(6, 82);
            this.svmAlgorithm_comboBox.Name = "svmAlgorithm_comboBox";
            this.svmAlgorithm_comboBox.Size = new System.Drawing.Size(211, 24);
            this.svmAlgorithm_comboBox.TabIndex = 13;
            // 
            // svmKernel_comboBox
            // 
            this.svmKernel_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.svmKernel_comboBox.FormattingEnabled = true;
            this.svmKernel_comboBox.Location = new System.Drawing.Point(6, 23);
            this.svmKernel_comboBox.Name = "svmKernel_comboBox";
            this.svmKernel_comboBox.Size = new System.Drawing.Size(211, 24);
            this.svmKernel_comboBox.TabIndex = 9;
            // 
            // svmAlgorithm_label
            // 
            this.svmAlgorithm_label.Location = new System.Drawing.Point(3, 59);
            this.svmAlgorithm_label.Name = "svmAlgorithm_label";
            this.svmAlgorithm_label.Size = new System.Drawing.Size(214, 20);
            this.svmAlgorithm_label.TabIndex = 12;
            this.svmAlgorithm_label.Text = "Algorithm to use:";
            // 
            // svmKernel_label
            // 
            this.svmKernel_label.Location = new System.Drawing.Point(3, 0);
            this.svmKernel_label.Name = "svmKernel_label";
            this.svmKernel_label.Size = new System.Drawing.Size(214, 20);
            this.svmKernel_label.TabIndex = 11;
            this.svmKernel_label.Text = "Kernel to use:";
            // 
            // bayesianParameters_panel
            // 
            this.bayesianParameters_panel.Controls.Add(this.bayesian_label);
            this.bayesianParameters_panel.Location = new System.Drawing.Point(6, 28);
            this.bayesianParameters_panel.Name = "bayesianParameters_panel";
            this.bayesianParameters_panel.Size = new System.Drawing.Size(220, 242);
            this.bayesianParameters_panel.TabIndex = 1;
            this.bayesianParameters_panel.Visible = false;
            // 
            // bayesian_label
            // 
            this.bayesian_label.Location = new System.Drawing.Point(3, 111);
            this.bayesian_label.Name = "bayesian_label";
            this.bayesian_label.Size = new System.Drawing.Size(214, 20);
            this.bayesian_label.TabIndex = 11;
            this.bayesian_label.Text = "No parameters to show.";
            this.bayesian_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // treeParameters_panel
            // 
            this.treeParameters_panel.Controls.Add(this.decisionTree_checkBox);
            this.treeParameters_panel.Controls.Add(this.treeHeight_numericUpDown);
            this.treeParameters_panel.Controls.Add(this.treeJoin_numericUpDown);
            this.treeParameters_panel.Controls.Add(this.treeHeight_label);
            this.treeParameters_panel.Controls.Add(this.treeJoin_label);
            this.treeParameters_panel.Location = new System.Drawing.Point(6, 28);
            this.treeParameters_panel.Name = "treeParameters_panel";
            this.treeParameters_panel.Size = new System.Drawing.Size(220, 242);
            this.treeParameters_panel.TabIndex = 0;
            this.treeParameters_panel.Visible = false;
            // 
            // decisionTree_checkBox
            // 
            this.decisionTree_checkBox.Location = new System.Drawing.Point(6, 149);
            this.decisionTree_checkBox.Name = "decisionTree_checkBox";
            this.decisionTree_checkBox.Size = new System.Drawing.Size(211, 20);
            this.decisionTree_checkBox.TabIndex = 12;
            this.decisionTree_checkBox.Text = "Show decision tree";
            this.decisionTree_checkBox.UseVisualStyleBackColor = true;
            // 
            // treeHeight_numericUpDown
            // 
            this.treeHeight_numericUpDown.Location = new System.Drawing.Point(6, 121);
            this.treeHeight_numericUpDown.Name = "treeHeight_numericUpDown";
            this.treeHeight_numericUpDown.Size = new System.Drawing.Size(211, 22);
            this.treeHeight_numericUpDown.TabIndex = 12;
            this.treeHeight_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // treeJoin_numericUpDown
            // 
            this.treeJoin_numericUpDown.Location = new System.Drawing.Point(6, 55);
            this.treeJoin_numericUpDown.Name = "treeJoin_numericUpDown";
            this.treeJoin_numericUpDown.Size = new System.Drawing.Size(211, 22);
            this.treeJoin_numericUpDown.TabIndex = 11;
            this.treeJoin_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // treeHeight_label
            // 
            this.treeHeight_label.Location = new System.Drawing.Point(3, 84);
            this.treeHeight_label.Name = "treeHeight_label";
            this.treeHeight_label.Size = new System.Drawing.Size(214, 34);
            this.treeHeight_label.TabIndex = 10;
            this.treeHeight_label.Text = "Maximum height of the tree (set 0 to use default):";
            // 
            // treeJoin_label
            // 
            this.treeJoin_label.Location = new System.Drawing.Point(3, 0);
            this.treeJoin_label.Name = "treeJoin_label";
            this.treeJoin_label.Size = new System.Drawing.Size(214, 52);
            this.treeJoin_label.TabIndex = 9;
            this.treeJoin_label.Text = "How many times a variable can join the decision process (set 0 to use default):";
            // 
            // performance_groupBox
            // 
            this.performance_groupBox.Controls.Add(this.trainingTime_label);
            this.performance_groupBox.Controls.Add(this.testingTime_label);
            this.performance_groupBox.Controls.Add(this.classifierError_label);
            this.performance_groupBox.Controls.Add(this.predictionErrorValue_label);
            this.performance_groupBox.Controls.Add(this.predictionError_label);
            this.performance_groupBox.Controls.Add(this.trainingTimeValue_label);
            this.performance_groupBox.Controls.Add(this.classifierErrorValue_label);
            this.performance_groupBox.Controls.Add(this.testingTimeValue_label);
            this.performance_groupBox.Location = new System.Drawing.Point(1018, 294);
            this.performance_groupBox.Name = "performance_groupBox";
            this.performance_groupBox.Size = new System.Drawing.Size(232, 221);
            this.performance_groupBox.TabIndex = 24;
            this.performance_groupBox.TabStop = false;
            this.performance_groupBox.Text = "Performance";
            // 
            // testing_groupBox
            // 
            this.testing_groupBox.Controls.Add(this.confusionMatrix_checkBox);
            this.testing_groupBox.Controls.Add(this.classificationLog_richTextBox);
            this.testing_groupBox.Controls.Add(this.testingFile_button);
            this.testing_groupBox.Controls.Add(this.testClassifier_button);
            this.testing_groupBox.Location = new System.Drawing.Point(12, 294);
            this.testing_groupBox.Name = "testing_groupBox";
            this.testing_groupBox.Size = new System.Drawing.Size(1000, 287);
            this.testing_groupBox.TabIndex = 23;
            this.testing_groupBox.TabStop = false;
            this.testing_groupBox.Text = "Classifier Testing";
            // 
            // confusionMatrix_checkBox
            // 
            this.confusionMatrix_checkBox.Location = new System.Drawing.Point(794, 72);
            this.confusionMatrix_checkBox.Name = "confusionMatrix_checkBox";
            this.confusionMatrix_checkBox.Size = new System.Drawing.Size(200, 20);
            this.confusionMatrix_checkBox.TabIndex = 11;
            this.confusionMatrix_checkBox.Text = "Show confusion matrix";
            this.confusionMatrix_checkBox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 593);
            this.Controls.Add(this.testing_groupBox);
            this.Controls.Add(this.performance_groupBox);
            this.Controls.Add(this.parameters_groupBox);
            this.Controls.Add(this.training_groupBox);
            this.Controls.Add(this.reset_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Classification";
            ((System.ComponentModel.ISupportInitialize)(this.dataset_dataGridView)).EndInit();
            this.training_groupBox.ResumeLayout(false);
            this.parameters_groupBox.ResumeLayout(false);
            this.svmParameters_panel.ResumeLayout(false);
            this.bayesianParameters_panel.ResumeLayout(false);
            this.treeParameters_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeHeight_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeJoin_numericUpDown)).EndInit();
            this.performance_groupBox.ResumeLayout(false);
            this.performance_groupBox.PerformLayout();
            this.testing_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataset_dataGridView;
        private System.Windows.Forms.ComboBox attributeToPredict_comboBox;
        private System.Windows.Forms.Label attributeToPredict_label;
        private System.Windows.Forms.Button trainClassifier_button;
        private System.Windows.Forms.Button testClassifier_button;
        private System.Windows.Forms.Label classifierToUse_label;
        private System.Windows.Forms.ComboBox classifierToUse_comboBox;
        private System.Windows.Forms.OpenFileDialog training_openFileDialog;
        private System.Windows.Forms.Button trainingFile_button;
        private System.Windows.Forms.Button testingFile_button;
        private System.Windows.Forms.OpenFileDialog testing_openFileDialog;
        private System.Windows.Forms.RichTextBox classificationLog_richTextBox;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Label trainingTime_label;
        private System.Windows.Forms.Label testingTime_label;
        private System.Windows.Forms.Label classifierError_label;
        private System.Windows.Forms.Label predictionError_label;
        private System.Windows.Forms.Label predictionErrorValue_label;
        private System.Windows.Forms.Label classifierErrorValue_label;
        private System.Windows.Forms.Label testingTimeValue_label;
        private System.Windows.Forms.Label trainingTimeValue_label;
        private System.Windows.Forms.GroupBox training_groupBox;
        private System.Windows.Forms.GroupBox parameters_groupBox;
        private System.Windows.Forms.Panel treeParameters_panel;
        private System.Windows.Forms.Panel bayesianParameters_panel;
        private System.Windows.Forms.Panel svmParameters_panel;
        private System.Windows.Forms.Label treeJoin_label;
        private System.Windows.Forms.Label treeHeight_label;
        private System.Windows.Forms.Label bayesian_label;
        private System.Windows.Forms.Label svmKernel_label;
        private System.Windows.Forms.Label svmAlgorithm_label;
        private System.Windows.Forms.NumericUpDown treeHeight_numericUpDown;
        private System.Windows.Forms.NumericUpDown treeJoin_numericUpDown;
        private System.Windows.Forms.ComboBox svmAlgorithm_comboBox;
        private System.Windows.Forms.ComboBox svmKernel_comboBox;
        private System.Windows.Forms.GroupBox performance_groupBox;
        private System.Windows.Forms.GroupBox testing_groupBox;
        private System.Windows.Forms.CheckBox confusionMatrix_checkBox;
        private System.Windows.Forms.CheckBox decisionTree_checkBox;
    }
}

