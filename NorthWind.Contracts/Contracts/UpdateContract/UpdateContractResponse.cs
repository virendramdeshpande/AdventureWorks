using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.UpdateContract
{
    public class UpdateContractResponse:ResponseBase
    {
        public UpdateContractResponse() : base()
        {

        }
        public UpdateContractResponse(Exception ex) : base(ex)
        {

        }
    }
}
