using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Repositories.Entities
{
    public class RateChartEntity
    {
        public string CoveragePlan { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal NetPrice { get; set; }
    }
}
