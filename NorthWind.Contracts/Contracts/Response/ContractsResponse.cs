using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.Response
{
    public class ContractsResponse : ResponseBase
    {
        public ContractsResponse() : base()
        {

        }
        public ContractsResponse(Exception ex) : base(ex)
        {

        }

        public List<ContractsQueryResult> ContractsQueryResults { get; set; }

    }
    public class ContractsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime SaleDate { get; set; }

        public string CoveragePlan { get; set; }

        public decimal NetPrice { get; set; }

    }

}
