using Accord.Math;
using Accord.Statistics.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Classification
{
    /// <summary>
    /// Class used to import and store a dataset from a
    /// comma-separated values (CSV) text file, performing
    /// some useful operations to facilitate data classification.
    /// </summary>
    public class ClassificationData
    {
        public DataTable ExtractedDataset { get; private set; }
        public DataTable ProcessedDataset { get; private set; }
        public Codification CodeBook { get; private set; }
        public List<string> AllColumnNames { get; private set; }
        public List<string> InputColumnNames { get; private set; }
        public string OutputColumnName { get; private set; }
        public double[][] InputData { get; private set; }
        public int[] OutputData { get; private set; }
        public int InputAttributeNumber { get; private set; }
        public int OutputPossibleValues { get; private set; }
        
        /// <summary>
        /// Default constructor initializing the variables.
        /// </summary>
        public ClassificationData()
        {
            initializeVariables();
        }

        /// <summary>
        /// Initialize/reset all variables.
        /// </summary>
        private void initializeVariables()
        {
            ExtractedDataset = new DataTable();
            ProcessedDataset = new DataTable();
            CodeBook = new Codification();
            AllColumnNames = new List<string>();
            InputColumnNames = new List<string>();
            InputData = null;
            OutputData = null;
            InputAttributeNumber = 0;
            OutputPossibleValues = 0;
        }

        /// <summary>
        /// Open and parse a CSV text file, then store the parsed
        /// data (as strings) into the ExtractedDataset variable.
        /// </summary>
        /// <param name="filePath">Path to the CSV text file.</param>
        /// <param name="hasHeader">True if the first line of the CSV
        /// text file contains columns' names (by default false).</param>
        /// <returns>Bool value indicating whether the file was
        /// opened and parsed correctly or not.</returns>
        public bool OpenAndParseFile(string filePath, bool hasHeader = false)
        {
            try
            {
                using (StreamReader inputFile = new StreamReader(filePath))
                {
                    string textLine = "";
                    string[] textLineTokens = null;

                    // Read the first line in the file, then add a column
                    // to the ExtractedDataset table for each value found.
                    textLine = inputFile.ReadLine();
                    textLineTokens = textLine.Split(',');
                    for (int n = 0; n < textLineTokens.Length; ++n)
                    {
                        // If the file doesn't contain any header:
                        // columns' names are generated automatically as
                        // "attribute_columnNumber" where "columnNumber"
                        // is an ordinal number.
                        if (!hasHeader)
                            AllColumnNames.Add("attribute_" + (n + 1).ToString());
                        // If the file contains a header:
                        // columns' names are taken from the header.
                        else
                            AllColumnNames.Add(textLineTokens[n]);

                        ExtractedDataset.Columns.Add(AllColumnNames[n], typeof(string));
                    }
                    // If the file doesn't contain any header:
                    // add first row to the ExtractedDataset table.
                    if (!hasHeader)
                        ExtractedDataset.Rows.Add(textLineTokens);

                    // Parse all the lines in the file and add the
                    // values to the ExtractedDataset table.
                    while ((textLine = inputFile.ReadLine()) != null)
                    {
                        textLineTokens = textLine.Split(',');
                        ExtractedDataset.Rows.Add(textLineTokens);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Separate inputs columns from output column (from ExtractedDataset
        /// table) and convert strings into numeric values.
        /// </summary>
        /// <param name="attributeToPredict">Name of the output column.</param>
        /// <param name="codeBook">Codebook to be used (by default null).</param>
        /// <returns>Bool value indicating whether the dataset was
        /// processed correctly or not.</returns>
        public bool ProcessDataset(string attributeToPredict, Codification codeBook = null)
        {
            // ProcessedDataset will have the same structure of ExtractedDataset.
            ProcessedDataset = ExtractedDataset.Clone();

            // Inputs and outputs must preserve ExtractedDataset's dimensions.
            InputData = new double[ExtractedDataset.Rows.Count][];
            OutputData = new int[ExtractedDataset.Rows.Count];

            // Except for the output column, columns' types are changed to
            // double type (classifiers work with numbers, not with strings).
            foreach (DataColumn column in ExtractedDataset.Columns)
            {
                if (column.ColumnName != attributeToPredict)
                {
                    InputColumnNames.Add(column.ColumnName);
                    ProcessedDataset.Columns[column.Ordinal].DataType = typeof(double);
                }
                else
                    OutputColumnName = column.ColumnName;
            }

            try
            {
                // Temporary variables.
                double tempValue = 0;
                DataRow processedRow = null;
                List<double> tempInput = null;

                for (int row = 0; row < ExtractedDataset.Rows.Count; ++row)
                {
                    // Process one row at time.
                    processedRow = ProcessedDataset.NewRow();
                    tempInput = new List<double>();
                    foreach (DataColumn column in ExtractedDataset.Columns)
                    {
                        if (column.ColumnName != attributeToPredict)
                        {
                            Double.TryParse(
                                ExtractedDataset.Rows[row][column.Ordinal] as string,
                                System.Globalization.NumberStyles.Any,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out tempValue);
                            // Create a row of numeric values to be
                            // added to ProcessedDataset and InputData.
                            processedRow[column.Ordinal] = tempValue;
                            tempInput.Add(tempValue);
                        }
                        else
                        {
                            // Don't convert the output column to a number yet, just copy the string
                            // value (conversion to number will be done later by CodeBook).
                            processedRow[column.Ordinal] = ExtractedDataset.Rows[row][column.Ordinal];
                        }
                    }
                    // Add/fill a row in ProcessedDataset and InputData
                    // before going to next row.
                    ProcessedDataset.Rows.Add(processedRow);
                    InputData[row] = tempInput.ToArray();
                }

                if (codeBook != null)
                    // Use given codebook (codebook should be given only when dealing
                    // with testing datasets, in order to have the same codebook both
                    // for training and for testing data).
                    this.CodeBook = codeBook;
                else
                    // If no codebook is given, create one for the output column.
                    CodeBook = new Codification(ExtractedDataset, attributeToPredict);

                // Apply codebook to the ProcessedDataset.
                ProcessedDataset = CodeBook.Apply(ProcessedDataset);
                
                // InputData is already set, OutputData is set to be the output
                // column codified with the codebook.
                OutputData = ProcessedDataset.ToArray<int>(attributeToPredict);

                // Number of input columns.
                InputAttributeNumber = ExtractedDataset.Columns.Count - 1;

                // Number of possible values the output column may assume.
                OutputPossibleValues = CodeBook[attributeToPredict].Symbols;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}