using System;
using System.Collections.Generic;

public class ANU
{
    public double X { get; set; }
    public double Y { get; set; }
}

public class PSOAlgorithm
{
    private int numParticles;
    private int numDimensions;
    private int maxIterations;
    private double inertiaWeight;
    private double cognitiveWeight;
    private double socialWeight;
    private double[] globalBestPosition;
    private double globalBestFitness;
    private List<ANU> particles;
    private List<ANU> fixedNodeLocations;

    public PSOAlgorithm(int numParticles, int numDimensions, int maxIterations, double inertiaWeight, double cognitiveWeight, double socialWeight, List<ANU> fixedNodeLocations)
    {
        this.numParticles = numParticles;
        this.numDimensions = numDimensions;
        this.maxIterations = maxIterations;
        this.inertiaWeight = inertiaWeight;
        this.cognitiveWeight = cognitiveWeight;
        this.socialWeight = socialWeight;
        this.globalBestPosition = new double[numDimensions];
        this.globalBestFitness = double.MinValue;
        this.particles = new List<ANU>();
        this.fixedNodeLocations = fixedNodeLocations;
    }

    public double[] Optimize()
    {
        InitializeParticles();

        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            UpdateGlobalBest();

            foreach (ANU particle in particles)
            {
                UpdateANU(particle);
            }
        }

        return globalBestPosition;
    }

    private void InitializeParticles()
    {
        Random random = new Random();

        for (int i = 0; i < numParticles; i++)
        {
            ANU particle = new ANU
            {
                X = random.NextDouble(),
                Y = random.NextDouble()
            };

            particles.Add(particle);
        }
    }

    private void UpdateGlobalBest()
    {
        foreach (ANU particle in particles)
        {
            double fitness = CalculateFitness(particle.X, particle.Y);

            if (fitness > globalBestFitness)
            {
                globalBestFitness = fitness;
                globalBestPosition[0] = particle.X;
                globalBestPosition[1] = particle.Y;
            }
        }
    }

    private void UpdateANU(ANU particle)
    {
        Random random = new Random();

        double r1 = random.NextDouble();
        double r2 = random.NextDouble();

        particle.X = inertiaWeight * particle.X
            + cognitiveWeight * r1 * (particle.X - particle.X)
            + socialWeight * r2 * (globalBestPosition[0] - particle.X);

        particle.Y = inertiaWeight * particle.Y
            + cognitiveWeight * r1 * (particle.Y - particle.Y)
            + socialWeight * r2 * (globalBestPosition[1] - particle.Y);

        // Optional: Apply any constraints on the position within the valid range if needed

        double fitness = CalculateFitness(particle.X, particle.Y);

        if (fitness > globalBestFitness)
        {
            globalBestFitness = fitness;
            globalBestPosition[0] = particle.X;
            globalBestPosition[1] = particle.Y;
        }
    }

    private double CalculateFitness(double x, double y)
    {
        double coverage = CalculateCoverage(x, y);
        double cost = CalculateCost(x, y);
        double fitness = coverage / cost;

        return fitness;
    }

    private double CalculateCoverage(double x, double y)
    {
        // Calculate the coverage of the target node at position (x, y)
        // based on the fixed node locations

        // Implement your coverage calculation logic here
        // This can include factors such as signal strength, distance, and interference

        // For simplicity, let's assume a simple circular coverage area with a fixed radius
        double radius = 10.0; // Assuming a coverage radius of 10 units
        double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

        if (distance <= radius)
        {
            return 1.0; // Full coverage within the radius
        }
        else
        {
            return 0.0; // No coverage outside the radius
        }
    }

    private double CalculateCost(double x, double y)
    {
        // Calculate the cost of the target node at position (x, y)
        // based on the fixed node locations

        // Implement your cost calculation logic here
        // This can include factors such as infrastructure costs, deployment costs, and maintenance costs

        // For simplicity, let's assume a linear cost function based on the distance from the fixed nodes
        double cost = 0.0;

        foreach (ANU fixedNode in fixedNodeLocations)
        {
            double distance = Math.Sqrt(Math.Pow(x - fixedNode.X, 2) + Math.Pow(y - fixedNode.Y, 2));
            cost += distance;
        }

        return cost;
    }

    static void Main(string[] args)
    {
        // Define the problem-specific parameters
        int numParticles = 50;
        int numDimensions = 2;
        int maxIterations = 100;
        double inertiaWeight = 0.8;
        double cognitiveWeight = 2.0;
        double socialWeight = 2.0;

        // Create a list of fixed node locations
        List<ANU> fixedNodeLocations = new List<ANU>()
        {
            new ANU { X = 2.0, Y = 4.0 },
            new ANU { X = 5.0, Y = 7.0 },
            new ANU { X = 8.0, Y = 3.0 }
            // Add more fixed node locations as needed
        };

        // Create an instance of the PSO algorithm
        PSOAlgorithm psoAlgorithm = new PSOAlgorithm(numParticles, numDimensions, maxIterations, inertiaWeight, cognitiveWeight, socialWeight, fixedNodeLocations);

        // Run the PSO algorithm to find the optimal position for the target node
        double[] optimalPosition = psoAlgorithm.Optimize();

        // Display the optimal position for the target node
        Console.WriteLine("Optimal Position for Target ANU Node:");
        Console.WriteLine("X: " + optimalPosition[0]);
        Console.WriteLine("Y: " + optimalPosition[1]);

        Console.ReadLine();
    }
}