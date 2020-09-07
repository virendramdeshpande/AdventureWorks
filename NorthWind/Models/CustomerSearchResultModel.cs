using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Models
{
    public class CustomerSearchResultModel
    {
        public int CustomerId { get; set; }

        public int? PersonId { get; set; }

        public int? StoreId { get; set; }

        public int? TerritoryId { get; set; }

        public string AccountNumber { get; set; }

        public Guid Rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }


      

    }
}
