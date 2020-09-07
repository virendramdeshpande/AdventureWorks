using MediatR;
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Contracts.Customers.Query;
using NorthWind.Repositories.AdventureWorks;
using System;
using System.Collections.Generic;

namespace NorthWind.Contracts.Customers.Search
{
    public class CustomerQuery : IRequest<CustomerResponse>
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
