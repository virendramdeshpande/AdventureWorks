using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.UpdateContract
{
    public class UpdateContractResponse:ResponseBase
    {
        public UpdateContractResult Data { get; set; }
        public UpdateContractResponse() : base()
        {

        }
        public UpdateContractResponse(Exception ex) : base(ex)
        {

        }
    }
    public class UpdateContractResult
    {
        public int AffectedRecords { get; set; }
    }
}
