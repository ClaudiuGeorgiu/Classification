using Accord.Statistics.Kernels;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using System.Collections.Generic;

namespace Classification
{
    /// <summary>
    /// Class implementing a SVM classifier for continuous data.
    /// </summary>
    public class SVMClassifier : GenericClassifier
    {
        private MulticlassSupportVectorLearning SVMachineLearning;
        public MulticlassSupportVectorMachine SVMachine { get; private set; }

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public SVMClassifier()
        {

        }

        /// <summary>
        /// Train the classifier with some data and default parameters.
        /// </summary>
        /// <param name="trainingData">Data used to train the classifier.</param>
        /// <returns>Classifier prediction error.</returns>
        public override double TrainClassifier(ClassificationData trainingData)
        {
            // Train the classifier using default parameters.
            return TrainClassifierWithParameters(trainingData);
        }

        public double TrainClassifierWithParameters(
            ClassificationData trainingData,
            IKernel kernel = null,
            SupportVectorMachineLearningConfigurationFunction algorithm = null)
        {
            double classifierError = 0;

            // Use default parameters if no valid new
            // values are provided.
            if (kernel == null)
                kernel = new Linear();
            if (algorithm == null)
                algorithm = (SVM, inputData, outputData, i, j) =>
                    new SequentialMinimalOptimization(SVM, inputData, outputData);

            // Create a new SVM classifier.
            SVMachine = new MulticlassSupportVectorMachine(
                trainingData.InputAttributeNumber,
                kernel,
                trainingData.OutputPossibleValues);

            // Create an algorithm to be learned by the SVM.
            SVMachineLearning = new MulticlassSupportVectorLearning(
                SVMachine,
                trainingData.InputData,
                trainingData.OutputData);
            SVMachineLearning.Algorithm = algorithm;
            
            // Run the learning algorithm.
            classifierError = SVMachineLearning.Run(true);

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
                results.Add(SVMachine.Compute(input, MulticlassComputeMethod.Voting));
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
            int result = SVMachine.Compute(testingInput, MulticlassComputeMethod.Voting);
            return result;
        }
    }
}