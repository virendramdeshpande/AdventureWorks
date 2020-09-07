using MediatR;
using NorthWind.Contracts.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts
{
    public class ContractsQuery: IRequest<ContractsResponse>
    {
        public int id { set; get; }
    }

   
}
