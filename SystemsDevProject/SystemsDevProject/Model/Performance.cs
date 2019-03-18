using System;
using System.Collections.Generic;

namespace SystemsDevProject
{
    public class Performance
    {
        public DateTime PerformanceDate { get; set; }
        public string PerformanceStatus { get; set; }

        public List<string> PerformanceCast { get; set; }
        public List<Band> PerformanceBands { get; set; }


        public Performance()
        {

        }

        public Performance(DateTime performanceDate, string performanceStatus)
        {
            PerformanceDate = performanceDate;
            PerformanceStatus = performanceStatus;
            PerformanceCast = new List<string>();
            PerformanceBands = new List<Band>();
        }
    }
}