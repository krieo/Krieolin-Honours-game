using System;

public class FeedforwardNeuralNetwork
{
    private readonly int inputSize;   // Size of the input layer
    private readonly int hiddenSize;  // Size of the hidden layer
    private readonly int outputSize;  // Size of the output layer
    private double[,] weights1;       // Weights between input and hidden layer
    private double[,] weights2;       // Weights between hidden and output layer
    private double[] biases1;         // Biases for the hidden layer
    private double[] biases2;         // Biases for the output layer

    public FeedforwardNeuralNetwork(int inputSize, int hiddenSize, int outputSize)
    {
        this.inputSize = inputSize;
        this.hiddenSize = hiddenSize;
        this.outputSize = outputSize;

        // Initialize weights and biases randomly
        weights1 = InitializeRandomWeights(hiddenSize, inputSize);
        biases1 = InitializeRandomBiases(hiddenSize);
        weights2 = InitializeRandomWeights(outputSize, hiddenSize);
        biases2 = InitializeRandomBiases(outputSize);
    }

    // Initializes the weights with random values between -0.5 and 0.5
    public double[,] InitializeRandomWeights(int rows, int columns)
    {
        var random = new Random();
        var weights = new double[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                weights[i, j] = random.NextDouble() - 0.5; // Random value between -0.5 and 0.5
            }
        }
        return weights;
    }

    // Initializes the biases with random values between -0.5 and 0.5
    public double[] InitializeRandomBiases(int size)
    {
        var random = new Random();
        var biases = new double[size];
        for (int i = 0; i < size; i++)
        {
            biases[i] = random.NextDouble() - 0.5; // Random value between -0.5 and 0.5
        }
        return biases;
    }

    // Performs the forward pass through the neural network given an input
    public double[] FeedForward(double[] input)
    {
        // Hidden layer activation
        var hiddenLayer = new double[hiddenSize];
        for (int i = 0; i < hiddenSize; i++)
        {
            double sum = 0;
            for (int j = 0; j < inputSize; j++)
            {
                sum += input[j] * weights1[i, j];
            }
            hiddenLayer[i] = ActivationFunction(sum + biases1[i]);
        }

        // Output layer activation
        var output = new double[outputSize];
        for (int i = 0; i < outputSize; i++)
        {
            double sum = 0;
            for (int j = 0; j < hiddenSize; j++)
            {
                sum += hiddenLayer[j] * weights2[i, j];
            }
            output[i] = ActivationFunction(sum + biases2[i]);
        }

        return output;
    }

    // Sigmoid activation function
    public double ActivationFunction(double x)
    {
        return 1 / (1 + Math.Exp(-x));
    }
}

