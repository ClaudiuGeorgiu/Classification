using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Statistics.Distributions.Fitting;
using Accord.Statistics.Distributions.Univariate;
using System.Collections.Generic;

namespace Classification
{
    /// <summary>
    /// Class implementing a Naive Bayesian classifier for continuous data.
    /// </summary>
    public class NaiveBayesianClassifier : GenericClassifier
    {
        public NaiveBayes<NormalDistribution> BayesianModel { get; private set; }

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public NaiveBayesianClassifier()
        {

        }

        /// <summary>
        /// Train the classifier with some data.
        /// </summary>
        /// <param name="trainingData">Data used to train the classifier.</param>
        /// <returns>Classifier prediction error.</returns>
        public override double TrainClassifier(ClassificationData trainingData)
        {
            double classifierError = 0;

            // Create a new Naive Bayes classifier.
            BayesianModel = new NaiveBayes<NormalDistribution>(
                trainingData.OutputPossibleValues,
                trainingData.InputAttributeNumber,
                NormalDistribution.Standard);

            // Compute the Naive Bayes model.
            classifierError = BayesianModel.Estimate(
                trainingData.InputData,
                trainingData.OutputData,
                true,
                new NormalOptions { Regularization = 1e-5 /* To avoid zero variances. */ });

            return classifierError;
        }

        /// <summary>
        /// Test the classifier with some data.
        /// </summary>
        /// <param name="testingData">Data used to test the classifier.</param>
        /// <returns>Array of predicted values.</returns>
        public override int[] TestClassifier(ClassificationData testingData)
        {
            List<int> results = new List<int>();

            // Predict the results for a series of inputs.
            foreach (double[] input in testingData.InputData)
            {
                results.Add(BayesianModel.Compute(input));
            }

            return results.ToArray();
        }

        /// <summary>
        /// Test the classifier with a single input.
        /// </summary>
        /// <param name="testingInput">Input used to test the classifier.</param>
        /// <returns>Predicted value.</returns>
        public override int ComputeResult(double[] testingInput)
        {
            // Predict the result for a single input.
            int result = BayesianModel.Compute(testingInput);
            return result;
        }
    }
}