using System;
using System.Collections.Generic;
using NiuX.LogPanel.Models;

namespace NiuX.LogPanel.Handlers.LogCharts
{
    public class LogChartFactory
    {
        private static readonly Dictionary<ChartDataType, Type> LogChartDict;

        static LogChartFactory()
        {
            LogChartDict = new Dictionary<ChartDataType, Type>
            {
                { ChartDataType.Hour,typeof(HourChart)},
                { ChartDataType.Week,typeof(WeekLogChart)},
                { ChartDataType.Day,typeof(DayLogChart)},
                { ChartDataType.Month,typeof(MonthLogChart)}
            };
        }

        public static ILogChart GetLogChart(ChartDataType type)
        {
            return (ILogChart)Activator.CreateInstance(LogChartDict[type]);
        }
    }
}