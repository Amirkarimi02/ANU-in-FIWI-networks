# PSO Algorithm

Welcome to the PSO Algorithm repository! This project features a Particle Swarm Optimization (PSO) algorithm implemented in C#. The purpose of this algorithm is to determine the optimal position for a target node within a network, based on fixed node locations.

## Usage

To utilize the PSO algorithm, follow these steps:

1. Open the `Program.cs` file.

2. Customize the problem-specific parameters according to your requirements:
   - `numParticles`: Specify the number of particles in the swarm.
   - `numDimensions`: Define the number of dimensions in the problem (e.g., X and Y coordinates).
   - `maxIterations`: Set the maximum number of iterations for the algorithm.
   - `inertiaWeight`: Adjust the weight for the inertia component in particle movement.
   - `cognitiveWeight`: Modify the weight for the cognitive component in particle movement.
   - `socialWeight`: Adapt the weight for the social component in particle movement.

3. Define the fixed node locations by creating a list of `ANU` objects and adding them to the `fixedNodeLocations` list. Each `ANU` object represents a fixed node with X and Y coordinates.

4. Run the program.

5. The algorithm will execute the optimization process and provide the optimal position for the target node.

## Customization

Feel free to customize the PSO algorithm to meet your specific requirements. Here are a few suggestions for possible modifications:

- Adjust the fitness function (`CalculateFitness`) to reflect the goals and characteristics of your problem domain.
- Modify the constraints and validity checks in the `UpdateANU` method to enforce specific boundaries or restrictions on the particle positions.
- Extend the `ANU` class with additional properties or methods to represent more complex node characteristics.

## License

This project is licensed under the [MIT License](LICENSE), granting you the freedom to use and modify the code according to your needs.

## Acknowledgments

We would like to acknowledge the following:

- The PSO algorithm implementation is based on the Particle Swarm Optimization concept and its application to the problem of finding the optimal position for a target node in a network.

- Please note that the code provided in this repository serves as a basic implementation of the PSO algorithm and is intended for educational purposes. For real-world scenarios, further customization and adaptation may be necessary.

Thank you for using the PSO Algorithm repository. If you have any questions or feedback, please don't hesitate to reach out.
