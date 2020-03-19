﻿namespace Halal.Algorithms
{
    using System.Linq;
    using Halal.Problems.FunctionApproximation;

    public sealed class HillClimbingStochasticFA : Algorithm<Value, Coefficient>
    {
        private const double Epsilon = 0.0001;

        public HillClimbingStochasticFA(Problem problem)
            : base(problem)
        {
            this.solutions.Add(null);
            this.Solution = new Solution(problem);
            this.Solution.AddRange(Enumerable.Range(0, 5).Select(x => this.GetRandomCoefficient()));
        }

        public override string Name { get; protected set; } = "Hill Climbing Stochastic";

        public override void DoOneIteration()
        {
            foreach (Coefficient coefficient in this.Solution)
            {
                var next = this.GetNextSolution(coefficient, this.GetNextCoefficient(coefficient));
                if (this.Solution.CalculateFitness() > next.CalculateFitness())
                {
                    this.Solution = next;
                }
            }
        }

        private Solution GetNextSolution(Coefficient oldCoefficient, Coefficient newCoefficient)
        {
            var solution = new Solution(this.Problem);
            solution.AddRange(this.Solution);
            solution.Replace(oldCoefficient, newCoefficient);
            return solution;
        }

        private double GetNextValue(Coefficient coefficient) => this.Random.NextDouble() >= 0 ? coefficient.Value + Epsilon : coefficient.Value - Epsilon;

        private Coefficient GetRandomCoefficient() => new Coefficient(new[] { this.NormalDistRandom.Sample() });

        private Coefficient GetNextCoefficient(Coefficient coefficient) => new Coefficient(new[] { this.GetNextValue(coefficient) });
    }
}
