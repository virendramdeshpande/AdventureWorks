using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Repositories.Entities
{
    public class CoveragePlanEntity
    {
        public string CoveragePlan { get; set; }
        public DateTime EligibilityDateFrom { get; set; }
        public DateTime EligibilityDateTo { get; set; }
        public string EligibilityCountry { get; set; }
    }
}
