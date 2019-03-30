using System;
using System.Collections.Generic;

namespace SystemsDevProject
{
    public class Performance
    {
        public DateTime PerformanceDate { get; set; }
        public string PerformanceStatus { get; set; }
        public List<Band> PerformanceBands { get; set; }


        public Performance()
        {

        }

        public Performance(DateTime performanceDate, string performanceStatus)
        {
            PerformanceDate = performanceDate;
            PerformanceStatus = performanceStatus;
            PerformanceBands = new List<Band>();
        }
    }
}