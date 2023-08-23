using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.sub_classes
{
    /// <summary>
    /// This class handles the behaviors associated 
    /// with the logistic regression model.
    /// This class tries to solve the issue with the 
    /// neural network keep on placing game objects 
    /// in one location 
    /// </summary>
    public class LogisticRegressionModel
    {
        private double[] coefficients; 
        // Stores the model's learned weights

        /// <summary>
        /// This method is used to train the 
        /// logistic regression model using the provided training data.
        /// </summary>
        /// <param name="trainingData">The list of training data records.</param>
        public void Train(List<DataRecord> trainingData)
        {
            double[][] features = trainingData.Select(record => GetFeatureVector(record)).ToArray();
            int[] labels = trainingData.Select(record => Convert.ToInt32(record.GetTransform().position.x)).ToArray();

            coefficients = new double[features[0].Length + 1];

            GradientDescent(features, labels, coefficients, learningRate: 0.01, numIterations: 1000);
        }

        /// <summary>
        /// This class tries to predict the output 
        /// using the trained logistic regression 
        /// model for a given test record.
        /// Essentially what i end up settling on is that
        /// if the value is greater then 0.5 it scopes up
        /// to 1 otherwise it goes to 0
        /// </summary>
        /// <param name="testRecord">The test data record.</param>
        /// <returns>The predicted binary output (0 or 1).</returns>
        public int Predict(DataRecord testRecord)
        {
            double[] featureVector = GetFeatureVector(testRecord);
            double prediction = PredictLogisticRegression(featureVector, coefficients);

            return prediction >= 0.5 ? 1 : 0;
        }

        /// <summary>
        /// This method returns a feature record for the items
        /// position in the game world
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private double[] GetFeatureVector(DataRecord record)
        {
            return new double[]
            {
                record.GetTransform().position.x,
                record.GetTransform().position.y,
                record.GetTransform().position.z,
            };
        }


        /// <summary>
        /// This method tries to calculate the gradient descent to create 
        /// a smooter line and more optimal solution
        /// </summary>
        /// <param name="features"></param>
        /// <param name="labels"></param>
        /// <param name="coefficients"></param>
        /// <param name="learningRate"></param>
        /// <param name="numIterations"></param>
        private void GradientDescent(double[][] features, int[] labels, double[] coefficients, double learningRate, int numIterations)
        {
            int numFeatures = features[0].Length;

            for (int iteration = 0; iteration < numIterations; iteration++)
            {
                double[] predictions = new double[features.Length];

                for (int i = 0; i < features.Length; i++)
                {
                    predictions[i] = PredictLogisticRegression(features[i], coefficients);
                }

                double[] errors = new double[features.Length];

                for (int i = 0; i < features.Length; i++)
                {
                    errors[i] = labels[i] - predictions[i];
                }

                for (int j = 0; j < numFeatures + 1; j++)
                {
                    double gradient = 0;

                    for (int i = 0; i < features.Length; i++)
                    {
                        gradient += errors[i] * (j == 0 ? 1 : features[i][j - 1]);
                    }

                    coefficients[j] += learningRate * gradient;
                }
            }
        }

        /// <summary>
        /// This method is used to predict the logistic regression
        /// outcomes
        /// </summary>
        /// <param name="featureVector"></param>
        /// <param name="coefficients"></param>
        /// <returns></returns>
        private double PredictLogisticRegression(double[] featureVector, double[] coefficients)
        {
            double z = coefficients.Zip(featureVector, (c, x) => c * x).Sum();
            double probability = 1.0 / (1.0 + Math.Exp(-z));
            return probability;
        }
    }
}
