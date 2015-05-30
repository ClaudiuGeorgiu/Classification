using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using System.Collections.Generic;

namespace Classification
{
    /// <summary>
    /// Class implementing a Decision Tree classifier for continuous data.
    /// </summary>
    public class DecisionTreeClassifier : GenericClassifier
    {
        private C45Learning C45LearningTree;
        public List<string> DecisionVariableNames { get; set; }
        public DecisionTree ClassificationDecisionTree { get; private set; }

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public DecisionTreeClassifier()
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

        /// <summary>
        /// Train the classifier with some data, using parameters.
        /// </summary>
        /// <param name="trainingData">Data used to train the classifier.</param>
        /// <param name="maxJoin">How many times a variable can join
        /// the decision process.</param>
        /// <param name="maxHeight">Maximum height when learning the tree.</param>
        /// <returns>Classifier prediction error.</returns>
        public double TrainClassifierWithParameters(
            ClassificationData trainingData, 
            int maxJoin = 0,
            int maxHeight = 0)
        {
            double classifierError = 0;
            List<DecisionVariable> decisionVariables = new List<DecisionVariable>();

            if (DecisionVariableNames != null)
            {
                for (int n = 0; n < trainingData.InputAttributeNumber; ++n)
                {
                    decisionVariables.Add(
                        new DecisionVariable(DecisionVariableNames[n], DecisionVariableKind.Continuous)
                        );
                }
            }
            // Generate automatic names for the variables if no names are provided.
            else
            {
                for (int n = 0; n < trainingData.InputAttributeNumber; ++n)
                {
                    decisionVariables.Add(
                        new DecisionVariable("variable_" + (n + 1).ToString(), 
                            DecisionVariableKind.Continuous));
                }
            }

            // Create a new Decision Tree classifier.
            ClassificationDecisionTree = new DecisionTree(decisionVariables, trainingData.OutputPossibleValues);

            // Create a new instance of the C45 algorithm to be learned by the tree.
            C45LearningTree = new C45Learning(ClassificationDecisionTree);

            // Change some classifier's parameters if valid new
            // values are provided.
            if (maxJoin > 0)
                C45LearningTree.Join = maxJoin;
            if (maxHeight > 0)
                C45LearningTree.MaxHeight = maxHeight;

            // Use data to train the tree.
            classifierError = C45LearningTree.Run(trainingData.InputData, trainingData.OutputData);

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
                results.Add(ClassificationDecisionTree.Compute(input));
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
            int result = ClassificationDecisionTree.Compute(testingInput);
            return result;
        }
    }
}