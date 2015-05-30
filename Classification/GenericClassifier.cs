namespace Classification
{
    /// <summary>
    /// Generic base class that should be inherited by every classifier.
    /// </summary>
    abstract public class GenericClassifier
    {
        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public GenericClassifier()
        {

        }

        /// <summary>
        /// Train the classifier with some data.
        /// </summary>
        /// <param name="trainingData">Data used to train the classifier.</param>
        /// <returns>Classifier prediction error.</returns>
        abstract public double TrainClassifier(ClassificationData trainingData);

        /// <summary>
        /// Test the classifier with some data.
        /// </summary>
        /// <param name="testingData">Data used to test the classifier.</param>
        /// <returns>Array of predicted values.</returns>
        abstract public int[] TestClassifier(ClassificationData testingData);

        /// <summary>
        /// Test the classifier with a single input.
        /// </summary>
        /// <param name="testingInput">Input used to test the classifier.</param>
        /// <returns>Predicted value.</returns>
        abstract public int ComputeResult(double[] testingInput);
    }
}