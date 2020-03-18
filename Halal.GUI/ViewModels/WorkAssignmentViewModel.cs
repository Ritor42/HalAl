﻿using Halal.Problems.WorkAssignment;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halal.GUI.ViewModels
{
    public sealed class WorkAssignmentViewModel : BaseViewModel<Person, Rate>
    {
        public override void Setup()
        {
            this.PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            this.PlotModel.Series.Add(new ColumnSeries());
            base.Setup();
        }

        protected override void Plot()
        {
            var solution = this.Algorithm.Solutions.First() as Solution;
            var series = (ColumnSeries)this.PlotModel.Series.First();
            series.Items.Clear();
            series.Items.AddRange(solution.Select(element => new ColumnItem(element.Value)));
            this.PlotModel.Title = this.Algorithm.Name + "\r\nSalary: " + Math.Round(solution.CalculateSalary(), 4) + " Quality: " + Math.Round(solution.CalculateQuality(), 4);
        }
    }
}