using Accord.Statistics.Analysis;
using System.Data;
using System.Windows.Forms;

namespace Classification
{
    public partial class ConfusionMatrixView : Form
    {
        // DataTable representing the confusion matrix.
        DataTable confusionMatrixTable = new DataTable();

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="testingData">Source data containing the actual values.</param>
        /// <param name="predictedValues">Predicted results for the source data.</param>
        public ConfusionMatrixView(ClassificationData testingData, int[] predictedValues)
        {
            InitializeComponent();

            // Create a confusion matrix using source and predicted data.
            GeneralConfusionMatrix confusionMatrix =
                new GeneralConfusionMatrix(testingData.OutputPossibleValues, predictedValues, testingData.OutputData);

            // The confusion matrix will be shown as a DataTable,
            // in which columns represent the actual values while
            // rows represent the predicted values. The first column
            // holds the names of the values.

            // Create the structure of the table.
            for (int n = 0; n <= testingData.OutputPossibleValues; ++n)
            {
                if (n == 0)
                {
                    confusionMatrixTable.Columns.Add("Confusion matrix", typeof(string));
                }
                else
                    confusionMatrixTable.Columns.Add(
                        testingData.CodeBook.Translate(testingData.OutputColumnName, n - 1),
                        typeof(int));
            }

            // Populate the table rows with data.
            for (int i = 0; i < testingData.OutputPossibleValues; ++i)
            {
                DataRow newRow = confusionMatrixTable.NewRow();
                for (int j = 0; j <= testingData.OutputPossibleValues; ++j)
                {
                    if (j == 0)
                    {
                        newRow[j] = testingData.CodeBook.Translate(testingData.OutputColumnName, i);
                    }
                    else
                        newRow[j] = confusionMatrix.Matrix[i, j - 1];
                }
                confusionMatrixTable.Rows.Add(newRow);
            }

            confusionMatrix_dataGridView.DataSource = confusionMatrixTable;
        }
    }
}