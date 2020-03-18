﻿namespace Halal.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Halal.Problems.WorkAssignment;

    public class ImportWorkAssignment : Import<Problem>
    {
        protected override Problem FromText(string[][] text)
        {
            int rows = text.Length - 1;
            double time = double.Parse(text[0][0]);
            var result = new Problem(time, rows);
            result.AddRange(text.Skip(1).Select(x => new Person(x.Select(y => double.Parse(y)))));

            return result;
        }
    }
}
