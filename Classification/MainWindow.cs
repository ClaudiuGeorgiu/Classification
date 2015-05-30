using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Classification
{
    public partial class MainWindow : Form
    {
        private GenericClassifier classifier;
        private ClassificationData trainingData;
        private ClassificationData testingData;
        private double classifierError;
        private double predictionError;
        private List<string> classificationMethods;
        private Dictionary<string, IKernel> kernelList;
        private Dictionary<string, SupportVectorMachineLearningConfigurationFunction> algorithmList;
        // Flags.
        private bool trainingFileLoaded;
        private bool testingFileLoaded;
        private bool dataTrained;
        private bool attributeChosen;
        private bool classifierChosen;
        // Used to measure performance.
        private Stopwatch chronometer;
        // Used to visualize the decision tree.
        private TreeView treeVisualizer;
        // Used to visualize the confusion matrix.
        private ConfusionMatrixView matrixVisualizer;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            classifierError = 0;
            predictionError = 0;
            trainingFileLoaded = false;
            testingFileLoaded = false;
            dataTrained = false;
            attributeChosen = false;
            classifierChosen = false;
            chronometer = new Stopwatch();
            
            classificationMethods = new List<string> 
            {
                "Decision Tree", "Naive Bayesian", "SVM" 
            };

            kernelList = new Dictionary<string, IKernel>
            {
                {"Default", null},
                {"Linear", new Linear()},
                {"Gaussian", new Gaussian()},
                {"Laplacian", new Laplacian()},
                {"Chi Square", new ChiSquare()},
                {"Histogram Intersection", new HistogramIntersection()}
            };

            algorithmList = new Dictionary<string, SupportVectorMachineLearningConfigurationFunction>
            {
                {"Default", null},
                {"Sequential Minimal Optimization",
                    (SVM, inputData, outputData, i, j) =>
                    new SequentialMinimalOptimization(SVM, inputData, outputData)},
                {"Least Squares Learning",
                    (SVM, inputData, outputData, i, j) =>
                    new LeastSquaresLearning(SVM, inputData, outputData)},
                {"Linear Newton Method",
                    (SVM, inputData, outputData, i, j) =>
                    new LinearNewtonMethod(SVM, inputData, outputData)}
            };

            svmKernel_comboBox.DataSource = kernelList.Keys.ToList();
            svmAlgorithm_comboBox.DataSource = algorithmList.Keys.ToList();
        }

        // Called when the user tries to train the classifier with the data previously loaded.
        private void trainClassifier_button_Click(object sender, EventArgs e)
        {
            // Scroll to the end of the text box.
            classificationLog_richTextBox.SelectionStart = classificationLog_richTextBox.Text.Length;
            classificationLog_richTextBox.ScrollToCaret();

            // Return if there was an error when processing the training dataset.
            if (!trainingData.ProcessDataset(attributeToPredict_comboBox.SelectedItem.ToString()))
            {
                classificationLog_richTextBox.SelectionColor = Color.Red;
                classificationLog_richTextBox.SelectedText =
                    "=====> There was a problem with processing the training data." +
                    Environment.NewLine;
                return;
            }
            classificationLog_richTextBox.SelectionColor = Color.Green;
            classificationLog_richTextBox.SelectedText =
                "=====> Training data was processed correctly." +
                Environment.NewLine;

            // Choose classifier to use.
            switch (classifierToUse_comboBox.SelectedItem.ToString())
            {
                case "Decision Tree":
                    classifier = new DecisionTreeClassifier();
                    // Give the inputs' names to the classifier,
                    // otherwise they will be generated automatically.
                    ((DecisionTreeClassifier)classifier).DecisionVariableNames = 
                        trainingData.InputColumnNames;
                    break;
                case "Naive Bayesian":
                    classifier = new NaiveBayesianClassifier();
                    break;
                case "SVM":
                    classifier = new SVMClassifier();
                    break;
                default:
                    // Return if no valid classifier is selected.
                    return;
            }

            // Measure and display training time and error.
            chronometer.Reset();
            chronometer.Start();
            try
            {
                if (classifier is DecisionTreeClassifier)
                    classifierError = ((DecisionTreeClassifier)classifier).TrainClassifierWithParameters(
                        trainingData,
                        (int)treeJoin_numericUpDown.Value,
                        (int)treeHeight_numericUpDown.Value);
                else if (classifier is NaiveBayesianClassifier)
                    classifierError = ((NaiveBayesianClassifier)classifier).TrainClassifier(
                        trainingData);
                else if (classifier is SVMClassifier)
                    classifierError = ((SVMClassifier)classifier).TrainClassifierWithParameters(
                        trainingData,
                        kernelList[svmKernel_comboBox.SelectedValue.ToString()],
                        /*svmAlgorithm_comboBox*/null);
            }
            catch
            {
                classificationLog_richTextBox.SelectionColor = Color.Red;
                classificationLog_richTextBox.SelectedText =
                    "=====> There was a problem with training the classifier." +
                    Environment.NewLine;
                return;
            }
            chronometer.Stop();
            classificationLog_richTextBox.SelectionColor = Color.Green;
            classificationLog_richTextBox.SelectedText =
                "=====> Classifier was trained successfully." +
                Environment.NewLine;
            trainingTimeValue_label.ForeColor = Color.Blue;
            trainingTimeValue_label.Text = chronometer.ElapsedMilliseconds + " ms";
            classifierErrorValue_label.ForeColor = (classifierError == 0) ? Color.Green : Color.Red;
            classifierErrorValue_label.Text = 
                string.Format("{0:0.00}", classifierError * 100) + "%";
            dataTrained = true;

            // Deactivate some window's controls if
            // classifier's training was successful.
            attributeToPredict_comboBox.Enabled = false;
            classifierToUse_comboBox.Enabled = false;
            trainingFile_button.Enabled = false;
            trainClassifier_button.Enabled = false;
            treeJoin_numericUpDown.Enabled = false;
            treeHeight_numericUpDown.Enabled = false;
            svmKernel_comboBox.Enabled = false;
            svmAlgorithm_comboBox.Enabled = false;
            decisionTree_checkBox.Enabled = false;
            testClassifier_button.Enabled = trainingFileLoaded && testingFileLoaded && dataTrained;
            this.Refresh();

            // Show a visual tree if decision tree classifier
            // was chosen and the user checked the check box.
            if ((classifier is DecisionTreeClassifier) && decisionTree_checkBox.Checked)
            {
                try
                {
                    VisualDecisionTree visualTree = new VisualDecisionTree(
                        ((DecisionTreeClassifier)classifier).ClassificationDecisionTree);
                    Bitmap image = visualTree.drawHorizontalTree(
                        trainingData.OutputColumnName,
                        trainingData.CodeBook);
                    treeVisualizer = new TreeView(image);
                }
                catch
                {
                    classificationLog_richTextBox.SelectionColor = Color.Red;
                    classificationLog_richTextBox.SelectedText =
                        "=====> There was a problem with drawing the decision tree." +
                        Environment.NewLine;
                    return;
                }
                treeVisualizer.Show();
            }
        }

        // Called when the user tries to test the classifier with some testing data.
        private void testClassifier_button_Click(object sender, EventArgs e)
        {
            // Scroll to the end of the text box.
            classificationLog_richTextBox.SelectionStart = classificationLog_richTextBox.Text.Length;
            classificationLog_richTextBox.ScrollToCaret();

            // Return if there was an error when processing the testing dataset.
            if (!testingData.ProcessDataset(trainingData.OutputColumnName, trainingData.CodeBook))
            {
                classificationLog_richTextBox.SelectionColor = Color.Red;
                classificationLog_richTextBox.SelectedText =
                    "=====> There was a problem with processing the testing data." +
                    Environment.NewLine;
                return;
            }
            classificationLog_richTextBox.SelectionColor = Color.Green;
            classificationLog_richTextBox.SelectedText =
                "=====> Testing data was processed correctly. Testing results:" +
                Environment.NewLine;

            // Reset prediction error.
            predictionError = 0;

            // Measure testing time.
            chronometer.Reset();
            chronometer.Start();
            int[] predictedValues = classifier.TestClassifier(testingData);
            chronometer.Stop();

            // Log results and calculate prediction error.
            for (int n = 0; n < predictedValues.Length; ++n)
            {
                // Verify if predicted results are equal to the actual results.
                if (predictedValues[n] == testingData.OutputData[n])
                {
                    classificationLog_richTextBox.SelectionColor = Color.Green;
                    classificationLog_richTextBox.SelectedText =
                        "MATCHING: expected " +
                        testingData.CodeBook.Translate(
                            testingData.OutputColumnName,
                            testingData.OutputData[n]) +
                        " and predicted " +
                        testingData.CodeBook.Translate(
                            testingData.OutputColumnName,
                            predictedValues[n]) +
                            Environment.NewLine;
                }
                else
                {
                    ++predictionError;
                    classificationLog_richTextBox.SelectionColor = Color.Red;
                    classificationLog_richTextBox.SelectedText =
                        "NOT MATCHNG: expected " +
                        testingData.CodeBook.Translate(
                            testingData.OutputColumnName,
                            testingData.OutputData[n]) +
                        " but predicted " +
                        testingData.CodeBook.Translate(
                            testingData.OutputColumnName,
                            predictedValues[n]) +
                        Environment.NewLine;
                }
            }

            // Scroll to the end of the text box.
            classificationLog_richTextBox.SelectionStart = classificationLog_richTextBox.Text.Length;
            classificationLog_richTextBox.ScrollToCaret();

            // Close the old window showing the confusion matrix
            // (if present) and show a new window if the user
            // checked the check box.
            if (matrixVisualizer != null)
                matrixVisualizer.Close();
            if (confusionMatrix_checkBox.Checked)
            {
                matrixVisualizer = new ConfusionMatrixView(testingData, predictedValues);
                matrixVisualizer.Show();
            }

            // Display testing time and prediction error.
            testingTimeValue_label.ForeColor = Color.Blue;
            testingTimeValue_label.Text = chronometer.ElapsedMilliseconds + " ms";
            predictionErrorValue_label.ForeColor = (predictionError == 0) ? Color.Green : Color.Red;
            predictionErrorValue_label.Text =
                string.Format("{0:0.00}", predictionError * 100 / predictedValues.Length) + "%";
        }

        // Called when the user tries to open a file to train the classifier.
        private void trainingFile_button_Click(object sender, EventArgs e)
        {
            // Scroll to the end of the text box.
            classificationLog_richTextBox.SelectionStart = classificationLog_richTextBox.Text.Length;
            classificationLog_richTextBox.ScrollToCaret();

            if (training_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                trainingData = new ClassificationData();

                // Return if the file was not open and parsed correctly.
                if (!trainingData.OpenAndParseFile(training_openFileDialog.FileName, true))
                {
                    classificationLog_richTextBox.SelectionColor = Color.Red;
                    classificationLog_richTextBox.SelectedText =
                        "=====> Training file: " +
                        training_openFileDialog.FileName +
                        " was not opened or parsed correctly." +
                        Environment.NewLine;
                    return;
                }
                trainingFileLoaded = true;
                classificationLog_richTextBox.SelectionColor = Color.Green;
                classificationLog_richTextBox.SelectedText =
                    "=====> Training file: " +
                    training_openFileDialog.FileName +
                    " was opened successfully. " +
                    Environment.NewLine;

                // Activate some window's controls if the file was loaded successfully.
                attributeToPredict_comboBox.DataSource = trainingData.AllColumnNames;
                attributeToPredict_comboBox.SelectedIndex = -1;
                attributeToPredict_comboBox.Enabled = true;
                classifierToUse_comboBox.DataSource = classificationMethods;
                classifierToUse_comboBox.SelectedIndex = -1;
                classifierToUse_comboBox.Enabled = true;
                dataset_dataGridView.DataSource = trainingData.ExtractedDataset;
                dataset_dataGridView.Enabled = true;
                classificationLog_richTextBox.Enabled = true;
                trainClassifier_button.Enabled = attributeChosen && classifierChosen;
                reset_button.Enabled = true;
                testClassifier_button.Enabled = trainingFileLoaded && testingFileLoaded && dataTrained;
            }
        }

        // Called when the user tries to open a file to test the classifier.
        private void testingFile_button_Click(object sender, EventArgs e)
        {
            // Scroll to the end of the text box.
            classificationLog_richTextBox.SelectionStart = classificationLog_richTextBox.Text.Length;
            classificationLog_richTextBox.ScrollToCaret();

            if (testing_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                testingData = new ClassificationData();

                // Return if file was not open and parsed correctly.
                if (!testingData.OpenAndParseFile(testing_openFileDialog.FileName, true))
                {
                    classificationLog_richTextBox.SelectionColor = Color.Red;
                    classificationLog_richTextBox.SelectedText =
                        "=====> Testing file: " +
                        testing_openFileDialog.FileName +
                        " was not opened or parsed correctly." +
                        Environment.NewLine;
                    return;
                }
                testingFileLoaded = true;
                classificationLog_richTextBox.SelectionColor = Color.Green;
                classificationLog_richTextBox.SelectedText =
                    "=====> Testing file: " +
                    testing_openFileDialog.FileName +
                    " was opened successfully." +
                    Environment.NewLine;

                reset_button.Enabled = true;
                testClassifier_button.Enabled = trainingFileLoaded && testingFileLoaded && dataTrained;
            }
        }

        // Called when the user changes the attribute to predict.
        private void attributeToPredict_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (attributeToPredict_comboBox.SelectedIndex >= 0)
                attributeChosen = true;
            else
                attributeChosen = false;
            trainClassifier_button.Enabled = attributeChosen && classifierChosen;
        }

        // Called when the user changes the classifier to use.
        private void classifierToUse_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable "parameter choosing panel" if a valid classifier is selected.
            if (classifierToUse_comboBox.SelectedIndex >= 0)
            {
                classifierChosen = true;
                parameters_groupBox.Text = classifierToUse_comboBox.SelectedValue.ToString();
                parameters_groupBox.Enabled = true;
                switch (classifierToUse_comboBox.SelectedItem.ToString())
                {
                    case "Decision Tree":
                        treeParameters_panel.Visible = true;
                        bayesianParameters_panel.Visible = false;
                        svmParameters_panel.Visible = false;
                        break;
                    case "Naive Bayesian":
                        treeParameters_panel.Visible = false;
                        bayesianParameters_panel.Visible = true;
                        svmParameters_panel.Visible = false;
                        break;
                    case "SVM":
                        treeParameters_panel.Visible = false;
                        bayesianParameters_panel.Visible = false;
                        svmParameters_panel.Visible = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                classifierChosen = false;
                treeParameters_panel.Visible = false;
                bayesianParameters_panel.Visible = false;
                svmParameters_panel.Visible = false;
                parameters_groupBox.Text = "Training Parameters";
                parameters_groupBox.Enabled = false;
            }
            trainClassifier_button.Enabled = attributeChosen && classifierChosen;
        }

        // Reset all controls.
        private void reset_button_Click(object sender, EventArgs e)
        {
            if (treeVisualizer != null)
                treeVisualizer.Close();
            if (matrixVisualizer != null)
                matrixVisualizer.Close();
            trainingFileLoaded = false;
            testingFileLoaded = false;
            dataTrained = false;
            attributeChosen = false;
            classifierChosen = false;
            classifierError = 0;
            predictionError = 0;
            classifier = null;
            trainingData = null;
            testingData = null;
            parameters_groupBox.Enabled = false;
            treeParameters_panel.Visible = false;
            bayesianParameters_panel.Visible = false;
            svmParameters_panel.Visible = false;
            treeJoin_numericUpDown.Value = 0;
            treeJoin_numericUpDown.Enabled = true;
            treeHeight_numericUpDown.Value = 0;
            treeHeight_numericUpDown.Enabled = true;
            svmKernel_comboBox.SelectedIndex = 0;
            svmKernel_comboBox.Enabled = true;
            svmAlgorithm_comboBox.SelectedIndex = 0;
            svmAlgorithm_comboBox.Enabled = true;
            decisionTree_checkBox.Enabled = true;
            attributeToPredict_comboBox.DataSource = null;
            attributeToPredict_comboBox.Enabled = false;
            classifierToUse_comboBox.DataSource = null;
            classifierToUse_comboBox.Enabled = false;
            trainingFile_button.Enabled = true;
            trainClassifier_button.Enabled = false;
            testClassifier_button.Enabled = false;
            dataset_dataGridView.DataSource = null;
            dataset_dataGridView.Enabled = false;
            trainingTimeValue_label.ForeColor = SystemColors.ControlText;
            testingTimeValue_label.ForeColor = SystemColors.ControlText;
            classifierErrorValue_label.ForeColor = SystemColors.ControlText;
            predictionErrorValue_label.ForeColor = SystemColors.ControlText;
            trainingTimeValue_label.Text = "-";
            testingTimeValue_label.Text = "-";
            classifierErrorValue_label.Text = "-";
            predictionErrorValue_label.Text = "-";
            classificationLog_richTextBox.Clear();
            classificationLog_richTextBox.Enabled = false;
        }
    }
}