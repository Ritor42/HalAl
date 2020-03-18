﻿namespace Halal.Problems.WorkAssignment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class Rate : List<double>, ISolutionElement
    {
        public Rate()
        {
        }

        public Rate(IEnumerable<double> items)
            : base(items)
        {
        }

        public double Value => this[0];

        public bool IsValid(int dimensionCount)
        {
            return this.Count == 1;
        }
    }
}