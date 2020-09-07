using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Customers.Query
{
    public class CustomerResponse : ResponseBase
    {
        public CustomerResponse() : base()
        {

        }
        public CustomerResponse(Exception ex) : base(ex)
        {

        }

        public List<CustomerSearchQueryResult> ContractsQueryResults { get; set; }

    }
    public class CustomerSearchQueryResult
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
