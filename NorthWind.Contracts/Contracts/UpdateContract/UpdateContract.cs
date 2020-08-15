using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.UpdateContract
{
    public class UpdateContract: IRequest<UpdateContractResponse>
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
