using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.DeleteContract
{

    public class DeleteContractResponse : ResponseBase
    {
        public DeleteContractResult Data { get; set; }
        public DeleteContractResponse() : base()
        {

        }
        public DeleteContractResponse(Exception ex) : base(ex)
        {

        }
    }
    public class DeleteContractResult
    {
        public int AffectedRecords { get; set; }
    }
}
