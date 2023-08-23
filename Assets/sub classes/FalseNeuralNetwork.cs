using System;
using System.Collections.Generic;

namespace Assets.sub_classes
{
    /// <summary>
    /// This class is responsible for the neural networks true
    /// values calculations
    /// </summary>
    public class FalseNeuralNetwork
    {
        private List<DataRecord> trainingData;
        // Training data containing input values and location labels
        private int inputCount;
        // Number of input features
        private int hiddenCount;
        // Number of neurons in the hidden layer
        private double learningRate;
        // Learning rate for updating weights

        private List<double> inputWeights;
        // Weights for the input layer
        private List<double> hiddenWeights;
        // Weights for the hidden layer
        private double outputWeight;
        // Weight for the output neuron

        /// <summary>
        /// Constructor to initialize the neural network with training data and optional parameters.
        /// </summary>
        public FalseNeuralNetwork(List<DataRecord> trainingData, int hiddenCount = 5, double learningRate = 0.1)
        {
            this.trainingData = trainingData;
            this.inputCount = GetInputValues(trainingData[0]).Count;
            this.hiddenCount = hiddenCount;
            this.learningRate = learningRate;

            InitializeWeights();
            // Initialize weights for the neural network

        }

        /// <summary>
        /// This method is used to initialize the weights 
        /// in the network
        /// with random values
        /// </summary>
        private void InitializeWeights()
        {
            Random random = new Random();

            inputWeights = new List<double>();

            //This initialises the input weights with random values
            for (int i = 0; i < inputCount; i++)
            {
                inputWeights.Add(random.NextDouble());
            }

            hiddenWeights = new List<double>();
            for (int i = 0; i < hiddenCount; i++)
            {
                hiddenWeights.Add(random.NextDouble());
            }

            outputWeight = random.NextDouble();
        }

        /// <summary>
        /// This method is used to 
        /// Apply the sigmoid activation 
        /// function to a given input.
        /// </summary>
        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        /// <summary>
        /// This method is used to calculate 
        /// the output of a hidden neuron based 
        /// on input values and weights.
        /// </summary>
        private double CalculateHiddenNeuronOutput(List<double> inputValues, List<double> weights)
        {
            double sum = 0;
            for (int i = 0; i < inputValues.Count; i++)
            {
                sum += inputValues[i] * weights[i]; // Weighted sum of inputs
            }
            return Sigmoid(sum); // Apply sigmoid activation
        }

        /// <summary>
        /// This method is used to train the neural 
        /// network using the provided training data.
        /// </summary>
        public void Train()
        {
            foreach (var record in trainingData)
            {
                List<double> inputValues = GetInputValues(record);
                double expectedOutput = 0;

                // Forward propagation
                List<double> hiddenLayerOutputs = new List<double>();
                for (int i = 0; i < hiddenCount; i++)
                {
                    hiddenLayerOutputs.Add(CalculateHiddenNeuronOutput(inputValues, inputWeights));
                }

                double outputNeuronInput = CalculateHiddenNeuronOutput(hiddenLayerOutputs, hiddenWeights);
                double output = Sigmoid(outputNeuronInput);

                // Backpropagation
                double outputError = expectedOutput - output;
                double outputDelta = outputError * output * (1 - output);

                for (int i = 0; i < hiddenCount; i++)
                {
                    double hiddenError = outputDelta * hiddenWeights[i];
                    double hiddenDelta = hiddenError * hiddenLayerOutputs[i] * (1 - hiddenLayerOutputs[i]);

                    hiddenWeights[i] += learningRate * outputDelta * hiddenLayerOutputs[i];
                    for (int j = 0; j < inputCount; j++)
                    {
                        inputWeights[j] += learningRate * hiddenDelta * inputValues[j];
                    }
                }
            }
        }

        /// <summary>
        /// This method gets the items transform positions
        /// these will be used as input for the neural network
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private List<double> GetInputValues(DataRecord record)
        {
            return new List<double>
            {
                record.GetTransform().position.x,
                record.GetTransform().position.y,
                record.GetTransform().position.z,
            };
        }

        /// <summary>
        /// Predict the output using the trained neural network for a given test record.
        /// </summary>
        public double Predict(DataRecord testRecord)
        {
            List<double> inputValues = GetInputValues(testRecord);
            double hiddenLayerOutput = CalculateHiddenNeuronOutput(inputValues, inputWeights);
            double outputNeuronInput = CalculateHiddenNeuronOutput(new List<double> { hiddenLayerOutput }, hiddenWeights);
            double output = Sigmoid(outputNeuronInput);
            return output;
        }
    }
}
